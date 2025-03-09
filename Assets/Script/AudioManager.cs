using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource _backGroundAudioSource;
    [SerializeField] AudioSource _effectAudioSource;

    [SerializeField] AudioClip _backGroundClip;
    [SerializeField] AudioClip _jumClip;
    [SerializeField] AudioClip _coinClip;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayBackgroundMusic();
    }

    public void PlayBackgroundMusic()
    {
        _backGroundAudioSource.clip = _backGroundClip;
        _backGroundAudioSource.Play();
    }
    public void CoinSound()
    {
        _effectAudioSource.PlayOneShot(_coinClip);
    }
    public void JumpSound()
    {
        _effectAudioSource.PlayOneShot(_jumClip);
    }
}
