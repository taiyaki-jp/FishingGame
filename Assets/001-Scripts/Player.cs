using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private BattleManager _battleManager;
    private GSPlayerSlider _GSSlider;
    private BPPlayerSlider _BPSlider;
    private FishingInput _input;
    private Fish _fish;

    private void Start()
    {
        _input = new FishingInput();
        _input.Enable();
        _GSSlider = GameObject.Find("GSPlayerSlider").GetComponent<GSPlayerSlider>();
        _BPSlider = GameObject.Find("BPPlayerSlider").GetComponent<BPPlayerSlider>();
    }

    void Update()
    {
        this.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _BPSlider.InputValue = _input.Player.BP.ReadValue<Vector2>();
        _GSSlider.InputValue = _input.Player.GS.ReadValue<float>();

        if (Input.GetMouseButtonUp(0))
            if (_fish != null)
            {
                _ = _battleManager.BattleStart(_fish.thisStates);
                Debug.Log($"{_fish.thisStates.name}がかかった!");
            }
            else
            {
                Debug.Log("何もかかっていない…");
            }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        _fish = collision.GetComponent<Fish>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _fish = null;
    }
}
