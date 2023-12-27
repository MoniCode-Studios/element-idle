using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchingScenes : MonoBehaviour
{
    public string scene;
    public void SwitchScene() => SceneManager.LoadScene(scene, LoadSceneMode.Single);
}
