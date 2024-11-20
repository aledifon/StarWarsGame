using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.ConstrainedExecution;
using System.Threading;
using UnityEngine;
using UnityEngine.Rendering;

public class Xwing : MonoBehaviour
{
    // Global vars of the class
    [Header("Movement")]
    [SerializeField]
    private int speed;
    private int moveSpeed;
    [SerializeField]
    private int turnSpeed;
    [SerializeField]
    private int speedBoost = 10;
    private float horizontal,
                    vertical,
                    xMouse,
                    yMouse;

    [Header("Attack")]
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private Transform[] posRotBullet;            

    private Rigidbody rb;
    private AudioSource shootAudio;
   
    private void Awake()
    {
        // Configure globally the invariant culture (In order to use '.' as floating point)
        System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        System.Threading.Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;

        Cursor.lockState = CursorLockMode.Locked;
    }
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        shootAudio = GetComponent<AudioSource>();

        moveSpeed = speed;      // Init the Movement Speed with the Def. Speed
    }
    
    void Update()
    {
        InputPlayer();
        Attack();
        //Spin();
        Movement();
        Turning();
    }

    private void FixedUpdate()
    {
        //InputPlayer();
        //Attack();
        //Spin();
        //MovementPhysics();
        //Turning();
    }

    // To move my starship in the x-axis and z-axis.
    private void Movement()
    {
        Vector3 direction = new Vector3(horizontal, 0, vertical);                

        transform.Translate(direction.normalized * moveSpeed * Time.deltaTime);        
    }
    private void Turning()
    {
        Vector3 rotation = new Vector3(-yMouse, xMouse,0);

        transform.Rotate(rotation.normalized * turnSpeed * Time.deltaTime);
    }
    private void MovementPhysics()
    {
        Vector3 inputPlayerDirection = new Vector3(horizontal, 0, vertical);        

        //rb.MovePosition(rb.position + inputPlayerDirection.normalized * Time.fixedDeltaTime * moveSpeed);
        rb.AddForce(inputPlayerDirection.normalized * Time.fixedDeltaTime * moveSpeed, ForceMode.Impulse);
    }
    private void InputPlayer()    
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        xMouse = Input.GetAxis("Mouse X");
        yMouse = Input.GetAxis("Mouse Y");
    }
    void Spin()
    {
        if (Input.GetMouseButtonDown(1) && horizontal != 0)        
        {
            moveSpeed = speed * speedBoost;
            StartCoroutine(SetDefaultSpeedAfterDelay(0.2f));
        }
    }
    IEnumerator SetDefaultSpeedAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);         // Wait for a delay        
        moveSpeed = speed;                              // Set again the default Movement Speed
    }

    // Create the bullets to attack the enemies
    void Attack()
    {        
        if (Input.GetMouseButtonDown(0))
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
