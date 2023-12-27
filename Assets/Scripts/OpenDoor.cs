using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OpenDoor : MonoBehaviour
{
    [SerializeField] private Transform Ldoor;
    [SerializeField] private Transform Rdoor;
    [SerializeField] private Camera _camera;
    [SerializeField] private playerTeleport _playerT;
    [SerializeField] private GameObject _image;
    [SerializeField] private float rotationSpeed = 50f;
    [SerializeField] float targetAngle = 90f;


     private bool isRotating = false;



    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Vector3 newDirection = new Vector3(90, 0, 0);
            other.transform.rotation = Quaternion.LookRotation(newDirection);           
            isRotating = true;
            _playerT.enabled = false;
            _camera.transform.localPosition = new Vector3(-7, 3, 0);
            _camera.transform.localRotation = Quaternion.LookRotation(newDirection);
            _image.SetActive(true);
            Invoke("NextLvl", 5f);
            

        }
    }
    private void Update()
    {

        if (isRotating)
        {
            RotateTowardsTarget();
        }
    }
    private void NextLvl()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void RotateTowardsTarget()
    {
        //Debug.Log("213425");
        float step = rotationSpeed * Time.deltaTime;
        Rdoor.Rotate(Vector3.up, step);
        Ldoor.Rotate(Vector3.down, step);
        if (Rdoor.rotation.eulerAngles.y >= 180)
        {
            Debug.Log(Rdoor.rotation.eulerAngles.y);
            isRotating = false;
        }
    }


}
