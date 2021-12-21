using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Spawner : MonoBehaviour
{
    public static int enemiesAlive;
    [HideInInspector]
    public int startEnemies=0;

    public static int currentSpeed;
    [HideInInspector]
    public int startSpeed=0;

    public static int indexWave;
    [HideInInspector]
    public int startIndex=0;

    private Enemy enemy;
    private float countdown = 0f;
    
    [Header("Config. Iniciais")]
    public GameManager gameManager;
    public Transform spawnPoint;
    public float waitingNextWave = 5f;

    [Header("Config. Ondas")]
    public WaveAttribute[] wave;

    [Header("UI")]
    public Text timerNextWave;
    public Text enemiesAliveText;
    public Text currentWaveText;

    void Start()
    {
        enemiesAlive=startEnemies;
        currentSpeed=startSpeed;
        indexWave=startIndex;
    }

    void Update()
    {
        if(enemiesAlive > 0)
        {
            enemiesAliveText.text = enemiesAlive.ToString();
            return;
        }
        if(enemiesAlive==0)
            enemiesAliveText.text = "0";

        if(GameManager.gameIsOver)
        {
            this.enabled=false;
            return;
        }

        if(indexWave == wave.Length)
        {
            gameManager.WinLevel();
            this.enabled=false;
            return;
        }
            currentWaveText.text = (indexWave + 1).ToString() + " / " + (wave.Length).ToString();
            if(countdown <= 0f)
            {
                StartCoroutine(SpawnWave());
                countdown = waitingNextWave;
                return;
            }

            countdown -= Time.deltaTime;
            countdown = Mathf.Clamp(countdown,0f,Mathf.Infinity);
            timerNextWave.text = string.Format("{0:0.00}",countdown); 
    }

    IEnumerator SpawnWave()
    {
        StatusPlayer.Waves++;

        WaveAttribute w = wave[indexWave];
        enemiesAlive=w.numberEnemies;
        currentSpeed=w.speedEnemy;
         
        for(int i = 0; i < w.numberEnemies; i++)
        {
            yield return new WaitForSeconds(w.timeBetweenEnemy);
            SpawnEnemy(w.enemy);
        }
        indexWave++;
    }

    void SpawnEnemy(GameObject enemyGO)
    {
        Instantiate(enemyGO,spawnPoint.position,spawnPoint.rotation);
    }
}
