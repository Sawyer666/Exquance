using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using ExquanceWpfClient.Command;
using GameApi.AlgoritmService;
using GameApi.ValidateService;

namespace ExquanceWpfClient.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        #region private

        private bool _isEnabledGameBoard;
        private readonly IValidator _gameValidator;

        #endregion

        #region public

        public bool IsEnabledGameBoard
        {
            get => _isEnabledGameBoard;
            set
            {
                _isEnabledGameBoard = value;
                OnPropertyChanged(nameof(IsEnabledGameBoard));
            }
        }

        public List<BoardItemViewModel> BoardItems { get; } = new();

        public bool IsComputerStart { get; set; }

        #endregion

        #region Command

        public AsyncCommand StartGameCmd { get; }

        public AsyncCommand MakeMoveCmd { get; }

        #endregion

        public MainViewModel(IAlgorithmService algorithm, IValidator gameValidator)
        {
            if (algorithm is null)
            {
                throw new ArgumentNullException(nameof(algorithm));
            }

            _gameValidator = gameValidator ?? throw new ArgumentNullException(nameof(gameValidator));

            IsComputerStart = true;

            IsEnabledGameBoard = false;

            for (var i = 0; i < 3; i++)
            {
                for (var j = 0; j < 3; j++)
                {
                    BoardItems.Add(new BoardItemViewModel(new[] {i, j}, ' '.ToString()));
                }
            }

            StartGameCmd = new StartGameCommand(this);

            MakeMoveCmd = new MakeMoveCommand(this, algorithm, _gameValidator);
        }

        public void UpdateBoard(int[] value, string inputSymbol)
        {
            try
            {
                var currentItem = BoardItems.FirstOrDefault(x => x.Position.SequenceEqual(value));
                currentItem.Title = inputSymbol;

                if (BoardItems.Count(x => string.IsNullOrEmpty(x.Title)) > 0)
                {
                    var data = _gameValidator.ConvertMatrix(BoardItems.Select(x => char.Parse(x.Title ?? ' '.ToString())).ToArray(), 3, 3);
                
                    var gameFinish = _gameValidator.Evaluate(data);

                    switch (gameFinish)
                    {
                        case 'X':
                        {
                            ClearRound("Computer is Win!");
                            break;
                        }
                        case '0':
                        {
                            ClearRound("Player is Win!");
                            break;
                        }
                        default:
                            break;
                    }
                }
                else
                {
                    ClearRound("Game is Finish. Draw!");
                }
            }
            catch (Exception e)
            {
                //log
                Console.WriteLine(e);
            }
        }

        public void ResetBoard()
        {
            BoardItems.ForEach(x => x.Title = null);
        }

        private void ClearRound(string message)
        {
            MessageBox.Show(message);
            IsEnabledGameBoard = false;
            ResetBoard();
        }
    }
}