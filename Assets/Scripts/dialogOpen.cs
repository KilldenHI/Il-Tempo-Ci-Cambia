using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogOpen : MonoBehaviour
{
    [SerializeField] private GameObject dialog;
    private bool check = true;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (check)
            {
                dialog.SetActive(true);
                check = false;
            }
            

        }
    }
}
