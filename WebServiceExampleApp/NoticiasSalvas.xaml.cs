using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using WebServiceExampleApp.Repository;

namespace WebServiceExampleApp
{
    public partial class NoticiasSalvas : PhoneApplicationPage
    {
        public NoticiasSalvas()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            List<Noticias> noticias = Repository.NoticiasRepositorio.Get();
            lstSalvas.ItemsSource = noticias;
        }
    }
}