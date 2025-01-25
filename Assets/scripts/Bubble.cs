using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    public float speed = 10f;
    public List<GameObject> items = new List<GameObject>();
    public GameObject item;

    private void OnEnable()
    {
        // Activate a random item when the bubble is enabled
        if (items.Count > 0)
        {
            item = items[Random.Range(0, items.Count)];
            item.SetActive(true);
            item.transform.SetParent(transform, false);
            item.transform.localPosition = Vector3.zero; // Center the item in the bubble
        }
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    private void OnMouseDown()
    {
        DeactivateBubble();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("X"))
        {
            DeactivateBubble();
        }
    }

    private void DeactivateBubble()
    {
        if (item != null)
        {
            item.transform.SetParent(null);
            GetComponent<Animator>().enabled = true;
            item.AddComponent<Rigidbody2D>();
            Destroy(item.gameObject, 5f);
            Destroy(gameObject, 0.5f); 
        }
    }
}