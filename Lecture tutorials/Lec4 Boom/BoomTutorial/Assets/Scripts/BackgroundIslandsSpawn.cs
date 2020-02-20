using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundIslandsSpawn : MonoBehaviour
{
    [SerializeField]
    private int width = 1000;
    [SerializeField]
    private int height = 1000;
    [SerializeField]
    private int depth = 1000;

    [SerializeField]
    private GameObject islandPrefab;

    [SerializeField]
    private int islandsAmount = 100;

    // Use this for initialization
    void Start()
    {
        //Loop through the island amounts
        for (int i = 0; i < islandsAmount; i++)
        {
            //Create a instance of a prefab
            GameObject instance = Instantiate(islandPrefab);
            instance.transform.parent = transform; //Parent this into a heirarcy
            instance.transform.position = RandomPosition();

            //Returns a vector with values (1,1,1) * by range between 5 and 10
            instance.transform.localScale = Vector3.one * Random.Range(5, 10);

            //Random rotation with Y from 0 - 360
            instance.transform.rotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
        }
    }

    private Vector3 RandomPosition()
    {
        return new Vector3(Random.Range(-width, width),
            Random.Range(-height, height),
            Random.Range(-depth, depth)
            );
    }
}
