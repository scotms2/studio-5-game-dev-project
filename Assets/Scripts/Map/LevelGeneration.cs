using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/*
    *Link to guide that helped me through this: https://gamedevacademy.org/complete-guide-to-procedural-level-generation-in-unity-part-1/
*/
public class LevelGeneration : MonoBehaviour
{
    [SerializeField] private int levelWidthInTiles, levelDepthInTiles;

    [SerializeField] private GameObject tilePrefab;

    [SerializeField] private Transform parent;

    public NavMeshSurface surface;

    // Start is called before the first frame update
    void Start()
    {
        GenerateMap();

        //Update NavMesh
        surface.BuildNavMesh();

    }

    void GenerateMap()
    {
        Vector3 tileSize = tilePrefab.GetComponent<MeshRenderer>().bounds.size;
        int tileWidth = (int)tileSize.x;
        int tileDepth = (int)tileSize.z;

        Vector3[] tileMeshVertices = tilePrefab.GetComponent<MeshFilter>().sharedMesh.vertices;
        int tileDepthInVertices = (int)Mathf.Sqrt (tileMeshVertices.Length);
        int tileWidthInVertices = tileDepthInVertices;

        //LevelData levelData = new LevelData (tileDepthInVertices, tileWidthInVertices, this.levelDepthInTiles, this.levelWidthInTiles);

        float distanceBetweenVertices = (float)tileDepth / (float)tileDepthInVertices;

        for (int x = 0; x < levelWidthInTiles; x++)
        {
            for (int z = 0; z < levelDepthInTiles; z++)
            {
                //Calculate the position of the tile based on the x and z indices
                Vector3 tilePos = new Vector3(this.gameObject.transform.position.x + x * tileWidth, this.gameObject.transform.position.y, 
                                                this.gameObject.transform.position.z + z * tileDepth);
                
                //Instantiate the Tile
                GameObject tile = Instantiate(tilePrefab, tilePos, Quaternion.identity);

                tile.transform.SetParent(parent);

            }
        }
    }
}
