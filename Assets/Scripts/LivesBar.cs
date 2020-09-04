using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesBar : MonoBehaviour
{
    private Transform[] heart = new Transform[5];

    private Character character;
    private void Awake()
    {
        character = FindObjectOfType<Character>();
        for (int i = 0; i < heart.Length; i++) 
        {
            heart[i] = transform.GetChild(i);
        }
    }

    public void Refresh()
    {
        for (int i = 0; i < heart.Length; i++)
        {
            if (i < character.Lives) heart[i].gameObject.SetActive(true);
            else heart[i].gameObject.SetActive(false);
        }
    }
}
