using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionPlayerController : MonoBehaviour
{
    public event EventHandler<int> HealthChange;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fruit"))
        {
            HealthChange?.Invoke(this, 1);
            collision.gameObject.SetActive(false);
        }
    }
}
