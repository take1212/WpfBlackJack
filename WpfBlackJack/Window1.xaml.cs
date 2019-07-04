using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MessageBox = System.Windows.Forms.MessageBox;

namespace WpfBlackJack
{
    /// <summary>
    /// Window1.xaml の相互作用ロジック
    /// </summary>
    public partial class Window1 : Window
    {
        internal User user;

        internal Dealer dealer;

        internal List<Card> decks;



        public Window1()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // マーク
            string[] marks = new string[] { "heart", "spade", "club", "diamond" };
            // 数字
            int[] nos = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };

            // 山札
            decks = new List<Card>();

            // 山札作成
            foreach (var mark in marks)
            {
                foreach (var no in nos)
                {

                    Card card = new Card
                    {
                        Mark = mark,

                        No = no
                    };

                    //「ハートの5」、「スペードのJ」などの文字列が順番にdecksに代入される
                    decks.Add(card);
                }
            }

            user = new User(new List<Card>(), 0, false);

            dealer = new Dealer(new List<Card>(), 0, false);

            // プレイヤーとディーラーはそれぞれ、カードを2枚引く
            user.Draw(decks, this);
            user.Draw(decks, this);
            dealer.Draw(decks, this);
            dealer.Draw(decks, this);

            drawbutton.Visibility = System.Windows.Visibility.Visible;
            nodrawbutton.Visibility = System.Windows.Visibility.Visible;




            /*           while (true)
                       {

                           //現在の得点を表示
                           Console.WriteLine("あなたの現在の得点は" + user.Score.ToString() + "です");
                           // カードを引くか
                           Console.Out.WriteLine("カードを引きますか？引く場合はYを、引かない場合はNを入力してください。");

                           var drawflag = Console.ReadLine();

                           if (drawflag.Equals("y") || drawflag.Equals("Y"))
                           {
                               user.Draw(decks,this);


                               if (user.Burst)
                               {
                                   break;
                               }
                           }
                           else if (drawflag.Equals("n") || drawflag.Equals("N"))
                           {
                               break;
                           }

                       }*/

            //現在の得点を表示
            // Console.WriteLine("ディーラーの2枚目のカードは" + dealer.Hand[1].Mark + "の" + dealer.Hand[1].NoString + "です。");



            // Console.WriteLine("あなたの得点は" + user.Score.ToString() + "です");

            // Console.WriteLine("ディーラーの得点は" + dealer.Score.ToString() + "です");




            // Console.WriteLine("また遊んでね");
        }


        private void Drawbutton_Click(object sender, RoutedEventArgs e)
        {
            user.Draw(decks,this);


            if (user.Burst)
            {
                drawbutton.Visibility = System.Windows.Visibility.Collapsed;
                nodrawbutton.Visibility = System.Windows.Visibility.Collapsed;

                DealerDraw();
            }
        }

        private void DealerDraw()
        {
            // 2枚目表示
            dealer.image2.Source = new BitmapImage(new Uri(CommonConstants.RESOURCES_PASS + "card_" + dealer.Hand[1].Mark + "_" + String.Format(CommonConstants.IMAGE_NUMBER_FORMAT, dealer.Hand[1].No) + ".png", UriKind.Relative));

            dealerscore.Content = dealer.Score;

            while (true)
            {
                

                if (dealer.Score >= 17)
                {
                    break;
                }

                dealer.Draw(decks, this);

                //Console.WriteLine("ディーラーの現在の得点は" + dealer.Score.ToString() + "です");

            }

            dealerscore.Content = dealer.Score;

            Judgment();
        }

        private void Judgment()
        {
            // 判定
            if ((user.Score > dealer.Score && !user.Burst) || (!user.Burst && dealer.Burst))
            {
                DialogResult dr = MessageBox.Show("YOU WIN!!\n\n続けますか?", "結果", MessageBoxButtons.OKCancel);
                RestartOrExit(dr);
            }
            else if (user.Score != dealer.Score && !dealer.Burst)
            {
                DialogResult dr = MessageBox.Show("YOU LOSE\n\n続けますか?", "結果", MessageBoxButtons.OKCancel);

                RestartOrExit(dr);
            }
            else
            {
                DialogResult dr = MessageBox.Show("引き分け\n\n続けますか?", "結果", MessageBoxButtons.OKCancel);

                RestartOrExit(dr);
            }
        }

        private void RestartOrExit(DialogResult dr)
        {
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                this.Close();
                // ウィンドウ生成
                var window = new Window1();
                // ウィンドウ表示
                window.Show();
            }
            else
            {
                this.Close();
            }
        }

        private void Nodrawbutton_Click(object sender, RoutedEventArgs e)
        {

            drawbutton.Visibility = System.Windows.Visibility.Collapsed;
            nodrawbutton.Visibility = System.Windows.Visibility.Collapsed;

            DealerDraw();
        }

  
    }
}
