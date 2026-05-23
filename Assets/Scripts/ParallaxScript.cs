using NUnit.Framework;
using UnityEngine;

public class ParallaxScript : MonoBehaviour
{
    
    [SerializeField] private float parallaxfactor;
    private Transform cameraTransform;
    private Vector3 lastPosition;

    void Start()
    {
        cameraTransform = Camera.main.transform;
        lastPosition = cameraTransform.position;
    }
    void Update()
    {
        Vector3 deltamovement=cameraTransform.position - lastPosition;
        transform.position += new Vector3(

            deltamovement.x * parallaxfactor,
            0f,
            0f

            );
        lastPosition= cameraTransform.position;
    }
}
