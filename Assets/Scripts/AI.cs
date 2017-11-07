using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    private Rigidbody rb;

    public GameObject puck;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;

    }

    // Update is called once per frame
    void Update()
    {
        if (puck.transform.localPosition.x < -1.25f)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, puck.transform.localPosition.z);
            rb.AddForce(new Vector3(20, 0, 0));
            print("got here");
        }
        if (-2 < transform.localPosition.x)
        {
            rb.velocity = new Vector3(2.31f, 0, 0);
        }

    }


}
