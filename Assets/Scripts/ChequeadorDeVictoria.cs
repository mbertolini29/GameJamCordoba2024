using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChequeadorDeVictoria : MonoBehaviour
{
    public GrandmotherProjectile abuela;
    public Rigidbody2D rb;

    public bool enAsilo = false;

    private void Update()
    {
        //si se lanzo. y no llego a llego

        if (abuela.seMovio && rb.velocity.magnitude < Mathf.Epsilon)
        {
            Debug.Log("se paro");
            if (enAsilo)
            {
                Debug.Log("se gano");

                Ganaste();
            }
            else
            {
                Perdiste();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Asilo"))
        {
            //Debug.Log("enen as.");
            enAsilo = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Asilo"))
        {
            //Debug.Log("/*ganas*/.");

            enAsilo = false;
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

    public void Ganaste()
    {

        NextScene();
    }

    public void Perdiste()
    {
        Reiniciar();
    }
}
