using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PlayFlockTest.View.CustomControls
{
    /// <summary>
    /// Interaction logic for EditRemoveControl.xaml
    /// </summary>
    public partial class EditRemoveControl : UserControl
    {
        public static readonly DependencyProperty EditButtonCommandProperty = DependencyProperty.Register("EditButtonCommand", typeof(ICommand), typeof(EditRemoveControl), new PropertyMetadata(null));
        public static readonly DependencyProperty RemoveButtonCommandProperty = DependencyProperty.Register("RemoveButtonCommand", typeof(ICommand), typeof(EditRemoveControl), new PropertyMetadata(null));
        public event RoutedEventHandler RemoveClick;
        public event RoutedEventHandler EditClick;

        public ICommand EditButtonCommand
        {
            get { return (ICommand)GetValue(EditButtonCommandProperty); }
            set { SetValue(EditButtonCommandProperty, value); }
        }
        public ICommand RemoveButtonCommand
        {
            get { return (ICommand)GetValue(RemoveButtonCommandProperty); }
            set { SetValue(RemoveButtonCommandProperty, value); }
        }

        public EditRemoveControl()
        {
            InitializeComponent();
        }
        private void removeButton_Click(object sender, RoutedEventArgs e)
        {
            RemoveClick?.Invoke(sender, e);
        }
        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            EditClick?.Invoke(sender, e);
        }
    }
}
