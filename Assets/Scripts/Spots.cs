using UnityEngine;
using UnityEngine.EventSystems;

public class Spots : MonoBehaviour
{
    public Color hoverColor;
    public Color notEnoughMoneyColor;
    public Vector3 positionOffset;

    [HideInInspector]
    public TowerBlueprint towerBlueprint;

    [HideInInspector]
    public GameObject tower;

    private Renderer rend;
    private Color startColor;

    BuildManager buildManager;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
    }

    public Vector3 getBuildPosition()
    {
        return transform.position + positionOffset;
    }

    private void OnMouseDown() {

        if(EventSystem.current.IsPointerOverGameObject())
            return;
    
        if(tower != null) //foi construido algo aqui
        {
            buildManager.SelectSpot(this);
            return;
        }

        if(!buildManager.CanBuild)
            return;

        BuildTower(buildManager.GetTowerToBuild()); //construir naquele spot
    }

    void BuildTower(TowerBlueprint blueprint)
    {
        if(StatusPlayer.dinheiro < blueprint.custo)
        {
            return;
        }

        StatusPlayer.dinheiro -= blueprint.custo;

        GameObject _tower = (GameObject)Instantiate(blueprint.prefab, getBuildPosition(), Quaternion.identity);
        tower = _tower;

        towerBlueprint = blueprint;
    }

    void OnMouseEnter() //quando o mouse entra na area
    {
        if(EventSystem.current.IsPointerOverGameObject())
            return;

        if(!buildManager.CanBuild) // evita que dê erro quando n tiver referencia
            return;

        if(buildManager.HasMoney)
            rend.material.color = hoverColor; 
        else
            rend.material.color = notEnoughMoneyColor;
    }

    void OnMouseExit() {
        rend.material.color = startColor;
    }

    public void SellTower()
    {
        StatusPlayer.dinheiro += towerBlueprint.GetSellAmount();
        Destroy(tower);
        towerBlueprint = null;
    }
}
