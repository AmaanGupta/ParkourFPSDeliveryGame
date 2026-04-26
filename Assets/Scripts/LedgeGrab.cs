using UnityEngine;

public class LedgeGrab : MonoBehaviour
{
    [SerializeField] private LayerMask ledgeLayer;
    private float boxCastDistance=0.75f;
    public bool isledgeGrab;

    void Start()
    {
        isledgeGrab=false;
    }
    void Update()
    {
        bool isHit=Physics.BoxCast(transform.position,new Vector3(0.1f,0,0),transform.forward,transform.rotation,boxCastDistance,ledgeLayer);
        isledgeGrab=isHit;
        Debug.Log(isHit);
        
    }
}
