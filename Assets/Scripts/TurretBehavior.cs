using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBehavior : MonoBehaviour
{
    public GameObject bulletPrefab;
    //[SerializeField]
    public float xDirection = 0;
    public float fireRate;
    float fireRateTimer;
    // Start is called before the first frame update
    void Start()
    {
        fireRateTimer = fireRate;
    }

    // Update is called once per frame
    void Update()
    {
        if (fireRateTimer > 0)
        {
            fireRateTimer -= Time.deltaTime;
        }
        else
        {
            // Cast a ray right.
            // RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right);
            RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(xDirection, 0));

            // If it hits something...
            if (hit.collider != null)
            {
                if (hit.collider.gameObject.layer == 0)
                {
                    //Debug.Log("Raycast hit! X: " + hit.point.x + " Y: " + hit.point.y);
                    fireRateTimer = fireRate;
                    var bullet = Object.Instantiate(bulletPrefab, transform.position, transform.rotation);
                    var bulletScript = bullet.GetComponent<BulletBehavior>();
                    bulletScript.xDirection = xDirection;
                }
            }
        }
    }

	private void OnDrawGizmosSelected()
	{
        Gizmos.color = new Color(1, 1, 0, 0.75f);
        //Gizmos.DrawSphere(transform.position, xDirection);
        Gizmos.DrawLine(new Vector3(-6, transform.position.y), new Vector3(6, transform.position.y));

    }
}
