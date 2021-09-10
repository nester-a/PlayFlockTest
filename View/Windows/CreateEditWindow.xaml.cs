using PlayFlockTest.Model;
using PlayFlockTest.View.CustomControls;
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
using System.Windows.Shapes;

namespace PlayFlockTest.View.Windows
{
    /// <summary>
    /// Interaction logic for CreateEditWindow.xaml
    /// </summary>
    public partial class CreateEditWindow : Window
    {
        public static readonly DependencyProperty RootUnitProperty = DependencyProperty.Register("RootUnit", typeof(Unit), typeof(CreateEditWindow), new PropertyMetadata(new Unit()));
        public static readonly DependencyProperty GreenButtonCommandProperty = DependencyProperty.Register("GreenButtonCommand", typeof(ICommand), typeof(CreateEditWindow), new PropertyMetadata(null));
        public static readonly DependencyProperty RedButtonCommandProperty = DependencyProperty.Register("RedButtonCommand", typeof(ICommand), typeof(CreateEditWindow), new PropertyMetadata(null));
        private EditUnitControlMode _selectionMode;
        public EditUnitControlMode SelectionMode
        {
            get => _selectionMode;
            set => _selectionMode = value;
        }

        public Unit RootUnit
        {
            get { return (Unit)GetValue(RootUnitProperty); }
            set { SetValue(RootUnitProperty, value); }
        }
        private Unit _tmpUnit;
        public CreateEditWindow(EditUnitControlMode mode)
        {
            InitializeComponent();
            SelectionMode = mode;
            editorControl.SelectionMode = SelectionMode;
            root.DataContext = this;
            _tmpUnit = (Unit)RootUnit.Clone();
        }
        public ICommand GreenButtonCommand
        {
            get { return (ICommand)GetValue(GreenButtonCommandProperty); }
            set { SetValue(GreenButtonCommandProperty, value); }
        }
        public ICommand RedButtonCommand
        {
            get { return (ICommand)GetValue(RedButtonCommandProperty); }
            set { SetValue(RedButtonCommandProperty, value); }
        }

        private void root_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            switch (SelectionMode)
            {
                case EditUnitControlMode.Edit:
                    RootUnit.needToEdit = false;
                    break;
                case EditUnitControlMode.Create:
                    RootUnit.needToEdit = false;
                    break;
            }
        }

        private void editorControl_RedButtonClick(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            if (SelectionMode == EditUnitControlMode.Edit)
            {
                RootUnit = _tmpUnit;
            }
        }

        private void editorControl_GreenButtonClick(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            RootUnit = editorControl.UpdateUnit();
        }
    }
}
