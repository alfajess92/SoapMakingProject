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
    //Vector3 offset = new Vector3(0f, 1f, 0f);

    // Update is called once per frame


        //if ladle script is touch
        
   public void CreateSoap()

    {
        //soapPos = GetComponentInParent<Transform>();
        //soapPos.position += offset * num_soap;
        //Instantiate(soapBar, soapPos.position, soapPos.rotation, soapPos);
        GameObject newSoap;
        //Rigidbody newRigidSoap;
        newSoap = Instantiate(soapBar, soapPos.position, soapPos.rotation, soapOrigin.transform);

        //newRigidSoap = Instantiate(rigidSoap, soapPos) as Rigidbody;

        //newRigidSoap = newSoap.GetComponent<Rigidbody>();
        ////newRigidSoap.velocity = offset;
        //newRigidSoap.AddForce(offset * 1f);
        //Instantiate(soapBar, soapPos.position + offset*num_soap, soapPos.rotation);
        //newSoap.SetActive(true);

        //TurnOffGravity();
        //num_soap++;
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
