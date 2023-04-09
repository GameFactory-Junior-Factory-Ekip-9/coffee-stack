using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.SceneManagement;


public class mainhand : MonoBehaviour
{
    public float money;
    public GameObject leveltext;
    public GameObject moneytext;

    public bool playing;
    public bool finished;
    bool cutted;
    public GameObject movingcups;
    public float speed;
    Touch touch;
    Transform previousposition;
    private void Update()
    {
        moneytext.GetComponent<TextMeshProUGUI>().text = money.ToString("0");

    }
    private void Start()
    {
        leveltext.GetComponent<TextMeshProUGUI>().text = "LV." + (SceneManager.GetActiveScene().buildIndex + 1);
        movingcups = GameObject.Find("movingcups");
        previousposition =this.transform;
        
        StartCoroutine(movecups());
        StartCoroutine(scalecups());
    }
    private void FixedUpdate()
    {
        if (playing)
        {
            transform.Translate(speed * Time.fixedDeltaTime, 0, 0);

            if (Input.touchCount > 0&&!finished)
            {
                touch = Input.GetTouch(0);
                transform.position = new Vector3(transform.position.x, transform.position.y,
                     0 - ((touch.position.x - (Screen.width / 2)) / Screen.width * 40 * Screen.width / Screen.height));


            }
        }
    }
    IEnumerator movecups()
    {
        bool first=true;
        for (int i = 0; i < movingcups.transform.childCount; i++)
         {
            previousposition = this.transform;
            if (movingcups.transform.GetChild(i).GetComponent<cup>().canmove) {
                
            if (first)
                {
                    movingcups.transform.GetChild(i).transform.position = this.transform.position;
                    previousposition = movingcups.transform.GetChild(i).transform;
                    first = false;
            }
            else {
                   movingcups.transform.GetChild(i).transform.position = new Vector3(movingcups.transform.GetChild(i-1).position.x + 4, movingcups.transform.GetChild(i).transform.position.y, movingcups.transform.GetChild(i).transform.position.z);
                    
                    movingcups.transform.GetChild(i).GetComponent<cup>().speedz = movingcups.transform.GetChild(i).transform.position.z- movingcups.transform.GetChild(i - 1).position.z;
                    previousposition = movingcups.transform.GetChild(i).transform;
                }
    }
            
         }
        yield return new WaitForSecondsRealtime(0.001f);
        StartCoroutine(movecups());

    }
   public IEnumerator scalecups()
    {
        for(int i= movingcups.transform.childCount-1; i > -1; i--) {
          movingcups.transform.GetChild(i).transform.DOScale(new Vector3(2.5f, 2.5f, 2.5f),0.05f);
            yield return new WaitForSecondsRealtime(0.05f);
            movingcups.transform.GetChild(i).transform.DOScale(new Vector3(2f, 2f, 2f), 0.25f);
            yield return new WaitForSecondsRealtime(0.01f);
        }
    }
    public void cutthecups()
    {
        bool cutting=false;
        for (int i = 0; i <movingcups.transform.childCount; i++)
        {
            if(movingcups.transform.GetChild(i).GetComponent<cup>().cutted){ cutting = true; }
            if (cutting) {
                GameObject cup = movingcups.transform.GetChild(i).gameObject;
                StartCoroutine(cup.GetComponent<cup>().controltriggertrigger());
       
               cup.GetComponent<cup>().canmove = false;
              cup.GetComponent<Rigidbody>().velocity=new Vector3(0, 10, (float)Random.Range(-0.1f, 0.1f));


                cup.transform.localScale = new Vector3(2, 2, 2);
                cup.transform.parent = null;
                cup.GetComponent<cup>().speedz = 0;
                
            }
            
        }





    }
}
