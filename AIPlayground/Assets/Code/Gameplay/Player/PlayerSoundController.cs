using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundController : MonoBehaviour {
    public AudioClip acReload;
    public AudioClip acShot;

    private AudioSource asReload;
    private AudioSource asShot;

    void Awake() {
        asReload = AddAudioSource(acReload, false, false, 1f);
        asShot = AddAudioSource(acShot, false, false, 1f);
    }

    public void PlayReload() {
        if (!asReload.isPlaying) {
            asReload.Play();
        }
    }

    public void PlayShotFired() {
        asShot.Play();
    }

    private AudioSource AddAudioSource(AudioClip ac, bool loop, bool playOnAwake, float volume) {
        AudioSource newAS = gameObject.AddComponent<AudioSource>();
        newAS.clip = ac;
        newAS.loop = loop;
        newAS.playOnAwake = playOnAwake;
        newAS.volume = volume;
        return newAS;
    }
}
