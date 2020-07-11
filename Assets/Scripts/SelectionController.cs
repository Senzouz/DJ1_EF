using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectionController : MonoBehaviour
{
    [SerializeField] Button btnNormal;
    [SerializeField] Button btnParao;
    
    void Start()
    {
        btnNormal.onClick.AddListener(()=> goNormal());
        btnParao.onClick.AddListener(()=> goParao());
    }
    void goNormal(){
        PlayerPrefs.SetInt("difficulty",1);
        PlayerPrefs.SetInt("cWave",1);
        PlayerPrefs.SetInt("score",0);
        SceneManager.LoadScene("Game");
    }
    void goParao(){
        PlayerPrefs.SetInt("difficulty",4);
        PlayerPrefs.SetInt("cWave",1);
        PlayerPrefs.SetInt("score",0);
        SceneManager.LoadScene("Game");
    }
}
