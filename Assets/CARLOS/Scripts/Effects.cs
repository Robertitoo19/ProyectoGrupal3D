using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;


public class Effects : MonoBehaviour
{
    [Header("Daño pantalla")]
    public Material screenDamageMat ;
    private Coroutine screenDamagetask;
    [SerializeField] Player player;
    float intensity = 0f;
    [SerializeField] private float pulsacionVelocidad;
    [SerializeField] float intensidadPulsacion;
    [Header("Shake Camera")]
    public Camera playerCamera; // Referencia a la cámara del jugador
    public float shakeDuration ; // Duración del efecto shake
    public float shakeMagnitude ; // Intensidad del efecto shake
    public float shakeSpeed ; // Velocidad de las sacudidas

    private Vector3 originalCameraPosition;
    private bool isShaking = false;
    private Player playerScript;

    private void Start()
    {
        if (playerCamera != null)
        {
            originalCameraPosition = playerCamera.transform.localPosition;
        }
        playerScript = GetComponent<Player>();
    }
    private void Update()
    {
        EfectoVidaPantalla();
        
    }

    

    public void StartCameraShake()
    {
        if (!isShaking && playerCamera != null)
        {
            StartCoroutine(CameraShake());
        }
    }
    private IEnumerator CameraShake()
    {
        isShaking = true;
        float elapsed = 0.0f;

        while (elapsed < shakeDuration)
        {
            elapsed += Time.deltaTime * shakeSpeed;

            float x = Random.Range(-1f, 1f) * shakeMagnitude;
            float y = Random.Range(-1f, 1f) * shakeMagnitude;

            playerCamera.transform.localPosition = originalCameraPosition + new Vector3(x, y, 0);

            yield return null;
        }

        playerCamera.transform.localPosition = originalCameraPosition;
        isShaking = false;
    }

    private void EfectoVidaPantalla()
    {
        if (player.VidaPlayer < 80 && player.VidaPlayer > 60)
        {
            intensidadPulsacion = Mathf.Lerp(intensidadPulsacion, Random.Range(0.1f, 0.2f), Time.deltaTime);
            StartCameraShake();
        }
        else if (player.VidaPlayer <= 60 && player.VidaPlayer > 40)
        {
            intensidadPulsacion = Mathf.Lerp(intensidadPulsacion, Random.Range(0.2f, 0.3f), Time.deltaTime);
        }
        else if (player.VidaPlayer <= 40 && player.VidaPlayer > 20)
        {
            intensidadPulsacion = Mathf.Lerp(intensidadPulsacion, Random.Range(0.3f, 0.6f), Time.deltaTime);
            shakeMagnitude = 0.2f; 
            StartCameraShake();
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
            shakeMagnitude = 0.1f;
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
