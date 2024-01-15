using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMobileController : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField]private float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
       
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 acceleration = Input.acceleration;
        acceleration = Quaternion.Euler(90,0,0)*acceleration;
        rb.AddForce(acceleration*speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("WinSquare"))
        {
            GameManagerMobile.instance.WinScreen();
        }
    }
}
