using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accesorie : MonoBehaviour
{

    private Transform egg;
    Vector3 original;
    private bool Moved;

    // Start is called before the first frame update
    void Start()
    {

        original = transform.position;

        egg = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Move()
    {

        if (!Moved)
        {
            transform.position = egg.position;
        }
        else
        {
            transform.position = original;
        }

        Moved = !Moved;

    }



}
