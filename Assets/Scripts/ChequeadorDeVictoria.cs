using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChequeadorDeVictoria : MonoBehaviour
{
    public GrandmotherProjectile abuela;
    public Rigidbody2D rb;

    public bool enAsilo = false;

    public bool yaParo = false;

    public GameObject pantallaAmbulancia;
    public GameObject pantallaVoloAbuela;

    private void Update()
    {
        //si se lanzo. y no llego a llego

        if (abuela.seMovio && rb.velocity.magnitude < Mathf.Epsilon && yaParo == false)
        {
            yaParo = true;
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

    public void Ganaste()
    {
        //se active pantalla. set active
        pantallaVoloAbuela.SetActive(true);

        StartCoroutine(WaitTimeAbuela());

    }

    IEnumerator WaitTimeAbuela()
    {
        yield return new WaitForSeconds(4f);

        NextScene();
    }

    public void NextScene()
    {
        //cargar la escena de la ambulancia 
        //SceneManager.LoadScene("Ambulancia");

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    /// <summary>
    /// 
    /// </summary>


    public void Perdiste()
    {
        //hacemos aparece la pantalla de la ambulancia.
        //SceneManager.LoadScene("Ambulancia");

        //se active pantalla. set active
        pantallaAmbulancia.SetActive(true);

        StartCoroutine(WaitTime());

    }

    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(4f);

        Reiniciar();
    }
    public void Reiniciar()
    {
        //cargar la escena de la ambulancia 
        //SceneManager.LoadScene("Ambulancia");

        //reinicia el juego.
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
