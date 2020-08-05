using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool player1 { get; set; }
        int[] fields = { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public MainWindow()
        {
            InitializeComponent();
            this.player1 = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            btn.Content = player1 ? "X" : "O";
            fields[int.Parse(btn.Tag.ToString())] = player1 ? 1 : 2;
            player1 = !player1;
            btn.IsEnabled = false;
            checkWin();
        }

        private void checkWin()
        {
            int i = winInt();
            if (i == 0) return;

            foreach(StackPanel st in Grid1.Children.OfType<StackPanel>())
                foreach(Button btn in st.Children.OfType<Button>()) 
                    btn.IsEnabled = false;

            if (i == 1) WinningLabel.Content = "Player 1 won the game!";
            if (i == 2) WinningLabel.Content = "Player 2 won the game!";
        }

        private int winInt()
        {
            if (fields[0] == 1 && fields[1] == 1 && fields[2] == 1) return 1;
            if (fields[3] == 1 && fields[4] == 1 && fields[5] == 1) return 1;
            if (fields[6] == 1 && fields[7] == 1 && fields[8] == 1) return 1;
            if (fields[0] == 1 && fields[3] == 1 && fields[6] == 1) return 1;
            if (fields[1] == 1 && fields[4] == 1 && fields[7] == 1) return 1;
            if (fields[2] == 1 && fields[5] == 1 && fields[8] == 1) return 1;
            if (fields[0] == 1 && fields[4] == 1 && fields[8] == 1) return 1;
            if (fields[6] == 1 && fields[4] == 1 && fields[2] == 1) return 1;

            if (fields[0] == 2 && fields[1] == 2 && fields[2] == 2) return 2;
            if (fields[3] == 2 && fields[4] == 2 && fields[5] == 2) return 2;
            if (fields[6] == 2 && fields[7] == 2 && fields[8] == 2) return 2;
            if (fields[0] == 2 && fields[3] == 2 && fields[6] == 2) return 2;
            if (fields[1] == 2 && fields[4] == 2 && fields[7] == 2) return 2;
            if (fields[2] == 2 && fields[5] == 2 && fields[8] == 2) return 2;
            if (fields[0] == 2 && fields[4] == 2 && fields[8] == 2) return 2;
            if (fields[6] == 2 && fields[4] == 2 && fields[2] == 2) return 2;

            return 0;
        }

        private void ResetGame(object sender, RoutedEventArgs e)
        {
            foreach (StackPanel st in Grid1.Children.OfType<StackPanel>())
                foreach (Button btn in st.Children.OfType<Button>())
                {
                    btn.Content = "";
                    btn.IsEnabled = true;
                }

            player1 = true;
            fields = new int[9]{ 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            WinningLabel.Content = "";
        }
    }
}
