using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hands : MonoBehaviour
{
    public GameObject camera;
    public GameObject mainhand;
    [SerializeField] GameObject[] hand;
    Animator animator;
    int notmove;
    void Start()
    {
        mainhand = GameObject.FindGameObjectWithTag("Player");
       hand = GameObject.FindGameObjectsWithTag("hands");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (mainhand.GetComponent<mainhand>().finished == false)
        {
            mainhand.GetComponent<mainhand>().finished = true;
            mainhand.transform.position = new Vector3(mainhand.transform.position.x,mainhand.transform.position.y, camera.transform.position.z);
        }
            foreach (GameObject item in hand)
        {
            animator = item.GetComponent<Animator>();
            notmove = Animator.StringToHash("notmove");
            animator.SetBool(notmove, true);
        }
    }

}
