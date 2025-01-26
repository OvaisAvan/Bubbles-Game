using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CollisionDetector : MonoBehaviour
{
    public static Action<string> OnCollision;
    public static Action<int> score;
    public static int SCORE = 0;

    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.CompareTag("Untagged"))
        {
            return;
        }

        if (other.gameObject.CompareTag("YellowPot") && this.gameObject.CompareTag("Yellow"))
        {
            SCORE++;
            score?.Invoke(SCORE);
            OnCollision?.Invoke("Yellow");
            gameObject.tag = "Untagged";
            Debug.Log("Correct Color");
            Destroy(this.gameObject, 1f);
        }
        else if (other.gameObject.CompareTag("PurplePot") && this.gameObject.CompareTag("Purple"))
        {
            SCORE++;
            score?.Invoke(SCORE);
            OnCollision?.Invoke("Purple");
            gameObject.tag = "Untagged";
            Debug.Log("Correct Color");
            Destroy(this.gameObject, 1f);
        }
        else if (other.gameObject.CompareTag("GreenPot") && this.gameObject.CompareTag("Green"))
        {
            SCORE++;
            score?.Invoke(SCORE);
            OnCollision?.Invoke("Green");
            gameObject.tag = "Untagged";
            Debug.Log("Correct Color");
            Destroy(this.gameObject, 1f);
        }
        else
        {
            if (gameObject.CompareTag("Untagged"))
            {
                return;
            }
            
            set_highest_Score(SCORE);
            Debug.Log(other.gameObject.name);
            OnCollision?.Invoke("Invalid");
        }
    }


    void set_highest_Score(int S)
    {
        int prev_highest_Score = PlayerPrefs.GetInt("HighestScore");
        if (prev_highest_Score == null)
        {
            PlayerPrefs.SetInt("Highest_Score", S);
        }

        else if (prev_highest_Score < S)
        {
            PlayerPrefs.SetInt("HighestScore", S);
            
        }
    }
}