using UnityEngine;

public class Player : MonoBehaviour
{
    private GameObject nowHit;
    void Update()
    {
        this.transform.position=Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonUp(0))
            if (nowHit != null)
            {
                Debug.Log($"{nowHit.GetComponent<Fish>().thisStates.name}���ނꂽ!");
            }
            else
            {
                Debug.Log("�����������Ă��Ȃ��c");
            }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        nowHit=collision.gameObject;
        //Debug.Log(nowHit.name);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        nowHit = null;
        //Debug.Log("���ꂽ");
    }
}
