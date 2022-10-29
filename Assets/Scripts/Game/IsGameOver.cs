using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsGameOver : MonoBehaviour
{
    public Action OnGameOver;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        CheckBottomBorder(collision.gameObject);
    }
    private void CheckBottomBorder(GameObject collision)
    {

        if (collision.tag == "PlayersBubble")
        {
            Destroy(collision);
            return;
        }
        if (collision.tag == "Bubble")
        {
            OnGameOver?.Invoke();
        }
            

    }
}
