using UnityEngine.Events;
using UnityEngine;

public class OpenDoorKey : MonoBehaviour
{
    private string keyTrigger;
    public UnityEvent openDoor;
    
    void Start()
    {
        keyTrigger = "keyTrigger";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(keyTrigger))
        {
            openDoor?.Invoke();
        }
    }
}
