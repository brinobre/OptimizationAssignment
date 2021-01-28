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
    private MeshRenderer meshRenderer;
    private BoxCollider boxCollider;


    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        boxCollider = GetComponent<BoxCollider>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(hammer) && hitCount < 4)
        {
            hitCount++;
            currentStone = pool.GetObjectFromPool();
            StartCoroutine(HitWall(currentStone));
        }
        else if (collision.gameObject.CompareTag(hammer))
        {
            StartCoroutine(HitWall(currentStone));
            meshRenderer.enabled = false;
            boxCollider.enabled = false;
        }
    }

    private IEnumerator HitWall (GameObject stone)
    {
        stone.transform.position = hitPos.position;
        stone.GetComponent<Rigidbody>().AddForce(Vector3.up, ForceMode.Impulse);

        yield return new WaitForSeconds(3f);
        pool.ReturnObjectToPool(stone);

        if (!meshRenderer.enabled)
        {
            yield return new WaitForSeconds(3.5f);
            Destroy(gameObject);
        }
    }

}
