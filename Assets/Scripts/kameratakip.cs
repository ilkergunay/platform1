using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kameratakip : MonoBehaviour
{
    private Vector2 hiz;
    public float yZY;
    public float yZX;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        //player=GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float posX,posY;
        posX=Mathf.SmoothDamp(transform.position.x,player.transform.position.x,ref hiz.x, yZX);
        posY=Mathf.SmoothDamp(transform.position.y,player.transform.position.y,ref hiz.y, yZY);
        transform.position=new Vector3(posX,posY,transform.position.z);
    }
}
