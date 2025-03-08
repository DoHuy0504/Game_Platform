using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    private int _score = 0;
    [SerializeField] TextMeshProUGUI _scoreText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        updateScore();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void AddScore(int score)
    {
        _score += score;
        updateScore(); // mỗi khi tính điểm xog thì sẽ gọi phương thức này
    }
    private void updateScore()
    {
        _scoreText.text = _score.ToString();
    }
}
