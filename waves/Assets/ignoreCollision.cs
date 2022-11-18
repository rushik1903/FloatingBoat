using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ignoreCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] water = GameObject.FindGameObjectsWithTag("wave");
        foreach(GameObject planeWater in water)
        {
            Physics.IgnoreCollision(planeWater.GetComponent<MeshCollider>(), gameObject.GetComponent<BoxCollider>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.layer == "Water")
    //    {
    //        Physics.IgnoreCollision(gameObject.collider, collider);
    //    }
    //}
}
