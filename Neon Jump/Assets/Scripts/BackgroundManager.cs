using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    [SerializeField] private Material sky;
    private Color initialColor;
    private Color endColor;

    void Start()
    {
        initialColor = new Color(0, 0, 0);
        endColor = new Color(0, 0, 0);
        RenderSettings.skybox.SetFloat("_Exposure", 6);
        RenderSettings.skybox.SetColor("_Tint", Color.white);
        print($"el color actual del cielo es {RenderSettings.skybox}");
    }

    void Update()
    {
        //RenderSettings.skybox.SetColor("_Tint", Color.Lerp(initialColor, endColor, 0.2f));
    }
}
