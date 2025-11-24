using System.Collections.Generic;
using UnityEngine;
using Whalytics.Internal;

namespace Whalytics
{
    /// <summary>
    /// The main entry point for the Whalytics SDK.
    /// </summary>
    /// <summary>
    /// The main entry point for the Whalytics SDK.
    /// </summary>
    public static class WhalyticsSDK
    {
        private static EventManager _eventManager;
        private static bool _isInitialized;

        /// <summary>
        /// Initializes the Whalytics SDK.
        /// </summary>
        /// <param name="apiKey">Your project's API Key.</param>
        public static void Initialize(string apiKey)
        {
            if (_isInitialized)
            {
                Debug.LogWarning("[Whalytics] Already initialized.");
                return;
            }

            GameObject go = new GameObject("Whalytics");
            Object.DontDestroyOnLoad(go);
            
            _eventManager = go.AddComponent<EventManager>();
            _eventManager.Initialize(apiKey);
            
            _isInitialized = true;
            Debug.Log("[Whalytics] Initialized.");
        }

        /// <summary>
        /// Enables or disables debug logging.
        /// </summary>
        /// <param name="enabled">If true, enables debug logging.</param>
        public static void SetDebugMode(bool enabled)
        {
            if (!_isInitialized)
            {
                Debug.LogWarning("[Whalytics] Not initialized. Call Initialize() first.");
                return;
            }
            _eventManager.SetDebugMode(enabled);
        }

        /// <summary>
        /// Logs a custom event.
        /// </summary>
        /// <param name="eventName">The name of the event.</param>
        /// <param name="parameters">Optional dictionary of event parameters.</param>
        public static void LogEvent(string eventName, Dictionary<string, object> parameters = null)
        {
            if (!_isInitialized)
            {
                Debug.LogWarning("[Whalytics] Not initialized. Call Initialize() first.");
                return;
            }
            _eventManager.LogEvent(eventName, parameters);
        }

        /// <summary>
        /// Sets a user property.
        /// </summary>
        /// <param name="property">Property name.</param>
        /// <param name="value">Property value.</param>
        public static void SetUserProperty(string property, object value)
        {
            if (!_isInitialized)
            {
                Debug.LogWarning("[Whalytics] Not initialized. Call Initialize() first.");
                return;
            }
            _eventManager.SetUserProperty(property, value);
        }

        /// <summary>
        /// Sets multiple user properties at once.
        /// </summary>
        /// <param name="properties">Dictionary of properties.</param>
        public static void SetUserProperties(Dictionary<string, object> properties)
        {
            if (!_isInitialized)
            {
                Debug.LogWarning("[Whalytics] Not initialized. Call Init() first.");
                return;
            }
            _eventManager.SetUserProperties(properties);
        }
    }
}
