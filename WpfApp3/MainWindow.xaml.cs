using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using HtmlAgilityPack;

namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string descriptions;
        public MainWindow()
        {
            InitializeComponent();
        }
        //First you need to retrieve html source of the given url
        //Get Url Title
        /*
        private string UrlTitle(string url)
        {
            string source = HtmlSrc(url);
            string title = Regex.Match(source, @"\<title\b[^>]*\>\s*(?<Title>[\s\S]*?)\</title\>", RegexOptions.IgnoreCase).Groups["Title"].Value;

            return title;
        }
        */

        //Get Url Meta Description tag
        private string getMetaDescription(string url) // use HTML Agility, run good with all page which have Meta Desc tag
        {
            //Get Meta Tags
            string description = "null";
            HtmlWeb web = new HtmlWeb();

            try
            {
                HtmlDocument doc = web.Load(url);
                HtmlNode node = doc.DocumentNode.SelectSingleNode("//meta[@property='og:description']");

                description = node.GetAttributeValue("content", "null");
                return description;
            }
            catch
            {
                return "Error retreiving url";
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            string[] urls = textBox.Text.Split("\n");


            foreach (string element in urls)
            { 
                descriptions += getMetaDescription(element) + "\n";
            }
            textBox1.Text = descriptions;
        }
    }
}
