using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Screen_fader : MonoBehaviour
{
    [SerializeField] private float WhiteSpeed = 1f;
    IEnumerator Start()
    {
        Image _image = GetComponent<Image>();
        Color _color = _image.color;
        while (_color.a < 1f)
        {
            _color.a += WhiteSpeed * Time.deltaTime;
            _image.color = _color;
            yield return null;
        }

    }
}
