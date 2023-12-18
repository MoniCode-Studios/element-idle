using UnityEngine;
using TMPro;

public class Upgrades : MonoBehaviour
{
    public static Upgrades instance;
    private void Awake() => instance = this;

    public TMP_Text clickUpCostTxt;
    public TMP_Text clickUpLVTxt; 
}
