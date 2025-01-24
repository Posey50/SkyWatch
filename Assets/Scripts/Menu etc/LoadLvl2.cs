using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLvl2 : MonoBehaviour
{
    public Animator fadesysteme;

    public PlayerController playerController;


    public void Loadlvl2()
    {
        fadesysteme.SetTrigger("fade");
    }

    private void Update()
    {
        if (playerController.change >= 50)
        {
            Loadlvl2();
        }
    }

    public void LoadScene()
    {
        SceneManager.LoadScene("Lvl 2");
    }
}