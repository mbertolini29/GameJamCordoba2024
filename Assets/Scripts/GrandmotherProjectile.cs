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
     
    //rigidbody
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
        
        Debug.Log($"la fuerza final tiene direccion {finalForce}");
    }
}
