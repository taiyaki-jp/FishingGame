using System.Threading;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;

public class quizManager : MonoBehaviour
{
    [SerializeField] private TMP_InputField _inputField;
    private scoreManager _scoreManager;
    private string _quizAnswer;
    private int _missCount;
    private CancellationTokenSource _tokenSource = new CancellationTokenSource();
    private CancellationToken _token;

    private void Start()
    {
        _inputField.onEndEdit.AddListener(End);
        _token = _tokenSource.Token;
        _scoreManager = GameObject.Find("scoreManager").GetComponent<scoreManager>();
    }

    public async UniTask Quiz(float quizTime, string answer,int missCount)
    {
        FieldReset();
        _missCount = missCount;
        _quizAnswer = answer;
        _inputField.gameObject.SetActive(true);
        _inputField.Select();
        var t = 0f;
        while (t < quizTime)
        {
            t += Time.deltaTime;
            await UniTask.Yield(_token);
        }
        Escaped();
    }

    private void End(string answer)
    {
        FieldReset();
        if (answer == _quizAnswer)
            Clear();
        else if (_missCount != 0)
        {
            _missCount--;
            _inputField.Select();
        }
        else
            Escaped();
    }

    private void Escaped()
    {
        FieldReset();
        _inputField.gameObject.SetActive(false);
        Debug.Log("逃げられた");
    }

    private void Clear()
    {
        _tokenSource.Cancel();
        FieldReset();
        _inputField.gameObject.SetActive(false);
        _scoreManager.AddScore(1);
        Debug.Log("釣り上げた");
    }

    private void FieldReset()
    {
        _inputField.text = "";
        _inputField.DeactivateInputField();
        _inputField.ActivateInputField();
    }
}
