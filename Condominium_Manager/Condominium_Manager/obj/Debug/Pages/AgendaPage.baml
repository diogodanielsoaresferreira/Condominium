   M S B A M L   `   `   `  ����N  JCondominium_Manager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Condominium_Manager.PagesCondominium_Manager.Pages  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5	      *    $Condominium_Manager.Pages.AgendaPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9local'clr-namespace:Condominium_Manager.Pages     5      6sys&clr-namespace:System;assembly=mscorlib     5	        � DataContext  5      �� *CurrentPage+.��5      � $��5q�6    � ColumnDefinitions 5   
   �� 5      �� 5       � RowDefinitions 5   
   �� 5      �� 5      .+�5   
   (� $��1��6   $��0��6"   .��5      &   System.Windows.Controls.Calendar  -   5          Name$ calendar��5   2      IsTodayHighlighted .  $��Stretch=�6y   $��Stretch=�6�      CalendarDayButtonStyle 5      �� 5       �� 
TargetType:  4System.Windows.Controls.Primitives.CalendarDayButton"  6    �� BasedOn# [B 6;   .�5      -   5        5      5      5      �� 5    
   $��0��6   $��0��6    $��5,5,5,5q�60   $��Dia Selecionado��5#      .��5$      �  5%      �� 5&      �� 5'      .+�5*      &   System.Windows.Controls.DataGrid  $��0��6      
IsReadOnly . 	   AutoGenerateColumns	 .  
   CanUserAddRows
 .     AlternatingRowBackground
 �����   GridLinesVisibility$
 None=�6�   ��6:   �� *	DayEvents+ �� Mode$ TwoWay=�   Columns 5+      0  *System.Windows.Controls.DataGridTextColumn  5,      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6-      Header$
 Data��67   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6E   �� *
dataString+  5-      $ * 6-   $ Título��67    6G   �� *titulo+5/      � 50      $��1��6    51      �� 52      �� 53       55      �� 56      �� 57      .+�5:      �� -   5         ��Name$ 
ButtonNota��5:      $��0��61   $��0��6>      SidebarButton#��[  6N   ��5;      � 5<      ��6#   �� *ActualWidth+ �� ElementName$ 
ButtonNota�� 5=   "   �� 5>   &   $
��Auto �67   �� 5?   &   $��* �67   �� 5@   &   $
��Auto �67   .+�5B   "   �� $��0,0,5,0q�6(   $��0��69   $��Center=�6I   $��Uniform=�6d   $��Center=�6v   $��20��6�   $��20��6�   $��/Images/postit.png��6�   �� 5C   "   $��1��6,   Adicionar Nota6L   5D      5F      �� 5H      -   5        $ ButtonManut��5H      $��1��62   $��1��6?   #��[  6O   ��5I      � 5J      ��6#   �� *ActualWidth+$ ButtonManut�� 5K   "   �� 5L   &   $
��Auto �67   �� 5M   &   $��* �67   �� 5N   &   $
��Auto �67   .+�5P   "   �� $��0,0,5,0q�6(   $��0��69   $��Center=�6I   $��Uniform=�6d   $��Center=�6v   $��20��6�   $��20��6�   $��/Images/settings.png��6�   �� 5Q   "   $��1��6,   Adicionar Manutenção6R   5R      5T      �� 5V      -   5        $ ButtonAviso��5V      $��0��62   $��1��6?   #��[  6O   ��5W      � 5X      ��6#   �� *ActualWidth+$ ButtonAviso�� 5Y   "   �� 5Z   &   $
��Auto �67   �� 5[   &   $��* �67   �� 5\   &   $
��Auto �67   .+�5^   "   �� $��0,0,5,0q�6(   $��0��69   $��Center=�6I   $��Uniform=�6d   $��Center=�6v   $��20��6�   $��20��6�   $��/Images/warning.png��6�   �� 5_   "   $��1��6,   Adicionar Aviso6M   5`      5b      �� 5d      -   5        $ 
ButtonReun��5d      $��1��61   $��0��6>   #��[  6N   ��5e      � 5f      ��6#   �� *ActualWidth+$ 
ButtonReun�� 5g   "   �� 5h   &   $
��Auto �67   �� 5i   &   $��* �67   �� 5j   &   $
��Auto �67   .+�5l   "   �� $��0,0,5,0q�6(   $��0��69   $��Center=�6I   $��Uniform=�6d   $��Center=�6v   $��20��6�   $��20��6�   $��/Images/people.png��6�   �� 5m   "   $��1��6,   Adicionar Reunião6O   5n      5p      5q      5s      5u      �� 5w      $��1��6   $��2��6$   $��5,5,5,5q�68   $��Próximos Eventos��5z   #   .��5{         . 	 .  
 .  
 �����$
 None=�6�   ��6   �� *	Eventos+ 5|        5}      $ * 6-   $
 Data��67    6E   �� *
dataString+  5~      $ * 6-   $ Título��67    6G   �� *titulo+5�      5�      5�      5�      