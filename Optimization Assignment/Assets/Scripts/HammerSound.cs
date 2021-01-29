using UnityEngine;


public class HammerSound : MonoBehaviour
{
    private AudioSource hammerSound;
    [SerializeField] private AudioClip[] audioClips;
    private string player = "Player";

    // Start is called before the first frame update
    void Start()
    {
        hammerSound = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(Time.timeSinceLevelLoad > 3f && !collision.gameObject.CompareTag(player))
        {
            if(!hammerSound.isPlaying)
            hammerSound.PlayOneShot(audioClips[Random.Range(0, audioClips.Length)], Random.Range(0.6f, 0.9f));
        }
    }
}
