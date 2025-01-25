using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Bubble : MonoBehaviour
{
    public float speed = 10f; 
    public float floatAmplitude = 0.5f; 
    public float floatFrequency = 1f;
    public List<GameObject> items = new List<GameObject>();
    public GameObject item;
    public List<SpriteRenderer> spriteRenderer;

    private Vector3 initialPosition; 
    private float timeElapsed;
    private int itemIndex;
    private SpriteRenderer itemSpriteRenderer;
    private void OnEnable()
    {
        if (items.Count > 0)
        {
            itemIndex = Random.Range(0, items.Count);
            item = items[itemIndex];
            item.SetActive(true);
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
        AudioClips.instance.PlayBubbleEffect();
        DeactivateBubble();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("X"))
        {
            Destroy(this.gameObject);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Yellow"))
        {
            Debug.Log("Correct Color");
        }
    }

    private void DeactivateBubble()
    {
        if (item != null)
        {
            //item.transform.SetParent(null);
            Destroy(item);
            itemSpriteRenderer = Instantiate(spriteRenderer[itemIndex], transform.position, Quaternion.identity);
            GetComponent<CircleCollider2D>().enabled = false;
            GetComponent<Animator>().enabled = true;
            //rb.gravityScale = 1f;
            //rb.constraints = RigidbodyConstraints2D.FreezePositionX; 

            Destroy(itemSpriteRenderer.gameObject, 5f);
        }

        Destroy(gameObject, 0.3f);
    }
}
