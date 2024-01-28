using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTest : MonoBehaviour
{
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print(collision.collider.name);
    }
}
