using UnityEngine.Events;
using UnityEngine;

public class HallwayButton : MonoBehaviour
{
    private string buttonTrigger;
    public UnityEvent toggle;
    public UnityEvent toggleOff;
    private int pushCount;
    // Start is called before the first frame update
    void Start()
    {
        buttonTrigger = "buttonTrigger";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(buttonTrigger) && pushCount % 2 == 0)
        {
            toggle?.Invoke();
            pushCount++;
        }
        else if (other.CompareTag(buttonTrigger))
        {
            toggleOff?.Invoke();
            pushCount++;
        }
    }
}
