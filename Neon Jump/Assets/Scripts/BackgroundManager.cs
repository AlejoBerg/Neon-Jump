using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    private Color startColor = Color.magenta;
    private Color endColor = Color.yellow;
    private float standardDuration = 20f;

    private bool isExecutingSpecialBGColor = false;
    private float specialLerp = 0;

    private void Update()
    {
        ExecuteSpecialBGColor(Color.green, 5f);
        ExecuteStandardBGColor();
    }

    private void ExecuteSpecialBGColor(Color _newColor, float _delay) //Cambio de color "especial" = Se usa cuando ocurre algo. Ej: Agarro powerUp
    {
        if(specialLerp <= 1f)
        {
            isExecutingSpecialBGColor = true;
            endColor = _newColor;

            specialLerp = Mathf.PingPong(Time.time, _delay) / _delay;
            RenderSettings.skybox.SetColor("_Tint", Color.Lerp(startColor, endColor, specialLerp));
        }
        else
        {
            isExecutingSpecialBGColor = false;
        }
    }

    private void ExecuteStandardBGColor() //Cambio de color "standard" = Se ejecuta constantemente a menos que se ejecute el cambio de color "especial"
    {
        if(isExecutingSpecialBGColor == false) 
        {
            float lerp = Mathf.PingPong(Time.time, standardDuration) / standardDuration;
            RenderSettings.skybox.SetColor("_Tint", Color.Lerp(startColor, endColor, lerp));
        }
    }
}
