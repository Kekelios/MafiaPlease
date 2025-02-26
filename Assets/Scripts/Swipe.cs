using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections.Generic;

public class Swipe : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private Vector2 startPos;
    private float rotationFactor = 10f;
    private bool isDragging = false;

    public float swipeThreshold = 200f;
    public float moveSpeed = 0.3f;  // Vitesse du swipe (plus rapide)
    public Transform cardParent;
    public Image cardImage; // Image de la carte

    public static List<Sprite> spriteList = new List<Sprite>(); // Liste d'images
    private static int currentIndex = 0; // Index global de la liste

    private Swipe otherSwipe; // R�f�rence � l'autre carte
    private Quaternion originalRotation; // Rotation d'origine de la carte

    void Start()
    {
        startPos = transform.position;
        originalRotation = transform.rotation;  // Sauvegarder la rotation d'origine
        FindOtherSwipe();
        UpdateCardImage(); // Affiche la premi�re image
    }

    void FindOtherSwipe()
    {
        foreach (Transform child in cardParent)
        {
            Swipe swipe = child.GetComponent<Swipe>();
            if (swipe != null && swipe != this)
            {
                otherSwipe = swipe;
                break;
            }
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        isDragging = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!isDragging) return;

        Vector2 newPos = (Vector2)transform.position + new Vector2(eventData.delta.x, 0);
        transform.position = newPos;

        float rotationZ = (newPos.x - startPos.x) / rotationFactor;
        transform.rotation = Quaternion.Euler(0, 0, rotationZ);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isDragging = false;
        float swipeDistance = transform.position.x - startPos.x;

        if (Mathf.Abs(swipeDistance) > swipeThreshold)
        {
            if (swipeDistance > 0)
                SwipeRight();
            else
                SwipeLeft();
        }
        else
        {
            ResetPosition();
        }
    }

    void SwipeRight()
    {
        LeanTween.moveX(gameObject, transform.position.x + 1000, moveSpeed)
            .setEase(LeanTweenType.easeInOutQuad)
            .setOnComplete(RepositionSwipe);
        LeanTween.rotateZ(gameObject, 15, moveSpeed);  // Rotation l�g�re pendant le swipe
    }

    void SwipeLeft()
    {
        LeanTween.moveX(gameObject, transform.position.x - 1000, moveSpeed)
            .setEase(LeanTweenType.easeInOutQuad)
            .setOnComplete(RepositionSwipe);
        LeanTween.rotateZ(gameObject, -15, moveSpeed);  // Rotation l�g�re pendant le swipe
    }

    void ResetPosition()
    {
        LeanTween.move(gameObject, startPos, 0.2f).setEase(LeanTweenType.easeOutBounce); // Retour rapide au centre
        LeanTween.rotateZ(gameObject, 0, 0.2f);  // R�initialisation de la rotation
    }

    void RepositionSwipe()
    {
        transform.position = startPos;
        transform.rotation = originalRotation;  // R�initialisation de la rotation � l'originale

        // Change l'image de la carte en prenant le prochain �l�ment de la liste
        IncrementIndex();
        UpdateCardImage();

        // Met cette carte en arri�re et active l'autre
        transform.SetAsFirstSibling();
        otherSwipe.transform.SetAsLastSibling();
    }

    void IncrementIndex()
    {
        if (spriteList.Count == 0) return;

        currentIndex++;
        if (currentIndex >= spriteList.Count) currentIndex = 0; // Boucle infinie
    }

    void UpdateCardImage()
    {
        if (spriteList.Count > 0)
        {
            cardImage.sprite = spriteList[currentIndex];
        }
    }

    // Fonction pour ajouter dynamiquement une image � la liste
    public static void AddNewImage(Sprite newSprite)
    {
        spriteList.Add(newSprite);
    }
}
