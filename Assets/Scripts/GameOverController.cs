using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    [SerializeField] Text txtScore;
    private float timePassed;
    void Start()
    {
        txtScore.text = "Score: " + PlayerPrefs.GetInt("score");
    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;
        if(timePassed >= 3.0f){
            SceneManager.LoadScene("Menu");
        }
    }
}
