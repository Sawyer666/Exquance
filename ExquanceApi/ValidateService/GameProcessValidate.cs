using System.Collections.Generic;
using System.Linq;

namespace GameApi.ValidateService
{
    public class GameProcessValidate : IValidator
    {
        public char Evaluate(char[,] data)
        {
            for (int row = 0; row < 3; row++)
            {
                if (data[row, 0] == data[row, 1] &&
                    data[row, 1] == data[row, 2])
                {
                    if (data[row, 0] == 'X')
                        return 'X';
                    else if (data[row, 0] == '0')
                        return '0';
                }
            }

            for (int col = 0; col < 3; col++)
            {
                if (data[0, col] == data[1, col] &&
                    data[1, col] == data[2, col])
                {
                    if (data[0, col] == 'X')
                        return 'X';

                    else if (data[0, col] == '0')
                        return '0';
                }
            }

            if (data[0, 0] == data[1, 1] && data[1, 1] == data[2, 2])
            {
                if (data[0, 0] == 'X')
                    return 'X';
                else if (data[0, 0] == '0')
                    return '0';
            }

            if (data[0, 2] == data[1, 1] && data[1, 1] == data[2, 0])
            {
                if (data[0, 2] == 'X')
                    return 'X';
                else if (data[0, 2] == '0')
                    return '0';
            }

            return '.';
        }

        public char[,] ConvertMatrix(char[] arr, int m, int n)
        {
            char[,] result = new char[n, m];
            for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
                result[i, j] = arr[j + i * 3];
            return result;
        }
    }
}