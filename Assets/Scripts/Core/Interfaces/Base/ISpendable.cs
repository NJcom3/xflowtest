namespace Core.Interfaces.Base
{
    public interface ISpendable
    {
        public bool IsEnough(int count);
        public void Spend(int count);
    }
}