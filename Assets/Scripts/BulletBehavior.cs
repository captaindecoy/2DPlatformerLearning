using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    [SerializeField]
    float speed = 2f;
    //[SerializeField]
    public float xDirection = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
	{
		transform.position += new Vector3(xDirection, 0, 0) * Time.deltaTime * speed;
        //transform.position = transform.position + new Vector3(1, 0, 0);
        if (transform.position.x > 20 || transform.position.x < -20)
        {
            Object.Destroy(gameObject);
        }
    }
}
