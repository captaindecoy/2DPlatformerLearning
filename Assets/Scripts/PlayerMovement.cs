using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    public int jumpVelocity;
    public GameObject floorPrefab;
    float maxVelocity = 20f;
    Vector2 maxVelocityVector;
    public Animator anim;

    void Start()
    {
        // Tried in awake but had no reference to SaveData yet
        //anim = gameObject.GetComponent<Animator>();
        transform.position = SaveData.Instance.lastCheckpoint;
        maxVelocityVector = new Vector2(0, maxVelocity);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(rigidBody.velocity.y);
        //anim.Play("Base Layer.anim3", 0, 0);
        //Debug.Log(anim.GetAnimatorTransitionInfo(0));
        if (Input.GetButtonDown("Jump"))
        {
            anim.SetFloat("Speed", jumpVelocity);
            //anim.Play("anim");
            if (rigidBody.velocity.y + jumpVelocity < maxVelocity)
            {
                //rigidBody.velocity += Vector2.up * jumpVelocity;
                rigidBody.AddForce(Vector2.up * jumpVelocity, ForceMode2D.Impulse);
            }
            else
            {
                //anim.SetFloat("Speed", 0);
                rigidBody.velocity = new Vector2(0, maxVelocity);
            }
            
            //Debug.Log("Velocity: " + rigidBody.velocity.y);
        }
        anim.SetFloat("Speed", rigidBody.velocity.y);
        //Debug.Log(rigidBody.velocity.y);
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("SampleScene");
        }

        if (transform.position.y < -30)
        {
            SceneManager.LoadScene("SampleScene");
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        /*
        if (collision.gameObject.layer == 6) // TODO: Change to Tag I think
        {
            SceneManager.LoadScene("Level1-1");
        }
        */
        /*
        if (collision.gameObject.layer == 7) // TODO: Change to Tag I think
        {
            // TODO: Likely something here messing up positioning for respawning
            SaveData.Instance.lastCheckpoint = collision.transform.position;
            var spawnPoint = new Vector3(transform.position.x, 
                                    transform.position.y - 1.5f, 
                                    transform.position.z);
            Object.Instantiate(floorPrefab, spawnPoint, transform.localRotation);
            Object.Destroy(collision.gameObject);
        }
        */

        if (collision.gameObject.CompareTag("Key"))
        {
            Debug.Log("Key!");
            Object.Destroy(collision.gameObject);
        }

    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
        if (collision.CompareTag("Enemy"))
        {
            SceneManager.LoadScene("Level1-1");
        }
        Debug.Log("Trigger!");
        if (collision.CompareTag("Checkpoint"))
        //if (collision.gameObject.layer == 7) // TODO: Change to Tag I think
        {
            // TODO: Likely something here messing up positioning for respawning
            SaveData.Instance.lastCheckpoint = collision.transform.position;
            var spawnPoint = new Vector3(transform.position.x,
                                    transform.position.y - 1.5f,
                                    transform.position.z);
            Object.Instantiate(floorPrefab, spawnPoint, transform.localRotation);
            Object.Destroy(collision.gameObject);
            rigidBody.velocity = Vector2.zero;
        }

        if (collision.gameObject.CompareTag("Goal"))
        {
            Debug.Log("Goal!");
            GoalBehavior gb = collision.GetComponent<GoalBehavior>();
            gb.loadNextScene();
        }
    }

    // This is an experiment with moving floors
	private void OnCollisionStay2D(Collision2D collision)
    {
		GameObject otherObject = collision.gameObject;
        if (otherObject.CompareTag("Floor") 
            && otherObject.transform.position.y < transform.position.y)
        {
			transform.parent = collision.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            transform.parent = null;

        }
    }
}
