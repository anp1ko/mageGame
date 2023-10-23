using System;
using UnityEngine;

public class DayCycleManager : MonoBehaviour
{
    [Range(0,1)]
    public float timeOfDay;
    public float dayDuration = 30f;

    public AnimationCurve sunCurve;
    public AnimationCurve moonCurve;
    
    public Light sun;
    public Light moon;

    private float _sunIntensity;
    private float _moonIntensity;

    private void Start()
    {
        _sunIntensity = sun.intensity;
        _moonIntensity = moon.intensity;
    }

    private void Update()
    {
        timeOfDay += Time.deltaTime / dayDuration;
        if (timeOfDay >= 1)
            timeOfDay -= 1;
        
        sun.transform.localRotation = Quaternion.Euler(timeOfDay * 360f, 180, 0);
        moon.transform.localRotation = Quaternion.Euler(timeOfDay * 360f + 180f, 180, 0);
        sun.intensity = _sunIntensity * sunCurve.Evaluate(timeOfDay);
        moon.intensity = _moonIntensity * moonCurve.Evaluate(timeOfDay);
    }
}
