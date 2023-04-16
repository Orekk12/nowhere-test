using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class SpawnManager : MonoBehaviour
    {
        public static event Action OnBallSpawn;
        private List<Ball> _balls = new List<Ball>();

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                SpawnBallAtMouseAndGiveName("Colored Ball");
            }
            else if (Input.GetMouseButtonDown(1))
            {
                for (var i = _balls.Count - 1; i >= 0; i--)//Previous code would exit the loop after removing the first red ball.
                {
                    if (_balls[i].ColorType == Ball.BallColorType.Red)
                    {
                        RemoveBall(_balls[i]);
                    }
                }
            }
        }

        public void RemoveBall(Ball ball)
        {
            _balls.Remove(ball);
            BallPool.Instance.Pool.Release(ball);
        }

        private void SpawnBallAtMouseAndGiveName(string ballName)
        {
            var ballMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            ballMousePos.z = 0;
            
            var ball = InstantiateBall(ballMousePos);
            
            var ballColor = (Ball.BallColorType) UnityEngine.Random.Range(0, Enum.GetNames(typeof(Ball.BallColorType)).Length);
            ball.InitBall(ballName, ballColor);
            
            OnBallSpawn?.Invoke();
        }

        public Ball InstantiateBall(Vector3 position)
        {
            var ball = BallPool.Instance.Pool.Get();
            ball.transform.position = position;
            ball.InitBall(name);
            _balls.Add(ball);
            return ball;
        }
    }
}