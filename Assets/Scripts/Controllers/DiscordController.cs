using System;
using UnityEngine;

public class DiscordController : MonoBehaviour
{
    public static DiscordController instance;

    public Discord.Discord discord;

    private long time;
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
        }
    }

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
            Debug.LogWarning("Found dupe of GameObject");
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
                State = Controller.instance.data.neutrons + " Neutrons",
                Timestamps =
                    {
                        Start = time
                    }
            };

            activityManager.UpdateActivity(activity, (res) =>
            {
                if (res != Discord.Result.Ok) Debug.LogWarning("Failed connecting to Discord!");
            });
        }
        catch (Exception err)
        {
            // If updating the status fails, Destroy the GameObject
            Destroy(gameObject);
            Debug.LogWarning("Failed connecting to Discord!");
            Debug.LogWarning(err.Message);
        }
    }
}