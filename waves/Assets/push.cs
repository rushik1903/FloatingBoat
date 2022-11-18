using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class push : MonoBehaviour
{
    public GameObject ship;
    public float maxHeightOfShip;
    private float time;
    public float waveHeight = -10000f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private Vector3 GetWaveHeight(float x, float z)
    {
        //Vector3 Ypoint = new Vector3(x, (Mathf.Sin((x+z)/2))*(Mathf.Sin(time)), z);
        //Vector3 Ypoint = new Vector3(x, (Mathf.Sin(x))*(Mathf.Sin(time)), z);
        //Vector3 Ypoint = new Vector3(x, Mathf.Sin(((x+z)/2)+time), z);

        float X = x / 3, Z = z / 3;
        Vector3 Ypoint = new Vector3(x, Mathf.Sin((X + Z) / 1.414f - Mathf.Sin((X - Z) / 1.414f) + time), z);

        return Ypoint;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        /*rayCasting
        RaycastHit[] hits;
        hits = Physics.RaycastAll(transform.position, new Vector3(0, 1, 0), 30f);
        Debug.Log(hits.Length);
        for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit hit = hits[i];
            Debug.Log(hit.transform.tag);
            if (hit.transform.tag == "wave")
            {
                Debug.Log(hit.point.y);
                waveHeight = hit.point.y;
            }
        }*/

        waveHeight = GetWaveHeight(gameObject.transform.position.x, gameObject.transform.position.z).y;

        Vector3 floaterPosition = gameObject.transform.position;
        //Debug.Log(waveHeight);
        if (gameObject.transform.position.y < waveHeight)
        {
            float buoyancyValue = waveHeight - floaterPosition.y;
            if (maxHeightOfShip< (waveHeight - floaterPosition.y))
            {
                buoyancyValue = maxHeightOfShip;
            }
            //boat moves with waves
            //Vector3 force = gameObject.transform.up;
            //force = -1 * force;
            //force = force.normalized * (buoyancyValue)*2;

            Vector3 force = new Vector3(0, 2f, 0) * (buoyancyValue);  // for standing boat
            ship.GetComponent<Rigidbody>().AddForceAtPosition(force, gameObject.transform.position, ForceMode.Acceleration);
        }
    }
}
