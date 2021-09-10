using PlayFlockTest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaction logic for UnitEditControl.xaml
    /// </summary>
    public partial class EditUnitControl : UserControl
    {
        public static readonly DependencyProperty UnitIdProperty = DependencyProperty.Register("UnitId", typeof(int), typeof(EditUnitControl), new PropertyMetadata(0));
        public static readonly DependencyProperty CurrentHpProperty = DependencyProperty.Register("CurrentHp", typeof(int), typeof(EditUnitControl), new PropertyMetadata(0));
        public static readonly DependencyProperty CurrentManaProperty = DependencyProperty.Register("CurrentMana", typeof(int), typeof(EditUnitControl), new PropertyMetadata(0));
        public static readonly DependencyProperty MaxHpProperty = DependencyProperty.Register("MaxHp", typeof(int), typeof(EditUnitControl), new PropertyMetadata(0));
        public static readonly DependencyProperty MaxManaProperty = DependencyProperty.Register("MaxMana", typeof(int), typeof(EditUnitControl), new PropertyMetadata(0));
        public static readonly DependencyProperty ArmorProperty = DependencyProperty.Register("Armor", typeof(int), typeof(EditUnitControl), new PropertyMetadata(0));
        public static readonly DependencyProperty MagResistProperty = DependencyProperty.Register("MagResist", typeof(int), typeof(EditUnitControl), new PropertyMetadata(0));
        public static readonly DependencyProperty XProperty = DependencyProperty.Register("X", typeof(int), typeof(EditUnitControl), new PropertyMetadata(0));
        public static readonly DependencyProperty YProperty = DependencyProperty.Register("Y", typeof(int), typeof(EditUnitControl), new PropertyMetadata(0));
        public static readonly DependencyProperty RootUnitProperty = DependencyProperty.Register("RootUnit", typeof(Unit), typeof(EditUnitControl), new PropertyMetadata(new Unit()));
        public static readonly DependencyProperty ClassProperty = DependencyProperty.Register("Class", typeof(UnitClass), typeof(EditUnitControl), new PropertyMetadata(UnitClass.Warrior));
        public static readonly DependencyProperty GreenButtonCommandProperty = DependencyProperty.Register("GreenButtonCommand", typeof(ICommand), typeof(EditUnitControl), new PropertyMetadata(null));
        public static readonly DependencyProperty RedButtonCommandProperty = DependencyProperty.Register("RedButtonCommand", typeof(ICommand), typeof(EditUnitControl), new PropertyMetadata(null));
        private EditUnitControlMode _selectionMode;
        public EditUnitControlMode SelectionMode
        {
            get => _selectionMode;
            set => _selectionMode = value;
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

        public Unit RootUnit
        {
            get { return (Unit)GetValue(RootUnitProperty); }
            set { SetValue(RootUnitProperty, value); }
        }
        public int UnitId
        {
            get { return (int)GetValue(UnitIdProperty); }
            set { SetValue(UnitIdProperty, value); }
        }
        public int CurrentHp
        {
            get { return (int)GetValue(CurrentHpProperty); }
            set { SetValue(CurrentHpProperty, value); }
        }
        public int CurrentMana
        {
            get { return (int)GetValue(CurrentManaProperty); }
            set { SetValue(CurrentManaProperty, value); }
        }
        public int MaxHp
        {
            get { return (int)GetValue(MaxHpProperty); }
            set { SetValue(MaxHpProperty, value); }
        }
        public int MaxMana
        {
            get { return (int)GetValue(MaxManaProperty); }
            set { SetValue(MaxManaProperty, value); }
        }
        public int Armor
        {
            get { return (int)GetValue(ArmorProperty); }
            set { SetValue(ArmorProperty, value); }
        }
        public int MagResist
        {
            get { return (int)GetValue(MagResistProperty); }
            set { SetValue(MagResistProperty, value); }
        }
        public UnitClass Class
        {
            get { return (UnitClass)GetValue(ClassProperty); }
            set { SetValue(ClassProperty, value); }
        }
        public int X
        {
            get { return (int)GetValue(XProperty); }
            set { SetValue(XProperty, value); }
        }
        public int Y
        {
            get { return (int)GetValue(YProperty); }
            set { SetValue(YProperty, value); }
        }
        public string EditGreenButton { get; set; } = "Edit";
        public string EditRedButton { get; set; } = "Cancel";
        public string CreateGreenButton { get; set; } = "Create";
        public string CreateRedButton { get; set; } = "Reset";

        public void SetUnit(Unit unit)
        {
            RootUnit = unit;
            UnitId = unit.Id;
            CurrentHp = unit.Hp;
            CurrentMana = unit.Mana;
            MaxHp = unit.MaxHp;
            MaxMana = unit.MaxMana;
            Armor = unit.Armor;
            MagResist = unit.MagResist;
            classComboBox.SelectedItem = unit.Class;
            X = unit.X;
            Y = unit.X;
        }
        public Unit UpdateUnit()
        {
            RootUnit.MaxHp = MaxHp;
            RootUnit.MaxMana = MaxMana;
            RootUnit.Hp = CurrentHp;
            RootUnit.Mana = CurrentMana;
            RootUnit.Armor = Armor;
            RootUnit.MagResist = MagResist;
            RootUnit.Class = Class;
            RootUnit.X = X;
            RootUnit.Y = Y;

            return RootUnit;
        }

        public EditUnitControl()
        {
            InitializeComponent();
            root.DataContext = this;
            classComboBox.ItemsSource = Enum.GetValues(typeof(UnitClass)).Cast<UnitClass>();
            switch (SelectionMode)
            {
                case EditUnitControlMode.Create:
                    greenButton.Content = CreateGreenButton;
                    redButton.Content = CreateRedButton;
                    break;
                case EditUnitControlMode.Edit:
                    greenButton.Content = EditGreenButton;
                    redButton.Content = EditRedButton;
                    break;
                default:
                    break;
            }
        }
        public event RoutedEventHandler RedButtonClick;
        public event RoutedEventHandler GreenButtonClick;

        private void redButton_Click(object sender, RoutedEventArgs e)
        {
            RedButtonClick?.Invoke(sender, e);
        }

        private void greenButton_Click(object sender, RoutedEventArgs e)
        {
            GreenButtonClick?.Invoke(sender, e);
        }
    }
}
