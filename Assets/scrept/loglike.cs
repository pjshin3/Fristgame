using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loglike : MonoBehaviour
{
    GameObject Grid;
    int number = -1;
    int MapCount;
    int x = 50;
    // Start is called before the first frame update
    public void Init()
    {
        Grid = Resources.Load<GameObject>("Tile/underground/UnderGround_MapGrid");

        GameObject Main = Instantiate(Grid, new Vector3(0, -300, 49), Quaternion.identity);

        MapCount = Random.Range(2, 6);

        GameObject Map_start = Resources.Load<GameObject>("Tile/underground/underground_strat");
        GameObject sub_start = Instantiate(Map_start, new Vector3(0, -250, 49), Quaternion.identity);
        sub_start.transform.parent = Main.transform;



        for (int i = 0; i < MapCount; i++)
        {
            int nb = Random.Range(0, 3);
            GameObject Map = Resources.Load<GameObject>("Tile/underground/underground_" + nb);
            GameObject sub = Instantiate(Map, new Vector3(x, -250, 49), Quaternion.identity);
            sub.GetComponent<underground_1>().Init();
            sub.transform.parent = Main.transform;
            x += 50;
        }

        MapConnection();

    }

    [System.Obsolete]
    public void MapConnection()
    {
        GameObject MapGrid = GameObject.FindGameObjectWithTag("UnderGroundGrid");


        MapGrid.transform.GetChild(0).transform.FindChild("potal_0").GetComponent<potal>().Init();
        MapGrid.transform.GetChild(1).transform.FindChild("potal_0").GetComponent<potal>().Init();

        MapGrid.transform.GetChild(0).transform.FindChild("potal_0").GetComponent<potal>().SetMoveposition(MapGrid.transform.GetChild(1).transform.FindChild("potal_0").GetComponent<potal>().ThisPostion);
        MapGrid.transform.GetChild(1).transform.FindChild("potal_0").GetComponent<potal>().SetMoveposition(MapGrid.transform.GetChild(0).transform.FindChild("potal_0").GetComponent<potal>().ThisPostion);

        for (int i = 0; i < MapCount; i++)
        {
            MapGrid.transform.GetChild(i+1).transform.FindChild("potal_0").GetComponent<potal>().Init();
            MapGrid.transform.GetChild(i+1).transform.FindChild("potal_1").GetComponent<potal>().Init();
            if(i+1 < MapCount)
            {
                Debug.Log("동작");

                MapGrid.transform.GetChild(i + 2).transform.FindChild("potal_0").GetComponent<potal>().Init();
                MapGrid.transform.GetChild(i + 2).transform.FindChild("potal_1").GetComponent<potal>().Init();

                MapGrid.transform.GetChild(i + 1).transform.FindChild("potal_1").GetComponent<potal>().SetMoveposition(MapGrid.transform.GetChild(i + 2).transform.FindChild("potal_0").GetComponent<potal>().ThisPostion);
                MapGrid.transform.GetChild(i + 2).transform.FindChild("potal_0").GetComponent<potal>().SetMoveposition(MapGrid.transform.GetChild(i + 1 ).transform.FindChild("potal_1").GetComponent<potal>().ThisPostion);
            }

        }

    }

}
