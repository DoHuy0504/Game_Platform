using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] float _speedEnemy = 2f;
    [SerializeField] float _distance = 3f; //khoảng cách
    Vector3 _starPos;
    bool _moveRight = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _starPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float leftBound = _starPos.x - _distance;
        float rightBound = _starPos.x + _distance;
        if (_moveRight)
        {
            transform.Translate(Vector2.right * _speedEnemy * Time.deltaTime);
            if(transform.position.x >= rightBound)
            {
                _moveRight = false;
                Flip();
            }
        }
        else
        {
            transform.Translate(Vector2.left * _speedEnemy * Time.deltaTime);
            if (transform.position.x <= leftBound)
            {
                _moveRight = true;
                Flip();
            }
        }
    }
    void Flip() //lật
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
