using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragHands : MonoBehaviour
{
    bool dragged;
    Collider2D collider2D;
    Vector2 delta;
    Vector3 newPosition;
    Vector2 force;
    // Start is called before the first frame update
    void Start()
    {
        collider2D = gameObject.GetComponent<Collider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if(dragged)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            newPosition.x = mousePosition.x - delta.x;
            newPosition.y = mousePosition.y - delta.y;
            //gameObject.transform.position = newPosition;
            force.x=newPosition.x - gameObject.transform.position.x;
            force.y = newPosition.y - gameObject.transform.position.y;
            gameObject.GetComponent<Rigidbody2D>().velocity= (newPosition- gameObject.transform.position)*10;
        }
        else { gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero; }
    }
    public void OnMouseDown()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (collider2D.OverlapPoint(mousePosition))
        {
            dragged = true;
            delta.x = mousePosition.x - gameObject.transform.position.x;
            delta.y = mousePosition.y - gameObject.transform.position.y;
        }
    }

    public void OnMouseUp()
    {
        dragged = false;
    }

}
