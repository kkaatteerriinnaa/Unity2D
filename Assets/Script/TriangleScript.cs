using UnityEngine;

public class TriangleScript : MonoBehaviour
{
    private Rigidbody2D rb2d;
    void Start()
    {
        Debug.Log("TriangleScript Starts");
        rb2d = GetComponent<Rigidbody2D>(); 
    }

    void Update()
    {
        Vector2 forceDirection = Vector2.zero;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            forceDirection += Vector2.up;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            forceDirection += Vector2.left;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            forceDirection += Vector2.right;
        }
        if (forceDirection != Vector2.zero)
        {
            rb2d.AddForce(forceDirection * 4);
        }
        /*
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            forceDirection += Vector2.up;  
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            forceDirection += Vector2.left;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            forceDirection += Vector2.right;
        }
        if (forceDirection != Vector2.zero)
        {
            rb2d.AddForce(forceDirection * 100);
        }*/

    }
}
