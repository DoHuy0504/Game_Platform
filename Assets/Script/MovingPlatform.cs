using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] Transform PosA;
    [SerializeField] Transform PosB;
    [SerializeField] float _speedPlatform = 2f;
    Vector3 target;
    Transform _player;

    void Start()
    {
        target = PosA.position;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position,
            target, _speedPlatform * Time.deltaTime);
        if (Vector3.Distance(transform.position, target) < 0.1f)
        {
            if (target == PosA.position)
            {
                target = PosB.position;
            }
            else
            {
                target = PosA.position;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null); 
        }
    }
}