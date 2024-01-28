using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrandmotherProjectile : MonoBehaviour
{
    public float sliceValueToForce;

    //public Vector3 direction;
    public float speed;

    //move
    public bool canMove = false;
    public bool seMovio = false;

    //fisica
    [SerializeField] private float forceMax = 350;
    public Slider sliderForce;

    //flip
    [SerializeField] SpriteRenderer spriteRendererPlayer;
    [SerializeField] SpriteRenderer spriteRendererRueda;

    //
    [SerializeField] GameObject lavieja;

    //rigidbody
    Rigidbody2D rb;

    //
    [SerializeField] Animator anim;

    [SerializeField] Ganar ganar;
    [SerializeField] SliderForce barra;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //si se lanzo. y no llego a llego


        //if (rb.velocity.normalized.x == 0f && (int)barra.estadoActual == 0)
        //{
        //    Debug.Log("tgas");
        //}
    }

    private void FixedUpdate()
    {
        if(rb.velocity.normalized.x < 0f)
        {
            Vector3 newPosRueda = spriteRendererRueda.transform.localPosition;
            newPosRueda.x = Mathf.Abs(newPosRueda.x);
            spriteRendererRueda.transform.localPosition = newPosRueda;
        }
        else if (rb.velocity.normalized.x > 0f)
        {
            Vector3 newPosRueda = spriteRendererRueda.transform.localPosition;
            newPosRueda.x = -Mathf.Abs(newPosRueda.x);
            spriteRendererRueda.transform.localPosition = newPosRueda;
        }

        if (rb.velocity.normalized.x != 0f)
        {
            Quaternion rot = Quaternion.Euler(Vector3.forward * 5f);
            lavieja.transform.rotation = lavieja.transform.rotation * rot;

            spriteRendererPlayer.flipX = rb.velocity.normalized.x < 0f;
            spriteRendererRueda.flipX = rb.velocity.normalized.x < 0f;
        }

    }

    public void MovePlayer( float forceAtClick)
    {
        //la fuerza sale desde una barra.
        //el angulo tmb   
        //sliceValueToForce = Mathf.Abs(Mathf.Cos(forceAtClick)) * forceMax;
        sliceValueToForce = forceAtClick * forceMax;

        Debug.Log($"la fuerza calculada entre 0 y {forceMax} es {sliceValueToForce}");

        var finalForce = new Vector2(sliceValueToForce, rb.velocity.y);

        //direccion y fuerza.
        rb.AddForce(finalForce, ForceMode2D.Impulse);

        //
        seMovio = true;

        //animacion.
        anim.SetTrigger("Golpe");
        
        Debug.Log($"la fuerza final tiene direccion {finalForce}");
    }
}
