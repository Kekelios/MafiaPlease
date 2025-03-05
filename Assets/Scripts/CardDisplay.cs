using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardDisplay : MonoBehaviour
{
    public CardsContainer cardsContainer;
    public Card card;

    public TMP_Text informations;
    public TMP_Text rightchoice;
    public TMP_Text leftchoice;

    public Image artwork;
    private int index;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        index = 0;
        card = cardsContainer.ChapterCards[index];
        informations.text = card.informations;
        artwork.sprite = card.artwork;
        rightchoice.text = card.rightchoice;
        leftchoice.text = card.leftchoice;
    }

    void Update()
    {
        Debug.Log("CardDisplay : " + cardsContainer.ChapterCards);
    }

    public void CardUpdate()
    {
        if (index < cardsContainer.ChapterCards.Count - 1)
        {
            index++;
            card = cardsContainer.ChapterCards[index];
            informations.text = card.informations;
            artwork.sprite = card.artwork;
            rightchoice.text = card.rightchoice;
            leftchoice.text = card.leftchoice;
        }

        else
        {
            Debug.Log("Chapitre finit !!!!!!!!!");
        }
    }
}
