   M S B A M L   `   `   `  ����F  BnotionClone, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:notionClonenotionClone  5      A%clr-namespace:notionClone.UserControlnotionClone.UserControl  5      1    +notionClone.UserControl.HabitTrackerControl   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      (vmclr-namespace:notionClone     5      7local%clr-namespace:notionClone.UserControl     5      $
��Auto��5      $
��Auto��6     � 	Resources  5      1   +notionClone.UserControl.HabitValueConverter   HabitValueConverter��%   &	          5	   
   6$   5
       � DataContext 5      '   !notionClone.HabitTrackerViewModel  5   
   .��5      �� $��10q�6   
�������.+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��0,0,0,10q�6.   .+�5      �� $��От:��6   
���   �$��Center=�66   (  "System.Windows.Controls.DatePicker  5      $	��5,0q�6<      SelectedDate 6   �� *	StartDate+6<   �� 5      $��До:��6   
���   �$��Center=�66   $��10,0,0,0q�6Q     5      $	��5,0q�6:    6   �� *	EndDate+6:   5      �� 5   
   $ Vertical=�6   $��0,0,0,10q�6,   .+�5      �� $��Привычки:��6   
���   �6)   �� 5      ��6   �� *
HabitNames+��5      �� 5      .R�5      �� $ 
Horizontal=�6%   $	��0,2q�6>   .+�5       �� $	��200��6a   ��6&   �� *Name+ �� UpdateSourceTrigger$ PropertyChanged=�6a   �� 5!      $	��✕��6%   $	��5,0q�61   $��20��5$      ��5"      �� * DataContext.RemoveHabitCommand+ �� RelativeSource ��  �� AncestorType UserControl��5#      �� *.+5$      5%      5&      5(      �� 5*      $)��#+ Добавить привычку��6   $��0,5,0,0q�5,      $	��150��6&   ��5+      �� *AddHabitCommand+5,   &   5-      �� 50   
   $#��Создать таблицу��6   $��0,0,0,10q�52      $	��150��6#   ��51      �� *GenerateCommand+52   #   �� 55   
   ���#f0f0f0.��56      �� ��6   �� *	TableView+��57      �� 58      .R�59      A� $��CardGrid��6&    A� Columns 66   �� *	Columns+5:      ��5=      �� 5>      .R�5@      ��  �� CornerRadius$ 10��6!   
�������
�������$��1q�5C      	 �� Padding$	 10q�5D      $��3q�5E      $	��200��5F      ._�5G      �� .+�5H   "   �� $
��Bold"�5I   $   $��14(�5J   $   $��Center=�5K   $   $��0,0,0,10q�5L   $   ��5H   ,   �� *Date+
 �� StringFormat$
 
dd.MM.yyyy��5L   $   �� 5M   "   ��6/   �� *.+ �� 	Converter# [  ��5N   &   �� 5O   *   .R�5P   .   �� $ 
Horizontal=�69   $	��0,5q�6R   .+�5Q   2   �� $��Center=�5S   3    d� 	IsChecked 5Q   ;   �� *	IsChecked+ �� Mode$ TwoWay=���5R   3   �� *	HabitName+5S   3   5T   /   5U   +   5W   #   5X      5Y      5Z      5\      5]      5_      5`      