using UnityEngine;

public class playerCamera : MonoBehaviour
{
    [SerializeField] private Transform _object; 
    
    private void LateUpdate() 
    {
        transform.position = _object.position; 
    }
}

