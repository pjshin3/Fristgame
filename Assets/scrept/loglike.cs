using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loglike : MonoBehaviour
{
    GameObject Grid;

    int Y = -250;
    int number = -1;
    bool isfrist = true;


    // Start is called before the first frame update
    void Start()
    {
    


        Grid = Resources.Load<GameObject>("Tile/underground/UnderGround_MapGrid");

        GameObject Main = Instantiate(Grid, new Vector3(0, Y, 49), Quaternion.identity);

        int MapCount = Random.Range(1, 5);

        for (int i = 0; i < MapCount; i++)
        {

            int nb = Random.Range(0, 2);

                GameObject Map = Resources.Load<GameObject>("Tile/underground/underground_" + nb);
                GameObject sub = Instantiate(Map, new Vector3(0, Y, 49), Quaternion.identity);

            sub.GetComponent<underground_1>().Init();
            sub.transform.parent = Main.transform;

                Y -= 50;
                //number = nb;

                //isfrist = false;
        }



        //Grid = Resources.Load<GameObject>("Tile/underground/UnderGround_MapGrid");

        //Map_0 = Resources.Load<GameObject>("Tile/underground/underground_0");
        //Map_1 = Resources.Load<GameObject>("Tile/underground/underground_1");
        //Map_2 = Resources.Load<GameObject>("Tile/underground/underground_2");


        //GameObject Main = Instantiate(Grid, new Vector3(0,-250,49), Quaternion.identity);
        //GameObject sub_0 = Instantiate(Map_0, new Vector3(0, -250, 49), Quaternion.identity);
        //GameObject sub_1 = Instantiate(Map_1, new Vector3(0, -300, 49), Quaternion.identity);
        //GameObject sub_2 = Instantiate(Map_2, new Vector3(0, -350, 49), Quaternion.identity);

        //sub_0.transform.parent = Main.transform;
        //sub_1.transform.parent = Main.transform;
        //sub_1.GetComponent<underground_1>().Init();
        //sub_2.transform.parent = Main.transform;

    }

    // Update is called once per frame
    void Update()
    {
        //if (!isfrist && nb != number)
        //{

        //}
        //else
        //{
        //    nb = Random.Range(0, 3);
        //}
    }
}
