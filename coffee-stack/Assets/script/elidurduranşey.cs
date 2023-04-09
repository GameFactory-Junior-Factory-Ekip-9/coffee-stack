using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elidurduranşey : MonoBehaviour
{
    public GameObject mainhand;
    private void Start()
    {
        mainhand = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "mainhand")
        {
            mainhand.GetComponent<mainhand>().speed = 0;

        }  
    }
}
