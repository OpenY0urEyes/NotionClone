   M S B A M L   `   `   `  ���� F  BnotionClone, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:notionClonenotionClone  4    .notionClone.UserControl.ScheduleTrackerControl   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     (vmclr-namespace:notionClone     $
��Auto��$
��Auto��  � DataContext  *   $notionClone.ScheduleTrackerViewModel  .���� $��10q����#f9f9f9.+���  �� Orientation$ 
Horizontal=�$��0,0,0,10q�.+��� $��	Дата:��$��Center=�(  "System.Windows.Controls.DatePicker  $	��5,0q�   SelectedDate �� *SelectedDate+�� $ 
Horizontal=�$��0,0,0,10q�.+��� $	��С:��$��Center=��� $��70��$	��5,0q�
���   ����� *AvailableTimes+ �� SelectedItem �� *	StartTime+���� .R��� 
���   �����  �� StringFormat$ 
{0:hh\:mm}���� $��До:��$��Center=�$��10,0,0,0q��� $��70��$	��5,0q�
���   ����� *AvailableTimes+ �� *	EndTime+���� .R��� 
���   ����� $ 
{0:hh\:mm}���� $��+ Событие��$��20,0,0,0q����� *AddItemCommand+�� ���� *Items+���� .R���  �� CornerRadius$ 8�����#CCC$��1q�
������� �� Padding$ 8q�$��0,0,0,5q�._��  � ColumnDefinitions �� $
��Auto ��� $
��Auto ��� $��* ��� $
��Auto �.+��� $��0��$
��Bold"�$��Center=�$��0,0,10,0q����� *Date+$ {0:dd.MM.yyyy}���� $��1��$ 
Horizontal=�$��Center=�$��0,0,10,0q�.+��� ���� *	StartTime+$ 
{0:hh\:mm}���� $	�� - ��$	��2,0q��� ���� *	EndTime+$ 
{0:hh\:mm}���� $��2��$��Center=����� *Description+ �� Mode$ TwoWay=�	 �� UpdateSourceTrigger$	 PropertyChanged=��� $��3��$��Center=�$��10,0,0,0q�
 d� 	IsChecked
 �� *IsDone+$ TwoWay=