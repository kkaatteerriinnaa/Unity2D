using UnityEngine;
using UnityEngine.SceneManagement;

public class ModalScript : MonoBehaviour
{
    [SerializeField]
    private GameObject content;
    [SerializeField]
    private TMPro.TextMeshProUGUI titleTmp;
    [SerializeField]
    private TMPro.TextMeshProUGUI messageTmp;

    private static ModalScript instance;

    void Start()
    {
        instance = this;
        if (content.activeInHierarchy)
        {
            Time.timeScale = 0.0f;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if( content.activeInHierarchy )
            {
                HideModal();
            }
            else
            {
                ShowModal(
                    "ГРА НА ПАУЗІ",
                    "Для продовження гри натисніть кнопку \"Продовжити\" або клавішу ESC. Для зупинки гри натисніть кнопку \"Завершити\""
                );
            }

        }
    }
    public static void ShowModal(string title, string message)
    {
        instance.titleTmp.text = title;
        instance.messageTmp.text = message;
        Time.timeScale = 0.0f;
        instance.content.SetActive(true);
    }
    private void HideModal()
    {
        Time.timeScale = 1.0f;
        content.SetActive(false);
    }

    public void OnExitButtonClick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
    public void OnResumeButtonClick()
    {
        GameState.idleTime = 0.0f;
        HideModal();
        if (GameState.isLevelFinished)
        {
            // Вимагається перезапуск сцени
            if (GameState.isFinishOk)
            {
                // Наступний рівень
                GameState.level += 1;
                if(GameState.level >= SceneManager.sceneCountInBuildSettings)
                {
                    GameState.level = 0;
                }
            }
            else
            {
                // Повтор того ж рівня                
            }
            SceneManager.LoadScene(GameState.level);
        }
    }
}
/* Д.З. На другій сцені (з попередніх ДЗ) реалізувати
 * можливість зміни персонажу (вибрати не таких, як на першій сцені),
 * роботу модального повідомлення.
 */
