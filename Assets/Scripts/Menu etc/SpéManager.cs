using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86;

public class SpéManager : MonoBehaviour
{
    public PlayerController playerController;

    public AttaqueSpé[] attaques;

    void Start()
    {
        
    }

    void Update()
    {
        var spe = Input.GetKeyDown(KeyCode.P);

        if (spe && playerController.count >= 10)
        {
            spe = false;
            foreach (var item in attaques)
            {
                item.AttaqueSpe();
            }
            playerController.count = 0;
        }
    }
}
