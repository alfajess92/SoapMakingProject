using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WoodSaucer : MonoBehaviour
{
    public GameObject definedButton;
    public UnityEvent OnClick = new UnityEvent();
    Animator animator;
    AudioSource audioSource;
    Vector3 position;


    // Start is called before the first frame update
    void Start()
    {
        definedButton = this.gameObject;
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        position = definedButton.transform.localPosition;
    }

    


    // Update is called once per frame
    void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit Hit;

        if (Input.GetMouseButtonDown(0))//zero refers to the right click of the mouse
        {
            if (Physics.Raycast(ray, out Hit) && Hit.collider.gameObject == gameObject)
            {

               Debug.Log("echale");
               animator.SetTrigger("ServeAsh");//inside the animator controller
               //PlaySound();

            }

        }

    }

    private void PlaySound()
    {
        if (!audioSource.isPlaying)                    //if the audio is not playing

        {
            audioSource.Play();
        }

        else

        {
            audioSource.Stop();
        }
    }
}
