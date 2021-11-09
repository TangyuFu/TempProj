using GameFramework;
using UnityEngine.Events;

namespace UnityGameFramework.Runtime.Extension
{
    public sealed partial class RComponent
    {
        private class LoadAssetInfo : IReference
        {
            public LoadAssetInfo()
            {
            }

            public int SerialId { get; private set; }

            public UnityAction<string, object, object> SuccessCallback { get; private set; }

            public UnityAction<string, string, object> FailureCallback { get; private set; }

            public object UserData { get; private set; }

            public static LoadAssetInfo Create(int serialId, UnityAction<string, object, object> successCallback,
                UnityAction<string, string, object> failureCallback, object userData)
            {
                LoadAssetInfo loadAssetInfo = ReferencePool.Acquire<LoadAssetInfo>();
                loadAssetInfo.SerialId = serialId;
                loadAssetInfo.SuccessCallback = successCallback;
                loadAssetInfo.FailureCallback = failureCallback;
                loadAssetInfo.UserData = userData;
                return loadAssetInfo;
            }

            public void Clear()
            {
                SerialId = default;
                SuccessCallback = default;
                FailureCallback = default;
                UserData = default;
            }
        }
    }
}