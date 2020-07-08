using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoapCreator : MonoBehaviour
{
    
    [SerializeField]
    Rigidbody rigidSoap;
    public Transform soapPos;
    public GameObject soapBar;
    public GameObject soapOrigin;
    public Component[] componentRigidBodyChildren;


    //Create the gameobject on realtime    
    public void CreateSoap()
    {
        GameObject newSoap;
        newSoap = Instantiate(soapBar, soapPos.position, soapPos.rotation, soapOrigin.transform);
    }

    public  void DestroySoap()
    {
        Destroy(this.gameObject);
    }

    public void TurnOnGravity()
    {
        componentRigidBodyChildren = soapOrigin.GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody rigidBody in componentRigidBodyChildren)
        {
            rigidBody.useGravity = true;
        }
            
    }

    public void TurnOffGravity()
    {
        componentRigidBodyChildren = soapOrigin.GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody rigidBody in componentRigidBodyChildren)
        {
            rigidBody.useGravity = false;
        }

    }

}


//Test this...
 
        //soapPos = GetComponentInParent<Transform>();
        //soapPos.position += offset * num_soap;
        //Instantiate(soapBar, soapPos.position, soapPos.rotation, soapPos);
        //
//        GameObject newSoap;
////Rigidbody newRigidSoap;
//newSoap = Instantiate(soapBar, soapPos.position, soapPos.rotation, soapOrigin.transform);

//        //newRigidSoap = Instantiate(rigidSoap, soapPos) as Rigidbody;

        //newRigidSoap = newSoap.GetComponent<Rigidbody>();
        ////newRigidSoap.velocity = offset;
        //newRigidSoap.AddForce(offset * 1f);
        //Instantiate(soapBar, soapPos.position + offset*num_soap, soapPos.rotation);
        //newSoap.SetActive(true);

        //TurnOffGravity();
        //num_soap++;
    