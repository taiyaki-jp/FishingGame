using TMPro;
using UnityEngine;

public class scoreManager : MonoBehaviour
{
    private TextMeshProUGUI scoreText;
    private TextMeshProUGUI timeText;
    private int _score;

    private void Start()
    {
        _score = 0;
    }

    public void AddScore(int score)
    {
        _score += score;
    }
}
