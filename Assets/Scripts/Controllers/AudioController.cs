using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class AudioController : MonoBehaviour
{

    public static AudioController instance;
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

    public AudioSource audioData;
    void Start()
    {
        audioData = GetComponent<AudioSource>();
        audioData.Play(0);
        if (PlayerPrefs.GetInt("playedBefore") == 0)
        {
            PlayerPrefs.SetFloat("volume", 1);
            PlayerPrefs.SetInt("playedBefore", 1);
            audioData.volume = 1;
        } else 
        {
            audioData.volume = PlayerPrefs.GetFloat("volume");
        }
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "SettingsScene")
        {
            Slider slider = (Slider)FindAnyObjectByType(typeof(Slider));
            audioData.volume = slider.value;
            PlayerPrefs.SetFloat("volume", audioData.volume);
        }
    }
}
