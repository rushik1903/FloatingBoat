using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public static WaveManager instance;
    public MeshRenderer meshRenderer;

    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance!=this)
        {
            Debug.Log("WaveManager instance already exists!");
            Destroy(this);
        }

        
        
    }

    private void Update()
    {
        
    }
}
