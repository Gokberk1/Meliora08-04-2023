using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Meliora08_04_2023.Controllers
{
    public class MainCircleController : MonoBehaviour
    {
        [SerializeField] float _xRange = 4f;
        [SerializeField] float _yRange = 4f;
        [SerializeField] float _speed = 1.5f;

        private Vector3 startPosition;
        private Vector3 targetPosition;

        private void Start()
        {
            startPosition = transform.position;
            SetTargetPosition();
        }

        private void Update()
        {
            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                SetTargetPosition();
            }

            transform.Translate((targetPosition - transform.position).normalized * _speed * Time.deltaTime);
        }

        private void SetTargetPosition()
        {
            float x = Random.Range(-_xRange, _xRange);
            float y = Random.Range(-_yRange, _yRange);
            targetPosition = startPosition + new Vector3(x, y, 0f);
        }
    }
}

