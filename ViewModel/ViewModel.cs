using PlayFlockTest.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PlayFlockTest.ViewModel
{
    public class ViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Unit> _units = new ObservableCollection<Unit>()
        {
            new Unit() { Id = 1, Class = UnitClass.Mage, Hp = 100, Mana = 100 },
            new Unit() { Id = 2, Class = UnitClass.Warrior, Hp = 100, Mana = 100 },
            new Unit() { Id = 3, Class = UnitClass.Archer, Hp = 100, Mana = 100 },
            new Unit() { Id = 4, Class = UnitClass.Warrior, Hp = 100, Mana = 100 },
            new Unit() { Id = 5, Class = UnitClass.Mage, Hp = 100, Mana = 100 },
            new Unit() { Id = 6, Class = UnitClass.Warrior, Hp = 100, Mana = 100 },
            new Unit() { Id = 7, Class = UnitClass.Archer, Hp = 100, Mana = 100 },
            new Unit() { Id = 8, Class = UnitClass.Warrior, Hp = 100, Mana = 100 },
            new Unit() { Id = 9, Class = UnitClass.Mage, Hp = 100, Mana = 100 },
            new Unit() { Id = 10, Class = UnitClass.Warrior, Hp = 100, Mana = 100 },
            new Unit() { Id = 11, Class = UnitClass.Archer, Hp = 100, Mana = 100 },
        };

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Unit> Units
        {
            get => _units;
            set
            {
                _units = value;
                OnPropertyChanged();
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
