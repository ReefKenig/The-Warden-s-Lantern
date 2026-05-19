using UnityEngine;

public class ShrineController : MonoBehaviour
{
    public Light shrineLight;
    private bool isLit = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        shrineLight.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isLit)
        {
            isLit = true;
            shrineLight.enabled = true;
            // Play the light woosh sound once and the fire crackle in a loop
            shrineLight.GetComponents<AudioSource>()[0].Play();
            shrineLight.GetComponents<AudioSource>()[1].Play();
            GameManager.Instance.LightShrine();
        }
    }
}
