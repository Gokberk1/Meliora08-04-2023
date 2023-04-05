using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Meliora08_04_2023.Managers;

namespace Meliora08_04_2023.Controllers
{
    public class MainCircleController : MonoBehaviour
    {
        [SerializeField] float _xRange = 4f;
        [SerializeField] float _yRange = 4f;
        [SerializeField] float _speed = 1.5f;

        private Vector3 _startPos;
        private Vector3 _nextPos;

        BallThrow _ball;

        private void Awake()
        {
            _ball = new BallThrow();

            _startPos = transform.position;
            SetNextPosition();
        }

        private void Update()
        {
            if (Vector3.Distance(transform.position, _nextPos) < 0.1f)
            {
                SetNextPosition();
            }
            transform.Translate((_nextPos - transform.position).normalized * _speed * Time.deltaTime);
        }

        private void SetNextPosition()
        {
            float x = Random.Range(-_xRange, _xRange);
            float y = Random.Range(-_yRange, _yRange);
            _nextPos = _startPos + new Vector3(x, y, 0f);
        }

        private void OnCollisionEnter(Collision collision)
        {
            _ball = collision.collider.GetComponent<BallThrow>();
            if(_ball != null)
            {
                _ball.GetComponent<Collider>().enabled = false;
            }
        }
    }
}

