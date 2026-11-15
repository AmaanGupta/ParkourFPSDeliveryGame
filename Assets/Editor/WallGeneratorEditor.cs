using UnityEngine;
using UnityEditor;
using UnityEditor.TerrainTools;
[CustomEditor(typeof(WallGeneration))]

public class WallGeneratorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        WallGeneration wallGeneration = (WallGeneration) target;
        if(GUILayout.Button("Generate Wall"))
        {
            wallGeneration.GenerateWall();
        }
        if(GUILayout.Button("Clear Wall"))
        {
            wallGeneration.ClearWall();
        }
    }
    
}
