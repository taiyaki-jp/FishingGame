using Cysharp.Threading.Tasks;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    private Sliders[] _sliders=new Sliders[2];//BP,GSの順番
    private int _battlePhase = 0;//0=待ち　1=逃げ　2＝暴れ


    private void Start()
    {
        _sliders[0] = GameObject.Find("BPSlider").GetComponent<Sliders>();
        _sliders[1] = GameObject.Find("GSSlider").GetComponent<Sliders>();
    }

    public async UniTask BattleStart(FishStates fish)
    {
        //バトル開始
        _battlePhase = 1;
        foreach (var slider in _sliders)
        {
            slider.SetPhase(fish, _battlePhase);
        }

        await PhaseOne();
    }

    private async UniTask PhaseOne()
    {
        await UniTask.Yield();
    }
}
