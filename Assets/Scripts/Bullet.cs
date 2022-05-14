using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] float _bounceForce;
    [SerializeField] float _bounceRadius;

    Vector3 _moveDir;

    private void Start()
    {
        _moveDir = Vector3.forward;
    }

    private void Update()
    {
        transform.Translate(_moveDir * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Block block))
        {
            block.Break();
            Destroy(gameObject);
        }
        if(other.TryGetComponent(out Obstacle obstacle))
        {
            Bounce();
        }
    }

    void Bounce()
    {
        _moveDir = Vector3.back + Vector3.up;
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.isKinematic = false;
        rigidbody.AddExplosionForce(_bounceForce, transform.position + new Vector3(0, -1.1f, 1), _bounceRadius);
    }
}