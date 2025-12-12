using System;
using UnityEngine;
#if UNITY_IOS
using Unity.Advertisement.IosSupport;
#endif

namespace GameEventsIO.Internal
{
    public static class ATTWrapper
    {
        public static void RequestTrackingAuthorization(Action<int> callback)
        {
#if UNITY_IOS && !UNITY_EDITOR
            if (Application.platform == RuntimePlatform.IPhonePlayer)
            {
                ATTrackingStatusBinding.RequestAuthorizationTracking();
                
                 GameObject go = new GameObject("ATTPoller");
                 go.AddComponent<ATTPoller>().Initialise(callback);
            }
            else
            {
                callback?.Invoke(3); // Authorized
            }
#else
            callback?.Invoke(3); // Authorized
#endif
        }

        public static int GetTrackingAuthorizationStatus()
        {
#if UNITY_IOS && !UNITY_EDITOR
             if (Application.platform == RuntimePlatform.IPhonePlayer)
             {
                 return (int)ATTrackingStatusBinding.GetAuthorizationTrackingStatus();
             }
             return 3;
#else
            return 3; // Authorized
#endif
        }
        
#if UNITY_IOS && !UNITY_EDITOR
        private class ATTPoller : MonoBehaviour
        {
            private Action<int> _callback;
            
            public void Initialise(Action<int> callback)
            {
                _callback = callback;
                DontDestroyOnLoad(gameObject);
            }

            private void Update()
            {
                var status = ATTrackingStatusBinding.GetAuthorizationTrackingStatus();
                if (status != ATTrackingStatusBinding.AuthorizationTrackingStatus.NOT_DETERMINED)
                {
                    _callback?.Invoke((int)status);
                    Destroy(gameObject);
                }
            }
        }
#endif
    }
}
