using UnityEngine;
using UnityGameFramework.Runtime.Extension;

namespace TempProj
{
    /// <summary>
    /// 场景界面。
    /// </summary>
    [Identity((int) UIFormId.SceneForm)]
    public class ScenePresenter : UIFormPresenter
    {
        public override void OnInit(int uniqueId, int formId, CustomUIFormLogic logic, Transform root,
            object userData)
        {
            base.OnInit(uniqueId, formId, logic, root, userData);
        }

        public override void OnDeinit()
        {
            base.OnDeinit();
        }
    }
}