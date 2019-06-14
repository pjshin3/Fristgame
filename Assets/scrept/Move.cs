using UnityEngine.EventSystems;
using UnityEngine;

public class Move : MonoBehaviour
{
    GameObject playe;
    GameObject MainCamera;
    mainguy Main;
    Maincamera_action camera;




    public void Init()
    {
        MainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        playe = GameObject.FindGameObjectWithTag("MainMen");
        Main = playe.GetComponent<mainguy>();
        camera = MainCamera.GetComponent<Maincamera_action>();

    }

    public void LeftUp()
    {
        Main.inputleft = false;
    }
    public void LeftDown()
    {
        Main.inputleft = true;
    }
    public void RightUp()
    {
        Main.inputright = false;
    }
    public void RightDown()
    {
        Main.inputright = true;
    }
    public void Jump()
    {
        Main.inpuJump = true;
    }
    public void Atteck()
    {
        Main.inpuAtteck = true;
        //camera.Shake = true;
    }
    public void Magic()
    {
        Main.inputMagic = true;
        //camera.Shake = true;
    }
}
