using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public GameObject door;
    public GameObject[] coin;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        CoinCounter coinCounter = FindObjectOfType<CoinCounter>();
        Character character = collider.GetComponent<Character>();
        coin = GameObject.FindGameObjectsWithTag("Coin");
        if (character)
        {
            character.coin++;
            coinCounter.Refresh(character.coin);
            if (coin.Length == 1)
            {
                door.SetActive(true);
            }
            Destroy(gameObject);
        }
    }
}
