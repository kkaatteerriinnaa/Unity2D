using UnityEngine;

public class DisplayScript : MonoBehaviour
{
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
}
