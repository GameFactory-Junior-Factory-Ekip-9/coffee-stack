using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class sleeve : MonoBehaviour
{
    public GameObject sleevesign;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "cup")
        {


            sleevesign.transform.DORotate(new Vector3(0,90,0),0.5f);
            
            
            other.gameObject.GetComponent<cup>().sleeve = true;

        }
    }
}
