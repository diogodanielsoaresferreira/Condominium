   M S B A M L   `   `   `  ����N  JCondominium_Manager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Condominium_Manager.PagesCondominium_Manager.Pages  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5      l hSystem.Windows.Controls.DataVisualization.Toolkit, Version=4.0.0.0, Culture=neutral, PublicKeyToken=null�{clr-namespace:System.Windows.Controls.DataVisualization.Charting;assembly=System.Windows.Controls.DataVisualization.Toolkit2System.Windows.Controls.DataVisualization.Charting 5      ,    &Condominium_Manager.Pages.FinancesPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9local'clr-namespace:Condominium_Manager.Pages     5      9System&clr-namespace:System;assembly=mscorlib     5      �chartingToolkit{clr-namespace:System.Windows.Controls.DataVisualization.Charting;assembly=System.Windows.Controls.DataVisualization.Toolkit     5        � DataContext  5
      �� *CurrentPage+.��5      � $��5,5,5,5q�6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      .+�5   
   >  8System.Windows.Controls.DataVisualization.Charting.Chart  -   5        $��	lineChart��5   .   $��0��6       Title$* $Balanço Anual dos últimos 12 Meses��6?   $	��Top=�5   	      Series. 5      C  =System.Windows.Controls.DataVisualization.Charting.LineSeries  ?  9System.Windows.Controls.DataVisualization.Charting.Series   Title$ Euros (€)��6)   H  BSystem.Windows.Controls.DataVisualization.Charting.DataPointSeries   DependentValuePath$ Value��6;      IndependentValuePath$	 Key��5         IsSelectionEnabled .    ItemsSource 6"   �� 5      5      � 5   
   $��1��6   $��0,10,0,0q�6   	 � ColumnDefinitions	 5      �� 5      �� 5      �� 5      .+�5       �� $��5q�6   $��0��6$   .+�5!      �� .��6   Data Inicial6&   (  "System.Windows.Controls.DatePicker  5"      -   5        $��datePicker1��5"   8   $
��Left=�6   $	��Top=�5'      
   SelectedDate
 5#      ��  �� Path$ 	StartDate� �� Mode$ TwoWay=�
 �� Now �� TargetNullValue# Z 5'      5(      �� 5*      $��1��6   $��Center=�6$   $��
ExtraBlack"�6A   $��26(�6Y   .��6h   
Movimentos6t   �� 5+      $��5q�6   $��2��6$   .+�5,      �� $��Right=�6   .��64   
Data Final6@     5-      -   5        $��datePicker2��5-   9   $��Right=�6   $	��Top=�52      
 5.      �� $ EndDate�$ TwoWay=�# Z 52      53      55      &   System.Windows.Controls.DataGrid  57   
   $��2��6      
IsReadOnly .    AutoGenerateColumns .     CanUserAddRows .     AlternatingRowBackground
 �����   GridLinesVisibility$
 None=�6�   ��62   �� *
Transacoes+   Columns 58      0  *System.Windows.Controls.DataGridTextColumn  59      ,  &System.Windows.Controls.DataGridColumn   Width5	  /System.Windows.Controls.DataGridLengthConverter$ *	 6%      Header$
 Data��6/   1
  +System.Windows.Controls.DataGridBoundColumn 
  Binding 6=   �� *
dataString+  5:      $ *	 6%   $ Valor��6/    6>   �� *	Balanco+  5;      $ *	 6%   $ Entidade��6/    6A   �� *
Entidade+  5<      $ *	 6%   $ Descrição��6/    6B   �� *Tipo+5>      5@      5A      