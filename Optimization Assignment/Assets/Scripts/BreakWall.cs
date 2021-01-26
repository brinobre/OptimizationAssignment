using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakWall : MonoBehaviour
{
    [SerializeField] private ObjectPool pool;
    private GameObject currentStone;
    private int hitCount = 0;
    public Transform hitPos;
    private string hammer = ("hammer");


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(hammer) && hitCount < 4)
        {
            hitCount++;
            currentStone = pool.GetObjectFromPool();
            HitWall(currentStone);
        }
        else if (other.gameObject.CompareTag(hammer))
        {
            Destroy(gameObject);
        }
    }

    private void HitWall (GameObject stone)
    {
        stone.transform.position = hitPos.position;
        stone.GetComponent<Rigidbody>().AddForce(Vector3.up, ForceMode.Impulse);
    }
}
