using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kapakmakinesi : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "cup")
        {
                other.gameObject.GetComponent<cup>().lid = true;
        }
    }
}
