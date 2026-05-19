using UnityEngine;

public class PlayerFootsteps : MonoBehaviour
{
    public AudioSource footstepAudioSource;
    public AudioClip[] footstepClips;

    public float walkStepInterval = 0.5f;
    private float stepTimer;
    private CharacterController controller;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();
        stepTimer = walkStepInterval;
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.isGrounded && controller.velocity.magnitude > 0.1f)
        {
            stepTimer -= Time.deltaTime;

            if (stepTimer <= 0f)
            {
                PlayFootstep();
                stepTimer = walkStepInterval;
            }
        }
        else
        {
            stepTimer = walkStepInterval; // Reset timer when not moving
        }
    }

    private void PlayFootstep()
    {
        if (footstepClips.Length > 0)
        {
            int index = Random.Range(0, footstepClips.Length);
            
            footstepAudioSource.volume = Random.Range(0.8f, 1f);
            footstepAudioSource.pitch = Random.Range(0.9f, 1.1f);
            
            footstepAudioSource.clip = footstepClips[index];
            footstepAudioSource.Play();
        }
    }
}
