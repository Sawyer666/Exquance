using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ExquanceWpfClient.View.PanelItem;

namespace ExquanceWpfClient.View.GameBoard
{
    public partial class UCGameBoard : UserControl
    {
        #region dep properties

        public static readonly DependencyProperty BoardItemsSourceProperty = DependencyProperty.Register(
            "BoardItemsSource", typeof(IEnumerable), typeof(UCGameBoard), new PropertyMetadata(default(IEnumerable)));

        public IEnumerable BoardItemsSource
        {
            get { return (IEnumerable) GetValue(BoardItemsSourceProperty); }
            set { SetValue(BoardItemsSourceProperty, value); }
        }

        public static readonly DependencyProperty MakeMoveOnBoardCommandProperty = DependencyProperty.Register(
            "MakeMoveOnBoardCommand", typeof(ICommand), typeof(UCGameBoard), new PropertyMetadata(default(ICommand)));

        public ICommand MakeMoveOnBoardCommand
        {
            get { return (ICommand) GetValue(MakeMoveOnBoardCommandProperty); }
            set { SetValue(MakeMoveOnBoardCommandProperty, value); }
        }

        #endregion

        public UCGameBoard()
        {
            InitializeComponent();
        }
    }
}