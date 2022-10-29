using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightController : MonoBehaviour
{
    [SerializeField] private Light2D light2d;
    [SerializeField] private float _changeRate;
    [SerializeField] private float _changeSpeed;

    private bool _isUpscale = false;

    void Start()
    {
        StartCoroutine(LightShow());   
    }

    // Update is called once per frame
    void Update()
    {
        if (_isUpscale)
        {
            if (light2d.pointLightOuterRadius < 6)
            {
                light2d.pointLightOuterRadius += _changeSpeed * Time.deltaTime;
            }
        }
        else
        {
            if (light2d.pointLightOuterRadius > 2)
            {
                light2d.pointLightOuterRadius -= _changeSpeed * Time.deltaTime;
            }
        }
    }

    private IEnumerator LightShow()
    {
        yield return new WaitForSeconds(_changeRate); 
        int random = Random.Range(0, 100);
        _isUpscale = !_isUpscale;
        StartCoroutine(LightShow());
    }
}
