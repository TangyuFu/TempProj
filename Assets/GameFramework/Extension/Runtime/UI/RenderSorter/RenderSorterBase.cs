using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;

#endif

namespace UnityGameFramework.Runtime.Extension
{
    /// <summary>
    /// 渲染排序基类。
    /// </summary>
    // [ExecuteAlways]
    public abstract class RenderSorterBase : MonoBehaviour
    {
        /// <summary>
        /// 是否需要重置。
        /// </summary>
        private bool m_IsDirty = false;

        [SerializeField] private RenderSorterMode m_RenderSorterMode = RenderSorterMode.Relative;

        /// <summary>
        /// 渲染模式。
        /// </summary>
        public RenderSorterMode RenderSorterMode
        {
            get => m_RenderSorterMode;
            set
            {
                if (UUtility.SetStruct(ref m_RenderSorterMode, value))
                {
                    SetDirty();
                }
            }
        }

        [SerializeField] private int m_RenderSorterOrder = 0;

        /// <summary>
        /// 渲染顺序。
        /// </summary>
        public int RenderSorterOrder
        {
            get => m_RenderSorterOrder;
            set
            {
                if (UUtility.SetStruct(ref m_RenderSorterOrder, value))
                {
                    SetDirty();
                }
            }
        }

        [SerializeField] private int m_StartOrder;

        /// <summary>
        /// 开始渲染顺序。
        /// </summary>
        protected int StartOrder
        {
            get => m_StartOrder;
            private set => m_StartOrder = value;
        }

        [SerializeField] private int m_EndOrder;

        /// <summary>
        /// 结束渲染顺序。
        /// </summary>
        protected int EndOrder
        {
            private get { return m_EndOrder; }
            set { m_EndOrder = value; }
        }

        [SerializeField] private List<RenderSorterBase> m_ChildrenRenderSorters = new List<RenderSorterBase>();

        /// <summary>
        /// 子渲染排序
        /// </summary>
        protected List<RenderSorterBase> ChildrenRenderSorters => m_ChildrenRenderSorters;

        [SerializeField] private RenderSorterBase m_ParentRenderSorter;

        /// <summary>
        /// 父渲染排序。
        /// </summary>
        protected RenderSorterBase ParentRenderSorter
        {
            get => m_ParentRenderSorter;
            set => m_ParentRenderSorter = value;
        }

        /// <summary>
        /// OnTransformParentChanged 会涵盖物体销毁的情况
        /// </summary>
        void OnDestroy()
        {
        }

        protected virtual void OnEnable()
        {
            SetDirty();
        }

        protected virtual void Reset()
        {
            SetDirty();
        }

        protected virtual void OnDisable()
        {
            SetDirty();
        }

        /// <summary>
        /// OnTransformParentChanged 当父物体改变时调用，Object.Instantiate不会调用，
        /// 物体销毁时会调用。
        /// </summary>
        protected virtual void OnTransformParentChanged()
        {
            SetDirty();
        }

        /// <summary>
        /// 添加子渲染排序。
        /// </summary>
        /// <param name="childSorter"></param>
        private void AddChild(RenderSorterBase childSorter)
        {
            if (!ChildrenRenderSorters.Contains(childSorter))
            {
                ChildrenRenderSorters.Add(childSorter);
            }
        }

        /// <summary>
        /// 移除子渲染排序。
        /// </summary>
        /// <param name="childSorter"></param>
        private void RemoveChild(RenderSorterBase childSorter)
        {
            if (ChildrenRenderSorters.Contains(childSorter))
            {
                ChildrenRenderSorters.Remove(childSorter);
            }
        }

        /// <summary>
        /// 开始排序，先对自己进行排序，再排子排序。
        /// </summary>
        private void Sort()
        {
            // 对自己进行排序。
            int orderTracker = StartOrder;
            SortSelf();
            orderTracker = EndOrder;
            // 对子排序进行排序。
            ChildrenRenderSorters.Sort(new Comparer<RenderSorterBase, int>((t) => t.RenderSorterOrder));
            ChildrenRenderSorters.ForEach((t) =>
            {
                if (t.StartOrder != orderTracker + 1 || t.m_IsDirty)
                {
                    t.StartOrder = orderTracker + 1;
                    t.Sort();
                }

                orderTracker = t.EndOrder;
            });
            EndOrder = orderTracker;
            // 排序结束。
            m_IsDirty = false;
        }

        /// <summary>
        /// 派生类实现并对 EndOrder 进行赋值。
        /// </summary>
        protected abstract void SortSelf();

