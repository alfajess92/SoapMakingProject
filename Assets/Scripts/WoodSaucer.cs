using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WoodSaucer : MonoBehaviour
{
    [SerializeField] SpillScriptWoodSaucer spill;

    //public GameObject definedButton;
    
    Animator animator;
    AudioSource audioSource;
    Vector3 position;
    ParticleSystem waterStreamWoodSaucer;
    public bool isTouchWoodsaucer = false;

    // Start is called before the first frame update
    void Start()
    {
       
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        waterStreamWoodSaucer = GetComponent<ParticleSystem>();
       
    }

   public void ServeWaterWoodSaucer()
    {
        Debug.Log("echale");
        animator.SetTrigger("ServeAsh");
        isTouchWoodsaucer = true;
    }

    
    public void PlayWaterStream()
    {
        spill.PlayWaterStreamWoodSaucer();
    }

    public void StopWaterStream()
    {
        spill.StopWaterStreamWoodSaucer();
    }


    public void PlaySoundWoodSaucerStream()//TODO check if this has to be here

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


    // Update is called once per frame
    /*
     * //void Update()
    //{
    //    Debug.Log("vengase la charolita");
    //    var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //    RaycastHit Hit;

    //    if (Input.GetMouseButtonDown(0))//zero refers to the right click of the mouse
    //    {
    //        if (Physics.Raycast(ray, out Hit) && Hit.collider.gameObject == gameObject)
    //        {

    //           Debug.Log("echale");
    //           animator.SetTrigger("ServeAsh");//inside the animator controller
               

    //        }

    //    }

    //}
    */

}
