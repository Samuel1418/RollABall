using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float speed;
    public Text countText;
    public Text winText;

    public float elapsedTime = 5f;
    private Rigidbody rb;
    private int count;

   
    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText ();
        winText.text = "";
    }

    void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");

        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

        rb.AddForce (movement * speed);
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag ( "Recoger"))
        {
            other.gameObject.SetActive (false);
            count = count + 1;
            SetCountText ();
        }
         if (other.gameObject.tag == "Enemy")
        {
            countText.text = "Oughh!!!!!";
            // vuelve al centro del tablero
           // player.transform.position = Vector3.zero;
           //Hacer que el nivel se resetee al detectar la colision con el enemigo
           elapsedTime += Time.deltaTime;
            Application.LoadLevel (Application.loadedLevelName);
            
        }
    }

    void SetCountText ()
    {
        countText.text = "Count: " + count.ToString ();
        if (count >= 10)
        {
            winText.text = "You Win!";
        }
    }
}