using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    public int jumpVelocity;
    public GameObject floorPrefab;
    float maxVelocity = 20f;
    Vector2 maxVelocityVector;
    public Animator anim;
    [SerializeField]
    float maxFallingSpeed;
    [SerializeField]
    GameObject spawner;
    Enemy2_Spawn enemy2Spawn;

    //private static readonly int Jump = Animator.StringToHash("Base Layer.Player_Jump");
    private static readonly int Idle = Animator.StringToHash("Player_Idle");
    private static readonly int Jump = Animator.StringToHash("Player_Jump");

    void Start()
    {
        // Tried in awake but had no reference to SaveData yet
        //anim = gameObject.GetComponent<Animator>();
        transform.position = SaveData.Instance.lastCheckpoint;
        maxVelocityVector = new Vector2(0, maxVelocity);
        enemy2Spawn = spawner.GetComponent<Enemy2_Spawn>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (rigidBody.velocity.y < 0)
        {
            anim.CrossFade(Idle, 0, 0);
        }
        */
        //Debug.Log(rigidBody.velocity.y);
        //anim.Play("Base Layer.anim3", 0, 0);
        //Debug.Log(anim.GetAnimatorTransitionInfo(0));
        if (Input.GetButtonDown("Jump"))
        {
            //anim.CrossFade(Jump, 0, 0);
            //anim.SetFloat("Speed", 1); //THIS WORKS
            anim.CrossFade(Jump, 0, 0);
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
        /*
        if (rigidBody.velocity.y < 0)
        {
            anim.SetFloat("Speed", rigidBody.velocity.y);
        }
        */
        //Debug.Log(rigidBody.velocity.y);
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            //SceneManager.LoadScene("SampleScene");
        }

        if (transform.position.y < -30)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            //SceneManager.LoadScene("SampleScene");
        }

        
        if (rigidBody.velocity.y < maxFallingSpeed)
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, maxFallingSpeed);
        }

        //Debug.Log("Y Velocity: " + rigidBody.velocity.y);
        
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
        if (collision.CompareTag("Enemy"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            //SceneManager.LoadScene("Level1-1");
        }
        //Debug.Log("Trigger!");
        if (collision.CompareTag("Checkpoint"))
        //if (collision.gameObject.layer == 7) // TODO: Change to Tag I think
        {
            SaveData.Instance.lastCheckpoint = collision.transform.position;
            var spawnPoint = new Vector3(transform.position.x,
                                    transform.position.y - 1.5f,
                                    transform.position.z);
            Object.Instantiate(floorPrefab, spawnPoint, transform.localRotation);
            Object.Destroy(collision.gameObject);
            rigidBody.velocity = Vector2.zero;
        }

        if (collision.gameObject.CompareTag("Key"))
        {
            //Debug.Log("Key!");
            Object.Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Goal"))
        {
            //Debug.Log("Goal!");
            GoalBehavior gb = collision.GetComponent<GoalBehavior>();
            SaveData.Instance.lastCheckpoint = Vector3.zero;
            //gb.loadNextScene();
            if (SceneManager.GetActiveScene().name == "Level1-1")
            {
                SceneManager.LoadScene("Level1-2"); //made this change due to build issue
            }
            else if (SceneManager.GetActiveScene().name == "Level1-2")
            {
                SceneManager.LoadScene("Level1-3"); //made this change due to build issue
            }
        }

        if (collision.gameObject.CompareTag("BottomWarp"))
        {
            ConnectedWarp warp = collision.gameObject.GetComponent<ConnectedWarp>();
            GameObject otherWarp = warp.getTopWarp();
            transform.position = new Vector3(otherWarp.gameObject.transform.position.x, otherWarp.gameObject.transform.position.y - 1f);
            //transform.position = new Vector3(transform.position.x, 6f, transform.position.z);
        }

        if (collision.gameObject.CompareTag("TopWarp"))
        {
            ConnectedWarp warp = collision.gameObject.GetComponent<ConnectedWarp>();
            GameObject otherWarp = warp.getTopWarp();
            transform.position = new Vector3(otherWarp.gameObject.transform.position.x, otherWarp.gameObject.transform.position.y + 1f);
            //transform.position = new Vector3(transform.position.x, 6f, transform.position.z);
        }

        if (collision.gameObject.CompareTag("Coin"))
        {
            enemy2Spawn.score += 100;
            Object.Destroy(collision.gameObject);
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
