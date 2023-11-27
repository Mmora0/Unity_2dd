using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Player : MonoBehaviour
{
     [SerializeField] UnityEngine.Vector3 position;
    Transform miTF;
    [SerializeField] float velocidad;
    [SerializeField] float fuerzaSalto;
    float movimiento;
    [SerializeField] float interX;
    SpriteRenderer miSR;
    Animator miAnim;
    Rigidbody2D miRB;
    bool ensuelo;

    // Start is called before the first frame update
    void Start()
    {
       velocidad = 3f;
       fuerzaSalto = 500f;
       miTF = gameObject.transform;
       movimiento = miTF.position.x;
       miSR = gameObject.GetComponent<SpriteRenderer>();
       miAnim = gameObject.GetComponent<Animator>();
       miRB = gameObject.GetComponent<Rigidbody2D>();
       ensuelo = true;
    }

    // Update is called once per frame
    void Update()
    {
        interX = Input.GetAxisRaw("Horizontal");
        movimiento += velocidad*Time.deltaTime*interX;
        miTF.transform.position = new UnityEngine.Vector2(miTF.transform.position.x + velocidad*Time.deltaTime*interX, miTF.position.y);
        if(interX != 0)
        {
         miAnim.SetBool("Walk", true);
         if(interX<0)
         {
            miSR.flipX = true;
         }
         else
         {
            miSR.flipX = false;
         }
        }
        else
        {
         miAnim.SetBool("Walk", false);
        }
        if(Input.GetButtonDown("Jump") && ensuelo == true)
        {
         miAnim.SetBool("Jump", true);
         miRB.AddForce( UnityEngine.Vector2.up * fuerzaSalto);
         ensuelo = false;
        }
        if(miTF.position.x < -10)
        {
         miTF.position = new UnityEngine.Vector2(9.5f, miTF.position.y);
         print("Menor");
        }
        else if (miTF.position.x > 10)
        {
         miTF.position = new UnityEngine.Vector2 (-9.5f, miTF.position.y);
         print("Mayor");
        }
    }
    void OnCollisionEnter2D (Collision2D collision )
    {
      if (collision.gameObject.tag == "piso")
      {
         ensuelo = true;
         miAnim.SetBool("Jump", false);
      }
    }
}
