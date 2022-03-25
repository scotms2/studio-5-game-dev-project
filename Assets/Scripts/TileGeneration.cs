using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    *Link to guide that helped me through this: https://gamedevacademy.org/complete-guide-to-procedural-level-generation-in-unity-part-1/

    *NOTE TO SELF: [,] makes a 2d array, [,,] makes a 3d array
*/

[System.Serializable]
public class TerrainType {
    public string name;
    public float height;
    public Color color;
}

public class TileGeneration : MonoBehaviour
{
    [SerializeField] private TerrainType[] terrainTypes;

    [SerializeField] private NoiseMapGeneration noiseMapGeneration;

    [SerializeField] private MeshRenderer tileRenderer;

    [SerializeField] private MeshFilter meshFilter;

    [SerializeField] private MeshCollider meshCollider;

    [SerializeField] private float heightMultiplier;

    [SerializeField] private AnimationCurve heightCurve;

    [SerializeField] private float mapScale;


    // Start is called before the first frame update
    void Start()
    {
        GenerateTile();
    }

    void GenerateTile()
    {
        //Calculate width and depth of tile based on vertices of the mesh
        Vector3[] meshVertices = this.meshFilter.mesh.vertices;
        int tileDepth = (int)Mathf.Sqrt(meshVertices.Length);
        int tileWidth = tileDepth;

        //Calculate the offsets based on tile position
        float offsetX = -this.gameObject.transform.position.x;
        float offsetZ = -this.gameObject.transform.position.z;

        //Calculate offset based on tile position
        float[,] heightMap = this.noiseMapGeneration.GenerateNoiseMap(tileDepth, tileWidth, this.mapScale, offsetX, offsetZ);

        //Generate heightMap
        Texture2D tileTexture = BuildTexture(heightMap);
        this.tileRenderer.material.mainTexture = tileTexture;

        // Update the tile mesh vertices
        UpdateMeshVertices(heightMap);
    }

    private void UpdateMeshVertices(float[,] heightMap)
    {
        int tileDepth = heightMap.GetLength(0);
        int tileWidth = heightMap.GetLength(1);

        Vector3[] meshVertices = this.meshFilter.mesh.vertices;

        int vertexIndex = 0;
        for (int z = 0; z < tileDepth; z++)
        {
            for (int x = 0; x < tileWidth; x++)
            {
                float height = heightMap[z, x];

                Vector3 vertex = meshVertices[vertexIndex];

                // Depending on the height value, change the vertex Y coordinate
                meshVertices[vertexIndex] = new Vector3(vertex.x, this.heightCurve.Evaluate(height) * this.heightMultiplier, vertex.z);

                vertexIndex++;
            }
        }

        // update the vertices in the mesh and update its properties
        this.meshFilter.mesh.vertices = meshVertices;
        this.meshFilter.mesh.RecalculateBounds();
        this.meshFilter.mesh.RecalculateNormals();
        //Update mesh collider
        this.meshCollider.sharedMesh = this.meshFilter.mesh;

    }

    private Texture2D BuildTexture(float[,] heightMap)
    {
        int tileDepth = heightMap.GetLength(0);
        int tileWidth = heightMap.GetLength(1);

        Color[] colorMap = new Color[tileDepth * tileWidth];

        for (int z = 0; z < tileDepth; z++)
        {
            for (int x = 0; x < tileWidth; x++)
            {
                int colorIndex = z * tileWidth + x;
                float height = heightMap[z, x];
                TerrainType terrainType = ChooseTerrainType(height);
                colorMap[colorIndex] = terrainType.color;
            }
        }

        Texture2D tileTexture = new Texture2D(tileWidth, tileDepth);
        tileTexture.wrapMode = TextureWrapMode.Clamp;
        tileTexture.SetPixels(colorMap);
        tileTexture.Apply();

        return tileTexture;
    }

    TerrainType ChooseTerrainType(float height)
    {
        //Foreach terrain type check if the height is lower than the terrainType height
        foreach (TerrainType terrainType in terrainTypes)
        {
            if(height < terrainType.height)
            {
                return terrainType;
            }
        }

        return terrainTypes[terrainTypes.Length - 1];
    }
}
