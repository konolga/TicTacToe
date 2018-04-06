using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Popups;



// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Game
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        bool pressed = false;
        string element = "O";//always begin with O
        char[,] data = new char[3, 3];
        char winner = '\0';//winner can be O, X or empty (\0)

        public MainPage()
        {
            this.InitializeComponent();

        }

        //The logic to change from X to O. Also get the position of clicked button
        private void Change(int i, int j)
        {
            if (pressed)
            {
                data[i, j] = 'X';
                element = "O";
                pressed = false;
            }
            else if (pressed == false)
            {
                data[i, j] = 'O';
                element = "X";
                pressed = true;
            }
            WinWin(); //after element is written on the button we want to check if there is a winner
        }

        //If click button, get position of the button on the grid (x,y) and write element on it (X or O)
        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            int x = (int)btn.GetValue(Grid.RowProperty);
            int y = (int)btn.GetValue(Grid.ColumnProperty);
            btn.Content = element;
            Change(x, y);//goes to Change -->(i,j)
            btn.IsEnabled = false;//Button cannot be clicked twice
        }

        //Method to check the winner
        private async void WinWin()
        {
            //case one: check rows
            for (int i = 0; i < 3; i++)
            {
                if ((data[i, 0] == data[i, 1] && data[i, 0] == data[i, 2] && data[i, 0] != '\0'))
                {
                    winner = data[i, 0];
                }
            }
            //case two: check columns
            for (int i = 0; i < 3; i++)
            {
                if (data[0, i] == data[1, i] && data[0, i] == data[2, i] && data[0, i] != '\0')
                {
                    winner = data[0, i];
                }
            }

            //case three: check diagonals
            if ((data[0, 0] == data[1, 1] && data[2, 2] == data[0, 0] && data[0, 0] != '\0')
                || (data[0, 2] == data[1, 1] && data[1, 1] == data[2, 0] && data[1, 1] != '\0'))
            {
                winner = data[1, 1];
            }

            //Show message is there is a winner.
            if (winner != '\0')
            {
                await new MessageDialog("The winner of this game is :" + winner).ShowAsync();
                StartOver();
            }
        }

        //Method to start game from the beggining
        private void StartOver()
        {
           Array.Clear(data,0,data.Length); //clear data array for WinWin
            winner = '\0';

            Btn1.IsEnabled = true; //enable and clear all buttons
            Btn1.Content = "";

            Btn2.IsEnabled = true;
            Btn2.Content = "";

            Btn3.IsEnabled = true;
            Btn3.Content = "";

            Btn4.IsEnabled = true;
            Btn4.Content = "";

            Btn5.IsEnabled = true;
            Btn5.Content = "";

            Btn6.IsEnabled = true;
            Btn6.Content = "";

            Btn7.IsEnabled = true;
            Btn7.Content = "";

            Btn8.IsEnabled = true;
            Btn8.Content = "";

            Btn9.IsEnabled = true;
            Btn9.Content = "";
        }

        //Start game again on Button click
        private void BtnOver_Click(object sender, RoutedEventArgs e)
        {
            StartOver(); //using StartOver method
        }
    }
}


//Technical part. On the side we want to have a table of all x and 0 entered
//00 01 02
//10 11 12
//20 21 22
//<Button Content = "Button" Visibility="Collapsed"  Height="67" Canvas.Left="657" Canvas.Top="454" Width="118" Click="Button_Click" ></Button>
//<TextBlock Name = "TxtBlock1" Visibility="Collapsed" Height="151" Canvas.Left="660" TextWrapping="Wrap" Text="TextBlock" Canvas.Top="264" Width="140"/>
//private void Button_Click(object sender, RoutedEventArgs e)
//{
//    TxtBlock1.Text = "";

//    for (int i = 0; i < 3; i++)
//    {
//        for (int j = 0; j < 3; j++)
//        {
//            char c = data[i, j];
//            if (c == '\0')
//            {
//                c = '_';
//            }

//            TxtBlock1.Text += c + "\t";
//        }
//        TxtBlock1.Text += "\n";
//    }
//}


