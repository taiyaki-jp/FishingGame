using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class GSPlayerSlider : MonoBehaviour
{
    private Slider _slider;
    [SerializeField] private float _speed=0.1f;
    public float SliderValue=>_slider.value;
    private int _phase=0;

    private float _inputValue;
    public float InputValue
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
        _ = GSPlayerSliderUpdate();
    }

    private async UniTask GSPlayerSliderUpdate()
    {
        float value=2.5f;
        while (_phase == 1)
        {
            if((int)_inputValue==1)value += _speed*Time.deltaTime;
            else              value -= _speed*Time.deltaTime;
            value=Mathf.Clamp(value,_slider.minValue,_slider.maxValue);
            _slider.value=value;
            await UniTask.Yield();
        }
    }
}
