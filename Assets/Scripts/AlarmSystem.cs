using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmSystem : MonoBehaviour
{
    [SerializeField] private float _volumeStep = 0.2f;

    private AudioSource _audioSource;
    private float _volumeDirection;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = 0f;
    }

    private void Update()
    {
        if(_audioSource.volume >= 0f || _audioSource.volume <= 1f)
        {
            _audioSource.volume += _volumeDirection * Time.deltaTime * _volumeStep;
        }

        if (_audioSource.volume <= 0f)
            _audioSource.Stop();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Thief>())
        {
            _audioSource.Play();
            _volumeDirection = 1;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Thief>())
        {
            _volumeDirection = -1;
        }
    }
}
