using UnityEngine;

public class BirdScript : MonoBehaviour
{
    [SerializeField]
    private Transform arrow;
    private Rigidbody2D rb2d;
    private bool isOnStart;

    private Vector3 startPosition; // Змінна для збереження стартової позиції

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        startPosition = transform.position; // Зберігаємо стартову позицію
        isOnStart = true;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && isOnStart && Time.timeScale != 0)
        {
            float forceMagnitude = 500f + GameState.birdForceFactor * 500f;
            rb2d.isKinematic = false; // Вмикаємо фізику перед запуском
            rb2d.AddForce(forceMagnitude * arrow.right);
            isOnStart = false;
        }

        // Якщо натиснута клавіша '1', повертаємо пташку на стартову позицію
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ResetBird();
        }
    }

    private void ResetBird()
    {
        transform.position = startPosition; // Повертаємо на стартову позицію
        rb2d.linearVelocity = Vector2.zero; // Скидаємо швидкість
        rb2d.angularVelocity = 0f; // Скидаємо обертання
        rb2d.isKinematic = true; // Вимикаємо фізику, щоб пташка залишалася на місці
        isOnStart = true; // Дозволяємо знову запускати пташку
    }
}