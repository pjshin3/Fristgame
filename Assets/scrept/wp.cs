using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wp : MonoBehaviour
{
    GameObject Mainguy;

    private void Start()
    {
        Mainguy = GameObject.FindGameObjectWithTag("MainMen");
    }

    public void Init(string path)
    {
        if (path.Equals("all_set_Animation 1_15"))
        {
            Mainguy.GetComponent<mainguy>().power = 50;
        }

        this.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Cheriter/Mainguy/wp/" + path);
    }
}
