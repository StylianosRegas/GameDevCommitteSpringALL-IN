using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UIElements;


public class CardManager : MonoBehaviour
{
    private int currCard = 0;
    
    public List<Card> cards = new List<Card>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        
        Debug.Log("CardManager Started!");
        
    }

    // Update is called once per frame
    void Update()
    {
        checkInputs();
    }

    void checkInputs()
    {
        

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (currCard == cards.Count - 1)
            {
                currCard = 0;
            }
            else
            {
                currCard++;
            }

            Debug.Log("New Card:");
            Debug.Log(cards[currCard].name);
        }

        if (Input.GetKeyDown(KeyCode.E) && !cards[currCard].hasCooldown)
        {

            useAbility();
            cards[currCard].hasCooldown = true;
        }
       
    }

    public void useAbility()
    {
        Debug.Log("Card ability used!");
    }
}
