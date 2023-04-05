using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Meliora08_04_2023.Managers;

namespace Meliora08_04_2023.Controllers
{
    public class TargetsController : MonoBehaviour
    {
        [SerializeField] Vector3 _direction;
        [SerializeField] float _factor;
        [SerializeField] float _speed = 1f;
        const float FULL_CIRCLE = Mathf.PI * 2f;

        Vector3 _startPosition;

        private void Awake()
        {
            _startPosition = transform.position;
        }
        private void Update()
        {
            float cycle = Time.time / _speed;
            float sinWave = Mathf.Sin(cycle * FULL_CIRCLE);
            _factor = sinWave / 2f + 0.5f;
            Vector3 offset = _direction * _factor;
            transform.position = offset + _startPosition;
        }

        private void OnCollisionEnter(Collision collision)
        {
            BallThrow ball = collision.collider.GetComponent<BallThrow>();
            if (ball != null)
            {
                if (gameObject.tag == "target10")
                {
                    GameManager.Instance.AddScore(10);
                }
                else if (gameObject.tag == "target15")
                {
                    GameManager.Instance.AddScore(15);
                }
                else if (gameObject.tag == "target30")
                {
                    GameManager.Instance.AddScore(30);
                }
            }
        }
    }
}

