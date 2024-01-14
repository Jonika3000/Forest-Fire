using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health;
    public int numOfHearts;
    public CollisionPlayerController collisionPlayerController;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    private void Awake()
    {
        collisionPlayerController = GetComponent<CollisionPlayerController>();
        collisionPlayerController.HealthChange += CollisionPlayerController_HealthChange;
    }

    private void CollisionPlayerController_HealthChange(object sender, int e)
    {
        health = health + e;
    }

    public void Update()
    {
        if(health > numOfHearts)
            health = numOfHearts;

        for(int i = 0; i < hearts.Length; i++)
        {
            if(i < health)
                hearts[i].sprite = fullHeart;
            else
                hearts[i].sprite = emptyHeart;

            if(i < numOfHearts)
                hearts[1].enabled = true;
            else
                hearts[i].enabled = false;
        }
    }
}
