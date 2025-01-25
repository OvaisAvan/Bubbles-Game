using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    public BubbleSpawner bubbleSpawner;
    [SerializeField] private ParticleSystem goalParticles;
    [SerializeField] private ParticleSystem failParticles;
    private string tagName;
    private void OnEnable()
    {
        bubbleSpawner = FindObjectOfType<BubbleSpawner>();
        CollisionDetector.OnCollision += DetectCollision;
        tagName = gameObject.tag;
    }
    private void DetectCollision(String colorName)
    {
        
        if (tagName == colorName)
        {
            goalParticles.Play();
            
        }
       if (colorName == "Invalid")
        {
           
            if (failParticles.isPlaying)
            {return;
            }

            bubbleSpawner.stop();
            failParticles.gameObject.SetActive(true);
            failParticles.Play();
        }
    }
    private void OnDisable()
    {
        CollisionDetector.OnCollision -= DetectCollision;
    }
}
