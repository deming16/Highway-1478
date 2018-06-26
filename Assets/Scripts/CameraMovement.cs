using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public bool flipEnter = false;
    public bool flipExit = false;
    public float speed;
    public float startTime;
    private Quaternion unflipped = Quaternion.Euler(0, 0, 0);
    private Quaternion flipped = Quaternion.Euler(0, 0, 180f);

    private void Update()
    {
        if (flipEnter == true)
        {
            transform.rotation = Quaternion.Slerp(unflipped, flipped, (Time.time - startTime) * speed);
            if (transform.rotation == flipped)
            {
                flipEnter = false;
            }
        }

        if (flipExit == true)
        {
            transform.rotation = Quaternion.Slerp(flipped, unflipped, (Time.time - startTime) * speed);
            if (transform.rotation == unflipped)
            {
                flipExit = false;
            }
        }
    }

}
