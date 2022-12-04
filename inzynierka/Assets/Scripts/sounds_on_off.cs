using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sounds_on_off : MonoBehaviour
{
    [SerializeField] AudioSource sound1;
    public GameObject toggler;
    public void SoundON()
    {
        if(toggler.GetComponent <Toggle>().isOn)
        {
            sound1.Play();
        }
        else
        {
            sound1.Stop();
        }
    }
}
