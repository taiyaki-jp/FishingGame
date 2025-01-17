using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private BattleManager _battleManager;
    private Fish _fish;
    void Update()
    {
        this.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonUp(0))
            if (_fish != null)
            {
                _battleManager.BattleStart(_fish.thisStates);
                Debug.Log($"{_fish.thisStates.name}が釣れた!");
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
