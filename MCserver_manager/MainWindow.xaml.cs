using System.Windows;
using System.Windows.Controls;
using System.IO;
using Microsoft.Win32;
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


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog()
            {
                Title = "サーバーにするjarファイルを選択",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                Multiselect = false
            };

            string fileName = "";
            if (dialog.ShowDialog() == true)
            {
                fileName = dialog.FileName;
            }

            this.TextBox1.Text = fileName;

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Minecraft EULAに同意しますか？", "EULAの確認", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                string fileName = TextBox1.Text;

                string foldername = Directory.GetCurrentDirectory();

                string ramPath = TextBox2.Text;

                File.Delete(@$"{foldername}\run.bat");
                File.Delete(@$"{foldername}\eula.txt");
                File.Delete(@$"{foldername}\server.jar");

                File.Copy(@$"{fileName}", @$"{foldername}\server.jar");

                string s = "@echo off" + Environment.NewLine + $"java -Xmx{ramPath}G -Xms{ramPath}G -jar server.jar" + Environment.NewLine + "pause";
                File.AppendAllText(@$"{foldername}\run.bat", @$"{s}");
                File.AppendAllText(@$"{foldername}\eula.txt", "#By changing the setting below to TRUE you are indicating your agreement to our EULA (https://aka.ms/MinecraftEULA).\r\n#Fri Jun 14 00:36:47 GMT+09:00 2024\r\neula = true");

                MessageBox.Show("サーバーを起動します。");

                var app = new ProcessStartInfo();

                app.FileName = @$"{foldername}\run.bat";
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

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            string foldername = Directory.GetCurrentDirectory();

            var app = new ProcessStartInfo();

            app.FileName = @$"{foldername}\run.bat";
            app.CreateNoWindow = true;
            app.UseShellExecute = false;

            Process.Start(app);

            MessageBox.Show("サーバーを起動します。");

            this.Close();
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            TextBox2.Text = Slider1.Value.ToString();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox2_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }
    }
}