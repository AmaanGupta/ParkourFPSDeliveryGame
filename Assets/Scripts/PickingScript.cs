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
    private Collider objectGrabbed;

    private bool isGrabbed= false;
    private bool didHitNotLocal=false;
    private float pickupDistance=10f;

    void Update()
    {
        if(isGrabbed) Grab();
    }


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
        Debug.Log("Grabbing");
        bool didHit=Physics.Raycast(fpsCamera.transform.position,fpsCamera.transform.forward,out RaycastHit Hit,pickupDistance,pickableLayer);
        Debug.Log(didHit);
        didHitNotLocal=didHit;
        if (didHit)
        {
            objectGrabbed=Hit.collider;
            Hit.collider.gameObject.GetComponent<Rigidbody>().isKinematic=true;
            Hit.collider.transform.position=holdPosition.transform.position;
            Hit.collider.transform.eulerAngles=holdPosition.transform.eulerAngles;

        }
        isGrabbed=true;
    }
    void StopInteract(InputAction.CallbackContext obj)
    {
        Leave();
    }

    

    void Grab()
    {
        if (didHitNotLocal)
        {
            objectGrabbed.gameObject.GetComponent<Rigidbody>().isKinematic=true;
            objectGrabbed.transform.position=holdPosition.transform.position;
            objectGrabbed.transform.eulerAngles=holdPosition.transform.eulerAngles;
        }
        
        
        
    }
    void Leave()
    {
        if (didHitNotLocal)
        {
            isGrabbed=false;
            Debug.Log("leaving");
            objectGrabbed.gameObject.GetComponent<Rigidbody>().isKinematic=false;
        }
        

    }
}
