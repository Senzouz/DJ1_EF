using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 4.0f;
    private Rigidbody2D body;
    
    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void Start(){
        switch(Player.instance.direction){
            case "right":
                body.velocity = new Vector2(speed,0);
                break;
            case "left":
                body.velocity = new Vector2(-speed,0);
                break;
            case "up":
                body.velocity = new Vector2(0,speed);
                break;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(gameObject.tag == "Red" && other.gameObject.tag == "EnemyRed"){
            GameController.instance.score += 10;
            GameController.instance.cantEnemies--;
            Destroy(other.gameObject);
        }
        if(gameObject.tag == "Yellow" && other.gameObject.tag == "EnemyYellow"){
            GameController.instance.score += 15;
            GameController.instance.cantEnemies--;
            Destroy(other.gameObject);
        }
        if(gameObject.tag == "Fly" && other.gameObject.tag == "EnemyFly"){
            GameController.instance.score += 50;
            GameController.instance.cantEnemies--;
            Destroy(other.gameObject);
        }
        if(gameObject.tag == "Brown" && other.gameObject.tag == "EnemyBrown"){
            GameController.instance.score += 5;
            GameController.instance.cantEnemies--;
            Destroy(other.gameObject);
        }
        if(gameObject.tag == "Cream" && other.gameObject.tag == "EnemyCream"){
            GameController.instance.score += 20;
            GameController.instance.cantEnemies--;
            Destroy(other.gameObject);
        }
        GameController.instance.txtScore.text = "Score: " + GameController.instance.score;
        if(other.gameObject.layer == 8)
            Destroy(gameObject);
    }
}
