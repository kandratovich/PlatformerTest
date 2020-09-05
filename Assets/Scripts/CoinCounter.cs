using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCounter : MonoBehaviour
{
    private int maxCoin;
    Text text;
    private void Start()
    {
        maxCoin = GameObject.FindGameObjectsWithTag("Coin").Length;
        text = GetComponent<Text>();
        text.text ="0 / " + maxCoin.ToString();
    }
    public void Refresh(int coin)
    {
        text.text = coin.ToString()+" / "+maxCoin.ToString();
    }
}
