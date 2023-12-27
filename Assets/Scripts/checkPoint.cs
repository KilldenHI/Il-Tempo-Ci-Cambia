using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkPoint : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private int index = 1;
    [SerializeField] Transform _transform;
    private void Awake()
    {
        Vector3 newPosition = _transform.position;
        newPosition.y += 3;
        if (DataContainer.checkPointIndex == index)
        {
            _rb.MovePosition(newPosition);
            Debug.Log(newPosition);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (index > DataContainer.checkPointIndex)
            {
                DataContainer.checkPointIndex = index;
                Debug.Log(DataContainer.checkPointIndex);
            }

        }
    }

}
