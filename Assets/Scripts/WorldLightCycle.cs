using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class WorldLightCycle : MonoBehaviour
{
    private Light2D light;

    [SerializeField]
    private WorldTime worldTime;

    [SerializeField]
    private Gradient gradient;

    private void Awake()
    {
        light = GetComponent<Light2D>();
        worldTime.WorldTimeChanged += WorldTime_WorldTimeChanged;
    }

    private void OnDestroy()
    {
        worldTime.WorldTimeChanged -= WorldTime_WorldTimeChanged;
    }

    private void WorldTime_WorldTimeChanged(object sender, System.TimeSpan newTime)
    {
        light.color = gradient.Evaluate(PercentOfDay(newTime));
    }

    private float PercentOfDay(TimeSpan timeSpan)
    {
        return (float)timeSpan.TotalMinutes % WorldTimeConstants.MinutesInDay / WorldTimeConstants.MinutesInDay;
    }
}
