using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMotion : MonoBehaviour
{
    private Animator anim;
    private AudioSource doorSound;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        doorSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame

    private void OnTriggerEnter(Collider other)
    {
        anim.SetBool("opening", true);
        doorSound.Play();
    }

    private void OnTriggerExit(Collider other)
    {
        anim.SetBool("opening", false);
        doorSound.Play();
    }
    void Update()
    {
        
    }
}
