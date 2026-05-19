using UnityEngine;
using System.Collections;

public class GateController : MonoBehaviour
{
    public Transform leftHinge;
    public Transform rightHinge;
    public AudioSource gateOpenAudioSource;

    [Header("Settings")]
    public float openAngle = 75f;
    public float openSpeed = 1f;

    private bool hasOpened = false;

    public void OpenGate()
    {
        if (!hasOpened)
        {
            hasOpened = true;
            StartCoroutine(OpenGateRoutine());
        }
    }

    private IEnumerator OpenGateRoutine()
    {
        if (gateOpenAudioSource != null)
        {
            gateOpenAudioSource.Play();
        }

        Quaternion leftStartRotation = leftHinge.localRotation;
        Quaternion rightStartRotation = rightHinge.localRotation;

        Quaternion leftTargetRotation = leftStartRotation * Quaternion.Euler(0f, -openAngle, 0f);
        Quaternion rightTargetRotation = rightStartRotation * Quaternion.Euler(0f, openAngle, 0f);

        float timeElapsed = 0f;

        while (timeElapsed < 1)
        {
            timeElapsed += Time.deltaTime * openSpeed;

            leftHinge.localRotation = Quaternion.Slerp(leftStartRotation, leftTargetRotation, timeElapsed);
            rightHinge.localRotation = Quaternion.Slerp(rightStartRotation, rightTargetRotation, timeElapsed);

            yield return null;
        }
    }
}
