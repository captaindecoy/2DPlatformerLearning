using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 cameraFollowPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > -10)
        {
            transform.position = new Vector3(
                0,
                player.transform.position.y + cameraFollowPosition.y,
                player.transform.position.z + cameraFollowPosition.z);
            //transform.position = player.transform.position + cameraFollowPosition;//new Vector3(0, 3, -8);
        }
    }
}
