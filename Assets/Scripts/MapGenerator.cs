using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Assets.Scripts
{
    public class MapGenerator : MonoBehaviour
    {
        public enum DrawMode { NoiseMap, ColourMap};
        public DrawMode drawMode;
        public int mapWidth;
        public int mapHeight;
        public float noiseScale;
        public Tilemap tilemap;
        public int octaves;
        [Range(0, 1)]
        public float persistance;
        public float lacunarity;

        public int seed;
        public Vector2 offset;

        public bool autoUpdate;
        public TerrainType[] regions;
        public void GenerateMap()
        {
            tilemap.ClearAllTiles();
            float[,] noiseMap = Noise.GenerateNoiseMap(mapWidth, mapHeight, seed, noiseScale, octaves, persistance, lacunarity, offset); 

            for (int y = 0; y<mapHeight; y++)
            {
                for(int x = 0; x<mapWidth; x++)
                {
                    float currentHeight  = noiseMap[x, y];  
                    for(int i = 0; i < regions.Length; i++)
                    {
                        if(currentHeight <= regions[i].height)
                        {
                            tilemap.SetTile(new Vector3Int(x, y, 0), regions[i].sprite);
                            //colorMap[y * mapWidth + x] = regions[i].color;
                            break;
                        }
                    }
                }
            }
            MapDisplay display = FindObjectOfType<MapDisplay>();
           // if(drawMode == DrawMode.NoiseMap)
           // {
           //     display.DrawTexture(TextureGenerator.TextureFromHeightMap(noiseMap));
           // }
           //else if(drawMode == DrawMode.ColourMap)
           // {
           //     display.DrawTexture(TextureGenerator.TextureFromColourMap(colorMap, mapWidth, mapHeight));
           // }
        }

        void OnValidate()
        {
            if (mapWidth < 1)
            {
                mapWidth = 1;
            }
            if (mapHeight < 1)
            {
                mapHeight = 1;
            }
            if (lacunarity < 1)
            {
                lacunarity = 1;
            }
            if (octaves < 0)
            {
                octaves = 0;
            }
        }

        public void Awake()
        {
            seed = PlayerPrefs.GetInt("WorldSeed");
        }
    }
}
[System.Serializable]
public struct TerrainType
{
    public string name;
    public float height;
    public Tile sprite;
}