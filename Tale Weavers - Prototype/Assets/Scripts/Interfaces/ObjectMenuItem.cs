using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectMenuItem : MonoBehaviour
{
    [HideInInspector] public Image img;

    private void Awake()
    {
        img = GetComponent<Image>();
        
    }
}
