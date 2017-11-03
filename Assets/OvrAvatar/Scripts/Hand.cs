using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{

    public Vector3 holdPosition = new Vector3(0, -0.025f, 0.03f);
    public Vector3 holdRotation = new Vector3(0, 180, 0);

    private bool holdingPaddle = false;
    private GameObject paddle = null;

    public OVRInput.Controller controller;

    private float indexTriggerState = 0;
    private float handTriggerState = 0;
    private float oldIndexTriggerState = 0;

    // Update is called once per frame
    void Update()
    {
        oldIndexTriggerState = indexTriggerState;
        indexTriggerState = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, controller);
        handTriggerState = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, controller);

    }

    void OnTriggerStay(Collider other)
    {
        print(other.gameObject);
        if (other.CompareTag("Paddle"))
        {
            if (handTriggerState > 0.9f && !holdingPaddle)
            {
                print("made it here");
                Grab(other.gameObject);
            }
        }
    }

    void Grab(GameObject obj)
    {
        holdingPaddle = true;
        paddle = obj;

        paddle.transform.parent = transform;

        paddle.transform.localPosition = holdPosition;
        paddle.transform.localEulerAngles = holdRotation;

        paddle.GetComponent<Rigidbody>().useGravity = false;
        paddle.GetComponent<Rigidbody>().isKinematic = true;
    }

    void Release()
    {
        paddle.transform.parent = null;

        Rigidbody rigidbody = paddle.GetComponent<Rigidbody>();

        rigidbody.useGravity = true;
        rigidbody.isKinematic = false;

        rigidbody.velocity = OVRInput.GetLocalControllerVelocity(controller);

        holdingPaddle = false;
        paddle = null;
    }
}