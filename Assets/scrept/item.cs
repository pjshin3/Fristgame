using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item : MonoBehaviour
{
    int loop = 0;
    bool isup = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(isup)
        {
            loop++;
            if(loop == 15)
            {
                loop = 0;
                isup = false;
            }
            transform.position += Vector3.up * 0.5f * Time.deltaTime;
        }
        else
        {
            loop++;
            if (loop == 15)
            {
                loop = 0;
                isup = true;
            }
            transform.position += Vector3.down * 0.5f * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "MainMen")
        {
            collision.GetComponent<mainguy>().additem(this.GetComponent<SpriteRenderer>().sprite.name);

            Destroy(this.gameObject);
        }
    }
}
