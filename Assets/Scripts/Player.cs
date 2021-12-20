using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float hz=10;
    public float zipH=10;
    public bool zipD=false;
    private float move;
    private Rigidbody2D rb;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        anim=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        move =Input.GetAxis("Horizontal");
        rb.velocity=new Vector2(move*hz,rb.velocity.y);
        if (move<0)
        {
            transform.eulerAngles=new Vector3(0,180,0);
        }
        else if(move>0)
        {
            transform.eulerAngles=new Vector3(0,0,0);
        }
        if(Input.GetButtonDown("Jump") && !zipD)
        {
            rb.AddForce(new Vector2(rb.velocity.x,zipH));
            zipD=true;
        }
        RunAnimations();
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Zemin"))
        {
            zipD=false;
        }
    }
    void RunAnimations()
    {
        anim.SetFloat("Hareket",Mathf.Abs(move));
        anim.SetBool("ziplamaDurum",zipD);
    }
}
