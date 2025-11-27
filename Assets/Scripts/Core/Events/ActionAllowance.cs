namespace Core.Events
{
    public class ActionAllowance
    {
        public bool Allowance { get; }

        public ActionAllowance(bool allowance)
        {
            Allowance = allowance;
        }
    }
}