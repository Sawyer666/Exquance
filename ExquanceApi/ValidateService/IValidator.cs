using System.Collections.Generic;

namespace GameApi.ValidateService
{
    public interface IValidator
    {
        char Evaluate(char[,] data);

        char[,] ConvertMatrix(char[] arr, int m, int n);
    }
}