using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public ClockHandMovement clockHand;
    public TextMeshProUGUI levelCompleteText;

    private void Start()
    {
        RotateHandOnClick(100f);
    }

    private void RotateHandOnClick(float duration)
    {
        if (clockHand != null)
        {
            StartCoroutine(WhenTimerDone(duration));
        }
    }

    private IEnumerator WhenTimerDone(float duration)
    {
        yield return clockHand.RotateHandCoroutine(Quaternion.Euler(0f, 0f, 360f), duration);

        if (levelCompleteText != null)
        {
            levelCompleteText.text = "Level Complete!";
            levelCompleteText.gameObject.SetActive(true);
        }
    }
}
