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
    public int index;

    public void BeginPlay()
    {
        index = 0;
        Debug.Log("cardsContainer.Cards[index] : " + cardsContainer.Cards[index]);
        card = cardsContainer.Cards[index];
        informations.text = card.informations;
        artwork.sprite = card.artwork;
        rightchoice.text = card.rightchoice;
        leftchoice.text = card.leftchoice;
    }

    public void CardUpdate()
    {
        if (index < cardsContainer.Cards.Count - 1)
        {
            index++;
            card = cardsContainer.Cards[index];
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
