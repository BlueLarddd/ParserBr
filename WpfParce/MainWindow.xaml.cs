using System;
using System.Windows;
using System.Windows.Media.Imaging;
using HtmlAgilityPack;
using System.Diagnostics;
using System.Reflection;


namespace WpfParce
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string[] text = new string[6];
        public MainWindow()
        {
            this.InitializeComponent();
            parcing();

        }
        public void parcing()
        {
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load("https://news.ykt.ru/");
            string[] headers = new string[6];

            string[] img = new string[6];

            HtmlNodeCollection article_headers = doc.DocumentNode.SelectNodes("//a[@class='n-interesting_title_link']");
            HtmlNodeCollection article_img = doc.DocumentNode.SelectNodes("//a[@class='n-interesting_thumb']//img");
            HtmlNodeCollection article_link = doc.DocumentNode.SelectNodes("//a[@class='n-interesting_title_link']");

            int i = 0;
            foreach (var tag in article_headers)
            {
                if (i >= headers.Length) break;
                headers[i] = tag.InnerText;
                i++;
            }
            i = 0;
            foreach (var tag in article_img)
            {
                if (i >= img.Length) break;
                img[i] = tag.Attributes["src"].Value;
                i++;
            }
            i = 0;
            foreach (var tag in article_link)
            {
                if (i >= text.Length) break;
                text[i] = tag.Attributes["href"].Value;

                i++;
            }
            header1.Text = headers[0];
            header2.Text = headers[1];
            header3.Text = headers[2];
            header4.Text = headers[3];
            BitmapImage image1 = new BitmapImage();
            image1.BeginInit();
            image1.UriSource = new Uri(img[0]);
            image1.EndInit();
            Frontimage1.Source = image1;
            BitmapImage image2 = new BitmapImage();
            image2.BeginInit();
            image2.UriSource = new Uri(img[1]);
            image2.EndInit();
            Frontimage2.Source = image2;
            BitmapImage image3 = new BitmapImage();
            image3.BeginInit();
            image3.UriSource = new Uri(img[2]);
            image3.EndInit();
            Frontimage3.Source = image3;
            BitmapImage image4 = new BitmapImage();
            image4.BeginInit();
            image4.UriSource = new Uri(img[3]);
            image4.EndInit();
            Frontimage4.Source = image4;
            BitmapImage image5 = new BitmapImage();
            image5.BeginInit();
            image5.UriSource = new Uri(img[4]);
            image5.EndInit();

        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("explorer.exe", text[0]);
        }
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("explorer.exe", text[1]);
        }
        private void button3_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("explorer.exe", text[2]);
        }
        private void button4_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("explorer.exe", text[3]);
        }

        private void close_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void restart_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(Assembly.GetExecutingAssembly().Location);
            Environment.Exit(0);
        }
    }

}
