namespace Common.Serialization.Json
{
    internal class JsonDeserializerV2
    {
        private int _currentStackLevel;

        internal int CurrentStackLevel
        {
            get { return _currentStackLevel; }
            set
            {
                _currentStackLevel = value;
                if (_currentStackLevel>MaxStackLevel)
                {
                    throw new JsonStackOverFlowException(MaxStackLevel);
                }
            }
        }

        internal int MaxStackLevel { get; set; }
    }
}