using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Transform derecha;
    [SerializeField] Transform izquierda;
    [SerializeField] Transform player;
    Transform inicio;
    Transform final;
    Transform miTF;
    float velocidad;
    SpriteRenderer miSR;
    Animator miAnim;
    bool direccion;
    // Start is called before the first frame update
    void Start()
    {
        miTF = gameObject.transform;
        miSR = GetComponent<SpriteRenderer>();
        miAnim = GetComponent<Animator>();
        player = GameObject.Find("Player").GetComponent<Transform>();
        miTF.position = izquierda.position;
        inicio = izquierda;
        final = derecha;
        velocidad = 0.2f;
    }

    // Update is called once per frame
    void Update()
    {
        miTF.Translate((final.position-inicio.position)*velocidad*Time.deltaTime);
        if(Vector3.Distance(miTF.position, derecha.position)< 0.2f)
        {
            direccion = true;
        }
        else if(Vector3.Distance(miTF.position, izquierda.position) < 0.2f)
        {
            direccion = false;
        }
        if(direccion)
        {
            inicio = derecha;
            final = izquierda;
        }
        else
        {
            inicio = izquierda;
            final = derecha;
        }
        if(Vector3.Distance(miTF.position, player.position)<1f)
        {
            velocidad = 0;
            miAnim.SetBool("Atacando", true);
            if(miTF.position.x < player.position.x)
            {
                direccion = false;
            }
            else
            {
                direccion = true;
            }
            miSR.flipX = direccion;
        }
        else
        {
            miAnim.SetBool("Atacando", false);
            velocidad = 0.2f;
            miSR.flipX = direccion;
        }
    }
}
