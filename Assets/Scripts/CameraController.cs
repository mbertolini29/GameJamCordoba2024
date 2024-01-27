using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject target;

    public Vector3 nuevaPosicion;

    void Start()
    {
        
    }

    private void Update()
    {
        //si objeto se esta moviendo.. mover la camara con el
        if (rb.velocity.magnitude > 0.01 && target.GetComponent<GrandmotherProjectile>().seMovio)
        {
            FollowObject();
        }
    }

    void FollowObject()
    {
        nuevaPosicion = target.transform.position;   
        nuevaPosicion.z = -10f;
        Camera.main.transform.position = nuevaPosicion;
    }
}
