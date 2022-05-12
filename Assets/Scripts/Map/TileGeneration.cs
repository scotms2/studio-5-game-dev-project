using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/*
    *Link to guide that helped me through this: https://gamedevacademy.org/complete-guide-to-procedural-level-generation-in-unity-part-1/

    *NOTE TO SELF: [,] makes a 2d array, [,,] makes a 3d array
*/

[System.Serializable]
public class TerrainType {
    public string name;
    public float threshold;
    public Color color;
    public int index;
}

public class TileGeneration : MonoBehaviour
{
    [SerializeField] private TerrainType[] terrainTypes;

    [SerializeField] private TerrainType[] heightTerrainTypes;

    [SerializeField] private NoiseMapGeneration noiseMapGeneration;

    [SerializeField] private MeshRenderer tileRenderer;

    [SerializeField] private MeshFilter meshFilter;

    [SerializeField] private MeshCollider meshCollider;

    [SerializeField] private float heightMultiplier;

    [SerializeField] private AnimationCurve heightCurve;

    [SerializeField] private float levelScale;

    [SerializeField] private Wave[] waves;
    [SerializeField] private GameObject treePrefab;

    [SerializeField] private GameObject rockPrefab;

    //[SerializeField] private GameObject housePrefab;

    // Start is called before the first frame update
    void Start()
    {
        GenerateTile();
    }

    public void GenerateTile()
    {
        //Calculate width and depth of tile based on vertices of the mesh
        Vector3[] meshVertices = this.meshFilter.mesh.vertices;
        int tileDepth = (int)Mathf.Sqrt(meshVertices.Length);
        int tileWidth = tileDepth;

        //Calculate the offsets based on tile position
        float offsetX = -this.gameObject.transform.position.x;
        float offsetZ = -this.gameObject.transform.position.z;

        //Calculate offset based on tile position
        float[,] heightMap = this.noiseMapGeneration.GenerateNoiseMap(tileDepth, tileWidth, this.levelScale, offsetX, offsetZ, waves);

        //Generate heightMap
        TerrainType[,] chosenHeightTerrainTypes = new TerrainType[tileDepth, tileWidth];
        Texture2D heightTexture = BuildTexture(heightMap, this.heightTerrainTypes, chosenHeightTerrainTypes);
        this.tileRenderer.material.mainTexture = heightTexture;

        // Update the tile mesh vertices
        UpdateMeshVertices(heightMap);

        float rand = Random.Range(0.0f, 1.0f);
        if(rand <= 0.3)
        {
            BuildTrees(heightMap);
        }

        if(rand >= 0.8)
        {
            PlaceRocks(heightMap);
        }

        //PlaceSpawn(heightMap);

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

    private Texture2D BuildTexture(float[,] heightMap, TerrainType[] terrainTypes, TerrainType[,] chosenTerrainTypes)
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

                chosenTerrainTypes[z, x] = terrainType;
            }
        }

        Texture2D tileTexture = new Texture2D(tileWidth, tileDepth);
        tileTexture.wrapMode = TextureWrapMode.Clamp;
        tileTexture.SetPixels(colorMap);
        tileTexture.Apply();

        return tileTexture;
    }

    TerrainType ChooseTerrainType(float noise)
    {
        //Foreach terrain type check if the height is lower than the terrainType height
        foreach (TerrainType terrainType in terrainTypes)
        {
            if(noise < terrainType.threshold)
            {
                return terrainType;
            }
        }

        return terrainTypes[terrainTypes.Length - 1];
    }

    public void BuildTrees(float[,] heightMap)
    {
        int tileDepth = heightMap.GetLength(0);
        int tileWidth = heightMap.GetLength(1);

        for (int z = 0; z < tileDepth; z++)
        {
            for (int x = 0; x < tileWidth; x++)
            {
                float height = heightMap[z, x];
                if(height <= 0.7)
                {
                    GameObject tree = Instantiate(treePrefab, this.transform.position, Quaternion.identity);
                    GameObject parent = GameObject.FindWithTag("Level");
                    tree.transform.SetParent(parent.transform);
                }
            }
        }
    }

    public void PlaceRocks(float[,] heightMap)
    {
        int tileDepth = heightMap.GetLength(0);
        int tileWidth = heightMap.GetLength(1);

        for (int z = 0; z < tileDepth; z++)
        {
            for (int x = 0; x < tileWidth; x++)
            {
                float height = heightMap[z, x];
                if(height <= 0.8)
                {
                    GameObject rock = Instantiate(rockPrefab, new Vector3(this.transform.position.x, 0.5f, this.transform.position.z), Quaternion.identity);
                    GameObject parent = GameObject.FindWithTag("Level");
                    rock.transform.SetParent(parent.transform);
                }
            }
        }
    }
}
