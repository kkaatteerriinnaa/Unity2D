using UnityEngine;

public class BirdScript : MonoBehaviour
{
    //[SerializeField]
    private Transform arrow;
    private Rigidbody2D rb2d;
    private Vector2 startPosition;
    private Quaternion startRotation;

    [SerializeField]
    private float actionTimeout = 5.0f;
    private float actionTime;

    //private Vector3 startPosition;
    
    void Start()
    {
        arrow = GameObject.Find("Arrow").transform;
        rb2d = GetComponent<Rigidbody2D>();
        GameState.isBirdFly = false;
        startPosition = transform.position;
        startRotation = transform.rotation;
        actionTime = 0.0f;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && !GameState.isBirdFly && Time.timeScale != 0)
        {
            float forceMagnitude = 500f + GameState.birdForceFactor * 500f;
            rb2d.AddForce(forceMagnitude * arrow.right);
            GameState.isBirdFly = true;
            actionTime = actionTimeout;
        }

        if (actionTime > 0)
        {
            actionTime -= Time.deltaTime;
            if (actionTime <= 0)
            {
                this.transform.position = startPosition; 
                this.transform.rotation = startRotation;
                rb2d.linearVelocity = Vector3.zero;
                rb2d.angularVelocity = 0f;
                GameState.isBirdFly = false;
            }
        }
    }
    /*void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        startPosition = transform.position; 
        isOnStart = true;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && isOnStart && Time.timeScale != 0)
        {
            float forceMagnitude = 500f + GameState.birdForceFactor * 500f;
            rb2d.isKinematic = false; 
            rb2d.AddForce(forceMagnitude * arrow.right);
            isOnStart = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ResetBird();
        }
    }

    private void ResetBird()
    {
        transform.position = startPosition;
        rb2d.linearVelocity = Vector2.zero;
        rb2d.angularVelocity = 0f; 
        rb2d.isKinematic = true; 
        isOnStart = true; 
    }*/
}