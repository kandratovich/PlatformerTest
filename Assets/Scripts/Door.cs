﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public GameObject GameOverWin;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Character character = collider.GetComponent<Character>();
        if (character)
        {
            CharacterStats.lives = character.lives;
            GameOverWin.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
