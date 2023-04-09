using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class canvasbugfix : MonoBehaviour
{
    public GameObject hand;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began&& hand.GetComponent<mainhand>().playing == false&& !hand.GetComponent<mainhand>().finished)
            {
                if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                {
                    hand.GetComponent<mainhand>().playing = false;
                }
                else
                {
                    hand.GetComponent<mainhand>().playing = true;
                }
            }
        }
    }
}
