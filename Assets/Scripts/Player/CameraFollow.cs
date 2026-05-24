using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float smooth_speed;    

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
    void LateUpdate()
    {
        Vector3 desiredPosition= new Vector3(

            target.position.x+offset.x,
            transform.position.y,
            offset.z
            
            );
        Vector3 smoothedPosition = Vector3.Lerp(

            transform.position,
            desiredPosition,
            smooth_speed*Time.deltaTime
    
            );
        transform.position = smoothedPosition;
        
    }
}
