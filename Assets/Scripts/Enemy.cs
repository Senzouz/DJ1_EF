using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D body;

    private float[] positionsX = {-8.0f,8.0f};

    private Vector3 initPos;

    void Start() {
        int i = Random.Range(0,2);
        float j = Random.Range(-6.2f,6.2f);
        body = GetComponent<Rigidbody2D>();
        switch(gameObject.tag){
            case "EnemyRed":
                initPos = transform.position;
                initPos.x = positionsX[i];
                initPos.y = -3.6f;
                transform.position = initPos;
                if(transform.position.x < 0)
                    body.velocity = new Vector2(4.0f,0);
                else if(transform.position.x > 0)
                    body.velocity = new Vector2(-4.0f,0);
                break;
            case "EnemyYellow":
                initPos = transform.position;
                initPos.x = positionsX[i];
                initPos.y = -3.6f;
                transform.position = initPos;
                if(transform.position.x < 0)
                    body.velocity = new Vector2(4.0f,0);
                else if(transform.position.x > 0)
                    body.velocity = new Vector2(-4.0f,0);
                break;
            case "EnemyFly":
                initPos = transform.position;
                initPos.x = positionsX[i];
                initPos.y = 0.0f;
                transform.position = initPos;
                if(transform.position.x < 0)
                    body.velocity = new Vector2(4.0f,0);
                else if(transform.position.x > 0)
                    body.velocity = new Vector2(-4.0f,0);
                break;
            case "EnemyBrown":
                initPos = transform.position;
                initPos.x = j;
                initPos.y = -5f;
                transform.position = initPos;
                body.velocity = new Vector2(0,4.0f);
                break;
            case "EnemyCream":
                initPos = transform.position;
                initPos.x = j;
                initPos.y = 5;
                transform.position = initPos;
                body.velocity = new Vector2(0,-4.0f);
                break;
        }
    }
    
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
