using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParpadeoLuz : MonoBehaviour
{
    private Light luz;
    void Start()
    {
        luz = GetComponent<Light>();
    }
    private void Update()
    {
        StartCoroutine(Parpadeo());
        
    }
    private IEnumerator Parpadeo()
    {
        while (true)
        {
            luz.enabled = true;
            yield return new WaitForSeconds(0.4f);
            luz.enabled = false;
            yield return new WaitForSeconds(1f);
        }
    }
}
