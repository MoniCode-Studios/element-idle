using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Upgrades : MonoBehaviour
{
    public int UpgradeID;

    public TMP_Text costTxt;
    public TMP_Text levelTxt;
    public TMP_Text powTxt;
    public Image btnImage;

    public void BuyClickUpgrade() => UpgradesManager.instance.BuyUpgrade(UpgradeID);
}
