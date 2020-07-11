using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    private int currentWave;
    private float spawnTime;
    public int cantEnemies;
    [SerializeField] GameObject[] enemies;
    private int maxType;
    private float timePassed;
    public int score;
    public Text txtScore;

    void Awake() {
        if(instance == null) instance = this;
    }
    void Start()
    {
        currentWave = PlayerPrefs.GetInt("cWave");
        score = PlayerPrefs.GetInt("score");
        if(currentWave == 1){
            spawnTime = 8f;
            cantEnemies = 4;
            maxType = 2;
        }
        else if(currentWave == 2){
            spawnTime = 6f;
            cantEnemies = 8;
            maxType = 3;
        }
        else if(currentWave == 3){
            spawnTime = 4f;
            cantEnemies = 16;
            maxType = 4;
        }
        else if(currentWave == 4){
            spawnTime = 3f;
            cantEnemies = 32;
            maxType = 5;
        }
        else if(currentWave >= 5){
            spawnTime = 2f;
            cantEnemies = 64;
            maxType = 6;
        }
        txtScore.text = "Score: " + PlayerPrefs.GetInt("score");
    }

    void Update()
    {
        
        timePassed += Time.deltaTime;
        if(timePassed >= spawnTime){
            int a = Random.Range(0,maxType);
            print(a);
            Instantiate(enemies[a],transform.position,Quaternion.identity);
            timePassed = 0;
        }
        if(cantEnemies <= 0){
            ChangeWave();
        }
    }

    void ChangeWave(){
        PlayerPrefs.SetInt("score",score);
        currentWave++;
        PlayerPrefs.SetInt("cWave",currentWave);
        SceneManager.LoadScene("Game");
    }
}
