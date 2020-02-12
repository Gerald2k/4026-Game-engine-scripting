using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Level : MonoBehaviour
{
    [SerializeField]
    private GameObject tilePrefab;

    private List<GameObject> tiles = new List<GameObject>();

    [SerializeField]
    private PoolStore pool;

    private int level = 0;

    // clears current level
    public void CleanLevel()
    {
        foreach(GameObject tile in tiles)
        {
            Destroy(tile);
        }
        tiles.Clear();
    }

    // Increases level counter and creates a random set of tiles
    public void GenerateLevel()
    {
        StartCoroutine(CheckFrameTime());

        CleanLevel();
        level++;
        Random.InitState(level);
        for(int y = 0; y < 100; y++)
        {
            for (int x = 0; x < 100; x++)
            {
                if(Random.value > 0.5)
                {
                    GameObject instance = Instantiate(tilePrefab);
                    instance.transform.position = new Vector3(x, y, 0);
                    instance.GetComponent<Tiles>().SetTile(Random.Range(0, 9));
                    tiles.Add(instance);
                }
            }
        }
        Debug.Log("Generate level...");
    }

    // a co-routine that waits for a frame and checks the time between the previous frame
    private IEnumerator CheckFrameTime()
    {
        float lasttime = Time.time;
        yield return true; // Wait for nesxt update
        int differenceInMilliseconds = (int)((Time.time - lasttime) * 1000f);
        Debug.Log("Took: " + differenceInMilliseconds + "ms");
    }
}
