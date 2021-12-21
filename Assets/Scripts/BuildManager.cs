using UnityEngine;

public class BuildManager : MonoBehaviour
{
    /*Utilizar o static significa que a variável 'instance' pode ser acessada por qualquer script dentro
    da cena em questão. Dessa forma, haverá apenas um Gerenciador responsável em construir as torres, pois,
    se houver mais de um Gerenciador no jogo, aumenta a complexidade por não saber qual é o gerenciador
    principal que está gerenciando toda a parte de construção do jogo*/
    public static BuildManager instance;

    void Awake() {
        if(instance != null)
        {
            Debug.LogError("Já tem um BuildManager na cena!");
            return;
        }        
        instance = this; //vai ter apenas um buildManager q é esse aqui
    }
    public SpotUI spotUI;

    private TowerBlueprint towerToBuild;
    private Spots selectedSpot;

/*
Propriedade que permite pega (get) o resultado da comparação em return. Neste caso, se for igual a nulo, logo
o resultado será false. Se o valor for diferente de nulo, então retorna true. */
    public bool CanBuild { get {return towerToBuild!=null;}}
    public bool HasMoney { get {return StatusPlayer.dinheiro>=towerToBuild.custo;}}//tem dinheiro pra comprar

    public void SelectSpot(Spots spot)
    {
        if(selectedSpot == spot)
        {
            DeselectSpot();
            return;
        }

        selectedSpot = spot;
        towerToBuild = null;

        spotUI.SetTarget(spot);
    }

    public void DeselectSpot()
    {
        selectedSpot = null;
        spotUI.Hide();
    }

    public void SelectToBuild(TowerBlueprint tower)
    {
        towerToBuild = tower;
        DeselectSpot();
    }

    public TowerBlueprint GetTowerToBuild()
    {
        return towerToBuild;
    }
}
