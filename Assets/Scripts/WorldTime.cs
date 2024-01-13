using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Assets.Scripts;

public class WorldTime : MonoBehaviour
{
    public event EventHandler<TimeSpan> WorldTimeChanged;

    [SerializeField]
    float _dayLength;
    TimeSpan _currentTime;
    float _minuteLength => _dayLength / WorldTimeConstants.MinutesInDay;

    private void Start()
    {
        StartCoroutine(AddMinute());
    }

    private IEnumerator AddMinute()
    {
        _currentTime += TimeSpan.FromMinutes(1);
        WorldTimeChanged?.Invoke(this, _currentTime);
        yield return new WaitForSeconds(_minuteLength);
        StartCoroutine(AddMinute());
    }
}
