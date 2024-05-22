using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace practic7
{
    /// <summary>
    /// Логика взаимодействия для ChatMyProject.xaml
    /// </summary>
    public partial class ChatMyProject : Window
    {
        
        List<Socket> user = new List<Socket>();
        Socket socket;
        public ChatMyProject()
        {
            InitializeComponent();

            socket = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream, ProtocolType.Tcp);
            socket.Connect("26.80.234.197", 5000);
            RecieveMessages(socket);
        }

        private async void SendMessage(string message)
        {
            byte[] b = Encoding.UTF8.GetBytes(message);
            await socket.SendAsync(b, SocketFlags.None);
        }

        private void batton_Click(object sender, RoutedEventArgs e)
        {
            SendMessage(panel.Text);
            ColorAnimation animation = new ColorAnimation();
            animation.From = Colors.Pink;
            animation.To = Colors.DarkSeaGreen;
            animation.Duration = TimeSpan.FromSeconds(1);
            animation.AutoReverse = true;
            animation.RepeatBehavior = RepeatBehavior.Forever;
        }

        private async void RecieveMessages(Socket client)
        {
            while (true)
            {
                byte[] b = new byte[1024];
                await socket.ReceiveAsync(b, SocketFlags.None);
                string message = Encoding.UTF8.GetString(b);

                allmessager.Items.Add(message);
            }
        }

        private void panel_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ColorAnimation animation = new ColorAnimation();
            animation.From = Colors.RosyBrown;
            animation.To = Colors.Fuchsia;
            animation.Duration = TimeSpan.FromSeconds(1);
            animation.AutoReverse = true;
            animation.RepeatBehavior = RepeatBehavior.Forever;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
    }
    
}
