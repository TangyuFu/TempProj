using UnityEngine;
using UnityGameFramework.Runtime.Extension;

namespace TempProj
{
    /// <summary>
    /// 场景界面。
    /// </summary>
    [Identity((int) UIFormId.SceneForm)]
    public class ScenePresenter : UIFormPresenter<SceneView, SceneProp>
    {
        public override void OnInit(GameObject target, object userData)
        {
            base.OnInit(target, userData);
        }

        public override void OnDeinit()
        {
            base.OnDeinit();
        }
    }
}