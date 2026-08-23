using Unity.Cinemachine;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public enum PlayerState
    {
        Normal
        
    }
    public PlayerState currentState;
    [SerializeField] private PlayerMovement playerMovementScript;
    
    [SerializeField] private Animator bodyAnim;
    [SerializeField] private Animator onlyHandsAnim;
    [SerializeField] private GameObject cam;

    void Start()
    {
        currentState=PlayerState.Normal;
    }
    void Update()
    {
        switch (currentState)
        {
            case PlayerState.Normal:
                UpdateNormal();
                break;
            
        }

    }
    void UpdateNormal()
    {
        playerMovementScript.ExecuteMovement();
    }
    

    
    


}
