using PlayFlockTest.Model;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PlayFlockTest.View.CustomControls
{
    /// <summary>
    /// Interaction logic for UnitInfoPanel.xaml
    /// </summary>
    public partial class UnitInfoPanel : UserControl
    {
        public static readonly DependencyProperty RootUnitProperty = DependencyProperty.Register("RootUnit", typeof(Unit), typeof(UnitInfoPanel), new PropertyMetadata(null));
        public static readonly DependencyProperty EditButtonCommandProperty = DependencyProperty.Register("EditButtonCommand", typeof(ICommand), typeof(UnitInfoPanel), new PropertyMetadata(null));
        public static readonly DependencyProperty RemoveButtonCommandProperty = DependencyProperty.Register("RemoveButtonCommand", typeof(ICommand), typeof(UnitInfoPanel), new PropertyMetadata(null));
        public event RoutedEventHandler RemoveClick;
        public event RoutedEventHandler EditClick;

        public Unit RootUnit
        {
            get { return (Unit)GetValue(RootUnitProperty); }
            set { SetValue(RootUnitProperty, value); }
        }
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

        public UnitInfoPanel()
        {
            InitializeComponent();
        }

        private void EditRemoveControl_EditClick(object sender, RoutedEventArgs e)
        {
            RemoveClick?.Invoke(sender, e);
            RootUnit.needToEdit = true;
        }
        private void EditRemoveControl_RemoveClick(object sender, RoutedEventArgs e)
        {
            EditClick?.Invoke(sender, e);
            RootUnit.needToRemove = true;
        }
    }
}
