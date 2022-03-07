namespace Command
{
    public abstract class BaseAction
    {
        public abstract void Execute();
        public abstract void Undo();
    }
}