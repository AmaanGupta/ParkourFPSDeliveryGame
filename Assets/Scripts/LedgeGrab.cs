using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class LedgeGrab : MonoBehaviour
{
    [SerializeField] private LayerMask ledgeLayer;
    [SerializeField] private CharacterController characterController;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private GameObject legCheckGO;
    [SerializeField] private bool legCheck;
    private float boxCastDistance=0.75f;
    public bool isledgeGrab;
    private float timeCounter;
    private float maxTime=0.2f;
    public bool climbCompleted;

    void Start()
    {
        isledgeGrab=false;

    }
    void Update()
    {
        bool isHit=Physics.BoxCast(transform.position,new Vector3(0.1f,0.2f,0),transform.forward,transform.rotation,boxCastDistance,ledgeLayer);
        isledgeGrab=isHit;
        Debug.Log(isHit);
        bool isWall=Physics.Raycast(legCheckGO.transform.position,legCheckGO.transform.forward,2f);
        legCheck=isWall;
    }

    public void LedgeClimb()
    {
        if (playerMovement.isClimb)
        {
            if (!legCheck)
            {
                
                StartCoroutine(MoveForwardCoroutine());
                return;
            }

            
            characterController.Move(transform.up*5f*Time.deltaTime);
        }

        
    }

    IEnumerator MoveForwardCoroutine()
    {
        timeCounter=0f;
        while (timeCounter <= maxTime)
        {
            characterController.Move(transform.forward*0.4f*Time.deltaTime);
            timeCounter+=Time.deltaTime;
            yield return null;
        }
        climbCompleted=true;
    }
}
