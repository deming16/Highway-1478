using UnityEngine;

public class SpeedCapTrigger : MonoBehaviour
{

    public GameObject player;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            player.GetComponent<PlayerMovement>().fowardForce = 0f;
        }
    }

}
