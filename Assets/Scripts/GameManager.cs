using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Tilemap DarkMap;
    public Tilemap Dark2Map;
    public Tilemap FloorMap;

    public Tile DarkTile;
    public Tile Dark2Tile;
    public GameObject LightTile;

    public List<GameObject> LightTiles;

    private float timeLeft = 3f;

    void Start()
    {
        DarkMap.origin = Dark2Map.origin = FloorMap.origin * 2;
        DarkMap.size = Dark2Map.size = FloorMap.size * 2;

        foreach(Vector3Int p in DarkMap.cellBounds.allPositionsWithin)
        {
            DarkMap.SetTile(p, DarkTile);
        }

        foreach (Vector3Int p in Dark2Map.cellBounds.allPositionsWithin)
        {
            Dark2Map.SetTile(p, Dark2Tile);
        }

        //Get all floor tiles
        BoundsInt bounds = FloorMap.cellBounds;
        TileBase[] allTiles = FloorMap.GetTilesBlock(bounds);
        for (int x = 0; x < bounds.size.x; x++)
        {
            for (int y = 0; y < bounds.size.y; y++)
            {
                TileBase tile = allTiles[x + y * bounds.size.x];

                if (tile != null)
                {
                    //Debug.Log("x:" + x + " y:" + y + " tile:" + tile.name);
                    LightTiles.Add(Instantiate(LightTile, (new Vector3(x + 0.5f, y + 0.5f, 0) * 2) + (FloorMap.origin * 2), Quaternion.identity, this.transform));
                }

                else
                {
                    //Debug.Log("x:" + x + " y:" + y + " tile: (null)");
                }
            }
        }
    }

    void Update()
    {
        var objects = GameObject.FindGameObjectsWithTag("Enemy");
        var objectCount = objects.Length;

        if (objectCount == 0)
        {
            timeLeft -= Time.deltaTime;

            if (timeLeft < 0)
            {
                SceneManager.LoadScene("SampleScene");
            }
        }

        else
        {
            timeLeft = 3f;
        }
    }
}
