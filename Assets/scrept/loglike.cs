using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loglike : MonoBehaviour
{
    GameObject Grid;

    int Y = -250;
    int number = -1;
    bool isfrist = true;
    int MapCount;

    // Start is called before the first frame update
    public void Init()
    {
        Grid = Resources.Load<GameObject>("Tile/underground/UnderGround_MapGrid");

        GameObject Main = Instantiate(Grid, new Vector3(0, Y, 49), Quaternion.identity);

        MapCount = Random.Range(2, 6);

        for (int i = 0; i < MapCount; i++)
        {

            int nb = Random.Range(0, 3);
            GameObject Map = Resources.Load<GameObject>("Tile/underground/underground_" + nb);
            GameObject sub = Instantiate(Map, new Vector3(0, Y, 49), Quaternion.identity);
            sub.GetComponent<underground_1>().Init();
            sub.transform.parent = Main.transform;
            Y -= 50;
        }
        MapConnection();
    }

    [System.Obsolete]
    public void MapConnection()
    {
        GameObject MapGrid = GameObject.FindGameObjectWithTag("UnderGroundGrid");

        MapGrid.transform.GetChild(0).transform.FindChild("potal_0").GetComponent<potal>().Init();
        MapGrid.transform.GetChild(0).transform.FindChild("potal_1").GetComponent<potal>().Init();
        MapGrid.transform.GetChild(1).transform.FindChild("potal_0").GetComponent<potal>().Init();
        MapGrid.transform.GetChild(1).transform.FindChild("potal_1").GetComponent<potal>().Init();


        MapGrid.transform.GetChild(1).transform.FindChild("potal_0").GetComponent<potal>().SetMoveposition(MapGrid.transform.GetChild(0).transform.FindChild("potal_1").GetComponent<potal>().ThisPostion);
        MapGrid.transform.GetChild(0).transform.FindChild("potal_1").GetComponent<potal>().SetMoveposition(MapGrid.transform.GetChild(1).transform.FindChild("potal_0").GetComponent<potal>().ThisPostion);

        for (int i = 0; i<MapCount; i++)
        {
        }

    }

}
