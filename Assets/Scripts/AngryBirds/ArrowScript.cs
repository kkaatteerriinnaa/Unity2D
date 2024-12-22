using UnityEngine;
using UnityEngine.UI;

public class ArrowScript : MonoBehaviour
{
    [SerializeField]
    private Transform rotAnchor;

    [SerializeField]
    private Image forceIndicator;

    void Start()
    {
        GameState.birdForceFactor = forceIndicator.fillAmount;
    }

    void Update()
    {
        if(GameState.isBirdFly) return;

        float dy = Input.GetAxis("Vertical");   // "сигнал" з усіх
        // пристроїв, що відповідають за управління по вертикалі
        float currentAngle = this.transform.eulerAngles.z;
        if(currentAngle > 180)
        {
            currentAngle -= 360;
        }
        if (-45 < currentAngle + dy && currentAngle + dy < 45)
        {
            this.transform.RotateAround(rotAnchor.position, Vector3.forward, dy);
        }

        float dx = Input.GetAxis("Horizontal") * Time.deltaTime;
        float f = forceIndicator.fillAmount;
        if (0 < f + dx && f + dx <= 1)
        {
            GameState.birdForceFactor = 
                forceIndicator.fillAmount = f + dx;
        }

        if (dy != 0.0f || dx != 0.0f)
        {
            GameState.idleTime = 0.0f;
        }
    }
}
/* Скрипт управління "Стрілкою"
 * за натиском "Вгору"/"Вниз" (W/S, джойстик) стрілка змінює кут нахилу
 * 
 * Д.З. На новій сцені (з попереднього ДЗ)
 * реалізувати взаємодію компонентів
 * - пауза гри
 * - колізії
 */
