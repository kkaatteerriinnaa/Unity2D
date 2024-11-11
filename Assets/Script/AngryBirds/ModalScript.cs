using UnityEngine;

public class ModalScript : MonoBehaviour
{
    [SerializeField]
    private GameObject content;

    void Start()
    {
        //content = GameObject.Find("Content")

    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = content.activeInHierarchy ? 1.0f : 0.0f;
            this.content.SetActive( ! this.content.activeInHierarchy );
        }
            
    }
}
