using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class BubbleSpawner : MonoBehaviour
{
    public bool isplaying = true;
    public GameObject bubblePrefab; 
    public RectTransform canvasRectTransform; 
    public float spawnInterval = 1f; 
    public Vector2 spawnAreaPadding = new Vector2(50, 50); 
    public float minY = 50f; 
    public float maxY = 500f;
    public float[] spawnXPositions; 
    public List<GameObject> bubbles = new List<GameObject>();
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI HighestScoreText;

    public GameObject Failed_Image;
    public GameObject HighestScore_Image;
    public TextMeshProUGUI End_Screen_Score_Text;
    private void Start()
    {
        
        HighestScoreText.text = PlayerPrefs.GetInt("HighestScore").ToString();
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

        if (!isplaying)
        {return;
        }

        GameObject bubble = Instantiate(bubblePrefab, canvasRectTransform);

        bubbles.Add(bubble);
        
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

    public void stop()
    {
        
        isplaying=false;

        StartCoroutine("End_Sequence");

        foreach (GameObject x in bubbles)
        {
            if (x != null)
            {
                Destroy(x);
            }
        }

       
    }

   
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
    }

    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void set_score(int x)
    {   
        scoreText.text = x.ToString("00");
        End_Screen_Score_Text.text = x.ToString("00");
        HighestScoreText.text = PlayerPrefs.GetInt("HighestScore").ToString();
    }

    private void OnEnable()
    {
        CollisionDetector.score += set_score;
        CollisionDetector.SCORE = 0;


    }

    private void OnDisable()
    {
        CollisionDetector.score -= set_score;
    }

    IEnumerator End_Sequence()
    {
        yield return new WaitForSeconds(2f);
        Failed_Image.SetActive(true);
        yield return new WaitForSeconds(.5f);
        Failed_Image.SetActive(false);
        HighestScore_Image.SetActive(true);
    }
}