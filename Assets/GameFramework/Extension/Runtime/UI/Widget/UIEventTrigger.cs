using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace UnityGameFramework.Runtime.Extension
{
    /// <summary>
    /// UI 事件触发器。
    /// </summary>
    public sealed class UIEventTrigger : MonoBehaviour,
        IPointerEnterHandler,
        IPointerExitHandler,
        IPointerDownHandler,
        IPointerUpHandler,
        IPointerClickHandler,
        IInitializePotentialDragHandler,
        IBeginDragHandler,
        IDragHandler,
        IEndDragHandler,
        IDropHandler,
        IScrollHandler,
        IUpdateSelectedHandler,
        ISelectHandler,
        IDeselectHandler,
        IMoveHandler,
        ISubmitHandler,
        ICancelHandler
    {
        /// <summary>
        /// 获取或添加事件触发器。
        /// </summary>
        /// <param name="go">要获取的游戏物体。</param>
        /// <returns>获取到的事件触发器。</returns>
        public static UIEventTrigger Get(GameObject go)
        {
            if (go == null)
            {
                Log.Error($"Invalid game object '{null}'.");
            }

            return go.GetOrAddComponent<UIEventTrigger>();
        }

        private UnityEvent<PointerEventData> m_OnPointerEnter;

        public UnityEvent<PointerEventData> onPointerEnter => m_OnPointerEnter ??= new UnityEvent<PointerEventData>();

        public void OnPointerEnter(PointerEventData eventData)
        {
            m_OnPointerEnter?.Invoke(eventData);
        }

        private UnityEvent<PointerEventData> m_OnPointerExit;

        public UnityEvent<PointerEventData> onPointerExit => m_OnPointerExit ??= new UnityEvent<PointerEventData>();

        public void OnPointerExit(PointerEventData eventData)
        {
            m_OnPointerExit?.Invoke(eventData);
        }

        private UnityEvent<PointerEventData> m_OnPointerDown;

        public UnityEvent<PointerEventData> onPointerDown => m_OnPointerDown ??= new UnityEvent<PointerEventData>();

        public void OnPointerDown(PointerEventData eventData)
        {
            m_OnPointerDown?.Invoke(eventData);
        }

        private UnityEvent<PointerEventData> m_OnPointerUp;

        public UnityEvent<PointerEventData> onPointerUp => m_OnPointerUp ??= new UnityEvent<PointerEventData>();

        public void OnPointerUp(PointerEventData eventData)
        {
            m_OnPointerUp?.Invoke(eventData);
        }

        private UnityEvent<PointerEventData> m_OnPointerClick;

        public UnityEvent<PointerEventData> onPointerClick => m_OnPointerClick ??= new UnityEvent<PointerEventData>();

        public void OnPointerClick(PointerEventData eventData)
        {
            m_OnPointerClick?.Invoke(eventData);
        }

        private UnityEvent<PointerEventData> m_OnInitializePotentialDrag;

        public UnityEvent<PointerEventData> onInitializePotentialDrag =>
            m_OnInitializePotentialDrag ??= new UnityEvent<PointerEventData>();

        public void OnInitializePotentialDrag(PointerEventData eventData)
        {
            m_OnInitializePotentialDrag?.Invoke(eventData);
        }

        private UnityEvent<PointerEventData> m_OnBeginDrag;

        public UnityEvent<PointerEventData> onBeginDrag => m_OnBeginDrag ??= new UnityEvent<PointerEventData>();

        public void OnBeginDrag(PointerEventData eventData)
        {
            m_OnBeginDrag?.Invoke(eventData);
        }

        private UnityEvent<PointerEventData> m_OnDrag;

        public UnityEvent<PointerEventData> onDrag => m_OnDrag ??= new UnityEvent<PointerEventData>();

        public void OnDrag(PointerEventData eventData)
        {
            m_OnDrag?.Invoke(eventData);
        }

        private UnityEvent<PointerEventData> m_OnEndDrag;

        public UnityEvent<PointerEventData> onEndDrag => m_OnEndDrag ??= new UnityEvent<PointerEventData>();

        public void OnEndDrag(PointerEventData eventData)
        {
            m_OnEndDrag?.Invoke(eventData);
        }

        private UnityEvent<PointerEventData> m_OnDrop;

        public UnityEvent<PointerEventData> onDrop => m_OnDrop ??= new UnityEvent<PointerEventData>();

        public void OnDrop(PointerEventData eventData)
        {
            m_OnDrop?.Invoke(eventData);
        }

        private UnityEvent<PointerEventData> m_OnScroll;

        public UnityEvent<PointerEventData> onScroll => m_OnScroll ??= new UnityEvent<PointerEventData>();

        public void OnScroll(PointerEventData eventData)
        {
            m_OnScroll?.Invoke(eventData);
        }

        private UnityEvent<BaseEventData> m_OnUpdateSelected;

        public UnityEvent<BaseEventData> onUpdateSelected => m_OnUpdateSelected ??= new UnityEvent<BaseEventData>();

        public void OnUpdateSelected(BaseEventData eventData)
        {
            m_OnUpdateSelected?.Invoke(eventData);
        }

        private UnityEvent<BaseEventData> m_OnSelect;

        public UnityEvent<BaseEventData> onSelect => m_OnSelect ??= new UnityEvent<BaseEventData>();

        public void OnSelect(BaseEventData eventData)
        {
            m_OnSelect?.Invoke(eventData);
        }

        private UnityEvent<BaseEventData> m_OnDeselect;

        public UnityEvent<BaseEventData> onDeselect => m_OnDeselect ??= new UnityEvent<BaseEventData>();

        public void OnDeselect(BaseEventData eventData)
        {
            m_OnDeselect?.Invoke(eventData);
        }

        private UnityEvent<AxisEventData> m_OnMove;

        public UnityEvent<AxisEventData> onMove => m_OnMove ??= new UnityEvent<AxisEventData>();

        public void OnMove(AxisEventData eventData)
        {
            m_OnMove?.Invoke(eventData);
        }

        private UnityEvent<BaseEventData> m_OnSubmit;

        public UnityEvent<BaseEventData> onSubmit => m_OnSubmit ??= new UnityEvent<BaseEventData>();

        public void OnSubmit(BaseEventData eventData)
        {
            m_OnSubmit?.Invoke(eventData);
        }

        private UnityEvent<BaseEventData> m_OnCancel;

        public UnityEvent<BaseEventData> onCancel => m_OnCancel ??= new UnityEvent<BaseEventData>();

        public void OnCancel(BaseEventData eventData)
        {
            m_OnCancel?.Invoke(eventData);
        }
    }
}