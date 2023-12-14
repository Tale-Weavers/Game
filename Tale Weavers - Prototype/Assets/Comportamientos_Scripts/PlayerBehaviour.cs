using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{

    CharacterController controller;

    [SerializeField] GameObject squawkRange;
    [SerializeField] GameObject attackRange;

    [SerializeField] private bool hidden;

    [SerializeField] float moveSpeed;
    ContinuousWoolBall woolBall;
    bool hasWoolball;

    public bool Hidden { get => hidden; set => hidden = value; }

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponentInChildren<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move(move*moveSpeed*Time.deltaTime);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            StartCoroutine(Squawk());
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(Attack());
        }        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlaceDistraction();
        }
    }


   IEnumerator Squawk()
    {
        Debug.Log("squwaking");
        squawkRange.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        squawkRange.SetActive(false);
    }
    IEnumerator Attack()
    {
        Debug.Log("attacking");
        attackRange.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        attackRange.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("WoolBall"))
        {
            if (!other.GetComponent<ContinuousWoolBall>().beingPlayed && !hasWoolball)
            {
                other.GetComponent<ContinuousWoolBall>().ForgetWoolball();
                other.gameObject.SetActive(false);
                woolBall = other.GetComponent<ContinuousWoolBall>();
                hasWoolball = true;
            }
        }
    }

    void PlaceDistraction()
    {
        int throwDist = 1;
        if (woolBall.isLaser) throwDist = 2;
        woolBall.transform.position = transform.position + transform.forward * throwDist;
        woolBall.gameObject.SetActive(true);
        hasWoolball = false;
    }


}
