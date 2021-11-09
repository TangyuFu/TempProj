using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.UI;

namespace UnityGameFramework.Runtime.Extension
{
    /// <summary>
    /// Unity 游戏框架摄像机组件。
    /// 提供主摄像机、UI 摄像机和 UI 3D 辅助摄像机功能。
    /// </summary>
    [DisallowMultipleComponent]
    [AddComponentMenu("Game Framework/Camera")]
    public sealed class CameraComponent : CustomGameFrameworkComponent
    {
        [SerializeField] private Camera m_MainCamera;

        [SerializeField] private Camera m_UI2DCamera;

        [SerializeField] private Camera m_UI3DCamera;

        [SerializeField] private CanvasScaler m_CanvasScaler;

        [SerializeField] private Canvas m_Canvas;

        [SerializeField] private float m_CanvasScale = 0f;

        [SerializeField] private RenderTexture m_RenderTexture = null;

        /// <summary>
        /// 初始化摄像机组件。
        /// </summary>
        protected override void Awake()
        {
            base.Awake();

            if (m_MainCamera == null)
            {
                Log.Error("Invalid main camera.");
                return;
            }

            if (m_UI2DCamera == null)
            {
                Log.Error("Invalid ui 2D camera.");
                return;
            }

            if (m_UI3DCamera == null)
            {
                Log.Error("Invalid ui 3D camera.");
                return;
            }

            if (m_CanvasScaler == null)
            {
                Log.Error("Invalid canvas scaler.");
                return;
            }

            if (m_Canvas == null)
            {
                Log.Error("Invalid canvas.");
                return;
            }

            m_UI3DCamera.gameObject.SetActive(false);

            // to-do Screen.safeArea NotchSolution
            // SystemInfo.deviceModel
            // List<string> mModels = new List<string>()
            // {
            //     "iPhone10,3",
            //     "iPhone10,6",
            //     "iPhone11,2",
            //     "iPhone11,4",
            //     "iPhone11,6",
            //     "iPhone11,8",
            // };
            
            Vector2 actualResolution = new Vector2(Screen.width, Screen.height);
            Vector2 referenceResolution = m_CanvasScaler.referenceResolution;
            float orthographicSize = m_UI2DCamera.orthographicSize;

            m_CanvasScale = orthographicSize / referenceResolution.y;
            orthographicSize *= (actualResolution.y / actualResolution.x) /
                                (referenceResolution.y / referenceResolution.x);
            m_UI2DCamera.orthographicSize = orthographicSize;
        }

        /// <summary>
        /// 获取画布缩放。
        /// </summary>
        public float CanvasScale => m_CanvasScale;

        /// <summary>
        /// 获取主摄像机。
        /// </summary>
        public Camera MainCamera => m_MainCamera;

        /// <summary>
        /// 获取 UI 2D 摄像机，
        /// </summary>
        public Camera UI2DCamera => m_UI2DCamera;

        /// <summary>
        /// 获取 UI 3D 摄像机，
        /// </summary>
        public Camera UI3DCamera => m_UI3DCamera;

        /// <summary>
        /// 世界的 3D 位置转换为 UI 世界位置。
        /// </summary>
        /// <param name="worldPosition"></param>
        /// <param name="uiPosition"></param>
        public void WorldPositionToUIPosition(Vector3 worldPosition, out Vector3 uiPosition)
        {
            if (!RectTransformUtility.ScreenPointToWorldPointInRectangle(
                m_Canvas.GetComponent<RectTransform>(),
                m_MainCamera.WorldToScreenPoint(worldPosition),
                m_UI2DCamera,
                out uiPosition))
            {
                Log.Error($"Failed to get ui position from '{worldPosition}'.");
            }
        }

        /// <summary>
        /// 显示渲染纹理。
        /// </summary>
        /// <param name="rawImage">要渲染的 RawImage。</param>
        public void ShowRenderTexture(RawImage rawImage)
        {
            RectTransform rectTransform = rawImage.GetComponent<RectTransform>();
            Vector2 size = rectTransform.GetSize();
            int width = (int) size.x;
            int height = (int) size.y;
            if (m_RenderTexture == null)
            {
                m_RenderTexture = new RenderTexture(width, height, 24)
                {
                    format = RenderTextureFormat.Default,
                    graphicsFormat = GraphicsFormat.R32G32B32A32_UInt,
                    antiAliasing = 8,
                };

                m_UI3DCamera.targetTexture = m_RenderTexture;
            }
            else
            {
                if (m_RenderTexture.IsCreated())
                {
                    Log.Error("Hide render texture before show it.");
                    return;
                }

                m_RenderTexture.width = width;
                m_RenderTexture.height = height;
            }

            m_UI3DCamera.targetTexture = m_RenderTexture;
            m_UI3DCamera.orthographicSize = size.y * m_CanvasScale;
            m_UI3DCamera.gameObject.SetActive(true);
            m_UI3DCamera.transform.position = rawImage.transform.position;
            rawImage.texture = m_RenderTexture;
        }

        /// <summary>
        /// 隐藏渲染纹理
        /// </summary>
        public void HideRenderTexture()
        {
            m_UI3DCamera.gameObject.SetActive(false);
            if (m_RenderTexture != null)
            {
                m_RenderTexture.Release();
            }
        }

        /// <summary>
        /// 摄像机组件优先级。
        /// </summary>
        internal override int Priority => ComponentPriority.Camera;

        /// <summary>
        /// 摄像机组件轮询。
        /// </summary>
        /// <param name="elapseSeconds">游戏逻辑流逝时间，以秒为单位。</param>
        /// <param name="realElapseSeconds">游戏真实流逝时间，以秒为单位。</param>
        internal override void Poll(float elapseSeconds, float realElapseSeconds)
        {
        }

        /// <summary>
        /// 关闭并清理摄像机组件。
        /// </summary>
        internal override void Shutdown()
        {
        }
    }
}