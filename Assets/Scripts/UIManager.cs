using UnityEngine;

public class UIManager : MonoBehaviour
{
    public ClockHandMovement clockHand;

    private void Start()
    {
        RotateHandOnClick(100f);
    }

    private void RotateHandOnClick(float duration)
    {
        if (clockHand != null)
        {
            clockHand.RotateHand(duration);
        }
    }
}
