using System.Collections.Generic;
using UnityEngine;
using GameEventsIO;

public class GameEventsIODemo : MonoBehaviour
{
    void Start()
    {
        // Initialize GameEventsIO with API Key and Debug Mode
        GameEventsIO.GameEventsIO.Init("YOUR_API_KEY_HERE", true);

        // Set some user properties
        GameEventsIO.GameEventsIO.SetUserProperty("user_level", 5);
        GameEventsIO.GameEventsIO.SetUserProperty("is_premium", true);

        // Set multiple user properties at once
        var userProps = new Dictionary<string, object>
        {
            { "cohort", "A" },
            { "login_method", "email" }
        };
        GameEventsIO.GameEventsIO.SetUserProperties(userProps);

        // Log a simple event
        GameEventsIO.GameEventsIO.LogEvent("game_started");

        // Log an event with parameters
        var paramsDict = new Dictionary<string, object>
        {
            { "level_name", "Level 1" },
            { "difficulty", "Hard" },
            { "score", 100 }
        };
        GameEventsIO.GameEventsIO.LogEvent("level_complete", paramsDict);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameEventsIO.GameEventsIO.LogEvent("space_pressed");
            Debug.Log("Logged 'space_pressed' event");
        }
    }
}
