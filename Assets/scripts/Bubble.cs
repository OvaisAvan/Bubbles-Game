using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Bubble : MonoBehaviour
{

    public float speed = 10f;
    public List<GameObject> items = new List<GameObject>();
    public GameObject item;
    private void Awake()
    {
        item = Instantiate(items[Random.Range(0, items.Count)], transform.position, Quaternion.identity);
        item.transform.parent = transform;
        
    }

    void set_item(int x)
    {
        
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);

    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
        item.transform.parent = null;
        item.AddComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log(other.gameObject.name);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.CompareTag("X"))
        {
            Destroy(gameObject);
        }
    }
}
