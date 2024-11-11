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
        float dy = Input.GetAxis("Vertical");
        float currentAngle = this.transform.eulerAngles.z;
        if(currentAngle > 180)
        {
            currentAngle -= 360;
        }
        if(-45 < currentAngle + dy && 45 > currentAngle + dy)
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
    }
}
