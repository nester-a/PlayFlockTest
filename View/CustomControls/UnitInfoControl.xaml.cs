using PlayFlockTest.Model;
using System.Windows;
using System.Windows.Controls;

namespace PlayFlockTest.View.CustomControls
{
    /// <summary>
    /// Interaction logic for UnitInfoControl.xaml
    /// </summary>
    public partial class UnitInfoControl : UserControl
    {
        public static readonly DependencyProperty RootUnitIdProperty = DependencyProperty.Register("RootUnitId", typeof(int), typeof(UnitInfoControl), new PropertyMetadata(0));
        public static readonly DependencyProperty RootUnitHpProperty = DependencyProperty.Register("RootUnitHp", typeof(int), typeof(UnitInfoControl), new PropertyMetadata(0));
        public static readonly DependencyProperty RootUnitManaProperty = DependencyProperty.Register("RootUnitMana", typeof(int), typeof(UnitInfoControl), new PropertyMetadata(0));
        public static readonly DependencyProperty RootUnitClassProperty = DependencyProperty.Register("RootUnitClass", typeof(UnitClass), typeof(UnitInfoControl), new PropertyMetadata(UnitClass.Warrior));
        public int RootUnitId
        {
            get { return (int)GetValue(RootUnitIdProperty); }
            set { SetValue(RootUnitIdProperty, value); }
        }
        public int RootUnitHp
        {
            get { return (int)GetValue(RootUnitHpProperty); }
            set { SetValue(RootUnitHpProperty, value); }
        }
        public int RootUnitMana
        {
            get { return (int)GetValue(RootUnitManaProperty); }
            set { SetValue(RootUnitManaProperty, value); }
        }
        public UnitClass RootUnitClass
        {
            get { return (UnitClass)GetValue(RootUnitClassProperty); }
            set { SetValue(RootUnitClassProperty, value); }
        }

        public UnitInfoControl()
        {
            InitializeComponent();
        }
    }
}
