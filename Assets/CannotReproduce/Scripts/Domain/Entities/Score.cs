namespace CannotReproduce.Domain.Entities
{
    public class Score
    {
        public int Combo { get; private set; }
        public int MaxCombo { get; private set; }

        public Score()
        {
            Combo = 0;
            MaxCombo = 0;
        }

        public void IncrementCombo()
        {
            Combo++;
            if (Combo > MaxCombo)
            {
                MaxCombo = Combo;
            }
        }

        public void ResetCombo()
        {
            Combo = 0;
        }
    }
}
