﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(ProGen))]
public class EditorProGen : Editor
{

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        ProGen proGen = (ProGen)target;

        if (GUILayout.Button("Generate"))
        {
            proGen.Generate();
        }

        if (GUI.changed)
        {
            proGen.Generate();

        }
    }

}
