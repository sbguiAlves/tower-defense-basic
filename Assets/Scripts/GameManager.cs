using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool gameIsOver;
    public float maxFire = 1.0f;
    
    public GameObject gameOverUI;
    public GameObject winLevelUI;

    void Start()
    {
        gameIsOver = false;    
    }

    void Update()
    {
        if(gameIsOver)
            return;
            
        if(StatusPlayer.amountFire >= maxFire)
        {
            EndGame();
        }    
    }

    public void WinLevel()
    {
        gameIsOver=true;
        winLevelUI.SetActive(true);
    }

    void EndGame()
    {
        gameIsOver=true;
        gameOverUI.SetActive(true);
    }
}
