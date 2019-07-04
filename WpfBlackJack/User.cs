using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace WpfBlackJack
{
    class User : PlayerBase
    {
        public User(List<Card> hand, int score, bool burst) : base(hand, score, burst) { }

        public override void Draw(List<Card> decks, Window1 window1)
        {
            var drawcard = Util.DrawCommon(this,decks);


            // 表示
            //Console.WriteLine("あなたの引いたカードは" + drawcard.Mark + "の" + drawcard.NoString + "です。");


            // コントロール作成
            System.Windows.Controls.Image image = new System.Windows.Controls.Image
            {
                Name = "userhand" + Hand.Count,
                Width = 65,
                Height = 77
            };

            window1.userscore.Content = Score;

            // 追加
            window1.userhands.Children.Add(image);

            // 画像表示
            image.Source = new BitmapImage(new Uri(CommonConstants.RESOURCES_PASS + "card_"+ drawcard.Mark + "_" + String.Format(CommonConstants.IMAGE_NUMBER_FORMAT, drawcard.No) + ".png", UriKind.Relative));
        }
    }
}
