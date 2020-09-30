using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoapClicked : MonoBehaviour
{

    Animator anim;
    Collider2D collider2D;
    GameObject[] coronitas;
    public Sprite soapy;
    bool isInside=false;
    public bool isStart;
    int count;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        collider2D = gameObject.GetComponent<Collider2D>();
    }
    void Update()    {    }

    public void OnMouseDown()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (collider2D.OverlapPoint(mousePosition))
        {
            anim.SetTrigger("Clicked");
            if (!isStart)
            {
                coronitas = GameObject.FindGameObjectsWithTag("Coronita");

                if (coronitas.Length > 0 & isInside)
                {
                    int index = (int)Mathf.Floor(Random.Range(0, coronitas.Length));
                    coronitas[index].GetComponent<SpriteRenderer>().sprite = soapy;
                    coronitas[index].tag = "Soapy";

                }
            }
            else 
            {

            }
            /* foreach(GameObject coronita in coronitas)
             {
                 coronita.GetComponent<SpriteRenderer>().sprite = soapy;
                 coronita.tag = "Soapy";
             }*/
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        isInside = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isInside = false;
    }

}
