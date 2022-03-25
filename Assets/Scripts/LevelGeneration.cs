using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    *Link to guide that helped me through this: https://gamedevacademy.org/complete-guide-to-procedural-level-generation-in-unity-part-1/
*/

public class LevelGeneration : MonoBehaviour
{
    [SerializeField] private int mapWidthInTiles, mapDepthInTiles;

    [SerializeField] private GameObject tilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        GenerateMap();
    }

    void GenerateMap()
    {
        Vector3 tileSize = tilePrefab.GetComponent<MeshRenderer>().bounds.size;
        int tileWidth = (int)tileSize.x;
        int tileDepth = (int)tileSize.z;

        for (int x = 0; x < mapWidthInTiles; x++)
        {
            for (int z = 0; z < mapDepthInTiles; z++)
            {
                //Calculate the position of the tile based on the x and z indices
                Vector3 tilePos = new Vector3(this.gameObject.transform.position.x + x * tileWidth, this.gameObject.transform.position.y, 
                                                this.gameObject.transform.position.z + z * tileDepth);
                
                //Instantiate the Tile
                GameObject tile = Instantiate(tilePrefab, tilePos, Quaternion.identity) as GameObject;
            }
        }
    }
}
