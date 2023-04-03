using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cup : MonoBehaviour
{
    public GameObject movingcups;
    public float speedz;
    GameObject hand;
    [Header("eklemeler")]
    public bool milk;
    public bool coffee;
    public bool sleeve;
    public bool lid;
    public bool canmove;
    public bool first;
    public bool second;
    public bool third;
    [Header("bardakçeþitleri")]
    public GameObject firstcup;
    public GameObject secondcup;
    public GameObject thirdcup;
    [Header("1.bardakmalzemeleri")]
    public GameObject kapak1;
    public GameObject ambalaj1;
    [Header("2.bardakmalzemeleri")]
    public GameObject kapak2;
    public GameObject ambalaj2;
    [Header("3.bardakmalzemeleri")]
    public GameObject kapak3;
    public GameObject ambalaj3;


    void Start()
    {
        hand = GameObject.FindGameObjectWithTag("Player");
        movingcups = GameObject.Find("movingcups");
    }

    private void FixedUpdate()
    {
        transform.Translate(0, 0, -10*speedz * Time.fixedDeltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "cup" && canmove == false)
        {
            this.gameObject.transform.parent = movingcups.transform;
            canmove = true;
            
            this.gameObject.transform.position = other.gameObject.transform.position+new Vector3(4,0,0);
            StartCoroutine(hand.GetComponent<cup_movement>().scalecups());
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "cup"&&canmove==false) {
            this.gameObject.transform.parent = movingcups.transform;
           
            canmove = true;
        
        }
    }
}
