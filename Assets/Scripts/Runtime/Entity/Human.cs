namespace Runtime.Entity
{
    public class Human: IHuman
    {
        public string GetName()
        {
            return "human";
        }

        public void Reset() { }
    }
    
    public interface IHuman
    {
        string GetName();

        void Reset();
    }
}