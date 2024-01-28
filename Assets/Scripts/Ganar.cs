using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ganar : MonoBehaviour
{
    GrandmotherProjectile abuela;
    SliderForce barra;

    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Debug.Log("ganas.");

            NextScene();
        }
    }

    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(2f);
    }

    public void NextScene()
    {
        //StartCoroutine(WaitTime());

        //cargar la escena de la ambulancia 
        //SceneManager.LoadScene("Ambulancia");

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Reiniciar()
    {
        //cargar la escena de la ambulancia 
        //SceneManager.LoadScene("Ambulancia");

        //reinicia el juego.
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Perdiste()
    {
        

    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        //si revota y sale de la casa perdiste.

        Reiniciar();
    }
}
