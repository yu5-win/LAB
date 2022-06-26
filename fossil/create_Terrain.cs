using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class create_Terrain : MonoBehaviour
{
    public Terrain terrain;
    //public GameObject Terrain_Spawn;
    private TerrainData terrainData;

    private int heightmapWidth;
    private int heightmapHeight;
    private float[,] heights;
    float[,] flat = new float[1, 1];


    void Start()
    {
        terrainData = terrain.terrainData;
        heightmapWidth = terrainData.heightmapResolution;
        heightmapHeight = terrainData.heightmapResolution;
        heights = terrainData.GetHeights(0, 0, heightmapWidth, heightmapHeight);

        for (int i = 0; i < heightmapWidth; i++)
        {
            for (int j = 0; j < heightmapHeight; j++)
            {
                heights[i, j] = 0.03f;
            }
        }
        terrainData.SetHeights(0, 0, heights);
    }
}

