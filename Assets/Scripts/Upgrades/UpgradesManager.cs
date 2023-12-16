using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using BreakInfinity;
using UnityEngine;

public class UpgradesManager : MonoBehaviour
{
    [SerializeField] private Controller controller;
    [SerializeField] private Upgrades upgrades;
    private BigDouble baseClickUpgradeCost;
    private BigDouble clickUpgradeCostMulti;

    public void StartUpgradesManager()
    {
        baseClickUpgradeCost = 10;
        clickUpgradeCostMulti = 2;
        UpdateUI();
    }

    public void BuyUp()
    {
        if (controller.playerData.neutrons >= Cost())
        {
            controller.playerData.neutrons -= Cost();
            controller.playerData.clickUpgradeLevel++;
            UpdateUI();
        }
    } 
    private BigDouble Cost() => baseClickUpgradeCost * BigDouble.Pow(clickUpgradeCostMulti, controller.playerData.clickUpgradeLevel);

    private void UpdateUI()
    {
        upgrades.clickUpLVTxt.text = controller.playerData.clickUpgradeLevel.ToString();
        upgrades.clickUpCostTxt.text = "Cost: " + Cost() + "n";
    }
}
