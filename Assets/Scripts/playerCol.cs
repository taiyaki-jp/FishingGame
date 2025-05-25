using UnityEngine;

public class playerCol : MonoBehaviour
{
    private Collider2D _collider;
    void Start()
    {
        _collider = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        enemyMove enemy = collision.gameObject.GetComponent<enemyMove>();
        _ = enemy.Move();
    }
}
