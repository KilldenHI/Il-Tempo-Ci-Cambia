
using UnityEngine;
using UnityEngine.EventSystems;

public class treningTree : MonoBehaviour
{
    [SerializeField] private Transform tree;
    [SerializeField] private float rotateSpeed = 50f;
    [SerializeField] private int rotation = 1;
    [SerializeField] private Rigidbody _rb;
    private void Start()
    {
        //_rb.angularVelocity = Vector3.up * rotateSpeed;
        //_rb.AddForce(Vector3.up * rotateSpeed);
    }
    void Update()
    {
        //tree.Rotate(0, rotateSpeed * Time.deltaTime, 0);
    }
    private void FixedUpdate()
    {
        _rb.angularVelocity = Vector3.up * rotateSpeed * rotation;
    } 
}
