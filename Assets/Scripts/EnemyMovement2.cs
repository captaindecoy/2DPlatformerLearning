using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement2 : MonoBehaviour
{
    public int startingDirection;
    public int speed;
    public int xMin = -6;
    public int xMax = 6;
    //bool enabled = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (enabled)
        //{
        /*
            gameObject.transform.position += new Vector3(speed * startingDirection * Time.deltaTime, 0, 0);
            if (gameObject.transform.position.x > xMax)
            {
                startingDirection = -1;
            }
            if (gameObject.transform.position.x < xMin)
            {
                startingDirection = 1;
            }
        */
        //}
        if (transform.position.x > 15 || transform.position.x < -15)
        {
            Object.Destroy(gameObject);
        }
    }

	private void FixedUpdate()
	{
        gameObject.transform.position += new Vector3(speed * startingDirection * Time.deltaTime, 0, 0);
    }

    /*
	private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, 0.75f);
        //Gizmos.DrawSphere(transform.position, xDirection);
        Gizmos.DrawLine(new Vector3(xMin, transform.position.y), new Vector3(xMax, transform.position.y));

    }
    */
}
