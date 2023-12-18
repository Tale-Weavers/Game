using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerBehaviour : MonoBehaviour
{

    CharacterController controller;

    [SerializeField] GameObject squawkRange;
    [SerializeField] GameObject attackRange;

    [SerializeField] private bool hidden;

    [SerializeField] float moveSpeed;
    ContinuousWoolBall woolBall;
    bool hasWoolball;
    public GameObject cleanerPrefab;
    public GameObject buddyGO;

    public bool Hidden { get { return hidden; } set { hidden = value; } }

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
        if (Input.GetKeyDown(KeyCode.Q)&& !buddyGO.gameObject.activeSelf)
        {

            buddyGO.transform.position = transform.position + transform.forward;
            buddyGO.SetActive(true);
            buddyGO.GetComponent<BuddyAlly>().UpdateActions();
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
        if (!hasWoolball)
        {
            return;
        }
        int throwDist = 1;
        if (woolBall.isLaser) throwDist = 2;
        woolBall.transform.position = transform.position + transform.forward * throwDist;
        woolBall.gameObject.SetActive(true);
        hasWoolball = false;

        Square furthestSquare = GM.instance.cleanerSpawnPoints[0];
        float distToSpawn = 0;
        foreach(Square square in GM.instance.cleanerSpawnPoints)
        {
            if((square.transform.position - woolBall.transform.position).magnitude > distToSpawn)
            {
                furthestSquare = square;
                distToSpawn = (square.transform.position - woolBall.transform.position).magnitude;
            }
        }

        GameObject newEnemy = Instantiate(cleanerPrefab);
        newEnemy.GetComponent<CleanerEnemy>().CleanerEnemySetup(woolBall.gameObject, furthestSquare);
        newEnemy.GetComponent<CleanerEnemy>().enabled = true;
        
    }

    public void GiveWollball(ContinuousWoolBall wb)
    {
        if(wb!=null)
        {
            if (!hasWoolball)
            {
                woolBall = wb;
                hasWoolball = true;
            }
            else
            {
                wb.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 2);
                wb.gameObject.SetActive(true) ;
                
            }
        }
    }


}
