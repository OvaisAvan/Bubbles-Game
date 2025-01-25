using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    public float speed = 10f; 
    public float floatAmplitude = 0.5f; 
    public float floatFrequency = 1f;
    public List<GameObject> items = new List<GameObject>();
    public GameObject item;

    private Vector3 initialPosition; 
    private float timeElapsed; 
    private void OnEnable()
    {
        if (items.Count > 0)
        {
            item = items[Random.Range(0, items.Count)];
            item.SetActive(true);

            item.transform.SetParent(transform, false);
            item.transform.localPosition = Vector3.zero; 
        }
    }
    public void SetInitialPosition(Vector3 position)
    {
        initialPosition = position;
    }
    private void FixedUpdate()
    {
        timeElapsed += Time.deltaTime;
        float offsetY = Mathf.Sin(timeElapsed * floatFrequency) * floatAmplitude;

        transform.position = new Vector3(
            transform.position.x + speed * Time.deltaTime, 
            initialPosition.y + offsetY, 
            transform.position.z
        );
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

            item.transform.position = transform.position;
            GetComponent<Animator>().enabled = true;

            Rigidbody2D rb = item.AddComponent<Rigidbody2D>();
            rb.gravityScale = 1f;
            rb.constraints = RigidbodyConstraints2D.FreezePositionX; 

            Destroy(item.gameObject, 5f);
        }

        Destroy(gameObject, 0.2f);
    }
}
