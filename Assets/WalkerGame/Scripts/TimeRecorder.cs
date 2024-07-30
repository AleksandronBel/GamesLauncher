using System;
using TMPro;
using UnityEngine;

public class TimeRecorder : MonoBehaviour
{
    [SerializeField] StartTrigger _startTrigger;
    [SerializeField] FinishTrigger _finishTrigger;
    [SerializeField] TextMeshProUGUI _currentTimeUI;
    [SerializeField] TextMeshProUGUI _recordTimeUI;

    float _timer;
    bool _isTimerRunning;

    void OnEnable()
    {
        _startTrigger.OnStartTriggered += PrepareTimer;
        _finishTrigger.OnFinishTriggered += StopTimer;
    }

    void OnDisable()
    {
        _startTrigger.OnStartTriggered -= PrepareTimer;
        _finishTrigger.OnFinishTriggered -= StopTimer;
    }

    void Start()
    {
        if (!PlayerPrefs.HasKey("Timer"))
        {
            PlayerPrefs.SetFloat("Timer", float.MaxValue);
            PlayerPrefs.Save();
        }
    }

    void Update()
    {
        StartTimer();
    }

    void PrepareTimer()
    {
        if (!_isTimerRunning)
            _isTimerRunning = true;
    }

    void StartTimer()
    {
        if (_isTimerRunning)
        {
            _timer += Time.deltaTime;
            ShowTimerResult(_timer, _currentTimeUI);
        }
    }

    void StopTimer()
    {
        _isTimerRunning = false;

        if (_timer < PlayerPrefs.GetFloat("Timer"))
        {
            PlayerPrefs.SetFloat("Timer", _timer);
            PlayerPrefs.Save();
            ShowTimerResult(_timer, _recordTimeUI);
        }
        else
        {
            ShowTimerResult(PlayerPrefs.GetFloat("Timer"), _recordTimeUI);
        }
    }

    void ShowTimerResult(float time, TextMeshProUGUI timer)
    {
        TimeSpan timeSpan = TimeSpan.FromSeconds(time);
        int milliseconds = timeSpan.Milliseconds / 10;
        string formattedTime = string.Format("{0:D2} : {1:D2} : {2:D2}",
                                             timeSpan.Minutes,
                                             timeSpan.Seconds,
                                             milliseconds);
        timer.text = formattedTime;
    }

    //void ShowResult(float time)
    //{
    //    TimeSpan timeSpan = TimeSpan.FromSeconds(time);
    //    string formattedTime = string.Format("{0:D2}:{1:D2}:{2:D2}",
    //                                         timeSpan.Minutes,
    //                                         timeSpan.Seconds,
    //                                         timeSpan.Milliseconds);
    //
    //    _timerUI.text = formattedTime;
    //}

    //IEnumerator Timer()
    //{
    //    while (_isCoroutineRunning)
    //    {
    //        _isCoroutineRunning = true;
    //
    //        if (_milliSeconds == 99)
    //        {
    //            _seconds++;
    //            _milliSeconds = 0;
    //
    //            if (_seconds == 59)
    //            {
    //                _minutes++;
    //                _seconds = 0;
    //            }
    //        }
    //
    //        _milliSeconds += 1;
    //
    //        _timer.text = _minutes.ToString("00") + " : " + _seconds.ToString("00") + " : " + _milliSeconds.ToString("00");
    //
    //        yield return _timeOfOneMilliSecond;
    //    }
    //}

    //async void Timer()
    //{
    //    while (_isTimerRunning)
    //    {
    //        _isTimerRunning = true;
    //
    //        if (_milliSeconds == 99)
    //        {
    //            _seconds++;
    //            _milliSeconds = 0;
    //
    //            if (_seconds == 59)
    //            {
    //                _minutes++;
    //                _seconds = 0;
    //            }
    //        }
    //
    //        _milliSeconds += 1;
    //
    //        _timer.text = _minutes.ToString("00") + " : " + _seconds.ToString("00") + " : " + _milliSeconds.ToString("00");
    //
    //        await Task.Delay(10);
    //    }
    //}
}
