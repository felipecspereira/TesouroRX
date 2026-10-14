using UnityEngine;
using UnityEditor;

public class ResetTreeData
{
    [MenuItem("Tools/Resetar Arvores do Terreno")]
    public static void ResetTrees()
    {
        Terrain terrain = Terrain.activeTerrain;
        if (terrain != null && terrain.terrainData != null)
        {
            Undo.RecordObject(terrain.terrainData, "Reset Tree Prototypes");
            terrain.terrainData.treePrototypes = new TreePrototype[0];
            terrain.Flush();
            EditorUtility.SetDirty(terrain.terrainData);
            AssetDatabase.SaveAssets();
            Debug.Log("Protótipos de árvores resetados com sucesso no TerrainData!");
        }
        else
        {
            Debug.LogWarning("Nenhum Terrain ativo foi encontrado na cena.");
        }
    }
}