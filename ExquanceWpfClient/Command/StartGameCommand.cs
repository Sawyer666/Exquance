using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ExquanceWpfClient.ViewModel;

namespace ExquanceWpfClient.Command
{
    public class StartGameCommand : AsyncCommand
    {
        #region private

        private readonly MainViewModel _vm;
        private Random gen;
        #endregion

        public StartGameCommand(MainViewModel vm)
        {
            _vm = vm ?? throw new ArgumentNullException(nameof(vm));
            gen = new Random();
        }

        public override async Task ExecuteAsync(object parameter)
        {
            await Task.Delay(500);

            _vm.IsEnabledGameBoard = true;
            
            _vm.IsComputerStart = true;

            _vm.ResetBoard();
            
            var position = new[] {gen.Next(0, 2), gen.Next(0, 2)};
            
            var moveData = _vm.BoardItems.FirstOrDefault(x => x.Position.SequenceEqual(position));

            await _vm.MakeMoveCmd.ExecuteAsync(moveData);
        }
    }
}