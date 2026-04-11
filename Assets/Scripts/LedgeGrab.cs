using UnityEngine;

public class LedgeGrab : MonoBehaviour
{
    [SerializeField] private LayerMask ledgeLayer;
    private float boxCastDistance=0.75f;
    void Update()
    {
        bool isHit=Physics.BoxCast(transform.position,new Vector3(0.1f,0,0),transform.forward,transform.rotation,boxCastDistance,ledgeLayer);
        Debug.Log(isHit);
    }
}
