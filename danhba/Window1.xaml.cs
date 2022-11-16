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
using System.Windows.Shapes;

namespace danhba
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            Number.PreviewKeyDown += (s, e) => {
                switch (e.Key)
                {
                    case Key.Tab:
                    case Key.Back:
                        return;
                }
                if (e.Key < Key.Space) return;
                e.Handled = (e.Key < Key.D0 || e.Key > Key.D9) && (e.Key < Key.NumPad0 || e.Key > Key.NumPad9);
            };
        }
        public event Action<object> OnDelete;
        private void Button_Delete_Click(object sender, RoutedEventArgs e)
        {
            var contact = (Contact)DataContext;
            if (MessageBox.Show("Sure to delete " + contact.Name + "?", "Contact", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                OnDelete?.Invoke(contact);
                DialogResult = true;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var contact = (Contact)DataContext;
            contact.Name = Name.Text.Trim();
            contact.Number = Number.Text.Trim();

            if (contact.Number == "" || contact.Name == "")
            {
                MessageBox.Show("");
            }

            //DataContext = contact;
            DialogResult = true;
        }
    }
}
