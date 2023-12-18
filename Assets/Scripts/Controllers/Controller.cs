using UnityEngine;
using TMPro;
using BreakInfinity;

public class Controller : MonoBehaviour
{
    public static Controller instance;
    private void Awake() => instance = this;

    public Data data;

    public TMP_Text neutronAmtText;
    public TMP_Text neutronClickPow;

    private void Start()
    {
        data = new Data();

        UpgradesManager.instance.StartUpgradesManager();

        DiscordController.instance.UpdateStatus();
    }
    
    private BigDouble ClickPow() => 1 + data.clickUpgradeLevel;
    
    public void Update()
    {
        neutronClickPow.text = "+" + ClickPow() + " Neutrons";
        neutronAmtText.text = data.neutrons + " Neutrons";
    }

    public void NeutronClickGen()
    {
        data.neutrons += ClickPow();
    }
}
