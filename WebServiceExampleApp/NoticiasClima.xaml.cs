using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.IO;
using System.Xml;
using System.ServiceModel.Syndication;
using Microsoft.Phone.Tasks;
using System.Xml.Linq;
using WebServiceExampleApp.Repository;

namespace WebServiceExampleApp
{
    public partial class NoticiasClima : PhoneApplicationPage
    {
        public Noticias not { get; set; }
        Objetos salva;
        public NoticiasClima()
        {
            InitializeComponent();
        }

        private void loadFeedButton_Click(object sender, RoutedEventArgs e)
        {
            progress.Visibility = System.Windows.Visibility.Visible;

            WebClient webClient = new WebClient();
            webClient.DownloadStringCompleted += new DownloadStringCompletedEventHandler(RssClient_DownloadStringCompleted);

            webClient.DownloadStringAsync(new Uri(@"http://www.climatempo.com.br/rss/regioes.xml"));

            progress.Visibility = System.Windows.Visibility.Collapsed;
        }

        void RssClient_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                var RssData = from rss in XElement.Parse(e.Result).Descendants("item")
                              select new Objetos
                              {

                                  title = rss.Element("title").Value,
                                  link = rss.Element("link").Value,
                                  description = rss.Element("description").Value,


                              };
                feedListBox.ItemsSource = RssData;
        }   
            catch (Exception ex)
            {
                MessageBox.Show("A Pagina não pode ser Carregada!");
                progress.Visibility = System.Windows.Visibility.Collapsed;
            }
        }

        private void Navigate(string pPage)
        {
            NavigationService.Navigate(new Uri(pPage, UriKind.Relative));
        }
           

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            if (this.State.ContainsKey("feed"))
            {

                if (feedListBox.Items.Count == 0)
                {
                    UpdateFeedList(State["feed"] as string);
                }
            }
        }

        private void UpdateFeedList(string feedXML)
        {
            StringReader stringReader = new StringReader(feedXML);
            XmlReader xmlReader = XmlReader.Create(stringReader);
            SyndicationFeed feed = SyndicationFeed.Load(xmlReader);


            Deployment.Current.Dispatcher.BeginInvoke(() =>
            {
                feedListBox.ItemsSource = feed.Items;

                loadFeedButton.Content = "Refresh Feed";
            });

        }

        private void feedListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

              salva = (sender as ListBox).SelectedItem as Objetos;

              WebBrowserTask wb = new WebBrowserTask();
              wb.Uri = new Uri(salva.link);
              wb.Show();
                 
        }

        private void appBarSave_Click(object sender, EventArgs e)
        {
            Noticias noticias = new Noticias
            {
               News = feedListBox.SelectedItem as Object
            };
            NoticiasRepositorio.create(noticias);
            MessageBox.Show("Noticia Salva!");
        }

        private void appBarFav_Click(object sender, EventArgs e)
        {
            Navigate("/NoticiasSalvas.xaml");
        }

        private void appBarquestionmark_Click(object sender, EventArgs e)
        {

        }

    }
}