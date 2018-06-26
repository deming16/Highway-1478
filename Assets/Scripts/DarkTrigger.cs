using UnityEngine;

public class DarkTrigger : MonoBehaviour {

    public GameManager gameManager;

    void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            gameManager.TurnDark();
        }
    }
}
