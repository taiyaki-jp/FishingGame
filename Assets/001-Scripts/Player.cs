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
                Debug.Log($"{nowHit.GetComponent<Fish>().thisStates.name}Ç™íﬁÇÍÇΩ!");
            }
            else
            {
                Debug.Log("âΩÇ‡Ç©Ç©Ç¡ÇƒÇ¢Ç»Ç¢Åc");
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
        //Debug.Log("ó£ÇÍÇΩ");
    }
}
