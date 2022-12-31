using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollector : MonoBehaviour
{
    private string EnemyTag = "Enemy";
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag(EnemyTag)){
            Destroy(other.gameObject);
        }
    }
}
