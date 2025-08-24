namespace CannotReproduce.Domain.Entities
{
    public class GameTimer
    {
        public float RemainingTime { get; private set; }
        public bool IsTimeUp => RemainingTime <= 0;

        public GameTimer(float initialTime)
        {
            RemainingTime = initialTime;
        }

        public void AddTime(float amount)
        {
            if (IsTimeUp) return;
            RemainingTime += amount;
        }

        public void SubtractTime(float amount)
        {
            RemainingTime -= amount;
            if (RemainingTime < 0)
            {
                RemainingTime = 0;
            }
        }

        // Presentation層でTime.deltaTimeを渡して呼び出すことを想定
        public void Tick(float deltaTime)
        {
            if (IsTimeUp) return;
            SubtractTime(deltaTime);
        }
    }
}
