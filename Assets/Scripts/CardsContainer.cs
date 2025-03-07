using System.Collections.Generic;
using UnityEngine;

public class CardsContainer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int i;
    private int k;
    
    public List<Card> ChapterCards;
    public List<Card> EventCards;

    public List<Card> Cards;

    public CardDisplay cardDisplay;

    public void BeginPlay()
    {
        Shuffle();
        AddEvent();
        i = 0;
        cardDisplay.BeginPlay();
    }

    public void Shuffle () 
    { 
        i = ChapterCards.Count;
        while (i > 0)
        {
            i--;
            k = Random.Range(0, i);
            (ChapterCards[k], ChapterCards[i]) = (ChapterCards[i], ChapterCards[k]);            
        }
    }

    public void AddEvent()
    {
        int x = ChapterCards.Count;
        int c = EventCards.Count;
        int ChapterIndex = 0;
        int EventIndex = 0;
        float AddIndex = ((100 - ((c * 100) / x)) * x) / 100;
        for (int maxi = x + c - 2; maxi >= 0; maxi--)
        {
            if (i == 0)
            {
                Cards.Add(ChapterCards[ChapterIndex]);
                ChapterIndex++;
            }

            if (i % AddIndex == 0)
            {
                Cards.Add(EventCards[EventIndex]);
                EventIndex++;
            }

            else
            {
                Cards.Add(ChapterCards[ChapterIndex]);
                ChapterIndex++;
            }
            i++;
        }
    }
}
