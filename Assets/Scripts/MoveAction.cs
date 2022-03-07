using UnityEngine;

namespace Command
{
    public class MoveAction : BaseAction
    {
        private Entity _entity;
        private Vector2 _direction;

        public MoveAction(Entity entity, Vector2 direction)
        {
            _entity = entity;
            _direction = direction;
        }
        
        public override void Execute()
        {
            _entity.Move(_direction);
        }

        public override void Undo()
        {
            _entity.Move(-_direction);
        }
    }
}