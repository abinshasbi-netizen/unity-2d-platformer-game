using UnityEngine;

public class BackgroundRepeat : MonoBehaviour
{
    private float spritewidth;
    private float camoffset;
    private Transform cam;
    
    void Start()
    {
        spritewidth = GetComponentInChildren<SpriteRenderer>().bounds.size.x;
        cam =Camera.main.transform;
       
        
    }

    
    void Update()
    {
        
    }
     void LateUpdate()
    {
        camoffset=cam.position.x-transform.position.x;

        if (Mathf.Abs(camoffset) >= spritewidth) { 

            float offset = camoffset>0 ? spritewidth: -spritewidth;

            transform.position += new Vector3(offset,0f,0f);
        
        }
        
    }
}
