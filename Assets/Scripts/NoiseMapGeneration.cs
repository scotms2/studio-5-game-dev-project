using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    *Link to guide that helped me through this: https://gamedevacademy.org/complete-guide-to-procedural-level-generation-in-unity-part-1/

    *NOTE TO SELF: [,] makes a 2d array, [,,] makes a 3d array
*/

public class NoiseMapGeneration : MonoBehaviour
{
    public float[,] GenerateNoiseMap(int mapDepth, int mapWidth, float scale, float offsetX, float offsetZ)
    {
        float[,] noiseMap = new float[mapDepth, mapWidth]; //Create empty noise map with depth and width

        for (int z = 0; z < mapDepth; z++)
        {
            for (int x = 0; x < mapWidth; x++)
            {
                //Calculate sample indices based on the coordinates and the scale
                float sampleX = (x + offsetX) / scale;
                float smapleZ = (z + offsetZ) / scale;

                //Generate noise value
                float noise = Mathf.PerlinNoise(sampleX, smapleZ);

                noiseMap [z, x] = noise;
            }
        }

        return noiseMap;
    }
}
