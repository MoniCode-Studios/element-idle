using BreakInfinity;
using UnityEngine;

public class UpgradesManager : MonoBehaviour
{
    public static UpgradesManager instance;
    private void Awake() => instance = this;

    public void StartUpgradesManager()
    {
        UpdateUI();
    }

    public void BuyUp()
    {
        var data = Controller.instance.data;
        if (data.neutrons >= Cost())
        {
            data.neutrons -= Cost();
            data.clickUpgradeLevel++;
            UpdateUI();
        }
    }
    private BigDouble Cost() 
    {
        var data = Controller.instance.data;
        return data.clickUpgradeCost * BigDouble.Pow(data.clickUpgradeCostMulti, data.clickUpgradeLevel); 
    }


    private void UpdateUI()
    {
        var data = Controller.instance.data;
        Upgrades.instance.clickUpLVTxt.text = data.clickUpgradeLevel.ToString();
        Upgrades.instance.clickUpCostTxt.text = "Cost: " + Cost() + "n";
    }
}
