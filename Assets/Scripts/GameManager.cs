using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public Slider floor;
    public Slider winHeight;
    public Slider bldgWidth;
    public Slider bldgBreadth;
    public Toggle noWindows;
    public Dropdown winType;
    public GameObject glass, darkGlass, plain, frontWall, frontWallW;

    public Dropdown viewDD;
    public GameObject camTop, camMiddle, camBottom;


    public void FloorChange()
    {
        ProGen.Instance.floor = (int)floor.value;
        ProGen.Instance.Generate();
    }

    public void WindowHeight()
    {
        ProGen.Instance.windowHeight = winHeight.value;
        ProGen.Instance.Generate();
    }

    public void BuildingWidth()
    {
        ProGen.Instance.length = (int)bldgWidth.value;
        ProGen.Instance.Generate();
    }
    public void BuildingBreadth()
    {
        ProGen.Instance.breadth = (int)bldgBreadth.value;
        ProGen.Instance.Generate();
    }

    public void NoWindows()
    {
        ProGen.Instance.hasWindows = noWindows.isOn;
        ProGen.Instance.Generate();
    }

    public void WindowType()
    {
        switch (winType.value)
        {
            case 0:
                ProGen.Instance.win = glass;
                ProGen.Instance.fViewWall = frontWallW;
                break;
            case 1:
                ProGen.Instance.win = darkGlass;
                ProGen.Instance.fViewWall = frontWallW;
                break;
            case 2:
                ProGen.Instance.win = plain;
                ProGen.Instance.fViewWall = frontWall;
                break;
            default:
                Debug.Log("Window Type Error");
                break;
        }
        ProGen.Instance.Generate();
    }
    public void ViewCam()
    {
        switch (viewDD.value)
        {
            case 0:
                camBottom.SetActive(true);
                camMiddle.SetActive(false);
                camTop.SetActive(false);
                break;
            case 1:
                camBottom.SetActive(false);
                camMiddle.SetActive(true);
                camTop.SetActive(false);
                break;
            case 2:
                camBottom.SetActive(false);
                camMiddle.SetActive(false);
                camTop.SetActive(true);
                break;
            default:
                Debug.Log("Camera Change Error");
                break;
        }
    }




}
