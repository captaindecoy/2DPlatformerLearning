using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    [SerializeField]
    GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 5f;
        //Debug.Log(mousePos);
       // mousePos.z = Camera.main.nearClipPlane;
        //transform.position = Camera.main.ScreenToWorldPoint(mousePos);
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        //Debug.Log(worldPos);
        //transform.position = new Vector3(worldPos.x, worldPos.y, 0);
        transform.rotation = Quaternion.LookRotation(Vector3.forward, worldPos - transform.position);

        if (Input.GetMouseButtonDown(0))
        {
            GameObject newBullet = Object.Instantiate(bullet, transform);
            PlayerBulletBehavior playerBulletBehavior = newBullet.GetComponent<PlayerBulletBehavior>();
            playerBulletBehavior.setTarget(worldPos);
            Debug.Log("Left mouse down");
        }
    }
}
