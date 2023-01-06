using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
	public AudioSource audioSource;
	public AudioClip[] clips;
	public float volume;

	public int _clip;
	public AudioClip clip;


	public void OnClickSound()
	{
		_clip = Random.Range(0, clips.Length);
		if (!audioSource.isPlaying)
		{
			audioSource.PlayOneShot(clips[_clip], volume);
		}
	}
}
