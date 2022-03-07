using UnityEngine;

namespace Command
{
    public class ChangeColorAction : BaseAction
    {
        private SpriteRenderer _spriteRenderer;
        private Color _originalColor;

        public ChangeColorAction(SpriteRenderer spriteRenderer)
        {
            _spriteRenderer = spriteRenderer;
        }
        
        public override void Execute()
        {
            _originalColor = _spriteRenderer.color;
            _spriteRenderer.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        }

        public override void Undo()
        {
            _spriteRenderer.color = _originalColor;
        }
    }
}