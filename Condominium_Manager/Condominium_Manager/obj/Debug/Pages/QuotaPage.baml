   M S B A M L   `   `   `  ����N  JCondominium_Manager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Condominium_Manager.PagesCondominium_Manager.Pages  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5      9!clr-namespace:Condominium_ManagerCondominium_Manager  5	      )    #Condominium_Manager.Pages.QuotaPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9local'clr-namespace:Condominium_Manager.Pages     5      6sys&clr-namespace:System;assembly=mscorlib     5      8
converters!clr-namespace:Condominium_Manager     5	        � DataContext  5
      �� *CurrentPage+ � 	Resources 5      -   'Condominium_Manager.MonthQuotaConverter  5   
      KeyMonthQuotaConverter  6)   0   *Condominium_Manager.EnabledButtonConverter  5   
   EnabledButtonConverter  6,   0   *Condominium_Manager.MultiBindingMonthQuota  5   
   MultiBindingMonthQuota  6,   ��5   
   Janeiro  1��6'   ��5   
   	Fevereiro  2��6)   ��5   
   	Marco  3��6%   ��5   
   	Abril  4��6%   ��5   
   Maio  5��6$   ��5   
   	Junho  6��6%   ��5   
   	Julho  7��6%   ��5   
   
Agosto  8��6&   ��5   
   Setembro  9��6(   ��5   
   Outubro  10��6(   ��5   
   Novembro  11��6)   ��5   
   Dezembro  12��6)   .��5      � $��5q�6    � RowDefinitions 5    
   �� 5!      $
��auto �6   �� 5"      $��* �6   .+�5$   
   �� -   5         ��Name$ CB��5$       �� SelectedIndex$ 5��6    �� 
IsReadOnly .   ComboBoxMenu#��[ 6C   ��6j   ��  �� Path$ Years� �� Mode$ TwoWay=�5%      �� 5&   
   $��1��6   $
��Auto=�6$   .��5'      &   System.Windows.Controls.DataGrid  -   5          Name$ 	QuotaGrid��5'   )   	   
IsReadOnly	 . 
   AutoGenerateColumns
 .     CanUserAddRows .     CanUserDeleteRows .     CanUserResizeRows .     AlternatingRowBackground
 �����   GridLinesVisibility$
 None=�6�   ��6�   �� $ Quotas�   Columns 5(      0  *System.Windows.Controls.DataGridTextColumn  5)      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6)      Header$ 
Condómino��63   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6F   �� *Nome+  5*      $ * 6)   $
 Piso��63    6A   �� *Piso+  5+      $ * 6)   $
 Zona��63    6A   �� *Zona+  5,      $ * 6)   $
 Tipo��63    6A   �� *Tipo+  5-      $ * 6)   $ Quota��63    6B   �� *Quota+4	  .System.Windows.Controls.DataGridTemplateColumn	  5.      $ 1��6-   $ SizeToHeader 68      
IsReadOnly .  	  CellTemplate 5/      �� 50      .R�51   "   �� ��52   &   `� 53   *     MultiBindingMonthQuota `� 	Converter# [ 67   .1�54   .   �� $ Janeiro�66   �� 55   .   $ 
DateCompra�66   �� 56   .   $ 	DateVenda�66   �� 57   .   $
 Text�66    �� ElementName$ CB��6B   �� 58   .     Janeiro �� Source# [ 66   59   +   5;   #   5<      5>      	  5@      $ 2��6-   $ SizeToHeader 68    .  5A      �� 5B      .R�5C   "   �� ��5D   &   `� 5E   *   # [ 67   .1�5F   .   �� $ 	Fevereiro�66   �� 5G   .   $ 
DateCompra�66   �� 5H   .   $ 	DateVenda�66   �� 5I   .   $
 Text�66   $ CB��6B   6U   �� 5J   .     	Fevereiro# [ 66   5K   +   5M   #   5N      5P      	  5R      $ 3��6-   $ SizeToHeader 68    .  5S      �� 5T      .R�5U   "   �� ��5V   &   `� 5W   *   # [ 67   .1�5X   .   �� $ Marco�66   �� 5Y   .   $ 
DateCompra�66   �� 5Z   .   $ 	DateVenda�66   �� 5[   .   $
 Text�66   $ CB��6B   6U   �� 5\   .    	 Marco# [ 66   5]   +   5_   #   5`      5b      	  5d      $ 4��6-   $ SizeToHeader 68    .  5e      �� 5f      .R�5g   "   �� ��5h   &   `� 5i   *   # [ 67   .1�5j   .   �� $ Abril�66   �� 5k   .   $ 
DateCompra�66   �� 5l   .   $ 	DateVenda�66   �� 5m   .   $
 Text�66   $ CB��6B   6U   �� 5n   .    	 Abril# [ 66   5o   +   5q   #   5r      5t      	  5v      $ 5��6-   $ SizeToHeader 68    .  5w      �� 5x      .R�5y   "   �� ��5z   &   `� 5{   *   # [ 67   .1�5|   .   �� $
 Maio�66   �� 5}   .   $ 
