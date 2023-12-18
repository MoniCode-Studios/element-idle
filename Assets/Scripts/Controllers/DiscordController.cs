using System;
using Discord;
using UnityEngine;

public class DiscordController : MonoBehaviour
{
    public long applicationID;
    [Space]
    public string details = "Partcle";
    public string state = " Neutrons";
    public Discord.Discord discord;

    [SerializeField] private Controller controller;
    private long time;
    private static bool instanceExists;

    void Awake()
    {
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
        discord = new Discord.Discord(applicationID, (System.UInt64)Discord.CreateFlags.NoRequireDiscord);

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
                Details = details,
                State = controller.playerData.neutrons + state,
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