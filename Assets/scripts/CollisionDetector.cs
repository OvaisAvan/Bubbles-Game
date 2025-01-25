using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Yellow") && this.gameObject.CompareTag("Yellow"))
        {
            Debug.Log("Correct Color");
        }
        if (other.gameObject.CompareTag("Purple") && this.gameObject.CompareTag("Purple"))
        {
            Debug.Log("Correct Color");
        }
        if (other.gameObject.CompareTag("Green") && this.gameObject.CompareTag("Yellow"))
        {
            Debug.Log("Correct Color");
        }
    }
}
