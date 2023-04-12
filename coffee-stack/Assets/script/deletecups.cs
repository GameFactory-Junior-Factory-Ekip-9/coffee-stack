using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deletecups : MonoBehaviour
{
    public GameObject mainhand;
    public GameObject movingcups;
    public Canvas para;
    private void OnTriggerEnter(Collider other)
    {

        mainhand.transform.rotation = Quaternion.Euler(0f, -90f, -90f);
        Destroy(movingcups);
        para.gameObject.SetActive(false);

    }
}
