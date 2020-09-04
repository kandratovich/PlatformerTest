using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        CoinCounter coinCounter = FindObjectOfType<CoinCounter>();
        Character character = collider.GetComponent<Character>();
        if (character)
        {
            character.coin++;
            coinCounter.Refresh(character.coin);
            Destroy(gameObject);
        }
    }
}
