using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace practic7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();       
            
        }

        private void addchat_Click(object sender, RoutedEventArgs e)
        {
            if(pepolename !=  null && idchat != null)
            {
                ChatMyProject cmp = new ChatMyProject();
                cmp.pepole.Items.Add(pepolename);
            }
            else
            {
                MessageBox.Show("имя пользователя не введено или id не правельный");
            }
        }

        private void createchat_Click(object sender, RoutedEventArgs e)
        {
            String password = "Admin";
            if (pepolename.Text == password)
            {
                ChatMyProject cmp = new ChatMyProject();
                cmp.Show();
                Close();
            }
        }
    }
}
