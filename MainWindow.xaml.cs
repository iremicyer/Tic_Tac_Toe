
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TicTacToe1
{

    public partial class MainWindow : Window
    {
        #region private members

        private MarkType[] mResults;
        private bool mPlayer1Turn; // oyuncu 1'in sırası X veya oyuncu 2'nin sırası O ise döndürür.
        private bool mGameEnded;

        #endregion // private members
        #region Constructor



        #endregion // constructor
        public MainWindow()

        {
            InitializeComponent();
            NewGame();
        }
      

        private void NewGame()
        {
            mResults = new MarkType[9]; // dizi oluşturur.

            for (var i = 0; i < mResults.Length; i++)
                mResults[i] = MarkType.Free;

            mPlayer1Turn = true;  // birinci oyuncu oyuna başlar.

            Container.Children.Cast<Button>().ToList().ForEach(Button =>
            {
                Button.Content = string.Empty;
                Button.Background = Brushes.White;
                Button.Foreground = Brushes.Blue;

            });
            mGameEnded = false; // oyun hala devam ediyor.


            /////////////


            var buttons = Container.Children.Cast<Button>().ToList();
            foreach (var b in buttons)
            {
                b.Content = string.Empty;
                b.Background = Brushes.White;
                b.Foreground = Brushes.Blue;
            }


            mGameEnded = false; //oyunun hala devam ettiğini gösterir.

        }

    
        private void KazananıKontrol()
        {
            if (mResults[3] != MarkType.Free && (mResults[3] & mResults[4] & mResults[5]) == mResults[3])
            {
                mGameEnded = true; // oyuunu bitirir.
                Button0_1.Background = Button1_1.Background = Button2_1.Background = Brushes.Green; // kazanan butonların arka planı yeşil olacak.
            }


            if (mResults[3] != MarkType.Free && (mResults[3] & mResults[4] & mResults[5]) == mResults[3])
            {

                Button0_1.Background = Button1_1.Background = Button2_1.Background = Brushes.Green;
            }

            if (mResults[6] != MarkType.Free && (mResults[6] & mResults[7] & mResults[8]) == mResults[6])
            {

                Button0_2.Background = Button1_2.Background = Button2_2.Background = Brushes.Green;
            }

            if (mResults[0] != MarkType.Free && (mResults[0] & mResults[3] & mResults[6]) == mResults[0])
            {
                mGameEnded = true;
                Button0_0.Background = Button0_1.Background = Button0_2.Background = Brushes.Green;
            }


            if (mResults[1] != MarkType.Free && (mResults[1] & mResults[4] & mResults[7]) == mResults[1])
            {
                mGameEnded = true;
                Button1_0.Background = Button1_1.Background = Button1_2.Background = Brushes.Green;
            }


            if (mResults[2] != MarkType.Free && (mResults[2] & mResults[5] & mResults[8]) == mResults[2])
            {
                mGameEnded = true;
                Button2_0.Background = Button2_1.Background = Button2_2.Background = Brushes.Green;
            }


            if (mResults[0] != MarkType.Free && (mResults[0] & mResults[4] & mResults[8]) == mResults[0])
            {
                mGameEnded = true;
                Button0_0.Background = Button1_1.Background = Button2_2.Background = Brushes.Green;
            }



            if (mResults[2] != MarkType.Free && (mResults[2] & mResults[4] & mResults[6]) == mResults[2])
            {
                mGameEnded = true;
                Button2_0.Background = Button1_1.Background = Button0_2.Background = Brushes.Green;
            }

            if (!mResults.Any(result => result == MarkType.Free))
            {
                mGameEnded = true;
                Container.Children.Cast<Button>().ToList().ForEach(button =>
                {
                    button.Background = Brushes.Orange; // hiç kazanan olmadığında bütün butonların arkplanı turuncu olur.
                });


            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (mGameEnded) // eğer oyun sonlanırsa yeni oyun başlat.
            {
                NewGame();
                return;
            }
            var Button = (Button)sender;//butona tıklama
            var Column = Grid.GetColumn(Button); // column'u gönderme
            var Row = Grid.GetRow(Button); // row' gönderme
            var index = Column + (Row * 3); // butonların konunu bulmak için index kullanılır.

            if (mResults[index] != MarkType.Free) // eğer hücrenin bir değeri var ise bir şey yapma yani free olsun.
                return;





            mResults[index] = mPlayer1Turn ? MarkType.Cross : MarkType.Nought;
            Button.Content = mPlayer1Turn ? "X" : "O";
            mPlayer1Turn ^= true; // oyunvuların dönüşlerini değiştirir.
            if (!mPlayer1Turn)
                Button.Foreground = Brushes.Red;





            //kazananı kontrol etmek için
            KazananıKontrol();
        }


    }
}



   