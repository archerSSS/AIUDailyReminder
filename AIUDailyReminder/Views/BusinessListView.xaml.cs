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

namespace AIUDailyReminder.Views
{
    /// <summary>
    /// Логика взаимодействия для BuisnessListView.xaml
    /// </summary>
    public partial class BusinessListView : UserControl
    {
        public BusinessListView()
        {
            InitializeComponent();
        }



        public bool CalendarEnabled
        {
            get { return (bool)GetValue(CalendarEnabledProperty); }
            set { SetValue(CalendarEnabledProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CalendarEnabled.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CalendarEnabledProperty =
            DependencyProperty.Register("CalendarEnabled", typeof(bool), typeof(BusinessListView), new PropertyMetadata(false));





        public Visibility CalendarVisibility
        {
            get { return (Visibility)GetValue(CalendarVisibilityProperty); }
            set { SetValue(CalendarVisibilityProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CalendarVisibility.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CalendarVisibilityProperty =
            DependencyProperty.Register("CalendarVisibility", typeof(Visibility), typeof(BusinessListView), new PropertyMetadata(Visibility.Hidden));

        private void OpenCalendar_Click(object sender, RoutedEventArgs e)
        {
            if (CalendarVisibility == Visibility.Visible) CalendarVisibility = Visibility.Hidden;
            else CalendarVisibility = Visibility.Visible;

            CalendarEnabled = !CalendarEnabled;
        }





        private void Grid_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            string s = "";
        }

        private void TextBox_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            
            /*if (!TextDescription.IsEnabled)
            {
                RemindAlertView RAV = new RemindAlertView();
                RAV.DataContext = DataContext;
                RAV.Show();
            }*/
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(TextName.Text) && !string.IsNullOrEmpty(TextDescription.Text) && CalendarRemindDate.SelectedDate != null)
            {
                
            }
        }
    }

}
