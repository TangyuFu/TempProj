using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace UnityGameFramework.Runtime.Extension
{
    /// <summary>
    /// UI 点击触发器。
    /// </summary>
    public sealed class UIClickTrigger : MonoBehaviour, IPointerClickHandler
    {
        private UnityEvent<GameObject> m_OnClick;

        /// <summary>
        /// 点击事件。
        /// </summary>
        public UnityEvent<GameObject> onClick => m_OnClick ??= new UnityEvent<GameObject>();

        /// <summary>
        /// 获取或添加点击触发器。
        /// </summary>
        /// <param name="go">要获取的游戏物体。</param>
        /// <returns>获取到的点击触发器。</returns>
        public static UIClickTrigger Get(GameObject go)
        {
            if (go == null)
            {
                Log.Error($"Invalid game object '{null}'.");
                return null;
            }

            return go.GetOrAddComponent<UIClickTrigger>();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            m_OnClick?.Invoke(eventData.pointerClick);
        }
    }
}