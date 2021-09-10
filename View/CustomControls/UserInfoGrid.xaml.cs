using PlayFlockTest.Model;
using PlayFlockTest.View.Windows;
using PlayFlockTest.ViewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
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
    /// Interaction logic for UserInfoGrid.xaml
    /// </summary>
    public partial class UserInfoGrid : UserControl
    {
        public static readonly DependencyProperty EditButtonCommandProperty = DependencyProperty.Register("EditButtonCommand", typeof(ICommand), typeof(UserInfoGrid), new PropertyMetadata(null));
        public static readonly DependencyProperty RemoveButtonCommandProperty = DependencyProperty.Register("RemoveButtonCommand", typeof(ICommand), typeof(UserInfoGrid), new PropertyMetadata(null));
        public static readonly DependencyProperty UnitsSourceProperty = DependencyProperty.Register("UnitsSource", typeof(IList), typeof(UserInfoGrid), new PropertyMetadata(new PropertyChangedCallback(OnUnitsSourcePropertyChanged)));

        public IList UnitsSource
        {
            get { return (IList)GetValue(UnitsSourceProperty); }
            set { SetValue(UnitsSourceProperty, value); }
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

        public UserInfoGrid()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Обновляем отображаемую коллекцию
        /// </summary>
        private void Refresh()
        {
            if (UnitsSource != null)
            {
                MainStackPanel.Children.Clear();
                foreach (var unit in UnitsSource)
                {
                    var uip = new UnitInfoPanel() { RootUnit = (Unit)unit, RemoveButtonCommand = RemoveCommand, EditButtonCommand = EditCommand };
                    MainStackPanel.Children.Add(uip);
                }
            }
        }

        ///<summary>
        ///Метод, который вызывается когда меняется свойство
        ///</summary>
        private static void OnUnitsSourcePropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var uig = sender as UserInfoGrid;
            if (uig != null)
            {
                uig.OnUnitSourceChanged((IEnumerable)e.OldValue, (IEnumerable)e.NewValue);
                uig.Refresh();
            }
        }

        ///<summary>
        ///Метод, который вызывается когда изменяется сам источник юнитов,
        ///в него мы передаём старое значение и новое значение
        ///</summary>
        private void OnUnitSourceChanged(IEnumerable oldValue, IEnumerable newValue)
        {
            var oldValueINotifyCollectionChanged = oldValue as INotifyCollectionChanged;
            if (oldValueINotifyCollectionChanged != null)
            {
                oldValueINotifyCollectionChanged.CollectionChanged -= new NotifyCollectionChangedEventHandler(newValueINotifyCollectionChanged_CollectionChanged);
            }
            var newValueINotifyCollectionChanged = newValue as INotifyCollectionChanged;
            if (newValueINotifyCollectionChanged != null)
            {
                newValueINotifyCollectionChanged.CollectionChanged += new NotifyCollectionChangedEventHandler(newValueINotifyCollectionChanged_CollectionChanged);
            }
        }

        ///<summary>
        ///Ну а тут у нас событие, что делать если коллекция изменилась
        ///</summary>
        private void newValueINotifyCollectionChanged_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            Refresh();
        }

        private ICommand _removeCommand;
        public ICommand RemoveCommand
        {
            get
            {
                if (_removeCommand != null) return _removeCommand;
                else
                {
                    return new RelayCommand(p =>
                    {
                        //как мы ищём объект для удаления
                        //в дочерний контрол я добавил флажок,
                        //он привязан к событию нажатия кнопки
                        //если кнопка была нажата, то он становится положительным
                        //тогда мы его и удаляем
                        for (int i = 0; i < MainStackPanel.Children.Count; i++)
                        {
                            var uip = MainStackPanel.Children[i] as UnitInfoPanel;
                            if (uip.RootUnit.needToRemove == true)
                            {
                                UnitsSource.RemoveAt(i);
                                break;
                            }
                        }
                    });
                }
            }
        }

        private ICommand _editCommand;
        public ICommand EditCommand
        {
            get
            {
                if (_editCommand != null) return _editCommand;
                else
                {
                    return new RelayCommand(p =>
                    {
                        for (int i = 0; i < MainStackPanel.Children.Count; i++)
                        {
                            var uip = MainStackPanel.Children[i] as UnitInfoPanel;
                            if (uip.RootUnit.needToEdit == true)
                            {
                                Unit tmp = (Unit)uip.RootUnit.Clone();
                                CreateEditWindow editWindow = new CreateEditWindow(EditUnitControlMode.Edit);
                                editWindow.RootUnit = tmp;
                                editWindow.ShowDialog();
                                if (editWindow.DialogResult == true)
                                {
                                    tmp = (Unit)UnitsSource[i];
                                    tmp.ChangeInfo(editWindow.RootUnit);
                                }
                                break;
                            }
                        }
                    });
                }
            }
        }
        private ICommand _addCommand;
        public ICommand AddCommand
        {
            get
            {
                if (_addCommand != null) return _addCommand;
                else
                {
                    return new RelayCommand(p =>
                    {
                        Unit NewUnit = new Unit() { Id = UnitsSource.Count + 1 };
                        CreateEditWindow editWindow = new CreateEditWindow(EditUnitControlMode.Create);
                        editWindow.RootUnit = NewUnit;
                        editWindow.ShowDialog();
                        if (editWindow.DialogResult == true)
                        {
                            UnitsSource.Add(NewUnit);
                        }
                    });
                }
            }
        }
    }
    #region
    //public static readonly DependencyProperty UnitsSourceProperty = DependencyProperty.Register("UnitsSource", typeof(IEnumerable), typeof(UserInfoGrid), new PropertyMetadata(new PropertyChangedCallback(OnUnitsSourcePropertyChanged)));

    //public IEnumerable UnitsSource
    //{
    //    get { return (IEnumerable)GetValue(UnitsSourceProperty); }
    //    set { SetValue(UnitsSourceProperty, value); }
    //}

    //public UserInfoGrid()
    //{
    //    InitializeComponent();
    //}

    ///// <summary>
    ///// Обновляем отображаемую коллекцию
    ///// </summary>
    //private void Refresh()
    //{
    //    if (UnitsSource != null)
    //    {
    //        MainStackPanel.Children.Clear();
    //        foreach (var unit in UnitsSource)
    //        {
    //            MainStackPanel.Children.Add(new UnitInfoPanel() { RootUnit = (Unit)unit });
    //        }
    //    }
    //}

    /////<summary>
    /////Метод, который вызывается когда меняется свойство
    /////</summary>
    //private static void OnUnitsSourcePropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
    //{
    //    var uig = sender as UserInfoGrid;
    //    if (uig != null)
    //    {
    //        uig.OnUnitSourceChanged((IEnumerable)e.OldValue, (IEnumerable)e.NewValue);
    //        uig.Refresh();
    //    }
    //}

    /////<summary>
    /////Метод, который вызывается когда изменяется сам источник юнитов,
    /////в него мы передаём старое значение и новое значение
    /////</summary>
    //private void OnUnitSourceChanged(IEnumerable oldValue, IEnumerable newValue)
    //{
    //    var oldValueINotifyCollectionChanged = oldValue as INotifyCollectionChanged;
    //    if (oldValueINotifyCollectionChanged != null)
    //    {
    //        oldValueINotifyCollectionChanged.CollectionChanged -= new NotifyCollectionChangedEventHandler(newValueINotifyCollectionChanged_CollectionChanged);
    //    }
    //    var newValueINotifyCollectionChanged = newValue as INotifyCollectionChanged;
    //    if (newValueINotifyCollectionChanged != null)
    //    {
    //        newValueINotifyCollectionChanged.CollectionChanged += new NotifyCollectionChangedEventHandler(newValueINotifyCollectionChanged_CollectionChanged);
    //    }
    //}

    /////<summary>
    /////Ну а тут у нас событие, что делать если коллекция изменилась
    /////</summary>
    //private void newValueINotifyCollectionChanged_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    //{
    //    Refresh();
    //}
    #endregion
}
