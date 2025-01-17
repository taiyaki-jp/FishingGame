using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    [SerializeField]private Slider _GSSlider;
    [SerializeField]private Slider _BPSlider;

    private FishStates _enemyFish;

    private float _GSSliderValue;//引きの強さ
    private float _BPSliderValue;//横位置

    private int _GSMoveInt;//原神の方(引きの強さ)が変わる頻度
    private int _BPMoveInt;//BPの方(横位置)が変わる頻度
    private int _battleInt;//特殊行動頻度

    private int _moveFrequently;//初期値保持
    private int _battleFrequently;//初期値保持

    private float _GSTarget;
    private float _BPTarget;

    private int _battlePhase = 0;//0=待ち　1=逃げ　2＝暴れ

    public void BattleStart(FishStates fish)
    {
        _moveFrequently = fish.move_Frequently;
        _battleFrequently = fish.battle_Frequently;

        //各数値初期化
        _BPSliderValue = 0;
        _GSSliderValue = 0;
        _enemyFish = fish;
        _GSMoveInt = _moveFrequently;
        _BPMoveInt = _moveFrequently;
        _battleInt = _battleFrequently;

        //バトル開始
        _battlePhase = 1;
        BPSliderUpdate();
    }

    private async UniTaskVoid BPSliderUpdate()
    {
        bool moveing = false;
        while (_battlePhase == 1)
        {

            _BPMoveInt -= Random.Range(0, 11);

            if (_BPMoveInt <= 0)
            {
                moveing = true;
                _BPTarget = Random.Range(-1.0f, 1.0f); //移動先設定
            }

            while (moveing)
            {
                if (Mathf.Abs(_BPSliderValue - _BPTarget) >= 0.05f)
                {
                    if (_BPSliderValue < _BPTarget) _BPSliderValue += 0.01f;
                    else _BPSliderValue -= 0.01f;

                    _BPSlider.value = _BPSliderValue; //値を反映
                }
                else
                {
                    moveing = false;
                    _BPMoveInt = _moveFrequently; //初期化
                }
                await UniTask.Yield();
            }

            await UniTask.Delay(1);
        }
    }

    private async UniTaskVoid GSSliderUpdate()
    {
        if (_GSMoveInt < 0) _GSTarget = Random.Range(0, 6);//変動先設定
        else _GSMoveInt -= Random.Range(0, 11);
        
        if (Mathf.Abs(_GSSliderValue-_GSTarget)<0.1f)
        {
            if (_GSSliderValue < _GSTarget) _GSSliderValue += 0.1f;
            else _GSSliderValue -= 0.1f;

            _GSSlider.value = _GSSliderValue;//値を反映
        }
        else _GSMoveInt = _moveFrequently;//初期化
        await UniTask.Yield();
    }
}
