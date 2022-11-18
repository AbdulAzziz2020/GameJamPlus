using System;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;
    [Range(.1f, 1f)] public float volume = .1f;
    [Range(.3f, 3f)] public float pitch = 1f;
    public AudioClip clip;
}

public class AudioManager : SingletonPersitant<AudioManager>
{
    #region Singleton Persistent

    public override void Awake()
    {
        base.Awake();
    }

    #endregion

    public Sound[] bgm;
    public AudioSource sourceBGM;

    public Sound[] sfx;
    public AudioSource sourceSFX;

    private void Start()
    {
        PlayBGM("BGM");
    }

    public void PlayBGM(string name)
    {
        Sound sound = Array.Find(bgm, x => x.name == name);

        if (sound == null)
        {
            Debug.Log("SFX Not Found!");
            return;
        }

        sourceBGM.clip = sound.clip;
        sourceBGM.volume = sound.volume;
        sourceBGM.pitch = sound.pitch;

        sourceBGM.Play();
    }

    public void PlaySFX(string name)
    {
        Sound sound = Array.Find(sfx, x => x.name == name);

        if (sound == null)
        {
            Debug.Log("SFX Not Found!");
            return;
        }

        sourceSFX.clip = sound.clip;
        sourceSFX.volume = sound.volume;
        sourceSFX.pitch = sound.pitch;

        sourceSFX.PlayOneShot(sourceSFX.clip);
    }
}