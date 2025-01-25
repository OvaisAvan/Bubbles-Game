using Unity.VisualScripting;
using UnityEngine;
public class BubbleSpawner : MonoBehaviour
{
    public GameObject bubblePrefab; 
    public RectTransform canvasRectTransform; 
    public float spawnInterval = 1f; 
    public Vector2 spawnAreaPadding = new Vector2(50, 50); 
    public float minY = 50f; 
    public float maxY = 500f;
    public float[] spawnXPositions; 
    
    public static System.Action<Transform> OnSpawnPos; 

    private void Start()
    {
        if (bubblePrefab == null || canvasRectTransform == null || spawnXPositions.Length == 0)
        {
            Debug.LogError("BubblePrefab, CanvasRectTransform, or SpawnXPositions is not assigned.");
            return;
        }
        
        InvokeRepeating(nameof(SpawnBubble), 0f, spawnInterval);
    }

    private void SpawnBubble()
    {
        
        float randomX = spawnXPositions[Random.Range(0, spawnXPositions.Length)];
        
        float randomY = Random.Range(minY, maxY);

        GameObject bubble = Instantiate(bubblePrefab, canvasRectTransform);

        bubble.transform.parent = this.gameObject.transform;

        RectTransform bubbleRect = bubble.GetComponent<RectTransform>();
        if (bubbleRect != null)
        {
            bubbleRect.anchoredPosition = new Vector2(randomX, randomY);
        }
        else
        {
            Debug.LogError("BubblePrefab must have a RectTransform component.");
        }
        
        Bubble bubbleScript = bubble.GetComponent<Bubble>();
        if (bubbleScript != null)
        {
            bubbleScript.SetInitialPosition(bubble.transform.position);
        }
    }
}