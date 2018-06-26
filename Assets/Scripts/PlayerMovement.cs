using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public Rigidbody rb;
    public float fowardForce;
    public Vector3 laneSwitch;

    //variables for switching lanes;
    public float keyDelay = 1f;  // 1 second
    private float timePassed = 0f;


    // Use this for initialization
    void Start() {
        rb.useGravity = false;
    }

    // Update is called once per frame
    void FixedUpdate() {
        rb.AddForce(0, 0, fowardForce * Time.deltaTime);

        timePassed += Time.deltaTime;

        if (timePassed >= keyDelay)
        {
            if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < 3)
            {
                transform.position += laneSwitch * Time.deltaTime;
                timePassed = 0f;
            }

            if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x > -3)
            {
                transform.position -= laneSwitch * Time.deltaTime;
                timePassed = 0f;
            }
        }
    }



}
