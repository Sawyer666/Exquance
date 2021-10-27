using System;
using GameApi.Exceptions;

namespace GameApi.ValueInputService
{
    public class ValueInputService : IValueInputService
    {
        public string Validate(int value)
        {
            if (((value % 3) == 0) && ((value % 5) == 0))
            {
                return "Foo Bar";
            }

            if ((value % 3) == 0)
            {
                return "Foo";
            }

            if ((value % 5) == 0)
            {
                return "Bar";
            }

            throw new IncorrectValueException($"Incorrect Value {value}");
        }
    }
}