        /// <summary>
        /// 设置重新排序一帧会多次调用，设置 m_IsDirty 标志与 isActiveAndEnabled 当前不可用有时会出现一些问题。
        /// SetDirty 中 m_IsDirty 用于截断可能出现的多次重置问题，可能会出现，一帧出现多种情况的重置情况，
        /// </summary>
        public void SetDirty()
        {
            // 当前不可用时，从父排序中删除并置空（如果存在父排序）。
            if (!gameObject.activeInHierarchy || !enabled)
            {
                if (m_ParentRenderSorter) m_ParentRenderSorter.RemoveChild(this);
                if (m_ParentRenderSorter) m_ParentRenderSorter.SetDirty();
                m_ParentRenderSorter = null;
                return;
            }

            // 重置之前只设置一次。
            // if (m_IsDirty)
            //     return;
            // 绝对模式删除父排序。
            if (m_RenderSorterMode == RenderSorterMode.Absolute)
            {
                if (m_ParentRenderSorter) m_ParentRenderSorter.RemoveChild(this);
                if (m_ParentRenderSorter) m_ParentRenderSorter.SetDirty();
                m_ParentRenderSorter = null;
            }
            // 相对模式检查父排序节点。
            else if (m_RenderSorterMode == RenderSorterMode.Relative)
            {
                RenderSorterBase currentParent = null;
                if (transform.parent)
                    currentParent = transform.parent.GetComponentInParent<RenderSorterBase>();

                // 父排序改变。
                if (!UUtility.EqualClass(ref currentParent, ref m_ParentRenderSorter))
                {
                    if (m_ParentRenderSorter) m_ParentRenderSorter.RemoveChild(this);
                    if (m_ParentRenderSorter) m_ParentRenderSorter.SetDirty();
                    m_ParentRenderSorter = currentParent;
                    if (m_ParentRenderSorter) m_ParentRenderSorter.AddChild(this);
                }
            }

            // 重置标志。
            m_IsDirty = true;
            // 绝对模式下直接开始排序。
            if (RenderSorterMode == RenderSorterMode.Absolute)
            {
                StartOrder = RenderSorterOrder;
                StartResort();
            }
            // 相对模式下如果为根排序，直接开始排序。
            else if (!m_ParentRenderSorter)
            {
                StartOrder = RenderSorterOrder;
                StartResort();
            }
            // 相对模式下不为根排序，通知父排序开始排序。
            else
            {
                m_ParentRenderSorter.SetDirty();
                if (m_ResortStarted)
                {
                    m_ResortStarted = false;
                    StopCoroutine(m_ResortCoroutine);
                }
            }
        }

        /// <summary>
        /// 重置开始标志。
        /// </summary>
        private bool m_ResortStarted = false;

        /// <summary>
        /// 重置协程。
        /// </summary>
        private Coroutine m_ResortCoroutine = null;

        /// <summary>
        /// 开始重新排序。
        /// </summary>
        private void StartResort()
        {
            if (m_ResortStarted)
                return;
            m_ResortStarted = true;
            m_ResortCoroutine = StartCoroutine(Resort());
        }

        /// <summary>
        /// WaitForEndOfFrame 等待所有摄像机和GUI渲染之后，屏幕显示之前，在同一帧进行。
        /// yield return null 会在下一帧所有 MonoBehaviour.Update 之后调用。
        /// </summary>
        /// <returns></returns>
        private IEnumerator Resort()
        {
            yield return new WaitForEndOfFrame();
            Sort();
            m_ResortStarted = false;
            m_ResortCoroutine = null;
        }
    }

#if UNITY_EDITOR
    [CustomEditor(typeof(RenderSorterBase), true)]
    public class RenderSorterEditor : UnityEditor.Editor
    {
        SerializedProperty mRenderSorterMode;
        SerializedProperty mRenderSorterOrder;
        SerializedProperty mStartOrder;
        SerializedProperty mEndOrder;
        SerializedProperty mParentRenderSorter;
        SerializedProperty mChildrenRenderSorters;

        protected virtual void OnEnable()
        {
            mRenderSorterMode = serializedObject.FindProperty("m_RenderSorterMode");
            mRenderSorterOrder = serializedObject.FindProperty("m_RenderSorterOrder");
            mStartOrder = serializedObject.FindProperty("m_StartOrder");
            mEndOrder = serializedObject.FindProperty("m_EndOrder");
            mParentRenderSorter = serializedObject.FindProperty("m_ParentRenderSorter");
            mChildrenRenderSorters = serializedObject.FindProperty("m_ChildrenRenderSorters");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.UpdateIfRequiredOrScript();
            EditorGUILayout.PropertyField(mRenderSorterMode, true);
            EditorGUILayout.PropertyField(mRenderSorterOrder, true);
            EditorGUI.BeginDisabledGroup(true);
            EditorGUILayout.PropertyField(mStartOrder, true);
            EditorGUILayout.PropertyField(mEndOrder, true);
            EditorGUILayout.PropertyField(mParentRenderSorter, true);
            EditorGUILayout.PropertyField(mChildrenRenderSorters, true);
            EditorGUI.EndDisabledGroup();
            if (serializedObject.hasModifiedProperties)
            {
                serializedObject.ApplyModifiedProperties();
                RenderSorterBase rendererSorting = target as RenderSorterBase;
                if (rendererSorting) rendererSorting.SetDirty();
            }
        }
    }
#endif
}