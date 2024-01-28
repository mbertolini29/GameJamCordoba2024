using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public AudioClip sonidoBoton;
    public AudioSource audioSourceSonidos;

    public void Sonido()
    {
        audioSourceSonidos.PlayOneShot(sonidoBoton);

    }

    public void PlayAgain()
    {
        //SceneManager.LoadScene("Gameplay");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
