using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{

    public AudioClip sonidoPatada;
    public AudioSource audioSourceSonidos;

    void Start()
    {
        
    }

    public void SonidoPatada()
    {
        audioSourceSonidos.PlayOneShot(sonidoPatada);
    }
}
