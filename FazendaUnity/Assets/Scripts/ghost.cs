using System.Collections;
using System.Collections.Generic;
using UnityEditor.MPE;
using UnityEngine;
using UnityEngine.InputSystem;
public class ghost : MonoBehaviour
{
     public InputActionAsset InputActions;
    private InputAction GhostActionPlayer;
    private InputAction GhostActionUI;

    private void Awake()
    {
        GhostActionPlayer = InputSystem.actions.FindAction("Player/Ghost");

    }

     private void Ghost()
    {
        if (GhostActionPlayer.WasPressedThisFrame())
        {

            // Desativa o objeto
            gameObjectPlayer.SetActive(false);

        }

        else if ()
        {
            
        }
    }
}
