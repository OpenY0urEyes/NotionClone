   M S B A M L   `   `   `  ����F  BnotionClone, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:notionClonenotionClone  5      4    .notionClone.UserControl.ScheduleTrackerControl   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      (vmclr-namespace:notionClone     5      $
��Auto��5      $
��Auto��6     � DataContext  5      *   $notionClone.ScheduleTrackerViewModel  5   
   .��5
      �� $��10q�6   ���#f9f9f9.+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��0,0,0,10q�6.   .+�5      �� $��	Дата:��6   $��Center=�6%   (  "System.Windows.Controls.DatePicker  5      $	��5,0q�6?      SelectedDate 6   �� *SelectedDate+6?   5      �� 5   
   $ 
Horizontal=�6   $��0,0,0,10q�6.   .+�5      �� $	��С:��6   $��Center=�6"   �� 5      $��70��5      $	��5,0q�6   
���   ���5      �� *AvailableTimes+ �� SelectedItem 5      �� *	StartTime+��5      �� 5      .R�5      �� 
���   ���6$   ��  �� StringFormat$ 
{0:hh\:mm}��6P   5      5       �� 5"      $��До:��6   $��Center=�6#   $��10,0,0,0q�6>   �� 5#      $��70��5%      $	��5,0q�6   
���   ���5#      �� *AvailableTimes+ 5$      �� *	EndTime+��5'      �� 5(      .R�5)      �� 
���   ���6$   �� $ 
{0:hh\:mm}��6P   5*      5,      �� 5.      $��+ Событие��6   $��20,0,0,0q�6L   ��6)   �� *AddItemCommand+6L   5/      �� 52   
   ��6   �� *Items+��53      �� 54      .R�55      ��  �� CornerRadius$ 8��6   ���#CCC$��1q�57      
������� �� Padding$ 8q�59      $��0,0,0,5q�5:      ._�5;      �  � ColumnDefinitions 5<      �� 5=   "   $
��Auto �63   �� 5>   "   $
��Auto �63   �� 5?   "   $��* �63   �� 5@   "   $
��Auto �63   .+�5D      �� $��0��6(   $
��Bold"�5F      $��Center=�5G      $��0,0,10,0q�5H      ��5E      �� *Date+$ {0:dd.MM.yyyy}��5H      �� 5K      $��1��6)   $ 
Horizontal=�69   $��Center=�6R   $��0,0,10,0q�6m   .+�5L   "   �� ��6,   �� *	StartTime+$ 
{0:hh\:mm}���� 5M   "   $	�� - ��6,   $	��2,0q�67   �� 5N   "   ��6,   �� *	EndTime+$ 
{0:hh\:mm}��5O      �� 5S      $��2��6&   $��Center=�5U      ��5T      �� *Description+ �� Mode$ TwoWay=�	 �� UpdateSourceTrigger$	 PropertyChanged=�5U      �� 5X      $��3��6'   $��Center=�5Z      $��10,0,0,0q�5[      
 d� 	IsChecked
 5Y      �� *IsDone+$ TwoWay=�5[      5\      5]      5^      5`      5b      5c      