using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;


public class Effects : MonoBehaviour
{
    public Material screenDamageMat ;
    private Coroutine screenDamagetask;
    [SerializeField] Player player;
    float intensity = 0f;
    [SerializeField] private float pulsacionVelocidad;
    [SerializeField] float intensidadPulsacion;
   

    private void Update()
    {
        EfectoVidaPantalla();
    }

    private void EfectoVidaPantalla()
    {
        if (player.VidaPlayer < 80 && player.VidaPlayer > 60)
        {
            intensidadPulsacion = Mathf.Lerp(intensidadPulsacion, Random.Range(0.1f, 0.2f), Time.deltaTime);
        }
        else if (player.VidaPlayer <= 60 && player.VidaPlayer > 40)
        {
            intensidadPulsacion = Mathf.Lerp(intensidadPulsacion, Random.Range(0.2f, 0.3f), Time.deltaTime);
        }
        else if (player.VidaPlayer <= 40 && player.VidaPlayer > 20)
        {
            intensidadPulsacion = Mathf.Lerp(intensidadPulsacion, Random.Range(0.3f, 0.6f), Time.deltaTime);
        }
        else if (player.VidaPlayer <= 20 && player.VidaPlayer > 10)
        {
            intensidadPulsacion = Mathf.Lerp(intensidadPulsacion, Random.Range(0.6f, 0.9f), Time.deltaTime);
        }
        else if (player.VidaPlayer <= 10)
        {
            intensidadPulsacion = Mathf.Lerp(intensidadPulsacion, Random.Range(0.9f, 1f), Time.deltaTime);
        }
        else
        {
            intensidadPulsacion = Mathf.Lerp(intensidadPulsacion, 0f, Time.deltaTime * 2);
        }
        if (intensidadPulsacion > 0.01f)
        {
            SetScreenDamage(intensidadPulsacion);
        }

        else
        {
            screenDamageMat.SetFloat("_Vignette_radius", 1f);
        }
    }

    void SetScreenDamage(float intensity)
    {
        float pulse = Mathf.Sin(Time.time * pulsacionVelocidad) * 0.02f; 
        float adjustedIntensity = intensity + pulse;
        adjustedIntensity = Mathf.Clamp(adjustedIntensity, 0, 1); 
        screenDamageMat.SetFloat("_Vignette_radius", Remap(adjustedIntensity, 0, 1, 0.4f, -0.15f));
    }

    private float Remap(float value, float fromMin, float fromMax, float toMin, float toMax)
    {
        return Mathf.Lerp(toMin, toMax, Mathf.InverseLerp(fromMin, fromMax, value));
    }
}
