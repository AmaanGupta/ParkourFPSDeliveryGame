using System;
using System.Collections;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator bodyAnim;
    public Animator BodyAnim => bodyAnim;
    [SerializeField] private Animator onlyHandsAnim;
    public Animator OnlyHandsAnim => onlyHandsAnim;
    private PlayerInput playerInput;

    void Awake()
    {
        playerInput=GetComponent<PlayerInput>();
    }    
    public void HandleAnimation()
    {
        bodyAnim.SetFloat("MoveX",playerInput.inputmoveDirection.x);
        bodyAnim.SetFloat("MoveY",playerInput.inputmoveDirection.y);
        onlyHandsAnim.SetFloat("MoveX",playerInput.inputmoveDirection.x);
        onlyHandsAnim.SetFloat("MoveY",playerInput.inputmoveDirection.y);
        
    }
    

}