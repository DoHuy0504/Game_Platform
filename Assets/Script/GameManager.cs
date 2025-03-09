using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    private int _score = 0;
    [SerializeField] TextMeshProUGUI _scoreText;
    [SerializeField] GameObject gameOverUI;
    [SerializeField] GameObject gameWinUI;
    bool isGameOver = false;
    bool isGameWin = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        updateScore();
        gameOverUI.SetActive(false);
        gameWinUI.SetActive(false);
    }

    public void AddScore(int score)
    {
        if (!isGameOver && !isGameWin) // Chỉ thêm điểm khi game chưa kết thúc
        {
            _score += score;
            updateScore();
        }
    }
    private void updateScore()
    {
        _scoreText.text = _score.ToString();
    }
    public void GameOver()
    {
        isGameOver = true;
        _score = 0;
        Time.timeScale = 0; // để người chơi kh thể bấm phím nào khác
        gameOverUI.SetActive(true);
    }
    public void restarGame()
    {
        isGameOver = false; 
        _score = 0;
        updateScore();
        Time.timeScale = 1;
        SceneManager.LoadScene("Game");
    }
    public bool IsGameOver()
    {
        return isGameOver;
    }
    public void GameWin()
    {
        isGameWin = true;
        Time.timeScale = 0; // để người chơi kh thể bấm phím nào khác
        gameWinUI.SetActive(true);
    }
    public bool IsGameWin()
    {
        return isGameWin;
    }
    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
    }
}
