using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private float moveX;
    private float JumpForce = 8f;
    private Rigidbody2D body;
    private Animator anim;
    private string WalkAnimation = "IsWalk";
    private string JumpAnimation = "IsJump";
    private string GroundTag = "Ground";
    private string EnemyTag = "Enemy";
    private bool IsGrounded;
    public float velocity = 5f;
    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        PlayerMovement();
        PlayerJump();
        PlayerAnimation();
    }

    private void PlayerMovement(){
        moveX = Input.GetAxisRaw("Horizontal");
        if(moveX < 0){
        transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if(moveX > 0){
        transform.localScale = new Vector3(1f, 1f, 1f);
        }

        transform.position += new Vector3(moveX, 0f, 0f) * velocity * Time.deltaTime;
    }

    private void PlayerJump(){
        if(Input.GetKeyDown(KeyCode.UpArrow) && IsGrounded){
            anim.SetBool(JumpAnimation, true);
            body.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
            IsGrounded = false;
        }
    }
    private void PlayerAnimation(){
        if(moveX != 0){
            anim.SetBool(WalkAnimation, true);
        }
        else{
            anim.SetBool(WalkAnimation, false);
        }
    }

   private void OnCollisionEnter2D(Collision2D other) {
    if(other.gameObject.CompareTag(GroundTag)){
        IsGrounded = true;
        anim.SetBool(JumpAnimation, false);
    }

    if(other.gameObject.CompareTag(EnemyTag)){
        Destroy(gameObject);
        SceneManager.LoadScene("EndGame");
        // GameManager.instance.IsPlayerDead = true;
    }
   }
}
