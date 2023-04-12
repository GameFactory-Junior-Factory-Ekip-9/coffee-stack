using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elidurduranşey : MonoBehaviour
{
    public GameObject mainhand;
    public GameObject money;
    public int moneynumber;
    private void Start()
    {
        mainhand = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "mainhand")
        {
            mainhand.GetComponent<mainhand>().speed = 0;
            for (int i = 0; i < moneynumber; i++)
            {
                Instantiate(money, new Vector3(money.transform.position.x, money.transform.position.y + (i / 2.5f), money.transform.position.z), Quaternion.identity);
                if (i == moneynumber - 1)
                {
                    mainhand.transform.position = new Vector3(mainhand.transform.position.x, money.transform.position.y + (i / 2.5f), mainhand.transform.position.z);
                }
            }

        }  
    }
}
