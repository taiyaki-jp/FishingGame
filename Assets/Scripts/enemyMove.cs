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
            this.transform.position =
                Vector3.MoveTowards(transform.position, player.transform.position, Time.deltaTime * 3f);
            await UniTask.Yield();
        }
        this.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, this.transform.position.z);
        var quizManager = GameObject.Find("Canvas").GetComponent<quizManager>();
        _ = quizManager.Quiz(10f,"まぐろ",3);
    }
}
