using System.Collections;
using NUnit.Framework;
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
    [SerializeField] private Animator onlyHandsAnim;
    [SerializeField] private Animator bodyAnim;
    private float boxCastDistance=0.5f;
    public bool isledgeGrab;
    private float timeCounter;
    private float maxTime=0.2f;
    public bool climbCompleted;
    public Transform ledgeTransform;

    void Start()
    {
        isledgeGrab=false;

    }
    void Update()
    {
        RaycastHit hitInfo;
        bool isHit=Physics.BoxCast(transform.position,new Vector3(0.1f,0.2f,0),transform.forward,out hitInfo,transform.rotation, boxCastDistance,ledgeLayer);
        if (isHit)
        {
            ledgeTransform=hitInfo.collider.transform;
        }
        
        isledgeGrab=isHit;
        Debug.Log(isHit);
        bool isWall=Physics.Raycast(legCheckGO.transform.position,legCheckGO.transform.forward,1.5f);
        legCheck=isWall;
    }

    public void LedgeClimb()
    {
        if (playerMovement.isClimb)
        {
            bodyAnim.SetBool("Climb",true);
            onlyHandsAnim.SetBool("Climb",true);
            
            
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
        playerMovement.isClimb=false;
        bodyAnim.SetBool("Climb",false);
        onlyHandsAnim.SetBool("Climb",false);
        climbCompleted=true;
        

    }
}
