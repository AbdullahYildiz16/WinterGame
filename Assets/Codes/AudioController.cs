using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSO audioSo;
    [SerializeField] private AudioSource musicAudioSource, soundAudioSource;
    [SerializeField] private AudioClip throwingGiftSound, winPointSound, losePointSound, gameEndSound;
    [SerializeField] private AudioClip crashGameSound;
    private float startMusicVolume, startSoundVolume;

    private void Start()
    {
        startMusicVolume = musicAudioSource.volume;
        startSoundVolume = soundAudioSource.volume;
        RefreshMusicStat();
        RefreshSoundStat();
    }

    public void RefreshMusicStat() => musicAudioSource.volume = audioSo.isMusicOn ? startMusicVolume : 0;
    public void RefreshSoundStat() => soundAudioSource.volume = audioSo.isSoundOn ? startSoundVolume : 0;

    public void PlayThrowingGiftSound() => soundAudioSource.PlayOneShot(throwingGiftSound);
    public void PlayWinPointSound() => soundAudioSource.PlayOneShot(winPointSound);
    public void PlayLosePointSound() => soundAudioSource.PlayOneShot(losePointSound);
    public void PlayCrashGameSound() => soundAudioSource.PlayOneShot(crashGameSound);
    public void PlayGameEndSound() => soundAudioSource.PlayOneShot(gameEndSound);
    


}
