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

namespace TilePuzzle.controls
{
    /// <summary>
    /// Interaction logic for TilePuzzle.xaml
    /// </summary>
    public partial class TilePuzzle : UserControl
    {
        Label[] tiles;
        public TilePuzzle()
        {
            InitializeComponent();
            tiles = new Label[9];
            tiles[0] = l1;
            tiles[1] = l2;
            tiles[2] = l3;
            tiles[3] = l4;
            tiles[4] = l5;
            tiles[5] = l6;
            tiles[6] = l7;
            tiles[7] = l8;
            tiles[8] = l9;

            foreach (Label l in tiles)
                l.MouseDoubleClick += doubleClickPressed;

        }


        public string Order
        {
            get
            {
                string s = "";
                foreach (Label l in tiles)
                    s += l.Content.ToString();
                return s;
            }
            set
            {
                string s = value;
                for (int i = 0; i < 9; i++)
                {
                    tiles[i].Content = s[i];
                    if (s[i] == ' ')
                        tiles[i].Background = Brushes.Gray;
                    else
                        tiles[i].Background = Brushes.White;
                }
            }
        }
        public void move(int i)
        {
            string s = Order;

            int clickedRow = i / 3;
            int clickedColumn = i % 3;

            int grayRow = 0;
            int grayColumn = 0;

            int j = 0;
            for (j = 0; j < 9; j++)
            {
                if (s[j] == ' ')
                {
                    grayRow = j / 3;
                    grayColumn = j % 3;
                    break;
                }
            }
            if ((grayRow == clickedRow && (grayColumn + clickedColumn) % 2 == 1) || (grayColumn == clickedColumn && (grayRow + clickedRow) % 2 == 1))
                Order = switchChars(i, j, s);
        }
        public string switchChars(int i, int j, string s)
        {
            string newStr = "";

            char a = s[i];
            char b = s[j];

            var builder = new StringBuilder();

            for (int k = 0; k < 9; k++)
            {
                if (k == i)
                    builder.Append(b);
                else if (k == j)
                    builder.Append(a);
                else
                    builder.Append(s[k]);
            }
            newStr = builder.ToString();
            return newStr;
        }
        private void doubleClickPressed(object sender, MouseButtonEventArgs e)
        {
            int t = getIndex(sender as Label);
            move(t);
        }
        private int getIndex(Label l)
        {
            int i = 0;
            for (; i < tiles.Length; i++)
                if (tiles[i] == l)
                    break;
            return i;
        }

    }
}
