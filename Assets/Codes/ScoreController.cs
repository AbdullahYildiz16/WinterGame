using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreController : MonoBehaviour
{
    [SerializeField] private TMP_Text inGameScoreText,
        inGameGiftAmountText,
        gameEndScoreText,
        gameEndBestScoreText,
        gameEndGiftText;
    [SerializeField] private GameObject gameEndPanel, gameEndBG;
    [SerializeField] private GameObject character;
    public AudioController audioController;
    public Animator handAnimator;
    private int score;
    private int giftAmount;
    private int bestScore;

    private void Start()
    {
        score = 0;
        giftAmount = 0;
        bestScore = PlayerPrefs.GetInt("bestScore", 0);
        RefreshScoreUI();
        RefreshGiftUI();
    }
    public void IncreaseScore()
    {
        score++;
        RefreshScoreUI();
        CheckBestScore();
        audioController.PlayWinPointSound();
    }
    public void DecreaseScore()
    {
        score--;
        RefreshScoreUI();
        audioController.PlayLosePointSound();
    }

    public void IncreaseGiftAmount()
    {
        giftAmount++;
        RefreshGiftUI();
        
    }
    void CheckBestScore()
    {
        if (score <= bestScore) return;
        bestScore = score;
        PlayerPrefs.SetInt("bestScore", bestScore);
    }
    void RefreshScoreUI() => inGameScoreText.text = score.ToString();
    
    void RefreshGiftUI() => inGameGiftAmountText.text = giftAmount.ToString();

    public void SetGameEnd()
    {
        character.SetActive(false);
        gameEndScoreText.text = score.ToString();
        gameEndGiftText.text = giftAmount.ToString();
        gameEndBestScoreText.text = "Best: " + bestScore;
        StartCoroutine(playGameEndSound());
        
    }
    IEnumerator playGameEndSound()
    {
        audioController.PlayCrashGameSound();
        yield return new WaitForSeconds(1.5f);
        audioController.PlayGameEndSound();
        gameEndPanel.SetActive(true);
        gameEndBG.SetActive(true);
    }

    public void ReturnMainMenu() => SceneManager.LoadScene(0);
    
    public void PlayHandAnimation()
    {
        handAnimator.Play("hand_Anim 0");
    }
}
