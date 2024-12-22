using UnityEngine;

public class CloudScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime);
        if(transform.position.x < -10)
        {
            transform.position = new Vector2(10, transform.position.y);
        }
    }
}
