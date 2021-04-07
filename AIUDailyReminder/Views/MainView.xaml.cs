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

namespace AIUDailyReminder.Views
{
    /// <summary>
    /// Логика взаимодействия для MainView.xaml
    /// </summary>
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();
        }


        public bool ReminderEnabled
        {
            get { return (bool)GetValue(ReminderEnabledProperty); }
            set { SetValue(ReminderEnabledProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ReminderEnabled.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ReminderEnabledProperty =
            DependencyProperty.Register("ReminderEnabled", typeof(bool), typeof(MainView), new PropertyMetadata(true));


        public bool BusinessListEnabled
        {
            get { return (bool)GetValue(BusinessListEnabledProperty); }
            set { SetValue(BusinessListEnabledProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BusinessListEnabled.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BusinessListEnabledProperty =
            DependencyProperty.Register("BusinessListEnabled", typeof(bool), typeof(MainView), new PropertyMetadata(false));




        public Visibility ReminderVisibility
        {
            get { return (Visibility)GetValue(ReminderVisibilityProperty); }
            set { SetValue(ReminderVisibilityProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ReminderVisibility.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ReminderVisibilityProperty =
            DependencyProperty.Register("ReminderVisibility", typeof(Visibility), typeof(MainView), new PropertyMetadata(Visibility.Visible));




        public Visibility BusinessListVisibility
        {
            get { return (Visibility)GetValue(BusinessListVisibilityProperty); }
            set { SetValue(BusinessListVisibilityProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BusinessListVisibility.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BusinessListVisibilityProperty =
            DependencyProperty.Register("BusinessListVisibility", typeof(Visibility), typeof(MainView), new PropertyMetadata(Visibility.Hidden));






        private void UpdateVisibility(bool r, bool b)
        {
            ReminderEnabled = r;
            BusinessListEnabled = b;

            ReminderVisibility = r ? Visibility.Visible : Visibility.Hidden;
            BusinessListVisibility = b ? Visibility.Visible : Visibility.Hidden;
        }

        private void ReminderView_Click(object sender, RoutedEventArgs e)
        {
            UpdateVisibility(true, false);
        }

        private void BusinessListView_Click(object sender, RoutedEventArgs e)
        {
            UpdateVisibility(false, true);
        }

        protected override void OnClosed(EventArgs e)
        {
            System.Environment.Exit(0);
        }
    }
}
