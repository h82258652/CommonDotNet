using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Serialization.Json.Exception;

namespace Common.Serialization.Json.Serialize
{
    internal partial class JsonSerializer
    {
        private int _currentStackLevel;

        internal DateTimeFormat DateTimeFormat { get; set; }

        internal EnumFormat EnumFormat { get; set; }

        internal RegexFormat RegexFormat { get; set; }

        internal int MaxStackLevel { get; set; }

        internal int CurrentStackLevel {
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
    }
}
