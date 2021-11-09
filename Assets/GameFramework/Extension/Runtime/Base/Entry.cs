using UnityEngine;

namespace UnityGameFramework.Runtime.Extension
{
    /// <summary>
    /// 游戏入口。
    /// </summary>
    public partial class Entry : MonoBehaviour
    {
        private void Start()
        {
            InitBuiltinComponents();
            InitCustomComponents();
        }

        private void Update()
        {
            CustomGameFrameworkEntry.Update(UnityEngine.Time.deltaTime, UnityEngine.Time.unscaledTime);
        }

        private void OnDestroy()
        {
            if (Event != null)
            {
                Event.FireNow(GameQuitEventArgs.EventId, GameQuitEventArgs.Create());
            }
            
            CustomGameFrameworkEntry.Shutdown();
        }

        private void OnApplicationFocus(bool hasFocus)
        {
            if (Event != null)
            {
                Event.FireNow(GameFocusChangedEventArgs.EventId, GameFocusChangedEventArgs.Create(hasFocus, null));
            }
        }

        private void OnApplicationPause(bool pauseStatus)
        {
            if (Event != null)
            {
                Event.FireNow(GamePauseChangedEventArgs.EventId, GamePauseChangedEventArgs.Create(pauseStatus, null));
            }
        }
    }
}