using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovevment : MonoBehaviour
{
    private Rigidbody2D body;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement();
    }

    private void movement(){
        body.velocity = new Vector2(speed, body.velocity.y);
    }
}
