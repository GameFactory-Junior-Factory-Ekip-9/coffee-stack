using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class takethecupattheend : MonoBehaviour
{
    [SerializeField] GameObject hand;
    Animator animator;
    int drink;
    public GameObject bilek;
    public GameObject mainhand;
    
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
            Debug.Log("collidera çarpan = " + other.gameObject.name);
            
            other.gameObject.transform.parent = bilek.gameObject.transform;
            Destroy(this.gameObject);
        
    }

}
