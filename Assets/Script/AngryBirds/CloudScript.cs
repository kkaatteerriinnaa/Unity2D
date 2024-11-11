using UnityEngine;

public class CloudScript : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime);
        if(transform.position.x < -10)
        {
            transform.position = new Vector2(10, transform.position.y);
        }
    }
}
