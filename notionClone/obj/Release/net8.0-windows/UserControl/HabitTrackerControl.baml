   M S B A M L   `   `   `  ���� F  BnotionClone, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:notionClonenotionClone  A%clr-namespace:notionClone.UserControlnotionClone.UserControl  1    +notionClone.UserControl.HabitTrackerControl   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     (vmclr-namespace:notionClone     7local%clr-namespace:notionClone.UserControl     $
��Auto��$
��Auto��  � 	Resources  1   +notionClone.UserControl.HabitValueConverter   HabitValueConverter��%   &	           � DataContext '   !notionClone.HabitTrackerViewModel  .���� $��10q�
�������.+���  �� Orientation$ 
Horizontal=�$��0,0,0,10q�.+��� $��От:��
���   �$��Center=�(  "System.Windows.Controls.DatePicker  $	��5,0q�   SelectedDate �� *	StartDate+�� $��До:��
���   �$��Center=�$��10,0,0,0q�  $	��5,0q� �� *	EndDate+�� $ Vertical=�$��0,0,0,10q�.+��� $��Привычки:��
���   ��� ���� *
HabitNames+���� .R��� $ 
Horizontal=�$	��0,2q�.+��� $	��200������ *Name+ �� UpdateSourceTrigger$ PropertyChanged=��� $	��✕��$	��5,0q�$��20������ * DataContext.RemoveHabitCommand+ �� RelativeSource ��  �� AncestorType UserControl���� *.+�� $)��#+ Добавить привычку��$��0,5,0,0q�$	��150������ *AddHabitCommand+�� $#��Создать таблицу��$��0,0,0,10q�$	��150������ *GenerateCommand+�� ���#f0f0f0.���� ���� *	TableView+���� .R�A� $��CardGrid�� A� Columns �� *	Columns+���� .R���  �� CornerRadius$ 10��
�������
�������$��1q�	 �� Padding$	 10q�$��3q�$	��200��._��� .+��� $
��Bold"�$��14(�$��Center=�$��0,0,0,10q����� *Date+
 �� StringFormat$
 
dd.MM.yyyy���� ���� *.+ �� 	Converter# [  ���� .R��� $ 
Horizontal=�$	��0,5q�.+��� $��Center=� d� 	IsChecked �� *	IsChecked+ �� Mode$ TwoWay=����� *	HabitName+