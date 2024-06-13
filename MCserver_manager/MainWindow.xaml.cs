using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Net.Http;
using Microsoft.Win32;
using System.IO.Compression;
using System.Diagnostics;


namespace MCserver_manager
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

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFolderDialog dialog = new OpenFolderDialog()
            {
                Title = "サーバーを置くディレクトリの選択",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                Multiselect = false
            };

            string folderName = "";
            if (dialog.ShowDialog() == true)
            {
                folderName = dialog.FolderName;
            }

            this.TextBox1.Text = folderName;

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Minecraft EULAに同意しますか？", "EULAの確認", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                string folderName = TextBox1.Text;

                File.Delete(@$"{folderName}\run.bat");
                File.Delete(@$"{folderName}\eula.txt");
                File.AppendAllText(@$"{folderName}\run.bat", "@echo off\r\njava -Xmx4G -Xms4G -jar server.jar\r\npause");
                File.AppendAllText(@$"{folderName}\eula.txt", "#By changing the setting below to TRUE you are indicating your agreement to our EULA (https://aka.ms/MinecraftEULA).\r\n#Fri Jun 14 00:36:47 GMT+09:00 2024\r\neula = true");

                MessageBox.Show("サーバーを起動します。");

                var app = new ProcessStartInfo();

                app.FileName = @$"{folderName}\run.bat";
                app.CreateNoWindow = true;
                app.UseShellExecute = false;

                Process.Start(app);

                this.Close();
            }
            else
            {
                this.Close();
            }

            
            
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }
    }
}

