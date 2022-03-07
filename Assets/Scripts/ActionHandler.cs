using System.Collections.Generic;

namespace Command
{
    public class ActionHandler
    {
        private Stack<BaseAction> _stack = new Stack<BaseAction>();

        public void RecordAction(BaseAction action)
        {
            _stack.Push(action);
            
            action.Execute();
        }

        public void Undo()
        {
            if (_stack.Count == 0) return;

            BaseAction action = _stack.Pop();
            action.Undo();
        }
    }
}