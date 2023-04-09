using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cup : MonoBehaviour
{
    public bool triggertrigger;
    public GameObject movingcups;
    public float speedz;
    public bool cutted;
    GameObject hand;
    [Header("eklemeler")]
    public bool coffee;
    public bool sleeve;
    public bool lid;
    public bool canmove;
    void Start()
    {
        hand = GameObject.FindGameObjectWithTag("Player");
        movingcups = GameObject.Find("movingcups");
    }
    private void Update()
    {
        if (hand.GetComponent<mainhand>().playing&&hand.GetComponent<mainhand>().finished==false)
        {
        gameObject.GetComponent<Rigidbody>().useGravity=!canmove;
        gameObject.GetComponent<CapsuleCollider>().isTrigger = canmove;


        }
       
        transform.Find("kahve").gameObject.SetActive(coffee);
        transform.Find("Cup_Head").gameObject.SetActive(lid);
        transform.Find("Cup_Sleeve").gameObject.SetActive(sleeve);
    }
    private void FixedUpdate()
    {
        transform.Translate(0, 0, -20*speedz * Time.fixedDeltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.tag=="mainhand" || other.gameObject.tag == "cup") && canmove == false && triggertrigger)
        {
            this.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            this.gameObject.transform.parent = movingcups.transform;
            canmove = true;
            this.gameObject.transform.position = other.gameObject.transform.position+new Vector3(4,0,0);
            StartCoroutine(hand.GetComponent<mainhand>().scalecups());
        }
        if (other.gameObject.tag == "engel")
        {
            
            cutted = true;
         hand.GetComponent<mainhand>().cutthecups();
        }
        if (other.gameObject.tag == "destroyer") { gameObject.SetActive(false); }
        if (other.gameObject.tag == "sleevemachine") { sleeve = true; }
        if (other.gameObject.tag == "lidmachine") {lid=true; }
    }
    public IEnumerator controltriggertrigger()
    {
        triggertrigger = false;
        yield return new WaitForSecondsRealtime(1);
        triggertrigger = true;


    }
}
