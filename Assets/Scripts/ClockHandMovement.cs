using System.Collections;
using UnityEngine;

public class ClockHandMovement : MonoBehaviour
{

    public void RotateHand(float duration)
    {
        Quaternion targetRotation = Quaternion.Euler(0f, 0f, 360f);

        StartCoroutine(RotateHandCoroutine(targetRotation, duration));
    }

    private IEnumerator RotateHandCoroutine(Quaternion targetRotation, float duration)
    {
        float elapsed = 0f;
        Quaternion startRotation = transform.rotation;

        while (elapsed < duration)
        {
            transform.Rotate(0, 0, -360f * (Time.deltaTime / duration));

            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.rotation = targetRotation;
    }
}
