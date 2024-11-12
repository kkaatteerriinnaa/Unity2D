using UnityEngine;

public class DisplayScript : MonoBehaviour
{
    [SerializeField]
    private GameObject bird1;
    [SerializeField]
    private GameObject bird2;
    private int selectedBird = 1;
    [SerializeField]
    private GameObject activeBird;

    private TMPro.TextMeshProUGUI clock;
    private float gameTime;
    private const float maxGameTime = 99 * 3600; 

    void Start()
    {
        gameTime = 0f;
        clock = GameObject.Find("ClockTMP").GetComponent<TMPro.TextMeshProUGUI>();
    }

    void Update()
    {
        if (gameTime < maxGameTime)
        {
            gameTime += Time.deltaTime;
        }

        int hours = Mathf.FloorToInt(gameTime / 3600);
        int minutes = Mathf.FloorToInt((gameTime % 3600) / 60);
        int seconds = Mathf.FloorToInt(gameTime % 60);
        int tenthMilliseconds = Mathf.FloorToInt((gameTime * 10) % 10); 

        clock.text = string.Format("{0:00}:{1:00}:{2:00}:{3:0}", hours, minutes, seconds, tenthMilliseconds);
    }

    public void OnBird1ButtonClick()
    {
        Debug.Log("Bird 1");
        if (selectedBird != 1 && !GameState.isBirdFly)
        {
            GameObject.Destroy(activeBird);
            activeBird = GameObject.Instantiate(bird1);
            selectedBird = 1;
        }
    }
    public void OnBird2ButtonClick()
    {
        Debug.Log("Bird 2");
        if (selectedBird != 2 && !GameState.isBirdFly)
        {
            GameObject.Destroy(activeBird);
            activeBird = GameObject.Instantiate(bird2);
            selectedBird = 2;
        }
    }

}
