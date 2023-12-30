using BreakInfinity;
using UnityEngine;
using TMPro;

public class MainController : MonoBehaviour
{
    public static MainController instance;
    private void Awake() => instance = this;

    public Data data;
    private void Start()
    {
        data = new Data();

        UpgradesManager.instance.StartUpgradesManager();

        DiscordController.instance.UpdateStatus();
    }
    
    private BigDouble ClickPow() {
        BigDouble total = 1;
        for (int i = 0; i < data.clickUpgradeLevel.Count; i++)
        {
            total += UpgradesManager.instance.clickUpgradesPower[i] * data.clickUpgradeLevel[i];
        }
        return total;
    }

    public TMP_Text neutronClickPow;
    public TMP_Text neutronAmtText;
    private void Update()
    {
        neutronClickPow.text = "+" + ClickPow() + " Neutrons";
        neutronAmtText.text = data.neutrons + " Neutrons";
        if (Input.GetButtonDown("NMake")) {
            NeutronClickGen();
        }
    }

    public void NeutronClickGen()
    {
        data.neutrons += ClickPow();
    }
}
