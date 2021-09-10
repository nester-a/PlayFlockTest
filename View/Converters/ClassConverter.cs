using PlayFlockTest.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace PlayFlockTest.View.Converters
{
    class ClassConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value != null && value is UnitClass)
            {
                switch((UnitClass)value)
                {
                    case UnitClass.Warrior:
                        return "WARRIOR";
                    case UnitClass.Archer:
                        return "ARCHER";
                    case UnitClass.Mage:
                        return "MAGE";
                    default:
                        return string.Empty;
                }
            }
            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
