using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Audio Sources")]
    [SerializeField] private AudioSource effectAudioSource;
    [SerializeField] private AudioSource defaultAudioSource;
    [SerializeField] private AudioSource bossAudioSource;

    [Header("Audio Clips")]
    [SerializeField] private AudioClip shootClip;
    [SerializeField] private AudioClip energyClip;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // Tự đổi nhạc theo scene
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Home" || scene.name == "Level1")
        {
            PlayDefaultSound();
        }
        else if (scene.name == "Level2")
        {
            PlayBossSound();
        }
    }

    // ---------- SFX ----------
    public void PlayShootSound()
    {
        effectAudioSource.PlayOneShot(shootClip);
    }

    public void PlayEnergySound()
    {
        effectAudioSource.PlayOneShot(energyClip);
    }

    // ---------- MUSIC ----------
    public void PlayBossSound()
    {
        if (!bossAudioSource.isPlaying)
            bossAudioSource.Play();

        defaultAudioSource.Stop();
    }

    public void PlayDefaultSound()
    {
        if (!defaultAudioSource.isPlaying)
            defaultAudioSource.Play();

        bossAudioSource.Stop();
    }

    public void StopAllSounds()
    {
        defaultAudioSource.Stop();
        bossAudioSource.Stop();
        effectAudioSource.Stop();
    }
}
