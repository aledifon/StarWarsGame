 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Control the bullet Speed
    [SerializeField]
    private int speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward*speed*Time.deltaTime);

        //// Applies force to each bullet through its RigidBody
        //Rigidbody rbBullet = cloneBullet.GetComponent<Rigidbody>();
        //rbBullet.AddForce(Vector3.forward * thrustBullet);
    }
}
