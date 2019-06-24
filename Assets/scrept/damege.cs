using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class damege : MonoBehaviour
{
    TextMeshPro damege_text;

    // Start is called before the first frame update
   public void Init(int poewr)
    {
        damege_text = GetComponent<TextMeshPro>();

        damege_text.SetText("" + poewr);
    }
    public void Init(string poewr)
    {
        damege_text = GetComponent<TextMeshPro>();

        damege_text.SetText("" + poewr);
    }

    // Update is called once per frame
    void Update()
    { 
        lplplplp
        transform.position += Vector3.up * 1 * Time.deltaTime;

    }
}
