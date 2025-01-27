using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParpadeoLuz : MonoBehaviour
{
    private Light luz;
    void Start()
    {
        luz = GetComponent<Light>();
        StartCoroutine(Parpadeo());
    }
    private void Update()
    {
        
    }
    private IEnumerator Parpadeo()
    {
        while (true)
        {
            luz.enabled = true;
            yield return new WaitForSeconds(Random.Range(0f, 0.15f));
            luz.enabled = false;
            yield return new WaitForSeconds(Random.Range(0f, 0.10f));
        }
    }
}
