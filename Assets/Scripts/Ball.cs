using System;
using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Ball : MonoBehaviour
    {
        public enum BallColorType
        {
            Red,
            Blue
        }
        
        public Color ColorValue => _spriteRenderer.color;//If the user wants the specific color value they can use this property.
        public BallColorType ColorType => _colorType;

        [SerializeField] private Color redColor = Color.red;
        [SerializeField] private Color blueColor = Color.blue;
        
        protected BallColorType _colorType;
        protected SpriteRenderer _spriteRenderer;

        protected virtual void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }
        
        public void InitBall(string ballName)
        {
            SetName(ballName);
        }
        
        public void InitBall(string ballName, BallColorType ballColorType)
        {
            SetName(ballName);
            SetColor(ballColorType);
        }
        
        private void SetName(string ballName)
        {
            this.name = ballName;
        }

        private void SetColor(BallColorType ballColor)//With an enum the user of the function doesn't have to know the specific color values.
        {
            switch (ballColor)
            {
                case BallColorType.Red:
                    _spriteRenderer.color = redColor;
                    _colorType = BallColorType.Red;
                    break;
                case BallColorType.Blue:
                    _spriteRenderer.color = blueColor;
                    _colorType = BallColorType.Blue;
                    break;
                default:
                    _spriteRenderer.color = redColor;
                    _colorType = BallColorType.Red;
                    break;
            }
        }
    }
}
