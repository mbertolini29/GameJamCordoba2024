using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Rigidbody2D rb;

    Vector3 direction;

    public GameObject target;
    public float speed = 10f;

    //[Header("Movement Controller")]

    void Start()
    {
        //rb = rb.GetComponentInChildren<Rigidbody2D>();

        if (Input.GetKey(KeyCode.Z))
        {
            HitPlayer();
        }
    }

    void HitPlayer()
    {
        //aca seria la animacion del movimiento de la patada.

        //el empujon a la abuela.
        //Vector2 targetPos = new Vector2(transform.position.x + 10, transform.position.y + 10);
        //transform.position = Vector2.Lerp(target.transform.position, targetPos, speed * Time.deltaTime);

        this.transform.position += this.direction * this.speed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Grandmother"))
        {
            //como llamo a la variable de la abuela??
            //collision.gameObject.GetComponent<GrandmotherProjectile>().canMove = true;
            
            //HitPlayer();
        }
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if(collision.gameObject.layer == LayerMask.NameToLayer("Grandmother"))
    //    {
    //        HitPlayer();
    //    }
    //}

}
