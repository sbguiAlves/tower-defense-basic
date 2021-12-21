using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{   
    public void TryAgain()
    {
        Spawner.indexWave=0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
