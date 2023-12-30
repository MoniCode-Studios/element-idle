using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class AudioController : MonoBehaviour
{

    void Awake()
    {
        bool instanceExists = false;
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

    AudioSource audioData;
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
