   M S B A M L   `   `   `  ����N  JCondominium_Manager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Condominium_Manager.PagesCondominium_Manager.Pages  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5      9!clr-namespace:Condominium_ManagerCondominium_Manager  5      .    (Condominium_Manager.Pages.ManutencaoPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9local'clr-namespace:Condominium_Manager.Pages     5      9System&clr-namespace:System;assembly=mscorlib     5      8
converters!clr-namespace:Condominium_Manager     5      -   5          � DataContext  5	      �� *CurrentPage+ � 	Resources 5      1   +Condominium_Manager.DescricaoValueConverter  5   
      KeyDescricaoValueConverter  6-   .��5      � $��5q�6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      �� 5      $
��auto �6   $��100px��6*   .+�5   
   � $��0��6   $��0,5,0,0q�6    � ColumnDefinitions 5      �� 5      �� 5      �� 5      .+�5       �� $��1��6   $��Center=�6$   $��
ExtraBlack"�6A   $��26(�6Y   .��6h   Manutenções6u   � 5!      $��2��6    5"      �� 5#      �� 5$      $��180px��6'   .+�5&      �� -   5         ��Name$ 
ButtonManu��5&      $��0,0,0,5q�6-   $��1��6>     SidebarButton#��[ 6N   ��5'      � 5(      ��6   �� *ActualWidth+ �� ElementName$ 
ButtonManu�� 5)      �� 5*   "   $
��Auto �63   �� 5+   "   $��* �63   .+�5-      �� $��	0,0,4.8,0q�6$   $��0��67   $��Bottom=�6G   $��Uniform=�6b   $��Center=�6t   $��20��6�   $��20��6�   $��/Images/add.png��6�   �� 5.      $��1��6(   Adicionar Manutenção6N   5/      51      52      53      �� 56   
   -   5         ��Name$ NoManuLabel��56      $<��6Escolha uma manutenção para veres a sua informação��6%   $��Center=�6b   $��1��6   6�   �� 58   
   -   5         ��Name$ ManutencaoViewer��58      $��1��6+   $��2q�68   
���   �$y�	Collapsed=�6`   $
��Auto=�6w   ._�5:      �� .��5;      � $��5q�6    5<      �� 5=      �� 5>      �� 5?      �� 5@      �� 5A      �� 5B      �� 5C      �� 5D      �� 5E      �� 5F      �� 5G      .+�5J      �� $��0��6   $��Título��6)   $��DemiBold"�6:   $��20(�6P   $��Center=�6^   6}   �� 5K      $��1��6    $��Center=�6-   ��6J   �� *SelectedItem.titulo+$ ManutencaoGrid��6�   �� 5L      $��0,5,0,0q�6   $��2��6-   $
��Data��6:   $��DemiBold"�6I   $��20(�6_   $��Center=�6m   6�   �� 5M      $��Center=�6    $��3��6=   ��6J   �� *SelectedItem.dataString+$ ManutencaoGrid��6�   �� 5N      $��0,5,0,0q�6   $��Center=�6-   $��4��6J   $��DemiBold"�6W   $��20(�6m   $��Descrição��6{   6�   �� 5O      $��5��6    $��Center=�6-   $��5,0,0,0q�6J   $
��Wrap=�6[   ��6o   �� *SelectedItem.descricao+$ ManutencaoGrid��  DescricaoValueConverter �� 	Converter# [ 6�   �� 5P      $��0,5,0,0q�6   $��Center=�6-   $��6��6J   $��DemiBold"�6W   $��20(�6m   $
��Tipo��6{   6�   �� 5Q      $��7��6    $��Center=�6-   $��5,0,0,0q�6J   $
��Wrap=�6[   ��6o   �� *SelectedItem.tipo+$ ManutencaoGrid��6�   �� 5R      $��0,5,5,0q�6   $��	Pagamento��6-   $��8��6A   $��DemiBold"�6O   $��20(�6e   $��Center=�6s   6�   �� 5S      -   5        	 ��Name$
	 NoPa��5S       $��Center=�6.   $��9��6K   Sem pagamento associado6q   �� 5T      -   5        
 ��Name$	
 SP1��5T   !   $��9��6.   $��Center=�6;   $��5,0,0,0q�6X    �� Orientation$ 
Horizontal=�6j   .+�5U      �� 	Balanço:6.   �� 5V      $
��Wrap=�6$   ��68   �� *SelectedItem.op.Balanco+$ ManutencaoGrid��6   5W      �� 5X      -   5        $	
 SP2��5X   !   $��10��6.   $��Center=�6<   $��5,0,0,0q�6Y   $ 
Horizontal=�6k   .+�5Y      �� Nome do Sujeito Fiscal:6=   �� 5Z      $
��Wrap=�6$   ��68   �� *SelectedItem.op.sf.nome+$ ManutencaoGrid��6   5[      5]      5^      5_      � 5a   
   $��2��6    5b      �� 5c      $
��auto �6    �� 5d      $��* �6    $��100px��6+   .+�5g      � $��0��6   .+�5h      �� $��5q�6   $��0��6(   .+�5i      �� .��6   Data Inicial6*   (  "System.Windows.Controls.DatePicker  5j      -   5        $��datePicker1��5j   <   $
��Left=�6!   $	��Top=�5o         SelectedDate 5k      ��  �� Path$ 	StartDate� �� Mode$ TwoWay=�
 �� Now �� TargetNullValue# Z 5o      5p      �� 5r      $��5q�6   $��2��6(   .+�5s      �� $��Right=�6   .��68   
Data Final6D     5t      -	   5        $��datePicker2��5t   =   $��Right=�6!   $	��Top=�5y       5u      �� $ EndDate�$ TwoWay=�# Z 5y      5z      5{      &   System.Windows.Controls.DataGrid  5}      -
   5          Name$ ManutencaoGrid��5}         
IsReadOnly . $��1��6A      AutoGenerateColumns .     CanUserAddRows .     AlternatingRowBackground
 �����   GridLinesVisibility$
 None=�6�   ��6N   �� *Manutencoes+   Columns 5~      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6)      Header$
 Data��63   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6A   �� *
dataString+  5�      $ * 6)   $ Titulo��63    6C   �� *titulo+5�      5�      5�      5�      