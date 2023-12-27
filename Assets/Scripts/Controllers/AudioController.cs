using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class AudioController : MonoBehaviour
{
    AudioSource audioData;
    public GameObject volSliderObj;

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

    void Start()
    {
        audioData = GetComponent<AudioSource>();
        audioData.Play(0);
        audioData.volume = PlayerPrefs.GetFloat("volume");
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
