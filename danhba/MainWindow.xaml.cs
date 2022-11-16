using System;
using System.Collections.Generic;
using System.Data;
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

namespace danhba
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        List<Contact> data = new List<Contact>();
        void Update()
        {
            MainTable.ItemsSource = null;
            MainTable.ItemsSource = data;

        }
        public MainWindow()
        {
            InitializeComponent();

            var prov = new Provider();
            var table = prov.ReadTable("SELECT * FROM Contacts where Id > 1 order by Name desc");
            foreach(DataRow r in table.Rows)
            {
                var contact = new Contact();
                contact.Name = (string)r["Name"];
                contact.Number = (string)r["Number"];
                data.Add(contact);
            }

            Update();
            MainTable.MouseDoubleClick += (o, e) =>
            {
                var item = MainTable.SelectedItem as Contact;
                if (item != null)
                {
                    BeginEdit(item);
                }
            };
        }
        EditContext context;
        private void AddNew_Click(object sender, RoutedEventArgs e)
        {
            BeginEdit(null);
        }
        void BeginEdit(Contact e)
        {
            context = new EditContext { 
                Action = e == null ? DataActions.Insert : DataActions.Update,
                Value = e == null ? new Contact() : e,
            };
            var dlg = new Window1();
            dlg.OnDelete += contact => {
                Demo.Contacts.Remove((Contact)context.Value);
                Update();
            };

            dlg.DataContext = context.Value;
            if (dlg.ShowDialog() == true)
            {
                if (context.Action == DataActions.Insert) { 
                    Demo.Contacts.Add((Contact)context.Value); 
                    Update();
                }
            }
        }
    }
}
