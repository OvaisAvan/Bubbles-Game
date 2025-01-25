using UnityEngine;

public class BubbleSpawner : MonoBehaviour
{
    public GameObject bubblePrefab; // The bubble prefab to spawn
    public RectTransform canvasRectTransform; // The RectTransform of the Canvas
    public float spawnInterval = 1f; // Time interval between spawns
    public Vector2 spawnAreaPadding = new Vector2(50, 50); // Padding from canvas edges
    public float minY = 50f; // Minimum Y position
    public float maxY = 500f; // Maximum Y position
    public float[] spawnXPositions; // Predefined X positions

    private void Start()
    {
        if (bubblePrefab == null || canvasRectTransform == null || spawnXPositions.Length == 0)
        {
            Debug.LogError("BubblePrefab, CanvasRectTransform, or SpawnXPositions is not assigned.");
            return;
        }

        // Start spawning bubbles at regular intervals
        InvokeRepeating(nameof(SpawnBubble), 0f, spawnInterval);
    }

    private void SpawnBubble()
    {
        // Select a random predefined X position
        float randomX = spawnXPositions[Random.Range(0, spawnXPositions.Length)];

        // Generate a random Y position within the specified range
        float randomY = Random.Range(minY, maxY);

        // Instantiate the bubble prefab
        GameObject bubble = Instantiate(bubblePrefab, canvasRectTransform);

        // Set the bubble's position
        RectTransform bubbleRect = bubble.GetComponent<RectTransform>();
        if (bubbleRect != null)
        {
            bubbleRect.anchoredPosition = new Vector2(randomX, randomY);
        }
        else
        {
            Debug.LogError("BubblePrefab must have a RectTransform component.");
        }
    }
}