using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPMotion : MonoBehaviour
{
    public GameObject playerCamera; // needs to be connected to real object in the ide 
    private CharacterController controller;
    private float speed = 6f;
    private float rx = 0, ry;
    private float angularSpeed = 5;
    private AudioSource stepFootSound;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();//gets player controller
        stepFootSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        //mouse
        rx -= Input.GetAxis("Mouse Y") * angularSpeed;
        //use Clampf to limit sight angles
        ry = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * angularSpeed;

        playerCamera.transform.localEulerAngles = new Vector3(rx, 0, 0);

        transform.localEulerAngles = new Vector3(0, ry, 0);//sets new orientation of player

        //keyboard
        float dx, dz;
        dx = Input.GetAxis("Horizontal") * speed * Time.deltaTime;//horizontal means "A" "D"        Vector3 motion = new Vector3(dx, 0, dz);
        dz = Input.GetAxis("Vertical") * speed * Time.deltaTime;//W or S

        Vector3 motion = new Vector3(dx, 0, dz);

        motion = transform.TransformDirection(motion);
        controller.Move(motion);


        //add sound of foot steps
        if (!stepFootSound.isPlaying && controller.velocity.magnitude > 0.1)
            stepFootSound.Play();
    }
}