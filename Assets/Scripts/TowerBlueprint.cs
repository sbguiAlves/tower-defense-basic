using UnityEngine;

[System.Serializable]
public class TowerBlueprint
{
    public GameObject prefab;
    public int custo;

    public int GetSellAmount()
    {
        return custo / 2;
    }
}
