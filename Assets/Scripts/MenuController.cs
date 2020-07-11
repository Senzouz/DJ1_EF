using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] Button btnSelection;

    void Start()
    {
        btnSelection.onClick.AddListener(()=> goSelection());
    }

    void goSelection(){
        SceneManager.LoadScene("Selection");
    }
}
