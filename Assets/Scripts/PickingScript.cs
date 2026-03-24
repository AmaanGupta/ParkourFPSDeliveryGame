using System;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PickingScript : MonoBehaviour
{
    [SerializeField] private InputActionReference interact;
    [SerializeField] private GameObject fpsCamera;
    [SerializeField] private LayerMask pickableLayer;
    [SerializeField] private GameObject holdPosition;
    private float pickupDistance=10f;
    

    void OnEnable()
    {
        interact.action.performed+=StartInteract;
        interact.action.canceled+=StopInteract;
    }
    void OnDisable()
    {
        interact.action.performed-=StartInteract;
        interact.action.canceled-=StopInteract;
    }


    void StartInteract(InputAction.CallbackContext obj)
    {
        Grab();
    }
    void StopInteract(InputAction.CallbackContext obj)
    {
        Leave();
    }

    void Grab()
    {
        Debug.Log("Grabbing");
        bool didHit=Physics.Raycast(fpsCamera.transform.position,fpsCamera.transform.forward,out RaycastHit Hit,pickupDistance,pickableLayer);
        Debug.Log(didHit);
        if (didHit)
        {
            Hit.collider.gameObject.GetComponent<Rigidbody>().isKinematic=true;
            Hit.collider.transform.position=holdPosition.transform.position;

        }
        
        
    }
    void Leave()
    {
        
        Debug.Log("leaving");
    }
}
