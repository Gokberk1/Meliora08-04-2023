using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Meliora08_04_2023.Managers;

namespace Meliora08_04_2023.Controllers
{
    public class TargetsController : MonoBehaviour
    {
        [SerializeField] Animator _animator;
        [SerializeField] Vector3 _direction;
        [SerializeField] float _factor;
        [SerializeField] float _speed = 1f;
        const float FULL_CIRCLE = Mathf.PI * 2f;
        Vector3 _startPosition;
        bool _hit = false;

        ScoreManager _scoreManager;
        [SerializeField] GameObject _scoreManagerGameObjet;

        private void Awake()
        {
            _scoreManager = _scoreManagerGameObjet.GetComponent<ScoreManager>();
            _startPosition = transform.localPosition;
        }
        private void Update()
        {
            float cycle = Time.time / _speed;
            float sinWave = Mathf.Sin(cycle * FULL_CIRCLE);
            _factor = sinWave / 2f + 0.5f;
            Vector3 offset = _direction * _factor;
            transform.localPosition = offset + _startPosition;
        }

        private void OnCollisionEnter(Collision collision)
        {
            BallThrow ball = collision.collider.GetComponent<BallThrow>();
            if (ball != null)
            {
                _animator.SetTrigger("Hit");
                if (gameObject.tag == "target10")
                {
                    _scoreManager.AddScore(10);
                }
                else if (gameObject.tag == "target15")
                {
                    _scoreManager.AddScore(15);
                }
                else if (gameObject.tag == "target30")
                {
                    _scoreManager.AddScore(30);
                }

                ball.GetComponent<Collider>().enabled = false;
            }
        }
    }
}

