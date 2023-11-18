using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SwipeController : MonoBehaviour,IEndDragHandler
{
    [SerializeField] private int maxPage;
    private int currentPage;
    private Vector3 targetPos;
    [SerializeField] private Vector3 pageStep;
    [SerializeField] private RectTransform levelPagesRect;

    private float dragTreshold;

    [SerializeField] private float tweenTime;
    [SerializeField] private Ease easeType;

    [SerializeField] private Image[] barImage;
    [SerializeField] private Sprite barClosed;
    [SerializeField] private Sprite barOpen;

    [SerializeField] private Button previousButton;
    [SerializeField] private Button nextButton;

    [SerializeField] private GameObject tutorial;
    [SerializeField] private GameObject levels;

    private void Awake()
    {
        currentPage = 1;
        targetPos = levelPagesRect.localPosition;
        dragTreshold = Screen.width / 15;
        //UpdateBar();
        UpdateArrowButton();
    }

    public void Next()
    {
        if(currentPage < maxPage)
        {
            currentPage++;
            targetPos += pageStep;
            MovePage();
        }
    }

    public void Previous()
    {
        if(currentPage>1)
        {
            currentPage--;
            targetPos -= pageStep;
            MovePage();
        }
    }

    void MovePage()
    {
        levelPagesRect.DOLocalMove(targetPos, tweenTime).SetEase(easeType);
        //UpdateBar();
        UpdateArrowButton();

        if(currentPage == 1) {
            tutorial.SetActive(true);
            levels.SetActive(false);
        }
        else {
            tutorial.SetActive(false);
            levels.SetActive(true);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if(Mathf.Abs(eventData.position.x-eventData.pressPosition.x)>dragTreshold)
        {
            if (eventData.position.x > eventData.pressPosition.x) Previous();
            else Next();
        }
        else
        {
            MovePage();
        }
    }

    private void UpdateBar()
    {
        foreach(var item in barImage)
        {
            //item.sprite = barClosed;
        }
        //barImage[currentPage-1].sprite = barOpen;
    }

    private void UpdateArrowButton()
    {
        nextButton.interactable = true;
        previousButton.interactable = true;

        if (currentPage == 1) previousButton.interactable = false;
        else if(currentPage==maxPage) nextButton.interactable = false;
    }
}
