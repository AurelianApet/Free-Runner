using UnityEngine;
using System.Collections;
using System;

[System.Serializable]
public class SoundsAndName
{
	public string name;
	public AudioClip clip;
	[Range (0, 1)]
	public float volume = 0.5f;
}

public class SoundController : MonoBehaviour
{

 
	 
	 
	public AudioSource[] audioSources;
	 
	 
	public AudioSource[] loopSounds;
	public SoundsAndName[] SingleShotSounds;
	float originalCoinSound;
	SoundsAndName coinSound;

	void OnEnable ()
	{
		Time.timeScale = 1;
		//Static = this;

		AceEvents.playSound += StartMusic;
		AceEvents.MuteSound += StopMusic;
		AceEvents.playSingleshotsounds += playSingleShotSoundFromName;	
		AceEvents.playloopsounds += playLoopSoundFromName;	
		AceEvents.stoploopsounds += stopLoopSoundFromName;	

		foreach (AudioSource sound in loopSounds) {
			 
			sound.enabled = false;
			 
		}

		foreach (SoundsAndName sound in SingleShotSounds) {

			if (sound.name.Contains ("coin")) {
				coinSound = sound;
				originalCoinSound = sound.volume;
				sound.volume = 0.01f;
			}



		}
	}

	void OnDisable ()
	{
		AceEvents.playSound -= StartMusic;
		AceEvents.MuteSound -= StopMusic;
		AceEvents.playSingleshotsounds -= playSingleShotSoundFromName;	
		AceEvents.playloopsounds -= playLoopSoundFromName;	
		AceEvents.stoploopsounds -= stopLoopSoundFromName;	
	}

	void resetCoinSound ()
	{
		coinSound.volume = 0.01f;

	}



	public void playSingleShotSoundFromName (System.Object obj, EventArgs args)
	{
		string clipName = (string)obj;
		foreach (SoundsAndName sound in SingleShotSounds) {

			if (clipName.Contains ("coin")) {
				if (coinSound.volume < originalCoinSound)
					coinSound.volume += 0.05f;
				if (IsInvoking ("resetCoinSound")) {

					CancelInvoke ("resetCoinSound");
				}
				Invoke ("resetCoinSound", 1.0f);
			} 

		
			if (sound.name.Contains (clipName)) {

				if (sound.clip == null) {

					Debug.Log ("Audio clip was not attached to clipNamed : " + clipName);
				} else
					swithAudioSources (sound.clip, sound.volume);
			}


		}
	}

	public void playLoopSoundFromName (System.Object obj, EventArgs args)
	{
		string clipName = (string)obj;

	


		foreach (AudioSource sound in loopSounds) {

			if (sound.name.Contains (clipName)) {
				 
				sound.enabled = true;
			}
		}


	}

	 
	public void stopLoopSoundFromName (System.Object obj, EventArgs args)
	{
		string clipName = (string)obj;
		foreach (AudioSource sound in loopSounds) {

			if (sound.name.Contains (clipName)) {

				sound.enabled = false;
			}
		}
	}

 
	 

	 
 
	public void StopSounds ()
	{
		//audio.Stop ();
	}

	 

	void swithAudioSources (AudioClip clip, float volume)
	{
 


		if (audioSources [0].isPlaying) {
			audioSources [1].PlayOneShot (clip);
			audioSources [1].volume = volume;
			//	audioSources [1].pitch = UnityEngine.Random.Range (0.9f, 1.1f);
		} else
			audioSources [0].PlayOneShot (clip);
		//audioSources [1].pitch = UnityEngine.Random.Range (0.9f, 1.1f);
		audioSources [0].volume = volume;

		 
	}


	void StartMusic (System.Object obj, EventArgs args)
	{
		AudioListener.volume = 1;

	}

	void StopMusic (System.Object obj, EventArgs args)
	{
		AudioListener.volume = 0;
	}

	 
}


