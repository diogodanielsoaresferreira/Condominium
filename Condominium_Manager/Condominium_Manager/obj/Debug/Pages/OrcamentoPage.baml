   M S B A M L   `   `   `  ����N  JCondominium_Manager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Condominium_Manager.PagesCondominium_Manager.Pages  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5      9!clr-namespace:Condominium_ManagerCondominium_Manager  5      -    'Condominium_Manager.Pages.OrcamentoPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9local'clr-namespace:Condominium_Manager.Pages     5      9System&clr-namespace:System;assembly=mscorlib     5      8
converters!clr-namespace:Condominium_Manager     5      -   5          � DataContext  5	      �� *CurrentPage+ � 	Resources 5      1   +Condominium_Manager.DescricaoValueConverter  5   
      KeyDescricaoValueConverter  6-   &    Condominium_Manager.AtaConverter  5   
   AtaConverter  6"   .��5      � $��5q�6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      �� 5      $
��auto �6   $��100px��6*   .+�5   
   � $��0��6   $��0,5,0,0q�6    � ColumnDefinitions 5      �� 5      �� 5      �� 5      .+�5"      �� $��1��6   $��Center=�6$   $��
ExtraBlack"�6A   $��26(�6Y   .��6h   Orçamentos6t   � 5#      $��2��6    5$      �� 5%      �� 5&      $��175px��6'   .+�5(      �� -   5         ��Name$ 
ButtonReun��5(      $��0,0,0,5q�6-   $��1��6>     SidebarButton#��[ 6N   ��5)      � 5*      ��6   �� *ActualWidth+ �� ElementName$ 
ButtonReun�� 5+      �� 5,   "   $
��Auto �63   �� 5-   "   $��* �63   .+�5/      �� $��0,0,5,0q�6$   $��0��65   $��Center=�6E   $��Uniform=�6`   $��Center=�6r   $��20��6�   $��20��6�   $��/Images/add.png��6�   �� 50      $��1��6(   Adicionar Orçamento6M   51      53      54      55      �� 57   
   -   5         ��Name$ ErrorBorder��57      
���  �� �� CornerRadius$ 5��67   $	��0,5q�6H    �� Padding$ 5q�6U   $y�	Collapsed=�6a   ._�58      �� -   5        	 ��Name$	 
ErrorLabel��58      
�������6=   59      �� 5;   
   -   5        $	 NoOrcamentoLabel��5;      $7��1Escolha um orçamento para ver a sua informação��6*   $��Center=�6c   $��1��6�   6�   �� 5=   
   -   5        $ OrcamentoViewer��5=      $��1��6*   $��2q�67   
���   �$y�	Collapsed=�6_   $
��Auto=�6v   ._�5?      �� .��5@      � $��5q�6    5A      �� 5B      �� 5C      �� 5D      �� 5E      �� 5F      �� 5G      �� 5H      �� 5I      �� 5J      .+�5L      �� $��0��6   $��Título��6)   $��DemiBold"�6:   $��20(�6P   $��Center=�6^   6}   �� 5M      $��1��6    $��Center=�6-   ��6J   �� *SelectedItem.Titulo+$ OrcamentoGrid��6�   � 5O      $��2��6    5P      �� 5Q      �� 5R      .+�5U      �� $��0,5,0,0q�6    $��0��61   $��Início��6A   $��DemiBold"�6R   $��20(�6h   $��Center=�6v   6�   �� 5V      $��0,5,0,0q�6    $��1��61   $	��Fim��6A   $��DemiBold"�6O   $��20(�6e   $��Center=�6s   6�   5W      � 5Y      $��3��6    5Z      �� 5[      �� 5\      .+�5_      �� $��Center=�6$   $��0��6A   ��6Q   �� *SelectedItem.Initial_Date+$ OrcamentoGrid��6�   �� 5`      $��Center=�6$   $��1��6A   ��6Q   �� *SelectedItem.Final_Date+$ OrcamentoGrid��6�   5a      �� 5d      $��0,5,0,0q�6   $��Center=�6-   $��4��6J   $��DemiBold"�6W   $��20(�6m   $��Descrição��6{   6�   �� 5e      $��5��6    $��5,0,0,0q�6-   $
��Wrap=�6>   ��6R   �� *SelectedItem.Descricao+$ OrcamentoGrid��  DescricaoValueConverter
 �� 	Converter#
 [ 6�   �� 5g      $��0,20,5,0q�6   $��Items��6.   $��5��6>   $��DemiBold"�6L   $��20(�6b   $��Center=�6p   6�   &   System.Windows.Controls.DataGrid  5i      $��6��6      AutoGenerateColumns .     
IsReadOnly .    CanUserAddRows .     CanUserDeleteRows .  ��6�   �� *SelectedItem.items+$ OrcamentoGrid��   Columns 5j      0  *System.Windows.Controls.DataGridTextColumn  5k      ,  &System.Windows.Controls.DataGridColumn   Header$ Descrição��61      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6D   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6N   �� *Nome+  5l      $ Balanço (€)��61   $ * 6F    6P   �� *	Balanco+5n      � 5p      $��7��6    5q      �� 5r      $��* �6/   �� 5s      $��* �6/   .+�5u      �� $��5,0,0,0q�6$   $��0��65   $��16(�6E   $
��Bold"�6S   Total6m   �� 5v      $��5,0,0,0q�6$   $��1��65   $��16(�6E   $
��Bold"�6S   ��6e   �� *Value+6~   5w      � 5y      $��8��6    5z      �� 5{      $��* �6/   �� 5|      $��* �6/   .+�5      � $��0��6    5�      �� 5�   "   $
��auto �63   �� 5�   "   $��* �63   .+�5�      �� $��Center=�6$   $��Descrição: ��6?   $��0��6U   �� 5�      -   5         ��Name$ tbTitulo��5�   1   $��5q�6&   $
��20px��6C   $��1��6Q    �� 	MaxLength$ 25��6a   6r   5�      � 5�      $��1��6    5�      �� 5�   "   $
��auto �63   �� 5�   "   $��* �63   �� 5�   "   $
��auto �63   .+�5�      �� $��
Balanço: ��6$   $��0��68   $��Center=�6H   �� 5�      -   5        $ 	tbBalanco��5�   O   $��5q�6&   $��1��61   $
��20px��6A   6d   �� 5�      -	   5        $��5q�5�   %   $��2��60   #��[ 6@   $��Adicionar Item��6g   6�   5�      5�      5�      5�      5�      � 5�   
   $��2��6    5�      �� 5�      $
��auto �6    �� 5�      $��* �6    $��100px��6+   .+�5�      � $��0��6   .+�5�      �� $��5q�6   $��0��6(   .+�5�      �� .��6   Data Inicial6*   (  "System.Windows.Controls.DatePicker  5�      -
   5        $��datePicker1��5�   <   $
��Left=�6!   $	��Top=�5�         SelectedDate 5�      ��  �� Path$ 	StartDate� �� Mode$ TwoWay=�
 �� Now �� TargetNullValue# Z 5�      5�      �� 5�      $��5q�6   $��2��6(   .+�5�      �� $��Right=�6   .��68   
Data Final6D     5�      -   5        $��datePicker2��5�   =   $��Right=�6!   $	��Top=�5�       5�      �� $ EndDate�$ TwoWay=�# Z 5�      5�      5�        5�      -   5          Name$ OrcamentoGrid��5�      $��1��6.    .  .   .     AlternatingRowBackground
 �����   GridLinesVisibility$
 None=�6�   ��6M   �� *
Orcamentos+ 5�        5�      $ * 6)   $ Data Inicial��63    6I   �� *Initial_Date+  5�      $ * 6)   $ 
Data Final��63    6G   �� *
Final_Date+  5�      $ * 6)   $ Titulo��63    6C   �� *Titulo+5�      5�      5�      5�      