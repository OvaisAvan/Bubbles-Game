using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    
    public List<GameObject> bubbles_prefabs;
    public List<GameObject> Active_Bubbles;
    public GameObject bubbleContainer;

    
    
    private void Start()
    {
        StartCoroutine("Spawn_bubbles");
    }
    
    void Spawn_bubble()
    {
        int x = Random.Range(0, bubbles_prefabs.Count);
        GameObject bubble = Instantiate(bubbles_prefabs[x], transform.position, Quaternion.identity);
        bubble.transform.parent = bubbleContainer.transform;
        Active_Bubbles.Add(bubble);
    }

    IEnumerator Spawn_bubbles()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
                Spawn_bubble();
        }
    }

    
}
