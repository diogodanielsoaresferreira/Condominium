   M S B A M L   `   `   `  ����N  JCondominium_Manager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Condominium_Manager.PagesCondominium_Manager.Pages  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5      9!clr-namespace:Condominium_ManagerCondominium_Manager  5      +    %Condominium_Manager.Pages.ReuniaoPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9local'clr-namespace:Condominium_Manager.Pages     5      9System&clr-namespace:System;assembly=mscorlib     5      8
converters!clr-namespace:Condominium_Manager     5      -   5          � DataContext  5	      �� *CurrentPage+ � 	Resources 5      1   +Condominium_Manager.DescricaoValueConverter  5   
      KeyDescricaoValueConverter  6-   &    Condominium_Manager.AtaConverter  5   
   AtaConverter  6"   .��5      � $��5q�6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      �� 5      $
��auto �6   $��100px��6*   .+�5   
   � $��0��6   $��0,5,0,0q�6    � ColumnDefinitions 5      �� 5      �� 5      �� 5      .+�5!      �� $��1��6   $��Center=�6$   $��
ExtraBlack"�6A   $��26(�6Y   .��6h   	Reuniões6r   � 5"      $��2��6    5#      �� 5$      �� 5%      $��150px��6'   .+�5'      �� -   5         ��Name$ 
ButtonReun��5'      $��0,0,0,5q�6-   $��1��6>     SidebarButton#��[ 6N   ��5(      � 5)      ��6   �� *ActualWidth+ �� ElementName$ 
ButtonReun�� 5*      �� 5+   "   $
��Auto �63   �� 5,   "   $��* �63   .+�5.      �� $��0,0,5,0q�6$   $��0��65   $��Center=�6E   $��Uniform=�6`   $��Center=�6r   $��20��6�   $��20��6�   $��/Images/add.png��6�   �� 5/      $��1��6(   Adicionar Reunião6K   50      52      53      54      �� 57   
   -   5         ��Name$ NoReunionLabel��57      $8��2Escolha uma reunião para veres a sua informação��6(   $��Center=�6b   $��1��6   6�   �� 59   
   -   5         ��Name$ ReunionViewer��59      $��1��6(   $��2q�65   
���   �$y�	Collapsed=�6]   $
��Auto=�6t   ._�5;      �� .��5<      � $��5q�6    5=      �� 5>      �� 5?      �� 5@      �� 5A      �� 5B      �� 5C      �� 5D      �� 5E      �� 5F      �� 5G      .+�5I      �� $��0��6   $��Título��6)   $��DemiBold"�6:   $��20(�6P   $��Center=�6^   6}   �� 5J      $��1��6    $��Center=�6-   ��6J   �� *SelectedItem.titulo+$ ReunionGrid��6�   �� 5K      $��0,5,0,0q�6   $��2��6-   $
��Data��6:   $��DemiBold"�6I   $��20(�6_   $��Center=�6m   6�   �� 5L      $��Center=�6    $��3��6=   ��6J   �� *SelectedItem.dataString+$ ReunionGrid��6�   �� 5M      $��0,5,0,0q�6   $��Center=�6-   $��4��6J   $��DemiBold"�6W   $��20(�6m   $��Descrição��6{   6�   �� 5O      $��5��6    $��5,0,0,0q�6-   $
��Wrap=�6>   ��6R   �� *SelectedItem.descricao+$ ReunionGrid��  DescricaoValueConverter �� 	Converter# [ 6�   �� 5P      $��0,5,0,0q�6   $��6��6-   $��Center=�6:   $��DemiBold"�6W   $��20(�6m   $	��Ata��6{   6�   �� 5Q      $��7��6    $��5,0,5,0q�6-   $
��Wrap=�6>   ��6R   �� *SelectedItem.ata+$ ReunionGrid��  AtaConverter# [ 6�   �� 5R      $��0,5,5,0q�6   $��Participantes��6-   $��8��6E   $��DemiBold"�6S   $��20(�6i   $��Center=�6w   6�   &   System.Windows.Controls.DataGrid  5S      	   
IsReadOnly	 . $��9��61   
   AutoGenerateColumns
 .     CanUserAddRows .     CanUserDeleteRows .  ��6�   �� *SelectedItem.condominos+$ ReunionGrid��   Columns 5T      0  *System.Windows.Controls.DataGridTextColumn  5U      ,  &System.Windows.Controls.DataGridColumn   Header$
 Name��61      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6?   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6I   �� *Nome+  5V      $ Email��61   $ * 6@    6J   �� *Email+5X      5Y      5Z      5[      � 5]   
   $��2��6    5^      �� 5_      $
��auto �6    �� 5`      $��* �6    $��100px��6+   .+�5c      � $��0��6   .+�5d      �� $��5q�6   $��0��6(   .+�5e      �� .��6   Data Inicial6*   (  "System.Windows.Controls.DatePicker  5f      -   5        $��datePicker1��5f   <   $
��Left=�6!   $	��Top=�5k         SelectedDate 5g      ��  �� Path$ 	StartDate� �� Mode$ TwoWay=�
 �� Now �� TargetNullValue# Z 5k      5l      �� 5n      $��5q�6   $��2��6(   .+�5o      �� $��Right=�6   .��68   
Data Final6D     5p      -   5        $��datePicker2��5p   =   $��Right=�6!   $	��Top=�5u       5q      �� $ EndDate�$ TwoWay=�# Z 5u      5v      5w        5y      -   5          Name$ ReunionGrid��5y      	 . $��1��6>   
 .   .     AlternatingRowBackground
 �����   GridLinesVisibility$
 None=�6�   ��6K   �� *
Reunioes+ 5z        5{      $ * 6)   $
 Data��63    6A   �� *
dataString+  5|      $ * 6)   $ Titulo��63    6C   �� *titulo+5~      5�      5�      5�      