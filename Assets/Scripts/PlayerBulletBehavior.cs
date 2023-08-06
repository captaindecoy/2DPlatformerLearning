using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletBehavior : MonoBehaviour
{
    Vector3 target;
    [SerializeField]
    float speed = 6f;
    Vector3 movementVector = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        movementVector = (target - transform.position).normalized * speed;
        movementVector.z = 0f;
        transform.SetParent(null);
    }

    // Update is called once per frame
    void Update()
    {
        //float step = speed * Time.deltaTime;

        // move sprite towards the target location
        //transform.position = Vector2.MoveTowards(transform.position, target, step);
        //Vector3 movementVector
        transform.position += movementVector * Time.deltaTime;
    }

    public void setTarget( Vector3 newTarget)
    {
        target = newTarget;
    }
}
