namespace EternalQuest
{
    public class SimpleGoal : Goal
    {
        private bool _isComplete;

        public SimpleGoal(string name, string description, int points)
            : base(name, description, points)
        {
            _isComplete = false;
        }

        public SimpleGoal(string name, string description, int points, bool isComplete)
            : base(name, description, points)
        {
            _isComplete = isComplete;
        }

        public override void RecordEvent()
        {
            _isComplete = true;
        }

        public override bool IsComplete()
        {
            return _isComplete;
        }

        public override string GetDetailsString()
        {
            return $"{_shortName} - {_description} - Points: {_points} - Complete: {_isComplete}";
        }

        public override string GetStringRepresentation()
        {
            return $"Simple,{_shortName},{_description},{_points},{_isComplete}";
        }
    }
}
