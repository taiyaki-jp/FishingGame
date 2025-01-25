using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class BPPlayerSlider : MonoBehaviour
{
    private Slider _slider;
    public float SliderValue=>_slider.value;
    private int _phase=0;

    private Vector2 _inputValue;
    public Vector2 InputValue
    {
        set => _inputValue = value;
    }


    private void Awake()
    {
        _slider=GetComponent<Slider>();
    }

    public void SetPhase(int phase)
    {
        _phase = phase;
        if (_phase == 1) BattleStart();
    }

    private void BattleStart()
    {
        _slider.value = 0;
        _ = BPPlayerSliderUpdate();
    }


    private async UniTask BPPlayerSliderUpdate()
    {
        float value=0;
        while (_phase==1)
        {
            if (Mathf.Abs(_inputValue.y)<=1&&_inputValue.x!=0) value=_inputValue.x;//コントローラー用 x != 0 コントローラーのときはx=0がありえない
            else
            {
                value+=_inputValue.y/20*Time.deltaTime;//マウスホイール用
            }
            value=Mathf.Clamp(value,_slider.minValue,_slider.maxValue);
            _slider.value=value;
            await UniTask.Yield();
        }
    }

}
