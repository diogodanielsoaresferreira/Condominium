   M S B A M L   `   `   `  ����N  JCondominium_Manager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Condominium_Manager.PagesCondominium_Manager.Pages  5      9!clr-namespace:Condominium_ManagerCondominium_Manager  5      ,    &Condominium_Manager.Pages.FractionPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9local'clr-namespace:Condominium_Manager.Pages     5      8
converters!clr-namespace:Condominium_Manager     5      -   5          � DataContext  5	      �� *CurrentPage+ � 	Resources 5      ,   &Condominium_Manager.DateValueConverter  5   
      KeyDateValueConverter  6(   )   #Condominium_Manager.CompraConverter  5   
   CompraConverter  6%   �� 5   
   
FadeIn  .��5      W�  g� Duration$ 0:0:.25D�6    �� TargetProperty$ Opacity�61    W� From$ 0X�6U   	 W� To$ 1X�6^   5      �� 5   
   FadeOut  .��5      W� $ 0:0:.5D�6   $ Opacity�60   $ 0X�6T   5      .��5      � $��5q�6    � ColumnDefinitions 5   
   �� 5      �� 5      .+�5!   
   � $��0��6    � RowDefinitions 5"      �� 5#      �� 5$      $
��auto �6    .+�5'      �� $��0��6   $��5,5,5,5q�6$   $
��Bold"�65   $��Histórico de Condóminos��5*   #   .��5+      �  5,      �� 5-      �� 5.      $
��auto �6(   .+�50      &   System.Windows.Controls.DataGrid  -   5          Name$ 
CompraGrid��50      $��0��63   	   
IsReadOnly	 . 
   AutoGenerateColumns
 .     CanUserAddRows .     AlternatingRowBackground
 �����   GridLinesVisibility$
 None=�6�   ��6@   �� *	Compras+   Columns 51      0  *System.Windows.Controls.DataGridTextColumn  52      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 61      Header$
 Nome��6;   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6I   ��  �� Path$ c.Nome�  53      $ * 61   $ Email��6;    6J   �� $ c.Email�  54      $ * 61   $ Data de Compra��6;    6S   �� $ Data_Compra�  55      $ * 61   $ Data de Venda��6;    6R   �� $ 
Data_Venda�  DateValueConverter �� 	Converter# [ 57      � 58      $��1��6    59      �� 5:      �� 5;      .+�5=      �� -   5        $��5,10,5,5q�5=   !   $��0��6{     SidebarButton#��[ 6�   $��Atribuir Condómino��6�   {�63   �� *Venda+  CompraConverter# [ 6�   �� 5>      -   5        $��5,10,5,5q�5>   !   $��1��6|   #��[ 6�   $��Remover Condómino��6�   {�63   �� *Compra+# [ 6�   5?      5@      5B      �� 5C      -   5        $��10q�5C      $��1��6!   $��Stretch=�6.   $��10q�6L   #��[ 6Y   .��6�   
Retroceder6�   5E      � 5G   
   $��1��6    5H      �� 5I      �� 5J      .+�5N      �� $��0��6   $��5,5,5,5q�6$   $
��Bold"�65   $��Informação��5Q   #   .��5S      � .+�5T      �  5U      �� 5V   "   �� 5W   "    5Y      �� 5Z   "   $��* �60   �� 5[   "   $
��auto �60   .+�5]      �� $��0��6)   .+�5^   "   �� $��Piso:��6(   6;   �� 5_   "   $��Zona: ��6(   6<   �� 5`   "   $��Quota: ��6(   6=   �� 5a   "   $��Área: ��6(   6;   �� 5b   "   $��Tipo: ��6(   6;   �� 5c   "   $
��Bold"�6(   $��Condómino: ��6:   6R   5d      �� 5f      $��1��6)   .+�5g   "   �� ��6(   �� $ f.Piso�6J   �� 5h   "   ��6(   �� $ f.Zona�6J   �� 5i   "   ��6(   �� $ f.Quota�6K   �� 5j   "   ��6(   �� $ f.Area�6J   �� 5k   "   ��6(   �� $ f.Tipo�6J   �� 5l   "   ��6(   �� $ f.CurrentCondomino.Nome�6[   5m      �� 5p      -   5        $��1��5p   %   $��0��62   $��2��6B   #��[ 6V   .��6�   Editar6�   5r      5t      5u      �� 5w      $��1��6   $��5,5,5,5q�6$   $
��Bold"�65   }�. $��Fotos da Fração��5z   #   .��5{      � -   5         �Name$ ImageCanvas��5{      $
��auto��6,   $
��auto��69   .+�5|      �� -   5         ��Name$ myImage��5|      $��UniformToFill=�6-    J� RenderTransformOrigin$ 0.5,0.5&�6E   z�5}      V� 5~      .~�5   "   T�  T� X$ 0Q�65    T� Y$ 0Q�6;   5�      5�      �� 5�      -	   5        $ myImage2��5�      $��UniformToFill=�6.   $ 0.5,0.5&�6F   z�5�      V� 5�      .~�5�   "   T� $ 0Q�65   $ 0Q�6;   5�      5�      �� 5�      -
   5         ��Name$ 	ErrorText��5�   4   $
��Wrap=�6    $��Stretch=�6G   $��Center=�6e    �� TextAlignment$ Center=�6�   $y�	Collapsed=�6�   $)��#The specified folder does not exist��6�   5�      5�      5�      5�      5�      