using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckLevelCompletion : MonoBehaviour
{
    private int nOfStars = 1;

    
    [SerializeField] private int nOfSteps2star;

    [SerializeField] private int nOfSteps3star;
    [SerializeField] private int nOfEnemiesKnockedOut;
    [SerializeField] private int nOfEnemiesDistracted;

    [SerializeField] private bool notUsedWoolball;
    [SerializeField] private bool notUsedLaser;
    [SerializeField] private bool notUsedSquawk;
    [SerializeField] private bool notUsedFlashlight;

    [SerializeField] private GameObject[] stars;
    public int CountStars()
    {
        if (Check3StarConditions()) nOfStars = 3;

        else if (GameManager.instance.currentTurn <= nOfSteps2star)
        {
            nOfStars = 2;
        }

        if (nOfStars >= 2) stars[1].SetActive(true);
        if(nOfStars >= 3) stars[2].SetActive(true);
        return nOfStars;
    }

    private bool Check3StarConditions()
    {
        bool star3 = true;

        if (nOfSteps3star < GameManager.instance.currentTurn) star3 = false;

        if (nOfEnemiesKnockedOut < GameManager.instance.enemiesKnockedOut) star3 = false;
        if (nOfEnemiesDistracted < GameManager.instance.enemiesDistracted) star3 = false;

        if (notUsedWoolball) { star3 = !GameManager.instance.woolBallUsed; }
        if (notUsedLaser) { star3 = !GameManager.instance.laserUsed; }
        if (notUsedSquawk) { star3 = !GameManager.instance.squawkUsed; }
        if (notUsedFlashlight) { star3 = !GameManager.instance.flashlightUsed; }



        return star3;
    }
}
