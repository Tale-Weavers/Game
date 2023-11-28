using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilPuddleController : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(WaitToCheck());
        }
    }

    private IEnumerator WaitToCheck()
    {
        yield return new WaitForSeconds(0.1f);
        Debug.Log("Cuervo");
        GameManager.instance.EnemiesVision();
    }
}
