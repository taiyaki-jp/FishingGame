using Cysharp.Threading.Tasks;
using UnityEngine;

public class enemyMove : MonoBehaviour
{
    private GameObject player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public async UniTask Move()
    {
        Debug.Log("動くよ");
        while ((player.transform.position-this.transform.position).magnitude>0.1)
        {
            this.transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 0.1f);
            await UniTask.Yield();
        }
        
    }
}
