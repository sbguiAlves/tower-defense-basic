using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public GameObject deathEffect;

    public float startSpeed = 5f;
    public float startHealth = 5f;
    public int goldGain = 500;

    [HideInInspector]
    public float speed;

    private float health;
    private bool isDead=false;

    [Header("Unity Stuff")]
    public Image healthBar;

    void Start()
    {
        speed = startSpeed;
        health = startHealth;   
    }

    public void TakeDamage(int dano)
    {
        health -= dano;
        healthBar.fillAmount = health / startHealth;

        if(health <=0 && !isDead)
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;
        StatusPlayer.dinheiro += goldGain;

        GameObject effect = (GameObject)Instantiate(deathEffect,transform.position,Quaternion.identity);
        Destroy(effect,5f);

        Spawner.enemiesAlive--;

        Destroy(gameObject);
    }

    public void Slow(float pct,float currentSpeed)
    {
        speed = currentSpeed * (1f - pct); 
    }
}