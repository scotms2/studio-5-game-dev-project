using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    *Link to guide that helped me through this: https://gamedevacademy.org/complete-guide-to-procedural-level-generation-in-unity-part-1/

    *NOTE TO SELF: [,] makes a 2d array, [,,] makes a 3d array
*/

[System.Serializable]
public class Wave {
    public float seed;
    public float frequency;
    public float amplitude;
}

public class NoiseMapGeneration : MonoBehaviour
{
    public float[,] GenerateNoiseMap(int mapDepth, int mapWidth, float scale, float offsetX, float offsetZ, Wave[] waves)
    {
        float[,] noiseMap = new float[mapDepth, mapWidth]; //Create empty noise map with depth and width

        for (int z = 0; z < mapDepth; z++)
        {
            for (int x = 0; x < mapWidth; x++)
            {
                //Calculate sample indices based on the coordinates and the scale
                float sampleX = (x + offsetX) / scale;
                float smapleZ = (z + offsetZ) / scale;

                float noise = 0f;
                float normalization = 0f;
                foreach(Wave wave in waves)
                {
                    // generate noise value using PerlinNoise for a given Wave
                    noise += wave.amplitude * Mathf.PerlinNoise(sampleX * wave.frequency + wave.seed, smapleZ * wave.frequency + wave.seed);
                    normalization += wave.amplitude;
                }

                // normalize the noise value so that it is within 0 and 1
                noise /= normalization;

                noiseMap [z, x] = noise;
            }
        }

        return noiseMap;
    }
}
