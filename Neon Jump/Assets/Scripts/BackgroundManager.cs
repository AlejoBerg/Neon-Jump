using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    [SerializeField] private Material sky;
    private Color initialColor;
    private float redChannelLerp = 0.1f;
    private float greenChannelLerp = 0.1f;
    private float blueChannelLerp = 0.1f;
    private float targetColor = 0;
    private float currentColor = 0;

    void Start()
    {
        initialColor = RenderSettings.skybox.color = Color.black;
        print($"entro en el start con {initialColor}");
        //RenderSettings.skybox.SetFloat("_Exposure", 6);
        //RenderSettings.skybox.SetColor("_Tint", Color.white);
    }

    void Update()
    {
        redChannelLerp = ChangeChannelColor(redChannelLerp, 0.0001f);
        greenChannelLerp = ChangeChannelColor(greenChannelLerp, 0.0005f); 
        blueChannelLerp = ChangeChannelColor(blueChannelLerp, 0.0002f);

        RenderSettings.skybox.SetColor("_Tint", new Color(redChannelLerp, greenChannelLerp, blueChannelLerp));
        print($"el color es = R:{redChannelLerp * 255}, G:{greenChannelLerp * 255}, B:{blueChannelLerp * 255}");
    }

    private float ChangeChannelColor(float _color, float _delay)
    {
        if(_color <= targetColor)
        {
            targetColor = 1;
            _color += _delay;
            return _color;
        }
        if(_color >= targetColor)
        {
            targetColor = 0;
        }
        if(_color > targetColor)
        {
            _color -= _delay;
            return _color;
        }

        return _color;
    }
}
