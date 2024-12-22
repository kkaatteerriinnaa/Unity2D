using UnityEngine;

public class TriangleScript : MonoBehaviour
{
    private Rigidbody2D rb2d;   // посилання на компонент

    void Start()
    {
        Debug.Log("TriangleScript Starts");
        rb2d = GetComponent<Rigidbody2D>();   // шукаємо серед компонентів
    }
    
    void Update()
    {
        // Формуємо вектор напряму сили в залежності від натиснених кнопок
        Vector2 forceDirection = Vector2.zero;
        // неперервне управління (затискання кнопок)
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
            rb2d.AddForce(forceDirection * 3);
        }
        /*
        // імпульсне управління (багаторазове натискання)
        if (Input.GetKeyDown(KeyCode.UpArrow))
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

/* Д.З. Фізичне управління
 * - забезпечити "кордони" ігрового поля (додати стіни, стелю)
 * - додати всі напрями прикладання сили до об'єкта
 * - реалізувати "скидання" сили кнопкою "ESC" за якої 
 *    обнулюються rb2d.linearVelocity та rb2d.angularVelocity
 * - прикласти відеозапис роботи проєкту
 */