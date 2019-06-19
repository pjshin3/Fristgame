using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Werter : MonoBehaviour
{
    public bool isclone;
    GameObject Damege;
    public int magicPower = 100;
    public bool input_darection = false;

    // Start is called before the first frame update
    public void init()
    {
        Damege = Resources.Load<GameObject>("font/Damege");
    }

    // Update is called once per frame
    void Update()
    {
        if (isclone)
        {
            if (input_darection)
            {
            }
            else
            {
                transform.localScale = new Vector3(-6, 6, 1);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "anermy")
        {
            if (!(collision.gameObject.GetComponent<Zombie>().Helth <= 0))
            {

                collision.gameObject.GetComponent<Zombie>().Helth = collision.gameObject.GetComponent<Zombie>().Helth - magicPower;
                collision.gameObject.GetComponent<Zombie>().reciveDamege(magicPower);

                GameObject clone = Instantiate(Damege, new Vector3(collision.transform.position.x, collision.transform.position.y + 1.1f, 49), Quaternion.identity);
                clone.GetComponent<damege>().Init(magicPower);
                Destroy(clone, 0.5f);


              
            }
        }
    }
}
