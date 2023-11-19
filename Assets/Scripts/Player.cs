using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed; 
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
       
    }
    private void Awake()
    {
        animator = this.GetComponent<Animator>();
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
        vector3 = vector3.normalized * speed * Time.deltaTime;
        animator.SetFloat("x", v);
        animator.SetFloat("y", h);
        this.transform.position += vector3;
    }
}
