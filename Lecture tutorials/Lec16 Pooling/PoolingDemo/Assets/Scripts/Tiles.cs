using System.Collections.Generic;
using UnityEngine;

public class Tiles : MonoBehaviour
{
    private Material material;

    public int tilesInX = 3;
    public int tilesInY = 3;

    private Renderer render;

    // Saving our materials (or grouping them) into tiles. We should have only 9 materials
    private static Dictionary<int, Material> tileMaterials = new Dictionary<int, Material>();

    public void SetTile(int index)
    {
        if (render == null)
        {
            render = GetComponent<Renderer>();
        }

        if (tileMaterials.ContainsKey(index))
        {
            render.material = tileMaterials[index];
        }
        else
        {
            Material material = render.material;

            int positionX = index % tilesInY;
            int positionY = index / tilesInY; // floored to int

            float scaleX = 1.0f / tilesInX;
            float scaleY = 1.0f / tilesInY;

            material.mainTextureOffset = new Vector2(scaleX * positionX, scaleY * positionY);
            material.mainTextureScale = new Vector2(scaleX, scaleY);

            tileMaterials.Add(index, material);
        }
    }
}