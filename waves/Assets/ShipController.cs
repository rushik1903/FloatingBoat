using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    Rigidbody shipBody;
    public float forwardForce = 3;
    // Start is called before the first frame update
    void Start()
    {
        shipBody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Vector3 force = gameObject.transform.forward.normalized;
            force *= -1*forwardForce;
            shipBody.AddForce(force, ForceMode.Acceleration);
        }
    }
}
