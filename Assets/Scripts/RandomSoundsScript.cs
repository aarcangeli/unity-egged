﻿using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class RandomSoundsScript : MonoBehaviour
{
	public AudioClip[] AudioSources;
	public bool PlayOnStart;

	private AudioSource _audioClip;
	
	public AudioSource Clip => _audioClip;

	void Awake()
	{
		if (AudioSources.Length == 0)
		{
			Debug.LogError("No audio sources set for RandomSoundsScript");
			return;
		}

		_audioClip = GetComponent<AudioSource>();
		
		// help reduce latency on first play
		ChooseNextRandom();

		if (PlayOnStart)
		{
			PlayRandomSound();
		}
	}

	public void PlayRandomSound()
	{
		if (AudioSources.Length == 0) return;

		_audioClip.Play();
		ChooseNextRandom();
	}

	private void ChooseNextRandom()
	{
		_audioClip.clip = AudioSources[Random.Range(0, AudioSources.Length)];
	}
}
