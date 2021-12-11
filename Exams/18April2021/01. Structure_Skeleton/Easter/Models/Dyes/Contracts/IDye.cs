namespace Easter.Models.IDyes.Contracts
{
    public interface IDye
    {
        int Power { get; }

        void Use();

        bool IsFinished();
    }
}
