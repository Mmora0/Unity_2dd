using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Transform Derecha;
    [SerializeField] Transform Izquierda;
    Transform inicio;
    Transform final;
    Transform miTF;
    float velocidad;
    SpriteRenderer miSR;
    // Start is called before the first frame update
    void Start()
    {
        miTF = GetComponent<Transform>();
        miTF.position = Izquierda.position;
        inicio = Izquierda;
        final = Derecha;
        velocidad = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        miTF.Translate((final.position-inicio.position)*velocidad*Time.deltaTime);
        if(Vector3.Distance(miTF.position, Derecha.position)< 0.1f)
        {
            inicio = Derecha;
            final = Izquierda;
            miSR.flipX = true;
        }
        else if(Vector3.Distance(miTF.position, Izquierda.position) < 0.1f)
        {
            inicio = Izquierda;
            final = Derecha;
            miSR.flipX = false;
        }
    }
}
