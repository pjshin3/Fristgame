using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entery : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void CreateLoglike()
    {
        GameObject MapManager = GameObject.FindGameObjectWithTag("mapmanager");
        MapManager.GetComponent<loglike>().Init();
    }
}
