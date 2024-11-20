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
   

    private void Update()
    {
        
        if (Input.GetKey(KeyCode.W))
        {
            ScreenDamageEffect(Random.Range(0.1f,1f));
        }
            
    }
    void ScreenDamageEffect(float intensity)
    {
        if (screenDamagetask != null)
            StopCoroutine(screenDamagetask);
        screenDamagetask = StartCoroutine(screenDamage(intensity));
    }

    private IEnumerator screenDamage (float intensity)
    {
        var targetRadius = Remap(intensity, 0, 1, 0.4f, -0.15f);
        var curRadius = 1f; // sin daño
        for(float t = 0; curRadius != targetRadius; t += Time.deltaTime)
        {
            curRadius = Mathf.Lerp(1, targetRadius, t); //no me deja porque es un float creo
            screenDamageMat.SetFloat("_Vignette_radius", curRadius);
            yield return null;
        }
        for (float t = 0; curRadius < 1; t += Time.deltaTime)
        {
            curRadius = Mathf.Lerp(targetRadius, 1, t);
            screenDamageMat.SetFloat("_Vignette_radius", curRadius);
            yield return null;
        }
    }

    private float Remap(float value, float fromMin, float fromMax, float toMin, float toMax)
    {
        return math.lerp(toMin, toMax, Mathf.InverseLerp(fromMin, fromMax, value));
    }
}
