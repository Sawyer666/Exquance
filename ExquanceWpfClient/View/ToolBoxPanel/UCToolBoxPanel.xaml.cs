using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ExquanceWpfClient.View.ToolBoxPanel
{
    public partial class UCToolBoxPanel : UserControl
    {
        #region dep properties

        public static readonly DependencyProperty StartGameCommandProperty = DependencyProperty.Register(
            "StartGameCommand", typeof(ICommand), typeof(UCToolBoxPanel), new PropertyMetadata(default(ICommand)));

        public ICommand StartGameCommand
        {
            get { return (ICommand) GetValue(StartGameCommandProperty); }
            set { SetValue(StartGameCommandProperty, value); }
        }
        
        #endregion
        
        public UCToolBoxPanel()
        {
            InitializeComponent();
        }
    }
}