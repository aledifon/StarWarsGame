using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField]
    private int speed;
    [SerializeField]
    private float minDistanceToPlayer;  // Min Distance allowed to approach to player
    [SerializeField]
    private float minDistanceToAttack;  // Min Distance allowed to attack

    private float distance;             // Distance between the enemy and the player

    [Header("Attack")]
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private Transform[] posRotBullet;
    [SerializeField]
    private float shootingCadence;

    GameObject player;
    private AudioSource shootAudio;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        shootAudio = GetComponent<AudioSource>();

        InvokeRepeating("Attack", 1, shootingCadence);
    }

    // Update is called once per frame
    void Update()
    {
        // If you don't find the GO player don't do anything
        if(player == null)
        {
            return;
        }
        transform.LookAt(player.transform.position);
        FollowPlayer();
    }
    private void FollowPlayer()
    {
        // Calculate the distance between the enemy and the player (in meters)
        distance = Vector3.Distance(transform.position,player.transform.position);
        if (distance > minDistanceToPlayer)
        {            
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }
    private void Attack()
    {
        if (distance <= minDistanceToAttack)
        {
            shootAudio.Play();
            foreach (Transform bullet in posRotBullet)
            {
                GameObject cloneBullet = Instantiate(bulletPrefab, bullet.position, bullet.rotation);
                // Destroyes the bullet after 5s
                Destroy(cloneBullet, 3);
            }
        }
    }
}
