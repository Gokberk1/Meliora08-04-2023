using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Meliora08_04_2023.Managers;

namespace Meliora08_04_2023.Controllers
{
    public class BallThrow : MonoBehaviour
    {
        [SerializeField] float _minSwipeDist = 0;
        [SerializeField] float _maxBallSpeed = 40;
        [SerializeField] float _smooth;
        float _ballVelocity = 0;
        float _ballSpeed = 0;
        float _startTime;
        float _endTime;
        float _swipeDistance;
        float _swipeTime;
        Vector2 _startPos;
        Vector2 _endPos;
        Vector3 _ballDefaultPos;
        Vector3 _angle;
        Vector3 _newPos;
        bool _thrown, _holding;
        Rigidbody _rigidbody;


        private void Awake()
        {
            _ballDefaultPos = transform.position;
            ResetBall();
        }

        private void Update()
        {
            if (_holding)
            {
                PickUpBall();
            }
            if (_thrown)
            {
                return;
            }
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if(Physics.Raycast(ray,out hit, 100f))
                {
                    if(hit.transform == gameObject.transform)
                    {
                        _startTime = Time.time;
                        _startPos = Input.mousePosition;
                        _holding = true;

                    }
                }
            }
            else if (Input.GetMouseButtonUp(0))
            {
                _endTime = Time.time;
                _endPos = Input.mousePosition;
                _swipeDistance = (_endPos - _startPos).magnitude;
                _swipeTime = _endTime - _startTime;

                if(_swipeTime < 1f && _swipeDistance > 30f)
                {
                    CallAngle();
                    CallSpeed();
                    _rigidbody.AddForce( new Vector3((_angle.x * _ballSpeed), (_angle.y * _ballSpeed), (_angle.z * _ballSpeed)));
                    _rigidbody.useGravity = true;
                    _holding = false;
                    _thrown = true;
                    Invoke("ResetBall", 4f);
                    Invoke("ChangeTurn", 4f);
                }
                else
                {
                    ResetBall();
                }
            }
        }

        void ChangeTurn()
        {
            GameManager.Instance.ChangePlayersTurn();
        }

        void ResetBall()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _angle = Vector3.zero;
            _endPos = Vector2.zero;
            _startPos = Vector2.zero;
            _ballSpeed = 0;
            _startTime = 0;
            _endTime = 0;
            _swipeDistance = 0;
            _swipeTime = 0;
            _thrown = false;
            _holding = false;
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.useGravity = false;
            transform.position = _ballDefaultPos;
        }

        void PickUpBall()
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = Camera.main.nearClipPlane + 3f;
            _newPos = Camera.main.ScreenToWorldPoint(mousePos);
            gameObject.transform.localPosition = Vector3.Lerp(transform.position, _newPos, 80f * Time.deltaTime);
        }

        void CallAngle()
        {
            _angle = Camera.main.ScreenToWorldPoint(new Vector3(_endPos.x, _endPos.y + 50f, (Camera.main.nearClipPlane + 15)));
        }

        void CallSpeed()
        {
            if(_swipeTime > 0)
            _ballVelocity = _swipeDistance / (_swipeDistance - _swipeTime);
            
            _ballSpeed = _ballVelocity * 40f;
            
            if(_ballSpeed <= _maxBallSpeed)
            {
                _ballSpeed = _maxBallSpeed;
            }
           
            _swipeTime = 0;
        }

        
    }
}

