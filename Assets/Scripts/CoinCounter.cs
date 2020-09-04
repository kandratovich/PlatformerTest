using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCounter : MonoBehaviour
{
    Text text;
    private void Start()
    {
        text = GetComponent<Text>();
    }
    public void Refresh(int coin)
    {
        text.text = coin.ToString();
    }
}
