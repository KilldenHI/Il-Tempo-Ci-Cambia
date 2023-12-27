using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagRotetion : MonoBehaviour
{
    public Transform player;
    public float rotationSpeed = 5f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 direction = player.position - transform.position;
        direction.y = 0; // убираем смещение по оси y
        Quaternion rotation = Quaternion.LookRotation(direction);
        rb.MoveRotation(Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime));
    }
}
