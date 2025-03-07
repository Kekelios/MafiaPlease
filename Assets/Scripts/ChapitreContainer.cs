using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChapitreContainer : MonoBehaviour
{
    public List<CardsContainer> listCardsContainer;
    public int i = 0;
    public int max = 0;

    IEnumerator PlayChapters()
    {
        Debug.Log("LE JEU COMMENCE !!!");
        for (i = 0; i < listCardsContainer.Count; i++)
        {
            listCardsContainer[i].gameObject.SetActive(true);
            listCardsContainer[i].BeginPlay();
            Debug.Log("Chapitre en cours : " + i);

            // Attendre que le chapitre soit terminé
            yield return new WaitUntil(() => listCardsContainer[i].cardDisplay.index >= listCardsContainer[i].Cards.Count - 1);

            Debug.Log("Chapitre suivant !");
            listCardsContainer[i].gameObject.SetActive(false);
        }
        Debug.Log("LE JEU EST FINI !!!");
    }

    void Start()
    {
        StartCoroutine(PlayChapters());
    }






    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //void Start()
    //{
    //    Debug.Log("LE JEU COMMENCE !!!");
    //    while (listCardsContainer.Count - 1 >= i & listCardsContainer[i].i <= listCardsContainer[i].Cards.Count)
    //    {
    //        listCardsContainer[i].gameObject.SetActive(true);
    //        listCardsContainer[i].BeginPlay();
    //        Debug.Log("Chapitre en cours : " + i);
    //        if (listCardsContainer[i].i >= listCardsContainer[i].Cards.Count - 1)
    //        {
    //            Debug.Log("Chapitre suivant !");
    //            listCardsContainer[i].gameObject.SetActive(false);
    //            i++;
    //        }   
    //    }
    //    Debug.Log("LE JEU EST FINI !!!");
    //}
}
