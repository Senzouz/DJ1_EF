using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static Player instance;
    [SerializeField] GameObject redBullet;
    [SerializeField] GameObject yellowBullet;
    [SerializeField] GameObject flyBullet;
    [SerializeField] GameObject brownBullet;
    [SerializeField] GameObject creamBullet;

    private float minX = -6.2f;
    private float maxX = 6.2f;
    public string direction = "";
    private float speed = 5.0f;
    private Rigidbody2D body;
    private Animator animator;
    private bool canJump;
    public int hp;

    void Awake(){
        if (instance == null){
            instance = this;
        }
        hp = 4 / PlayerPrefs.GetInt("difficulty");
    }
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        Vector2 initPos = transform.position;
        initPos.y = -3.6f;
        transform.position = initPos;
    }

    void Update()
    {

        //movimiento
        float moveH = Input.GetAxis("Horizontal");
        float moveV = Input.GetAxis("Vertical");
        if(Input.GetAxis("Horizontal") > 0.0f){
            animator.Play("MovingRight");
            direction = "right";
            body.velocity = new Vector2(moveH*speed,0);
        }
        else if(Input.GetAxis("Horizontal") < 0.0f){
            animator.Play("MovingLeft");
            direction = "left";
            body.velocity = new Vector2(moveH*speed,0);
        }
        if(Input.GetAxis("Vertical") > 0.0f && canJump){
            canJump = false;
            direction = "up";
            body.velocity = new Vector2(0,speed);
        }
        //restricciones de movimiento
        if(transform.position.x >= maxX){
            Vector2 dummy = transform.position;
            dummy.x = maxX;
            transform.position = dummy;
        }
        else if(transform.position.x <= minX){
            Vector2 dummy = transform.position;
            dummy.x = minX;
            transform.position = dummy;
        }
        if(Mathf.Abs(body.velocity.y) == 0) canJump = true;
        

        //disparos
        if(Input.GetKeyDown(KeyCode.A)){
            Instantiate(brownBullet,transform.position,Quaternion.identity);
        }
        if(Input.GetKeyDown(KeyCode.S)){
            Instantiate(creamBullet,transform.position,Quaternion.identity);
        }
        if(Input.GetKeyDown(KeyCode.D)){
            Instantiate(flyBullet,transform.position,Quaternion.identity);
        }
        if(Input.GetKeyDown(KeyCode.F)){
            Instantiate(redBullet,transform.position,Quaternion.identity);
        }
        if(Input.GetKeyDown(KeyCode.G)){
            Instantiate(yellowBullet,transform.position,Quaternion.identity);
        }
        
    }

    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.layer != 9){
            Destroy(other.gameObject);
            hp--;
        }
        if(hp <= 0){
            PlayerPrefs.SetInt("score",GameController.instance.score);
            SceneManager.LoadScene("GameOver");
        }
    }
}
