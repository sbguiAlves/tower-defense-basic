using UnityEngine;
using UnityEngine.UI;

public class SpotUI : MonoBehaviour
{
    public GameObject ui;

    private Spots target;

    public Text sellAmount;

    public void SetTarget(Spots _target)
    {
        target = _target;

        transform.position = target.getBuildPosition();

        ui.SetActive(true);

        sellAmount.text = target.towerBlueprint.GetSellAmount() + " G";
    }

    public void Hide()
    {
        ui.SetActive(false);
    }

    public void Sell()
    {
        target.SellTower();
        BuildManager.instance.DeselectSpot();
    }
}
