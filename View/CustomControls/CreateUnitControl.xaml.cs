using PlayFlockTest.Model;
using PlayFlockTest.View.Windows;
using PlayFlockTest.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PlayFlockTest.View.CustomControls
{
    /// <summary>
    /// Interaction logic for CreateUnitControl.xaml
    /// </summary>
    public partial class CreateUnitControl : UserControl
    {

        public static readonly DependencyProperty AddCommandProperty = DependencyProperty.Register("AddCommand", typeof(ICommand), typeof(CreateUnitControl), new PropertyMetadata(null));
        public static readonly DependencyProperty RootUnitProperty = DependencyProperty.Register("RootUnit", typeof(Unit), typeof(CreateUnitControl), new PropertyMetadata(null));
        public Unit RootUnit
        {
            get { return (Unit)GetValue(RootUnitProperty); }
            set { SetValue(RootUnitProperty, value); }
        }

        public ICommand AddCommand
        {
            get { return (ICommand)GetValue(AddCommandProperty); }
            set { SetValue(AddCommandProperty, value); }
        }

        public CreateUnitControl()
        {
            InitializeComponent();
        }

        public event RoutedEventHandler AddButtonClick;
        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            AddButtonClick?.Invoke(sender, e);
        }





        //private ICommand _addCommand;
        //public ICommand AddCommand
        //{
        //    get
        //    {
        //        if (_addCommand != null) return _addCommand;
        //        else
        //        {
        //            return new RelayCommand(p =>
        //            {
        //                RootUnit = new Unit();
        //                CreateEditWindow editWindow = new CreateEditWindow(EditUnitControlMode.Create);
        //                editWindow.RootUnit = RootUnit;
        //                editWindow.ShowDialog();
        //                if (editWindow.DialogResult != true)
        //                {
        //                    RootUnit = null;
        //                }
        //            });
        //        }
        //    }
        //}
    }
}
