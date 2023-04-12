using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class takethecupattheend : MonoBehaviour
{
    [SerializeField] GameObject hand;
    Animator animator;
    int drink;
    public GameObject bilek;
    public GameObject mainhand;
    public TMP_Text money;
    public int moneynumber;
    public int m;
    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.transform.localScale = new Vector3(2, 2, 2);
        other.gameObject.GetComponent<cup>().canmove = true;
        other.gameObject.GetComponent<cup>().triggertrigger = false;
        other.gameObject.GetComponent<cup>().speedz = 0;
        other.gameObject.transform.position = this.transform.position+new Vector3(0,-2,0);
        animator = hand.GetComponent<Animator>();
            drink = Animator.StringToHash("drink");
            animator.SetBool(drink, true);
            moneynumber = Int32.Parse(money.text) + m;
            money.text = moneynumber.ToString();
            Debug.Log("collidera çarpan = " + other.gameObject.name);
        other.gameObject.transform.parent = bilek.gameObject.transform;
            Destroy(this.gameObject);
    }

}
