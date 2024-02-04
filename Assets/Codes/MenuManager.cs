using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject infoPanel;
    [SerializeField] private Image musicImg, soundImg;
    [SerializeField] private Sprite musicOnSprite, musicOffSprite, soundOnSprite, soundOffSprite;
    [SerializeField] private AudioController audioController;
    private AudioSO audioSo;

    private void Start()
    {
        audioSo = audioController.audioSo;
        RefreshMusicUI();
        RefreshSoundUI();
    }

    #region OnClicks
    public void OnPlayBtnClicked()
    {
        SceneManager.LoadScene(1);
    }

    public void OnMusicBtnClicked()
    {
        if (audioSo.isMusicOn)
        {
            audioSo.isMusicOn = false;
            musicImg.sprite = musicOffSprite;
        }
        else
        {
            audioSo.isMusicOn = true;
            musicImg.sprite = musicOnSprite;
        }
        audioController.RefreshMusicStat();
    }

    public void OnSoundBtnClicked()
    {
        if (audioSo.isSoundOn)
        {
            audioSo.isSoundOn = false;
            soundImg.sprite = soundOffSprite;
        }
        else
        {
            audioSo.isSoundOn = true;
            soundImg.sprite = soundOnSprite;
        }
        audioController.RefreshSoundStat();
    }
    public void OnInfoBtnClicked() =>  infoPanel.SetActive(!infoPanel.activeInHierarchy);
    public void OnExitBtnClicked() => Application.Quit();
    #endregion
    
    void RefreshMusicUI() => musicImg.sprite = audioSo.isMusicOn ? musicOnSprite : musicOffSprite;
    void RefreshSoundUI() => soundImg.sprite = audioSo.isSoundOn ? soundOnSprite : soundOffSprite;


}
