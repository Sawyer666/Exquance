using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ExquanceWpfClient.ViewModel;
using GameApi;
using GameApi.AlgoritmService;
using GameApi.ValidateService;

namespace ExquanceWpfClient.Command
{
    public class MakeMoveCommand : AsyncCommand
    {
        #region private

        private readonly MainViewModel _vm;

        private readonly IAlgorithmService _algorithm;

        private readonly IValidator _gameValidator;

        #endregion

        public MakeMoveCommand(MainViewModel vm, IAlgorithmService algorithm, IValidator gameValidator)
        {
            _vm = vm ?? throw new ArgumentNullException(nameof(vm));

            _algorithm = algorithm ?? throw new ArgumentNullException(nameof(algorithm));

            _gameValidator = gameValidator ?? throw new ArgumentNullException(nameof(gameValidator));
        }

        public override async Task ExecuteAsync(object parameter)
        {
            if (parameter is not BoardItemViewModel data) return;

            if (_vm.IsComputerStart)
            {
                _vm.UpdateBoard(data.Position, "X");

                _vm.IsComputerStart = false;
            }
            else
            {
                _vm.UpdateBoard(data.Position, "0");

                var boardSymbols = _vm.BoardItems.Select(x => char.Parse(x.Title ?? "_")).ToArray();

                var items = _gameValidator.ConvertMatrix(boardSymbols, 3, 3);

                var currentSquare = await _algorithm.GetSquare(items);

                _vm.UpdateBoard(currentSquare, "X");
            }
        }
    }
}