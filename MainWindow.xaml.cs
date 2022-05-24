using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace FunCanvas
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Black;
            
       

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            new Thread(StartDraw).Start();
        }

        private void StartDraw()
        {
            int count = 0;
            while (count <= 2500)
            {
             //   Random rd = new Random();
                for (int i = 0; i <= 700; i += 20) { 
                    Thread obj1 = new Thread(() => move(i,count));
                obj1.Start();
             
            }
                
                count+=20;
                if (count >= 500)
                {
                    ClearCanvas();
                    StartDraw();
                }
               

            }
            
        }
        private void  move(int posx,int count) {
            Random rd = new Random();
            draw(posx, count, rd.Next(1, 10),31, 170, 59);
            Thread.Sleep(400);
         
        }
        private void draw(int posx,int posy,int num,int r,int g ,int b) {
            Text(posx, posy,num, Color.FromRgb(Convert.ToByte(r), Convert.ToByte(g), Convert.ToByte(b)));
        }

        private void Text(double x, double y, int num, Color color)
        {
            this.Dispatcher.Invoke(() =>
            {
                TextBlock textBlock = new TextBlock();
                textBlock.Text = Convert.ToString(num);
                textBlock.Foreground = new SolidColorBrush(color);
                Canvas.SetLeft(textBlock, x);
                Canvas.SetTop(textBlock, y);
                canvas.Children.Add(textBlock);
            });
        }

        private void ClearCanvas()
        {
            this.Dispatcher.Invoke(() =>
            {
                canvas.Children.Clear();
            });
        }


    }
}
