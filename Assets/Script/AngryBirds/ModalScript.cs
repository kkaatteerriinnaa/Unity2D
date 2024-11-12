using UnityEngine;

public class ModalScript : MonoBehaviour
{
    [SerializeField]
    private GameObject content;
    [SerializeField]
    private TMPro.TextMeshProUGUI titleTmp;
    [SerializeField]
    private TMPro.TextMeshProUGUI massageTmp;

    void Start()
    {
        if (content.activeInHierarchy)
        {
            Time.timeScale = 0.0f;
        }

    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (content.activeInHierarchy)
            {
                HideModal();
            }
            else
            {
                ShowModal(
                    "ГРА НА ПАУЗІ",
                    "Для продовження гри нажміть кнопку продовжити або клавішу ESC. Для завершення натисніть кнопку вихід"
                    );
            }
        }
            
    }
    public void ShowModal(string title, string message)
    {
        titleTmp.text = title;
        massageTmp.text = message;
        Time.timeScale = 0.0f;
        content.SetActive( true );
    }
    private void HideModal()
    {
        Time.timeScale = 1.0f;
        content.SetActive( false );
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
        HideModal();
    }

}
