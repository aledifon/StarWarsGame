using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private float maxHealth;        // Max Health

    private float currentHealth;    // Current Health
    [SerializeField]
    private float damageBullet;     // Bullet's player damage

    [SerializeField]
    private Image lifeBar;
    [SerializeField]
    private ParticleSystem bigExplosion,
                        smallExplosion;

    // Start is called before the first frame update
    void Awake()
    {
        // Stop particle systems by def.
        bigExplosion.Stop();
        smallExplosion.Stop();

        // Initialise CurrentHealth
        currentHealth = maxHealth;
        lifeBar.fillAmount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BulletPlayer"))
        {
            //smallExplosion.Play();
            currentHealth -= damageBullet;
            lifeBar.fillAmount = currentHealth / maxHealth;
            Destroy(other.gameObject);

            if (currentHealth <= 0)
                Death();
            else
                smallExplosion.Play();
        }
    }
    private void Death()
    {
        bigExplosion.Play();        
        Destroy(gameObject, 1f);
    }
}
