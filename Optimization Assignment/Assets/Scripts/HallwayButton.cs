using UnityEngine.Events;
using UnityEngine;

public class HallwayButton : MonoBehaviour
{
    private string buttonTrigger;
    public UnityEvent toggle;
    // Start is called before the first frame update
    void Start()
    {
        buttonTrigger = "buttonTrigger";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(buttonTrigger))
        {
            toggle?.Invoke();
        }
    }
}
