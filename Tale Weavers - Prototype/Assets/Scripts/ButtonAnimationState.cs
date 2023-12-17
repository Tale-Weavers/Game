using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;

public class ButtonAnimationState : MonoBehaviour
{

    public GameObject spikes;
    public NavMeshSurface navMesh;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" )
        {
            Debug.Log("tira de la palanca kronk");
            spikes.SetActive(false);
            navMesh.BuildNavMesh();
            this.gameObject.SetActive(false);
        }
        else if( other.gameObject.tag == "Pizza")
        {
            Debug.Log("tira de la palanca kronk");
            spikes.SetActive(false);
            navMesh.BuildNavMesh();
            BuddyAlly buddy = other.GetComponent<BuddyAlly>();
            buddy.buttonPressed = true;
            this.gameObject.SetActive(false);
        }
    }
}
