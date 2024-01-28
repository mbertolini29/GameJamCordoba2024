using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoloLaAbuela : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 5f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    //private void FixedUpdate()
    //{
    //    Vector3 vector = new Vector3(-1f, 1f, 0f);
    //    rb.AddForce(vector * force * Time.deltaTime);
    //}

    private void Update()
    {
        //var vectorLeft += Vector3.left * speed * Time.deltaTime;
        //var vectorUp += Vector3.up * speed * Time.deltaTime;

        StartCoroutine(WaitTimeAbuela());
    }

    IEnumerator WaitTimeAbuela()
    {
        yield return new WaitForSeconds(1.5f);
        
        RotarYMoverAbuela();
    }

    void RotarYMoverAbuela()
    {
        Vector3 vectomovimiento = new Vector3(-1f, 1f, 0);
        transform.position += vectomovimiento.normalized * speed * Time.deltaTime;

        //
        //transform.R
        Quaternion rot = Quaternion.Euler(Vector3.forward * 5f);
        transform.rotation = transform.rotation * rot;
    }
}
