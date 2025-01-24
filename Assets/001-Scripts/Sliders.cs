using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Sliders : MonoBehaviour
{
    private Slider _slider;
    [SerializeField]private float _moveSpeed=0.01f;
    private float _sliderValue;//横位置
    public float SliderValue=>_sliderValue;
    private int _moveInt;//BPの方(横位置)が変わる頻度
    private int _moveFrequently;//初期値保持
    private int _phase = 0;//0=待ち　1=逃げ　2＝暴れ

    private void Awake()
    {
        _slider=GetComponent<Slider>();
    }

    public void SetPhase(FishStates fish,int phase)
    {
        _phase = phase;
        if (_phase == 1) BattleStart(fish);
    }

    private void BattleStart(FishStates fish)
    {
        _moveFrequently = fish.move_Frequently;
        _sliderValue = 0;
        _moveInt = _moveFrequently;
        _ = BPSliderUpdate();
    }

    private async UniTaskVoid BPSliderUpdate()
    {
        var moving = false;
        var target=0f;
        while (_phase == 1)
        {

            _moveInt -= Random.Range(0, 11);

            if (_moveInt <= 0)
            {
                moving = true;
                target = Random.Range(_slider.minValue,_slider.maxValue); //移動先設定
            }

            while (moving && _phase == 1)
            {
                if (Mathf.Abs(_sliderValue - target) >= 0.05f)
                {
                    if (_sliderValue < target) _sliderValue += _moveSpeed;
                    else _sliderValue -= _moveSpeed;

                    _slider.value = _sliderValue; //値を反映
                }
                else
                {
                    moving = false;
                    _moveInt = _moveFrequently; //初期化
                }
                await UniTask.Yield();
            }

            await UniTask.Delay(1);
        }
    }
}
