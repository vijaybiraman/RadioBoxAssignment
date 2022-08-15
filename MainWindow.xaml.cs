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
using LibraryForCountry;
using System.Configuration;

namespace DistinctCountryWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        EmpDataProvider dataProvider = null;
        
        public MainWindow()
        {
            InitializeComponent();
            dataProvider = new EmpDataProvider(ConfigurationManager.ConnectionStrings["connstr"].ConnectionString);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string name = txtcountry.Text;
            getEmps.DataContext = dataProvider.GetEmployees(name);
            
        }

        private void MainLayout_Loaded(object sender, RoutedEventArgs e)
        {
            List<Employee> employees = dataProvider.getCountry();
            foreach(var i in employees)
            {
                txtcountry.Items.Add(i.country);
            }
        }
    }
}
