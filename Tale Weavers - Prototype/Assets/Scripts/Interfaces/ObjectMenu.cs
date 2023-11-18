using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class ObjectMenu : MonoBehaviour
{
    [Header("space between menu items")]
    [SerializeField] Vector2 spacing;

    [Space]
    [Header("Main Button Rotation")]
    [SerializeField] private float rotationDuration;
    [SerializeField] private Ease rotationEase;

    [Space]
    [Header("Animation")]
    [SerializeField] private float expandDuration;
    [SerializeField] private float collapseDuration;
    [SerializeField] Ease expandEase;//Dani putero
    [SerializeField] Ease collapseEase;//Dani putero

    [Space]
    [Header("Fading")]
    [SerializeField] private float expandFadeDuration;
    [SerializeField] private float collapseFadeDuration;



    [SerializeField] private Button mainButton;
    [SerializeField] private ObjectMenuItem[] menuItems;
    [SerializeField] private bool isExpanded;

    private Vector2 mainButtonPosition;
    private int itemsCount;

    // Start is called before the first frame update
    void Start()
    {
        itemsCount =menuItems.Length;
        

        mainButton.onClick.AddListener(ToggleMenu);
        mainButtonPosition = transform.GetChild(0).position;
        mainButton.transform.SetAsLastSibling();
        
        ResetPositions();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ResetPositions()
    {
        foreach (ObjectMenuItem item in menuItems)
        {
            item.transform.position = mainButtonPosition;
            Color tusmuertos = item.img.color;
            tusmuertos.a = 0f;
            item.img.color = tusmuertos;
        }
    }

    void ToggleMenu()
    {
        if (GameManager.instance.enemyTurn)
        {
            return;
        }

        isExpanded = !isExpanded;

        if(isExpanded)
        {
            Open(false);
        }
        else
        {
            Close();
        }

        mainButton.transform.DOShakePosition(rotationDuration).SetEase(rotationEase);
    }

    private void OnDestroy()
    {
        mainButton.onClick.RemoveListener(ToggleMenu);
    }

    public void UpdateMenu()
    {
        Open(true);
    }

    public void EndTurn()
    {
        if (isExpanded)
        {
            Close();
            isExpanded = false;
        }
    }


    private void Close()
    {
        for (int i = 0; i < itemsCount; i++)
        {
            //menuItems[i].transform.position = mainButtonPosition + spacing*(i+1);
            menuItems[i].transform.DOMove(mainButtonPosition, collapseDuration).SetEase(collapseEase);
            menuItems[i].img.DOFade(0f, collapseFadeDuration);


        }
    }

    private void Open(bool type)
    {
        float time = type ? 0 : expandFadeDuration;
        int cont = 0;
        for (int i = 0; i < itemsCount; i++)
        {
            if (menuItems[i].gameObject.activeSelf)
            {

                //menuItems[i].transform.position = mainButtonPosition + spacing*(i+1);
                menuItems[i].transform.DOMove(mainButtonPosition + spacing * (cont + 1), expandDuration).SetEase(expandEase);
                menuItems[i].img.DOFade(1f, time).From(0f);
                cont++;
            }


        }
    }
}
