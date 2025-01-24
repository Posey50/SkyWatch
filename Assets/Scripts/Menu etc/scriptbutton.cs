using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scriptbutton : MonoBehaviour
{
    public GameObject OptionMenu;

   public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
       
    public void Settings()
    {
        OptionMenu.SetActive(true);
    }
    
    public void Credits()
    {
        SceneManager.LoadScene("credits");
    }
    
    public void Back()
    {
        OptionMenu.SetActive(false);
    }

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
