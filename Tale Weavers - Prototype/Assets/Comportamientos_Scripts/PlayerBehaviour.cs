using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{

    CharacterController controller;

    [SerializeField] GameObject squawkRange;

    [SerializeField] private bool hidden;

    [SerializeField] float moveSpeed;

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
            Squawk();
        }
    }

    void Squawk()
    {
        StartCoroutine(SquawkAttack());
    }

   IEnumerator SquawkAttack()
    {
        Debug.Log("squwaking");
        squawkRange.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        squawkRange.SetActive(false);
    }




}
