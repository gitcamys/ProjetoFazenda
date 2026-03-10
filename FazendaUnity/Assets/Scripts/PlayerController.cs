using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 20f;
    public float xRange = 15f;
    public GameObject projectilePrefab;
    float horizontalInput;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // float horizontalInput = Input.GetAxis("Horizontal");
        // movimenta o player para esquerda e direita a partir da entrada do usuario
        transform.Translate(Vector3.right * speed * Time.deltaTime * horizontalInput);
        // mantem o player dentro dos limites do jogo (eixo x)
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.y);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.y);
        }
        // dispara comida ao pressionar barra de espaco
        // if (Input.GetKeyDown(KeyCode.Space))
        //{
       //     Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
       // }
        
 
   }  
   public void MoveEvent(InputAction.CallbackContext context)
    {
        horizontalInput = context.ReadValue<Vector2>().x;
    }             
    public void FireEvent(InputAction.CallbackContext context)
    {
      //if(Context.) 
    //   Debug.Log("pizza"); 
    if(context.performed){
      Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
    }     
  }             
  }



