using UnityEngine;

public class BirdScript : MonoBehaviour
{
    // [SerializeField]
    private Transform arrow;
    private Rigidbody2D rb2d;
    private Vector2 startPosition;
    private Quaternion startRotation;

    [SerializeField]
    private float idleTimeout = 10.0f;
    [SerializeField]
    private float actionTimeout = 10.0f;
    private float actionTime;


    void Start()
    {
        arrow = GameObject.Find("Arrow").transform;
        rb2d = GetComponent<Rigidbody2D>();
        GameState.isBirdFly = false;
        GameState.shotCount = 2;
        GameState.idleTime = 0.0f;
        startPosition = this.transform.position;
        startRotation = this.transform.rotation;
        actionTime = 0.0f;
    }

    void Update()
    {
        if (!GameState.isBirdFly)
        {
            GameState.idleTime += Time.deltaTime;
            if (GameState.idleTime >= idleTimeout)
            {
                ModalScript.ShowModal("ОЧІКУВАННЯ",
                    "Ви не виконували жодних дій, тому гра стала на паузу");
                return;
            }
        }
        
        if (Input.GetKeyDown(KeyCode.Space) && !GameState.isBirdFly && Time.timeScale != 0)
        {
            GameState.idleTime = 0.0f;
            float forceMagnitude = 500f + GameState.birdForceFactor * 500f;
            rb2d.AddForce(forceMagnitude * arrow.right);
            GameState.isBirdFly = true;
            actionTime = actionTimeout;
        }
        if (actionTime > 0)
        {
            actionTime -= Time.deltaTime;
            if(actionTime <= 0)
            {
                GameState.shotCount -= 1;
                if (GameState.shotCount > 0)
                {
                    this.transform.position = startPosition;
                    this.transform.rotation = startRotation;
                    rb2d.linearVelocity = Vector3.zero;
                    rb2d.angularVelocity = 0f;
                    GameState.isBirdFly = false;
                }
                else
                {
                    GameState.isLevelFinished = true;
                    GameState.isFinishOk = false;
                    ModalScript.ShowModal("ПРОГРАШ", "Вичерпано усі спроби");
                }
            }
        }
    }
}
/* Управління персонажем (птахом)
 * За натисненням кнопки "Пробіл" одноразово прикладаємо силу
 * у напрямі Стрілки
 */
