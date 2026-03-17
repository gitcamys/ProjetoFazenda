using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController2 : MonoBehaviour
{
    public float speed = 20f;
    public float xRange = 15f;
    public GameObject projectilePrefab;
   //float horizontalInput;

    public InputActionAsset InputActions;
    private InputAction moveAction;
    private InputAction fireAction;


    private InputAction PauseAction;
    private bool Pause = false;
    public GameObject Parar;


    void Awake() 
    { 
        moveAction = InputSystem.actions.FindAction("Move");  
        fireAction = InputSystem.actions.FindAction("Pizza");                                                                                                           
    }

    void Start()
  {
    Pause = false;
    Parar.SetActive(false);
  }

    // Update is called once per frame
    void Update()
    { 
       float horizontalInput = moveAction.ReadValue<Vector2>().x;

       transform.Translate(Vector3.right * speed * Time.deltaTime * horizontalInput);
       
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.y);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.y);
        }
        
        if (fireAction.WasPressedThisFrame()) {
          Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
        if(PauseAction.WasPressedThisFrame())
    {
      Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
    }
    if(PauseAction.WasPressedThisFrame())
    {
      if(Pause == false)
      {
        OnDisable();
      }
      else
      {
        OnEnable();
      }
    }

        
    }
 //  public void MoveEvent(InputAction.CallbackContext context)
  //  {
  //      horizontalInput = context.ReadValue<Vector2>().x;
//    }             
    // public void FireEvent(InputAction.CallbackContext context)
    // {
    //   //if(Context.) 
    // //   Debug.Log("pizza"); 
    // if(context.performed){
    //   Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
    // }     
//   }             
  private void OnEnable() 
  { 
    InputActions.FindActionMap("Player").Enable();
    Pause = false;
    PauseAction = InputSystem.actions.FindAction("Pause");
    Parar.SetActive(false);
    InputActions.FindActionMap("UI").Disable();  
  }                
  private void OnDisable() 
  { 
    Pause = true;
    PauseAction =InputSystem.actions.FindAction("Pause");
    Parar.SetActive(true);
    InputActions.FindActionMap("UI").Enable();
    InputActions.FindActionMap("Player").Disable();
  }
    
  }

