using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player : MonoBehaviour
{
    public float speed; 
    public Animator animator;
    public int health;
    public event EventHandler<int> HealthChange;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("PlayerPositionX") && PlayerPrefs.HasKey("PlayerPositionY"))
        {
            this.transform.position = new Vector2(PlayerPrefs.GetFloat("PlayerPositionX"), PlayerPrefs.GetFloat("PlayerPositionY"));
        }
        
    }
    private void Awake()
    {
        animator = this.GetComponent<Animator>();
    }

    private void CollisionPlayerController_HealthChange(object sender, int e)
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical"); 
        Vector3 vector3 = new Vector3(h, v, 0);
        PlayerPrefs.SetFloat("PlayerPositionX", this.transform.position.x);
        PlayerPrefs.SetFloat("PlayerPositionY", this.transform.position.y);
        vector3 = vector3.normalized * speed * Time.deltaTime;
        Vector2 normalizedMovement = new Vector2(h, v).normalized;
        if (normalizedMovement.y != 0 || normalizedMovement.x != 0)
        {
            animator.SetBool("IsWalk", true);
            animator.SetFloat("X", normalizedMovement.x);
            animator.SetFloat("Y", normalizedMovement.y);
        }
        else
        {
            animator.SetBool("IsWalk", false);
        }
        this.transform.position += vector3;
    }
}
