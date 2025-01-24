using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class scriptSettings : MonoBehaviour
{
    public AudioMixer audioMixer;
   
    public void SetVolume (float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }



}
