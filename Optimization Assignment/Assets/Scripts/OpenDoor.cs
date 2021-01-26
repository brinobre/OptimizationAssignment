using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    private Rigidbody rb;
    private AudioSource audioSource;
    public AudioClip openDoorAc;
    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    public void UnlockDoor()
    {
        rb.isKinematic = false;
        audioSource.PlayOneShot(openDoorAc, 0.7f);
    }
}
