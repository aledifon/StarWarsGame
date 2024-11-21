using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanevasEnemy : MonoBehaviour
{    
    // Update is called once per frame
    void Update()
    {
        // Look towards the scene's camera which has the 'Maincamera' tag
        transform.LookAt(Camera.main.transform.position);
    }
}
