using UnityEngine;

public enum GameState { Playing, Paused, GameOver }

public class GameManager : MonoBehaviour
{
    public static GameManager I { get; private set; }

    public GameState state = GameState.Playing;
    public WaveManager waveMgr;
    public UIManager ui;
    public Player player;
    public int score;

    void Awake()
    {
        I = this;
        StartGame();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void StartGame()
    {
        state = GameState.Playing;
        score = 0;
        ui.UpdateHUD(player.hp, player.lv, player.exp, waveMgr.WaveIndex, score);
        waveMgr.StartNextWave();
    }

    public void End()
    {
        if (state == GameState.GameOver) return;
        state = GameState.GameOver;
        waveMgr.StopWave();
        ui.ShowGameOver(score);
    }

    public void Restart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }
}
