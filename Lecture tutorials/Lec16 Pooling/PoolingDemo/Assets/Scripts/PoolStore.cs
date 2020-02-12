using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolStore : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;

    public void ReturnInstance(GameObject instance)
    {
        if (!usedItems.Contains(instance))
            return;

        usedsize--;

        usedItems.Remove(instance);
        Pool.Push(instance);

        // Hide gameobject in the unity Heirachy window
        instance.hideFlags |= HideFlags.HideInHierarchy;

        instance.SetActive(false);
    }
}
