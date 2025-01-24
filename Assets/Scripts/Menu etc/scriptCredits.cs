using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scriptCredits : MonoBehaviour
{
    public void LoadMenu()
    {
        SceneManager.LoadScene("menu");
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            LoadMenu();
        }
    }
}
