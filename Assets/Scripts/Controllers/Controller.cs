using UnityEngine;
using TMPro;
using BreakInfinity;

public class Controller : MonoBehaviour
{
    public PlayerData playerData;
    [SerializeField] private UpgradesManager upgradesManager;
    [SerializeField] private DiscordController discordController;
    [SerializeField] private TMP_Text neutronAmtText;
    [SerializeField] private TMP_Text neutronClickPow;

    public void Update()
    {
        neutronClickPow.text = "+" + ClickPow() + " Neutrons";
        neutronAmtText.text = playerData.neutrons + " Neutrons";
    }

    public void NeutronClickGen() 
    {
        playerData.neutrons += ClickPow();
    }

    private BigDouble ClickPow() => 1 + playerData.clickUpgradeLevel;

    private void Start()
    {
        playerData = new PlayerData();
        upgradesManager.StartUpgradesManager();
        discordController.UpdateStatus();
    }
}
