using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTo : MonoBehaviour
{
    public Transform jugador;
    UnityEngine.AI.NavMeshAgent enemigo;
    private bool dentro = false;
    public float proximidad;
    // el animator
    Animator animator;
  

	// Use this for initialization
	void Start () {
        enemigo = GetComponent<UnityEngine.AI.NavMeshAgent>();
        // asiganmos el animator del player para poder cambiar la bool
        animator = jugador.GetComponent<Animator>();
	}
	
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            dentro = true;
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            dentro = false;
        }
    }
	// Update is called once per frame
	void Update () {
		
        if (!dentro)
        {
            enemigo.destination = jugador.position;
        }
        if (dentro)
        {
            enemigo.destination = this.transform.position;
        }
        // comparamos la distancia al enemigo
        // cambiamos la variable bool
        // de esta manera forzamos la transicion desde Tarnquilo a Peligro
        // y vice versa
        
        if (enemigo.remainingDistance < proximidad)
        {
            Debug.Log("Peligro");
            // cambiamos a true la variable del animator
            animator.SetBool("EstarEnPeligro", true);
        }
        else
        {
            Debug.Log("Tranqui");
            // cambiamos a false la variable del animator
            animator.SetBool("EstarEnPeligro", false);
        }
	}
}