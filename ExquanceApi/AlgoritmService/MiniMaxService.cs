using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameApi.ValidateService;

namespace GameApi.AlgoritmService
{
    public class MiniMaxService : IAlgorithmService
    {
        #region private

        private char _computer = 'X';
        private char _player = '0';
        private readonly IValidator _validator;

        #endregion

        public MiniMaxService(IValidator validator)
        {
            _validator = validator ?? throw new ArgumentNullException(nameof(validator));
        }

        public async Task<int[]> GetSquare(char[,] boardSymbols)
        {
            try
            {
                return await Task.Run(() =>
                {
                    var bestVal = -1000;
                    var bestMove = new Int32[2];

                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            if (boardSymbols[i, j] == '_')
                            {
                                boardSymbols[i, j] = _computer;

                                int moveVal = MiniMax(boardSymbols, 0, false);

                                boardSymbols[i, j] = '_';

                                if (moveVal > bestVal)
                                {
                                    bestMove[0] = i;
                                    bestMove[1] = j;

                                    bestVal = moveVal;
                                }
                            }
                        }
                    }

                    return bestMove;
                });
            }
            catch (Exception)
            {
                throw;
            }
        }

        private int MiniMax(char[,] boardSymbols, int depth, bool isMax)
        {
            var res = _validator.Evaluate(boardSymbols);
            
            if (res == 'X')
                return 10;

            if (res == '0')
                return -10;

            if (IsMovesLeft(boardSymbols) == false)
                return 0;

            if (isMax)
            {
                int best = -1000;

                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (boardSymbols[i, j] == '_')
                        {
                            boardSymbols[i, j] = _computer;

                            best = Math.Max(best, MiniMax(boardSymbols,
                                depth + 1, !isMax));

                            boardSymbols[i, j] = '_';
                        }
                    }
                }

                return best;
            }

            else
            {
                int best = 1000;

                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (boardSymbols[i, j] == '_')
                        {
                            boardSymbols[i, j] = _player;

                            best = Math.Min(best, MiniMax(boardSymbols,
                                depth + 1, !isMax));

                            boardSymbols[i, j] = '_';
                        }
                    }
                }

                return best;
            }
        }
        
        private bool IsMovesLeft(char[,] boardSymbols)
        {
            for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
                if (boardSymbols[i, j] == '_')
                    return true;
            return false;
        }
    }
}