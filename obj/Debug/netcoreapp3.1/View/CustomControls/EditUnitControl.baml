   M S B A M L   `   `   `  ����H  DPlayFlockTest, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:PlayFlockTest.View.CustomControls!PlayFlockTest.View.CustomControls  5      7    1PlayFlockTest.View.CustomControls.EditUnitControl   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Alocal/clr-namespace:PlayFlockTest.View.CustomControls     5      -   5          >�Name$
  root��5       � 	Resources 5	       �� 
TargetType �� Property �� Value   borderThickness u� Left u� Right u� Bottom
 u� Top  borderBrush	 �� Color  confirmButtonColor  confirmButtonBorderBrush  cancelButtonColor  cancelButtonBorderBrush��%�  '��       '�� �     '��     &	  �    &	 �    &	 �    &	     &	 ,    &	 I    �� 5
   
   " ��6   .�5      ��  � ��$	 0.5q�60   �� 5       � ��
 �   �6,   �� 5       � ��$ 5q�6'   5      �� 5   
   " ��6   .�5      ��  �@��TextAlignment$ Center=�6.   �� 5       � ��$ Center=�62   5      �� 5   
   " ��6   .�5      ��  � ��$	 0.5q�60   �� 5       � ��$ 5q�6'   5      u� 5   
   $	 0.5Q�6,   $	 0.5Q�67   $	 0.5Q�6C   $	 0.5Q�6P   �� 5   
   $	 Black��6.   �� 5   
   $	 
LightGreen��65   �� 5   
   $	 Green��6;   �� 5   
   $		 Red��64   �� 5   
   $	 DarkRed��6:   5      .��5      � 
 � RowDefinitions
 5   
   �� 5       �� 5!      �� 5"      �� 5#      �� 5$      �� 5%      �� 5&      .+�5(   
   �� $��0��6   #��[  6   #��[ 6Q   
�������$��5q�6�   ��6�   Z� ._�5)      �� -   5         ��Name$ unitIdTextBlock��5)       �� TextAlignment$ Center=�6I   $��Center=�6`   ��61   �� *UnitId+6`   5*      � 5+   
   $��1��6    � ColumnDefinitions 5,      �� 5-      �� 5.      
 50      �� 51      �� 52      .+�54      �� $��0��6   $��0��6%   ._�55      �� -   5         ��Name$ currentHpTextBlock��55      ��66   �� *	CurrentHp+56      �� 57      $��0��6   $��1��6%   ._�58      �� -   5        $ currentManaTextBlock��58      ��68   �� *CurrentMana+59      �� 5:      $��1��6   $��0��6%   ._�5;      �� -   5        $ maxHpTextBlock��5;      ��62   �� *MaxHp+5<      �� 5=      $��1��6   $��1��6%   ._�5>      �� -   5        $ maxManaTextBlock��5>      ��64   �� *	MaxMana+5?      5@      �� 5A   
   $��2��6   ._�5B      �� -   5        $ armorTextBlock��5B      ��6.   �� *Armor+5C      �� 5D   
   $��3��6   ._�5E      �� -   5        $ magResistTextBlock��5E      ��62   �� *	MagResist+5F      �� 5G   
   $��4��6   ._�5H      �� -	   5         ��Name$ classComboBox��5H       �� SelectedItem 6.   �� *Class+5I      � 5J   
   $��5��6    5K      �� 5L      �� 5M      .+�5O      �� $��0��6   ._�5P      �� -
   5        $ 
xTextBlock��5P      ��6.   �� *X+5Q      �� 5R      $��1��6   ._�5S      �� -   5        $ 
yTextBlock��5S      ��6.   �� *Y+5T      5U      � 5V   
   $��6��6    5W      �� 5X      �� 5Y      .+�5[      �� -   5         ��Name$ greenButton��5[      $��Create��6*   $��0��6;   #��[ 6K   #��[ 6�   ��6�   �� *GreenButtonCommand+6�   �� 5\      -   5        $ 	redButton��5\      $��Reset��6(   $��1��68   #��[ 6H   #��[ 6   ��6�   �� *RedButtonCommand+6�   5]      5^      5_      