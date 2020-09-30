using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoapAmount : MonoBehaviour
{
    public double soapkg;
    public InputManagerProcess inputManagerProcess;
    TMPro.TextMeshProUGUI amountText;

    // Start is called before the first frame update
    void Start()
    {
        amountText = gameObject.GetComponent<TMPro.TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        soapkg = soapkg + inputManagerProcess.soapValue * Time.deltaTime;
        amountText.text = "Current Soap \n" + soapkg.ToString() + "kg";

    }
}
