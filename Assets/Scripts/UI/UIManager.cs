using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("Refs")]
    public Slider hpBar;
    public Slider expBar;
    public TextMeshProUGUI waveText;
    public TextMeshProUGUI scoreText;
    public GameObject gameOverPanel;

    public void UpdateHUD(int hp, int lv, int exp, int wave, int score)
    {
        hpBar.value = hpBar.maxValue > 0 ? hp : hpBar.value;
        expBar.value = exp; // ไว้ค่อยแม็ปกับ nextLevelExp จริง ๆ
        waveText.text = $"Wave : {wave}";
        scoreText.text = $"Score : {score}";
    }

    public void ShowGameOver(int score)
    {
        gameOverPanel.SetActive(true);
        scoreText.text = $"Score: {score}";
    }
}