DateCompra�66   �� 5~   .   $ 	DateVenda�66   �� 5   .   $
 Text�66   $ CB��6B   6U   �� 5�   .     Maio# [ 66   5�   +   5�   #   5�      5�      	  5�      $ 6��6-   $ SizeToHeader 68    .  5�      �� 5�      .R�5�   "   �� ��5�   &   `� 5�   *   # [ 67   .1�5�   .   �� $ Junho�66   �� 5�   .   $ 
DateCompra�66   �� 5�   .   $ 	DateVenda�66   �� 5�   .   $
 Text�66   $ CB��6B   6U   �� 5�   .    	 Junho# [ 66   5�   +   5�   #   5�      5�      	  5�      $ 7��6-   $ SizeToHeader 68    .  5�      �� 5�      .R�5�   "   �� ��5�   &   `� 5�   *   # [ 67   .1�5�   .   �� $ Julho�66   �� 5�   .   $ 
DateCompra�66   �� 5�   .   $ 	DateVenda�66   �� 5�   .   $
 Text�66   $ CB��6B   6U   �� 5�   .    		 Julho# [	 66   5�   +   5�   #   5�      5�      	  5�      $ 8��6-   $ SizeToHeader 68    .  5�      �� 5�      .R�5�   "   �� ��5�   &   `� 5�   *   # [ 67   .1�5�   .   �� $ Agosto�66   �� 5�   .   $ 
DateCompra�66   �� 5�   .   $ 	DateVenda�66   �� 5�   .   $
 Text�66   $ CB��6B   6U   �� 5�   .    

 Agosto# [
 66   5�   +   5�   #   5�      5�      	  5�      $ 9��6-   $ SizeToHeader 68    .  5�      �� 5�      .R�5�   "   �� ��5�   &   `� 5�   *   # [ 67   .1�5�   .   �� $ Setembro�66   �� 5�   .   $ 
DateCompra�66   �� 5�   .   $ 	DateVenda�66   �� 5�   .   $
 Text�66   $ CB��6B   6U   �� 5�   .     Setembro# [ 66   5�   +   5�   #   5�      5�      	  5�      $ 10��6-   $ SizeToHeader 69    .  5�      �� 5�      .R�5�   "   �� ��5�   &   `� 5�   *   # [ 67   .1�5�   .   �� $ Outubro�66   �� 5�   .   $ 
DateCompra�66   �� 5�   .   $ 	DateVenda�66   �� 5�   .   $
 Text�66   $ CB��6B   6U   �� 5�   .     Outubro# [ 66   5�   +   5�   #   5�      5�      	  5�      $ 11��6-   $ SizeToHeader 69    .  5�      �� 5�      .R�5�   "   �� ��5�   &   `� 5�   *   # [ 67   .1�5�   .   �� $ Novembro�66   �� 5�   .   $ 
DateCompra�66   �� 5�   .   $ 	DateVenda�66   �� 5�   .   $
 Text�66   $ CB��6B   6U   �� 5�   .     Novembro# [ 66   5�   +   5�   #   5�      5�      	  5�      $ 12��6-   $ SizeToHeader 69    .  5�      �� 5�      .R�5�   "   �� ��5�   &   `� 5�   *   # [ 67   .1�5�   .   �� $ Dezembro�66   �� 5�   .   $ 
DateCompra�66   �� 5�   .   $ 	DateVenda�66   �� 5�   .   $
 Text�66   $ CB��6B   6U   �� 5�   .     Dezembro# [ 66   5�   +   5  #   5     5     	  5     $ Pagar Quota��6-   $ SizeToHeader 6B    .  5     �� 5     .R�5	  "   �� -   5          SidebarButton#��[ 5	  :   $��0,0,0,0q�6a   {�5
  &   `� 5  *     EnabledButtonConverter# [ 67   .1�5  .   �� $ .�66   �� 5  .   $
 Text�66   $ CB��6B   6U   5  +   ��5  &   �� 5  *   $��0,0,5,0q�60   $��0��6A   $��Center=�6Q   $��Uniform=�6l   $��Center=�6~   $��20��6�   $��15��6�   $��/Images/pay.png��6�   5  #   5     5     5     5     5     5     