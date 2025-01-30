using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    [SerializeField] private float _BPDistance;
    [SerializeField] private float _GSDistance;

    private Sliders[] _sliders=new Sliders[2];//BP,GSの順番
    private int _battlePhase = 0;//0=待ち　1=逃げ　2＝暴れ
    private GSPlayerSlider _GSPlayerSlider;
    private BPPlayerSlider _BPPlayerSlider;

    private int _distance=300;
    [SerializeField]private TextMeshProUGUI _distanceText;


    private void Start()
    {
        _sliders[0] = GameObject.Find("BPSlider").GetComponent<Sliders>();
        _sliders[1] = GameObject.Find("GSSlider").GetComponent<Sliders>();
        _GSPlayerSlider = GameObject.Find("GSPlayerSlider").GetComponent<GSPlayerSlider>();
        _BPPlayerSlider = GameObject.Find("BPPlayerSlider").GetComponent<BPPlayerSlider>();
    }

    public async UniTask BattleStart(FishStates fish)
    {
        //バトル開始
        _battlePhase = 1;
        _distance = 300;
        _distanceText.text = _distance.ToString();
        foreach (var slider in _sliders)
        {
            slider.SetPhase(fish, _battlePhase);
        }
        _BPPlayerSlider.SetPhase(_battlePhase);
        _GSPlayerSlider.SetPhase(_battlePhase);

        await PhaseOne();
    }

    private async UniTask PhaseOne()
    {
        var BPEnemy = _sliders[0].SliderValue;
        var BPPlayer = _BPPlayerSlider.SliderValue;
        var BPDistance=Mathf.Abs(BPEnemy-BPPlayer);

        var GSEnemy= _sliders[1].SliderValue;
        var GSPlayer = _GSPlayerSlider.SliderValue;
        var GSDistance=Mathf.Abs(GSEnemy-GSPlayer);

        if (BPDistance < _BPDistance && GSDistance < _GSDistance)
        {
            _distance--;
            _distance=Mathf.Max(_distance,0);
            _distanceText.text = _distance.ToString();
        }

        await UniTask.Yield();
    }
}
