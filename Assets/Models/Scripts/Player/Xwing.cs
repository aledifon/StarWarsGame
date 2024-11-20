using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.Rendering;

public class Xwing : MonoBehaviour
{    
    // Global vars of the class
    [SerializeField]
    //[Header("Speed")]
    private int speed;

    private float horizontal,
                    vertical;

    private void Awake()
    {
        // Configure globally the invariant culture (In order to use '.' as floating point)
        System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        System.Threading.Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;
    }
    
    void Start()
    {
        
    }
    
    void Update()
    {
        InputPlayer();
    }

    //private void FixedUpdate()
    //{
        
    //}

    // To move my starship in the x-axis and z-axis.
    private void Movement()
    {
        
    }

    private void InputPlayer()    
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }
}
