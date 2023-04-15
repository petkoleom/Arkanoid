using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace darkvoyagestudios
{
    public class scr_Player : MonoBehaviour
    {
        [SerializeField]
        private float smoothTime = 0.3F;

        [SerializeField]
        private float bound = 8;

        private Vector2 mousePos;
        private Vector3 targetPos;
        private Vector2 velocity = Vector2.zero;

        scr_Ball ball;


        private void Start()
        {
            ball = transform.GetChild(0).GetComponent<scr_Ball>();
        }

        private void Update()
        {
            targetPos = Camera.main.ScreenToWorldPoint(mousePos);

            transform.position = Vector2.SmoothDamp(transform.position, new Vector2(targetPos.x, transform.position.y), ref velocity, smoothTime);
            if (transform.position.x > bound)
                transform.position = new Vector2(bound, transform.position.y);
            if (transform.position.x < -bound)
                transform.position = new Vector2(-bound, transform.position.y);
        }


        public void OnMove(InputValue value)
        {

            mousePos = value.Get<Vector2>();
        }

        public void OnLaunch(InputValue value)
        {
            ball.Launch();
        }
    }
}
