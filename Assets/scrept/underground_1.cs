using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class underground_1 : MonoBehaviour
{
    int MOSTER = 0;
    int ITEMBOX = 1;
    int HEART = 2;
    int COIN = 3;

    // Start is called before the first frame update
    public void Init()
    {
        int CASE = Random.Range(0, 4);

        Debug.Log("CASE = " + CASE);

        switch (CASE)
        {
            case 0:
                {
                    MosterCase();
                }
                break;
            case 1:
                {
                    ItemBoxCase();
                }
                break;
            case 2:
                {
                    HeartCase();
                }
                break;
            case 3:
                {
                    CoinCase();
                }
                break;

        }
    }



    void MosterCase()
    {
        int Count = Random.Range(1, 4);

        Debug.Log("Count = " + Count);

        GameObject Anermy = Resources.Load<GameObject>("Cheriter/Anermi/zobie");

        for(int i = 0; i<Count; i++)
        {
            GameObject Anermy_ob = Instantiate(Anermy, new Vector3(Random.Range(-2, 4), transform.position.y - 3.5f, 49), Quaternion.identity);

            Anermy_ob.transform.parent = this.transform;
        }

    }
    void ItemBoxCase()
    {

        GameObject Box = Resources.Load<GameObject>("Background/object/Box_Open");

        GameObject Anermy_ob = Instantiate(Box, new Vector3( -1, transform.position.y - 3.5f, 49), Quaternion.identity);
    
        Anermy_ob.transform.parent = this.transform;

    }
    void HeartCase()
    {
        GameObject Heart = Resources.Load<GameObject>("Background/object/Heart");

        GameObject Heart_ob = Instantiate(Heart, new Vector3(-1, transform.position.y - 3.5f, 49), Quaternion.identity);

        Heart_ob.transform.parent = this.transform;
    }

    void CoinCase()
    {
        int Count = Random.Range(1, 7);

        Debug.Log("Count = " + Count);

        GameObject Coin = Resources.Load<GameObject>("Background/object/Coin");

        for (int i = 0; i < Count; i++)
        {
            GameObject Coin_ob = Instantiate(Coin, new Vector3(Random.Range(-4, 4), transform.position.y - 2.5f, 49), Quaternion.identity);

            Coin_ob.transform.parent = this.transform;
        }
    }
}
