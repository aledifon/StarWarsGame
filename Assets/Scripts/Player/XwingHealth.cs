using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XwingHealth : MonoBehaviour
{
    [SerializeField]
    private float maxHealth;        // Max Health
    
    private float currentHealth;    // Current Health
    [SerializeField]
    private float damageBullet;     // Bullet's enemies damage

    [SerializeField]
    private Image lifeBar;
    [SerializeField]
    private ParticleSystem bigExplosion,
                        smallExplosion;

    [SerializeField]
    private GameManager gameManager;

    void Awake()
    {
        // Stop particle systems by def.
        bigExplosion.Stop();
        smallExplosion.Stop();

        // Initialise CurrentHealth
        currentHealth = maxHealth;
        lifeBar.fillAmount = 1;
    }    
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BulletEnemy"))
        {
            //smallExplosion.Play();
            currentHealth -= damageBullet;
            lifeBar.fillAmount = currentHealth/maxHealth;
            Destroy(other.gameObject);

            if (currentHealth <= 0)            
                Death();
            else
                smallExplosion.Play();
        }
    }
    private void Death()
    {
        gameManager.GameOver();    
        bigExplosion.Play();
        // Converts the Camera Scene (which is Xwing's daughter), and makes she has no parent
        Camera.main.transform.SetParent(null);
        Destroy(gameObject,1.8f);
    }
}
