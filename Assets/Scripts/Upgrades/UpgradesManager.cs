using System.Collections.Generic;
using BreakInfinity;
using UnityEngine;
using UnityEngine.UI;

public class UpgradesManager : MonoBehaviour
{
    public static UpgradesManager instance;
    private void Awake() => instance = this;

    public List<Upgrades> clickUpgrades;
    public Upgrades clickUpgradePrefab;

    public ScrollRect clickUpgradesScroll;
    public Transform clickUpgradesPanel;

    public string[] clickUpgradeNames;

    public BigDouble[] clickUpgradesCost;
    public BigDouble[] clickUpgradesCostMulti;
    public BigDouble[] clickUpgradesPower;

    public void StartUpgradesManager()
    {
        Methods.UpgradeCheck(MainController.instance.data.clickUpgradeLevel, 3);

        clickUpgradeNames = new[] { "Click Power +1", "Click Power +5", "Click Power +10" };
        clickUpgradesCost = new BigDouble[] { 10, 50, 100 };
        clickUpgradesCostMulti = new BigDouble[] { 2, 2.1, 2.2 };
        clickUpgradesPower = new BigDouble[] { 1, 5, 10 };

        for (int i = 0; i < MainController.instance.data.clickUpgradeLevel.Count; i++)
        {
            Upgrades upgrade = Instantiate(clickUpgradePrefab, clickUpgradesPanel);
            upgrade.UpgradeID = i;
            clickUpgrades.Add(upgrade);
        }

        clickUpgradesScroll.normalizedPosition = new Vector2(0, 0);

        ClickUpgradesUIUpdate();
    }

    public void BuyUpgrade(int UpgradeID)
    {
        var data = MainController.instance.data;
        if (data.neutrons >= ClickUpgradeCost(UpgradeID))
        {
            data.neutrons -= ClickUpgradeCost(UpgradeID);
            data.clickUpgradeLevel[UpgradeID] += 1;
        }

        ClickUpgradesUIUpdate(UpgradeID);
    }
    private BigDouble ClickUpgradeCost(int UpgradeID) => (clickUpgradesCost[UpgradeID] * BigDouble.Pow(clickUpgradesCostMulti[UpgradeID], MainController.instance.data.clickUpgradeLevel[UpgradeID])).Round();

    private void ClickUpgradesUIUpdate(int UpgradeID = -1)
    {
        var data = MainController.instance.data;
        if (UpgradeID == -1)
            for (int i = 0; i < clickUpgrades.Count; i++) UpdateUI(i);
        else UpdateUI(UpgradeID);

        void UpdateUI(int ID)
        {
            clickUpgrades[ID].levelTxt.text = data.clickUpgradeLevel[ID].ToString();
            clickUpgrades[ID].powTxt.text = $"+{clickUpgradesPower[ID]} Neutron per Click";
            clickUpgrades[ID].costTxt.text = $"Cost: {ClickUpgradeCost(ID):F0} n";
        }
    }
}
