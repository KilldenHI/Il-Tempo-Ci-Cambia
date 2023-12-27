using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Dialog : MonoBehaviour
{
    [SerializeField] private GameObject imageObject;
    [SerializeField] private float displayDuration = 5f;
    [SerializeField] private GameObject dialod;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            dialod.SetActive(false);
            if (imageObject != null) 
            {
                Invoke("ShowForDuration", 0);
            }
            
        }
    }

    void ShowForDuration()
    {
        imageObject.SetActive(true); // Картинка становится видимой

        Invoke("HideImage", displayDuration); // Через указанное время вызываем функцию для скрытия картинки
    }

    void HideImage()
    {
        imageObject.SetActive(false); // Картинка становится невидимой
    }
}
