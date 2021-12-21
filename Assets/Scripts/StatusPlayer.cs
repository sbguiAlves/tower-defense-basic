using UnityEngine;

public class StatusPlayer : MonoBehaviour
{
    public static int dinheiro;
    public int dinheiroInicial = 500;

    public static float amountFire;
    public float startAmountFire = 0.0f;

    public static int Waves;

    void Start()
    {
        Waves = 0;

        amountFire = startAmountFire;
        dinheiro = dinheiroInicial;
    }    
}
