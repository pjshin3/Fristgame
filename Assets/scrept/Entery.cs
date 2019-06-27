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
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "MainMen")
        {
            GameObject MapManager = GameObject.FindGameObjectWithTag("mapmanager");
            MapManager.GetComponent<loglike>().Init();

            GameObject Mainguy = GameObject.FindGameObjectWithTag("MainMen");
            Mainguy.transform.position = new Vector3(0, -250, 49);
        }
    }
}
