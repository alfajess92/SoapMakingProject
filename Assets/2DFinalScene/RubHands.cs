using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubHands : MonoBehaviour
{
    public WaterScript waterscript;
    GameObject[] soapys;
    GameObject[] cleans;
    Collider2D collider2D;
    public Sprite clean;
    public GameObject upHand;
    public GameObject downHand;

    // Start is called before the first frame update
    void Start()
    {
        collider2D = gameObject.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        cleans = GameObject.FindGameObjectsWithTag("Clean");

        foreach (GameObject clean in cleans)
        {
            clean.transform.position = new Vector3(clean.transform.position.x, clean.transform.position.y - 0.5f * Time.deltaTime, clean.transform.position.z);
        }
        HandsMove();
        if (waterscript.isInside)
        {
            soapys = GameObject.FindGameObjectsWithTag("Soapy");

            if (soapys.Length > 0 & waterscript.isInside & Random.value < 0.1)
            {
                int index = (int)Mathf.Floor(Random.Range(0, soapys.Length));
                soapys[index].GetComponent<SpriteRenderer>().sprite = clean;
                soapys[index].tag = "Clean";
                //                soapys[index].GetComponent<Rigidbody2D>().velocity = new Vector2(0, -1);
                soapys[index].transform.parent = null;
            }


        }
    }
    void HandsMove() 
    {
        
        if(waterscript.isInside)
        {
            upHand.GetComponent<Rigidbody2D>().velocity = new Vector2(upHand.transform.parent.position.x - upHand.transform.position.x, upHand.GetComponent<Rigidbody2D>().velocity.y);
            downHand.GetComponent<Rigidbody2D>().velocity = new Vector2(downHand.transform.parent.position.x - downHand.transform.position.x, downHand.GetComponent<Rigidbody2D>().velocity.y);
            upHand.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -5000*upHand.transform.localPosition.y)*Time.deltaTime);            
            downHand.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -5000* downHand.transform.localPosition.y)*Time.deltaTime);

        }
        else 
        {
            upHand.GetComponent<Rigidbody2D>().velocity=(new Vector2(upHand.transform.parent.position.x-upHand.transform.position.x, 1.5f-upHand.transform.localPosition.y)*10); 
            downHand.GetComponent<Rigidbody2D>().velocity =(new Vector2(downHand.transform.parent.position.x - downHand.transform.position.x, -1.5f-downHand.transform.localPosition.y)*10); 
        }
    }
}
