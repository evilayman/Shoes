using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
struct AudioFile
{
    public string name;
    public AudioClip clip;
    public float volume;
}

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    private AudioSource aS;

    [SerializeField]
    private List<AudioFile> audioFiles = new List<AudioFile>();

    private void Awake()
    {
        aS = GetComponent<AudioSource>();

        if (!Instance)
            Instance = this;
        else
            Destroy(this);
    }

    private void Play(string clipName)
    {
        foreach (var AudioFile in audioFiles)
        {
            if (AudioFile.name == clipName)
            {
                aS.PlayOneShot(AudioFile.clip, AudioFile.volume);
                break;
            }
        }
    }
}
