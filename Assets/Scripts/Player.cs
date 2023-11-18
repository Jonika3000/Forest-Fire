using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform player;
    public Vector2 newPos;
    public float speed = 3.3F; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
       newPos = player.position;
       if(Input.GetKey(KeyCode.W))
        {
            Debug.Log('W');
            newPos.y = player.position.y + speed;
        }
        player.position = newPos;
    }
}
