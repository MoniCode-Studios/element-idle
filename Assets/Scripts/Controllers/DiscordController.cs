using UnityEngine;
using System;

public class DiscordController : MonoBehaviour
{
    public static DiscordController instance;
    private static bool instanceExists;
    void Awake()
    {
        instance = this;
        // Transition the GameObject between scenes, destroy any duplicates
        if (!instanceExists)
        {
            instanceExists = true;
            DontDestroyOnLoad(gameObject);
        }
        else if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
            Debug.LogWarning("Found dupe of GameObject, destroying GameObject.");
        }
    }

    private long time;
    private Discord.Discord discord;
    void Start()
    {
        // Log in with the Application ID
        discord = new Discord.Discord(1186104201739259914, (System.UInt64)Discord.CreateFlags.NoRequireDiscord);

        time = System.DateTimeOffset.Now.ToUnixTimeMilliseconds();
    }

    void Update()
    {
        // Destroy the GameObject if Discord isn't running
        try
        {
            discord.RunCallbacks();
        }
        catch
        {
            Destroy(gameObject);
            Debug.LogWarning("No Discord client found, destroying GameObject.");
        }
    }

    void LateUpdate()
    {
        UpdateStatus();
    }

    public void UpdateStatus()
    {
        // Update Status every frame
        try
        {
            var activityManager = discord.GetActivityManager();
            var activity = new Discord.Activity
            {
                Details = "Partcle",
                State = MainController.instance.data.neutrons + " Neutrons",
                Timestamps =
                    {
                        Start = time
                    }
            };

            activityManager.UpdateActivity(activity, (res) =>
            {
                if (res != Discord.Result.Ok) Debug.LogError("Failed connecting to Discord!");
            });
        }
        catch (Exception err)
        {
            // If updating the status fails, Destroy the GameObject
            Destroy(gameObject);
            Debug.LogError("Failed connecting to Discord! Destroying GameObject.");
            Debug.LogError(err.Message);
        }
    }
}