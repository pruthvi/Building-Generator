using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProGen : MonoBehaviour
{
    public static ProGen Instance;

    public GameObject wall;
    public GameObject fViewWall;


    public GameObject win, roofGb;


    [Range(1, 5)]
    public int length = 1;
    [Range(1, 5)]

    public int breadth = 1;
    private float height = 1f;
    public float floorLength = 0f;
    public float floorBreadth = 0f;

    [Range(2, 15)]
    public int floor = 1;

    [Range(0.4f, 1f)]
    public float windowHeight = 1f;


    public bool hasWindows = true;
    private List<GameObject> building = new List<GameObject>();

    private void Awake()
    {
        Instance = this;

        Generate();
    }


    public void Generate()
    {
        foreach (GameObject b in building)
        {
            DestroyImmediate(b.gameObject);
        }
        building.Clear();

        for (int i = 0; i < floor; i++)
        {
            CreateWalls(i);
            if (hasWindows) { CreateWindows(i); }
        }

        CreateRoof(floor);

    }

    private void CreateRoof(int floor)
    {
        GameObject r = new GameObject();
        r.transform.position = new Vector3(0, floor + 1, 0);
        r.name = "Roof";
        building.Add(r);

        var roof = Instantiate(roofGb, new Vector3(0, floor, 0), Quaternion.Euler(0, 0, 0), r.transform);
        roof.transform.localScale = new Vector3(floorBreadth + breadth, 1, floorLength + length);
        roof.name = "Roof";

    }

    void CreateWalls(int floor)
    {
        GameObject walls = new GameObject();
        walls.transform.position = new Vector3(0, floor, 0);
        walls.name = "Walls";

        building.Add(walls);

        var frontWall = Instantiate(fViewWall, new Vector3(0, floor + 0.5f, -0.5f * length), Quaternion.Euler(0, 0, 0), walls.transform);
        frontWall.transform.localScale = new Vector3((1 * breadth) + 0.1f, height, 1);
        frontWall.name = "Front Wall";

        var backWall = Instantiate(wall, new Vector3(0, floor + 0.5f, 0.5f * length), Quaternion.Euler(0, 0, 0), walls.transform);
        backWall.transform.localScale = new Vector3((1 * breadth) + 0.1f, height, 1);
        backWall.name = "Back Wall";

        var rightWall = Instantiate(wall, new Vector3(0.5f * breadth, floor + 0.5f, 0), Quaternion.Euler(0, 90, 0), walls.transform);
        rightWall.transform.localScale = new Vector3(1 * length, height, 1);
        rightWall.name = "Right Wall";

        var leftWall = Instantiate(wall, new Vector3(-0.5f * breadth, floor + 0.5f, 0), Quaternion.Euler(0, -90, 0), walls.transform);
        leftWall.transform.localScale = new Vector3(1 * length, height, 1);
        leftWall.name = "Left Wall";

        floorLength = (floorLength < 0) ? 0 : floorLength;
        floorBreadth = (floorBreadth < 0) ? 0 : floorBreadth;

        var ground = Instantiate(wall, new Vector3(0, floor, 0), Quaternion.Euler(90, 0, 0), walls.transform);
        ground.transform.localScale = new Vector3(floorBreadth + breadth, floorLength + length, 1);
        ground.name = "Ground";

    }

    void CreateWindows(int floor)
    {
        GameObject windows = new GameObject();
        windows.transform.position = new Vector3(0, floor, 0);
        windows.name = "Windows";
        building.Add(windows);

        int winToBeCreated = Mathf.FloorToInt(breadth);

        int reminder = winToBeCreated % 2;

        // float winOnEachSide = winToBeCreated / 2;

        float xPos = 0;

        if (reminder % 2 == 0) // doesnt have decimal point
        {
            xPos = 0.5f;
        }
        else if (reminder % 2 == 1)
        {
            xPos = 0f;
        }


        for (int i = 0; i < winToBeCreated; i++)
        {
            var window = Instantiate(win, new Vector3(xPos, floor + 0.5f, -0.5f * length), Quaternion.Euler(0, 0, 0), windows.transform);
            window.transform.localScale = new Vector3(1, windowHeight, 1);
            window.name = "Window";

            if (xPos == 0)
            {
                xPos = 1f;
            }
            else if (Mathf.Sign(xPos) == 1) // if positive
            {
                xPos = -xPos;
            }
            else if (Mathf.Sign(xPos) == -1)
            {
                xPos = Mathf.Abs(xPos);
                xPos++;
            }

        }


    }

}
