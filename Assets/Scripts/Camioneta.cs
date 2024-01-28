using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camioneta : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.velocity += Vector2.left * speed * Time.deltaTime;

    }

    private void Update()
    {
        //StartCoroutine(WaitTime());

       
    }

    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(5f);

        ////
        //Reiniciar();
    }

    void Reiniciar()
    {

    }

}
