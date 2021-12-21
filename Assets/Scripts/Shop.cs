using UnityEngine;

public class Shop : MonoBehaviour
{
    public TowerBlueprint SingleTower;
    public TowerBlueprint CannonTower;
    public TowerBlueprint IceTower;

    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectSingleTower() //comunica com o build manager, apenas selecionando a arma
    {
        buildManager.SelectToBuild(SingleTower);
    }

    public void SelectCannonTower()
    {
        buildManager.SelectToBuild(CannonTower);
    }

    public void SelectIceTower()
    {
        buildManager.SelectToBuild(IceTower);
    }

}
