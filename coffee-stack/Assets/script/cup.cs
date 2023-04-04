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
    
    public bool milk;
    public bool coffee;
    public bool sleeve;
    public bool lid;
    public bool canmove;
    public bool first;
    public bool second;
    public bool third;
    


    void Start()
    {
        hand = GameObject.FindGameObjectWithTag("Player");
        movingcups = GameObject.Find("movingcups");
    }
    private void Update()
    {
       gameObject.GetComponent<Rigidbody>().useGravity=!canmove;
        gameObject.GetComponent<CapsuleCollider>().isTrigger = canmove;
        if (coffee && milk)
            {
                transform.Find("süt").gameObject.SetActive(false);
                transform.Find("kahve").gameObject.SetActive(false);
                transform.Find("sütlü_kahve").gameObject.SetActive(true);
            }
            else if (milk) {
                transform.Find("süt").gameObject.SetActive(true);
                transform.Find("kahve").gameObject.SetActive(false);
                transform.Find("sütlü_kahve").gameObject.SetActive(false);
            }
            else if (coffee)
            {
                transform.Find("süt").gameObject.SetActive(false);
                transform.Find("kahve").gameObject.SetActive(true);
                transform.Find("sütlü_kahve").gameObject.SetActive(false);
            }
            else {transform.Find("süt").gameObject.SetActive(false);
                transform.Find("kahve").gameObject.SetActive(false);
                transform.Find("sütlü_kahve").gameObject.SetActive(false); }

        transform.Find("first").gameObject.SetActive(first);
        transform.Find("second").gameObject.SetActive(second);
        transform.Find("third").gameObject.SetActive(third);
        if (first) {
            
            
            transform.Find("first").gameObject.transform.Find("Cup_Sleeve").gameObject.SetActive(sleeve);
            transform.Find("first").gameObject.transform.Find("Cup_Head").gameObject.SetActive(lid);
        }
        if (second)
        {
            transform.Find("second").gameObject.transform.Find("Cup_Sleeve").gameObject.SetActive(sleeve);
            transform.Find("second").gameObject.transform.Find("Cup_Head").gameObject.SetActive(lid);
        }
        if (third)
        {
            transform.Find("third").gameObject.transform.Find("Cup_Sleeve").gameObject.SetActive(sleeve);
            transform.Find("third").gameObject.transform.Find("Cup_Head").gameObject.SetActive(lid);
        }

    }
    private void FixedUpdate()
    {
        transform.Translate(0, 0, -15*speedz * Time.fixedDeltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "cup" && canmove == false&&triggertrigger)
        {
            this.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;

            this.gameObject.transform.parent = movingcups.transform;
            canmove = true;
            
            this.gameObject.transform.position = other.gameObject.transform.position+new Vector3(4,0,0);
            StartCoroutine(hand.GetComponent<cup_movement>().scalecups());
        }
        if (other.gameObject.tag == "engel")
        {
            
            cutted = true;
hand.GetComponent<cup_movement>().cutthecups();
        }
        if (other.gameObject.tag == "destroyer") { gameObject.SetActive(false); }
    }
    public IEnumerator controltriggertrigger()
    {
        triggertrigger = false;
        yield return new WaitForSecondsRealtime(1);
        triggertrigger = true;


    }
}
