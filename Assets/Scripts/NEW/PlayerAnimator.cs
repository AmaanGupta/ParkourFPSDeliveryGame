using System;
using System.Collections;
using Unity.Cinemachine;
using Unity.Mathematics;
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
        float dampTime = 0.15f;

        bodyAnim.SetFloat(
            "MoveX",
            playerInput.inputmoveDirection.x,
            dampTime,
            Time.deltaTime
        );

        bodyAnim.SetFloat(
            "MoveY",
            playerInput.inputmoveDirection.y,
            dampTime,
            Time.deltaTime
        );

        onlyHandsAnim.SetFloat(
            "MoveX",
            playerInput.inputmoveDirection.x,
            dampTime,
            Time.deltaTime
        );

        onlyHandsAnim.SetFloat(
            "MoveY",
            playerInput.inputmoveDirection.y,
            dampTime,
            Time.deltaTime
        );
    }

    public void JumpAnimation(bool jump)
    {
        bodyAnim.SetBool("Jump",jump);
        onlyHandsAnim.SetBool("Jump",jump);
    }
    public void FallAnimation(bool fall)
    {
        bodyAnim.SetBool("Jump",fall);
        onlyHandsAnim.SetBool("Jump",fall);
    }
    public void SprintAnimation(bool fall)
    {
        bodyAnim.SetBool("Sprint",fall);
        onlyHandsAnim.SetBool("Sprint",fall);
    }
    public void CrouchAnimation(bool fall)
    {
        bodyAnim.SetBool("Crouch",fall);
        onlyHandsAnim.SetBool("Crouch",fall);
    }
    

}