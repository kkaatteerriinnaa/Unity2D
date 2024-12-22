using UnityEngine;

public class PigScript : MonoBehaviour
{
    void Start()
    {
        GameState.pigsCount = GameObject.FindGameObjectsWithTag(this.gameObject.tag).Length;
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PigDestroy"))
        {
            // Рахуємо скільки є об'єктів з таким же тегом, як у даного
            int pigs = GameObject.FindGameObjectsWithTag(this.gameObject.tag).Length;
            pigs -= 1;
            GameState.pigsCount = pigs;
            if (pigs == 0)
            {
                GameState.isLevelFinished = true;
                GameState.isFinishOk = true;
                ModalScript.ShowModal("ПЕРЕМОГА", "Рівень пройдено");
            }
            GameObject.Destroy(this.gameObject);
        }
    }
}
/* Визначаємо зіткнення (колізії) з предметами, що "знищують" ворога
 */
