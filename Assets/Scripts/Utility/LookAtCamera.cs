using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    
    private Camera mainCamera;

    void Start()
    {
        
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (Camera.main != null)
        {
          
            transform.LookAt(transform.position + Camera.main.transform.rotation * -Vector3.forward,
                             Camera.main.transform.rotation * Vector3.up);
        }
    }
}
