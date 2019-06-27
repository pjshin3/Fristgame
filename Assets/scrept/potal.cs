using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class potal : MonoBehaviour
{
    public Vector3 MovePostion;

    public Vector3 ThisPostion;

    public void Init()
    {
        ThisPostion = transform.position;
    }
    public void SetMoveposition(Vector3 position)
    {
        MovePostion = position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "MainMen")
        {
            GameObject Mainguy = GameObject.FindGameObjectWithTag("MainMen");

            if(transform.localScale.x == -1)
            {
                Mainguy.transform.position = new Vector3(MovePostion.x - 1, MovePostion.y, 49);
            }
            else
            {
                Mainguy.transform.position = new Vector3(MovePostion.x + 1, MovePostion.y, 49);
            }
        }
    }

}
