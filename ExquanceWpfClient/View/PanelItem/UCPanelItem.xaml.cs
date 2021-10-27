using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ExquanceWpfClient.View.PanelItem
{
    public partial class UCPanelItem : UserControl
    {
        #region dep properties
        
        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(
            "Title", typeof(string), typeof(UCPanelItem), new PropertyMetadata(default(string)));

        public string Title
        {
            get { return (string) GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public static readonly DependencyProperty MakeMoveCommandProperty = DependencyProperty.Register(
            "MakeMoveCommand", typeof(ICommand), typeof(UCPanelItem), new PropertyMetadata(default(ICommand)));

        public ICommand MakeMoveCommand
        {
            get { return (ICommand) GetValue(MakeMoveCommandProperty); }
            set { SetValue(MakeMoveCommandProperty, value); }
        }
        
        #endregion
        public UCPanelItem()
        {
            InitializeComponent();
        }
    }
}