   M S B A M L   `   `   `  ����d  `Microsoft.Maps.MapControl.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35tRclr-namespace:Microsoft.Maps.MapControl.WPF;assembly=Microsoft.Maps.MapControl.WPFMicrosoft.Maps.MapControl.WPF  5      N JCondominium_Manager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Condominium_ManagerCondominium_Manager 5      E'clr-namespace:Condominium_Manager.PagesCondominium_Manager.Pages 5      -   'Condominium_Manager.Pages.FractionsPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      `mRclr-namespace:Microsoft.Maps.MapControl.WPF;assembly=Microsoft.Maps.MapControl.WPF     5      8
converters!clr-namespace:Condominium_Manager     5      9local'clr-namespace:Condominium_Manager.Pages     5        � DataContext  5
      �� *CurrentPage+ � 	Resources 5      -  'Condominium_Manager.QuotaValueConverter  5   
      KeyQuotaValueConverter  6)   ,  &Condominium_Manager.ZonaValueConverter  5   
   ZonaValueConverter  6(   1 +Condominium_Manager.CondominoValueConverter  5   
   CondominoValueConverter  6-   .��5      � $��5q�6    � ColumnDefinitions 5   
   �� 5      .+�5   
   � $��0��6    � RowDefinitions 5      �� 5      $��50 �6    �� 5      $��5* �6    .+�5      �  5      �� 5       $��* �6'   �� 5!      �� 5"      $
��auto �6'   �� 5#      $
��auto �6'   .+�5&      �� $��5,5,5,0q�6     DominiumMainColor#��[ 6*   $��2q�6[   ._�5'      �  5(      �� 5)      �� 5*      $
��auto �6/   �� 5+       5-      �� 5.      �� 5/      $
��auto �6,   �� 50      .+�53      �� #��[ 6!   $��1��6R   $��3��6_   $��1q�6s   �� 54      #��[ 6!   $��1��6R   $��3��6b   $��1q�6s   �� 55      $��0��6$   $��0��64   $��Center=�6A   $��Center=�6^   $��	Frações��6y   �� 56      $��2��6$   $��0��64   $��Center=�6A   $��Center=�6^   ��6y   ��  �� Path$ Items.Count��� 57      $��0��6$   $��2��64   $��Center=�6A   $��Center=�6^   $��
Ocupação��6y   �� 58      $��2��6$   $��2��64   $��Center=�6A   $��Center=�6^   ��6y   �� *
Ocupacao+5:      5;      �� 5<      -   5         ��Name$ 	AddFracao��5<      $��2��6,   $��0,5,5,0q�6<     SidebarButton#��[ 6M   $��50��6t   $��Bottom=�6�   ��5=      � 5>      ��6   �� *ActualWidth+ �� ElementName$ APButton�� 5?      �� 5@   "   $
��Auto �63   �� 5A   "   $��* �63   .+�5C      �� $��0,0,5,0q�6$   $��0��65   $��Center=�6E   $��Uniform=�6`   $��Center=�6r   $��20��6�   $��15��6�   $��/Images/add.png��6�   �� 5D      $��1��6(   $��Center=�68   Adicionar Fração6e   5E      5G      �� 5I      -   5        $ 
HelpButton��5I      $��3��6-   $��0,5,5,0q�6=   #��[ 6N   $��50��6u   $��Bottom=�6�   ��5J      �� 5K      $��0,0,0,0q�6    $��0��61   $��Center=�6A   $��Uniform=�6\   $��Center=�6n   $��20��6�   $��15��6�   $��/Images/help.png��6�    � ToolTip 5M      _� 5N      #��[ 6"   $	��200��6R   .��5O      �� $��5q�6)   .+�5P   "   �� $
��Bold"�6,   
�������Ajuda6X   �� 5Q   "   
�������$
��Wrap=�6@   �� 6U   ��Aqui pode adicionar novas frações ao seu prédio, sejam elas habitações, zonas comerciais ou estacionamentos. Pode ainda aceder a frações existentes e gira-las, como por exemplo adicionar e remover proprietários.66  5R      5S      5U      5W      �� 5Y      $��1��6   $��5,5,5,5q�6$   $��	Frações��5\   #   .��5]      &   System.Windows.Controls.DataGrid  -   5          Name$ FractionGrid��5]   L   	   
IsReadOnly	 . 
   AutoGenerateColumns
 .     CanUserAddRows .     AlternatingRowBackground
 �����   GridLinesVisibility$
 None=�6�   ��6t   �� *Items+   Columns 5^      0  *System.Windows.Controls.DataGridTextColumn  5_      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6-      Header$
 Piso��67   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6E   �� $
 Piso�  5`      $ * 6-   $
 Zona��67    6E   �� $
 Zona�  ZonaValueConverter �� 	Converter# [   5a      $ * 6-   $
 Tipo��67    6E   �� $
 Tipo�  5b      $ * 6-   $ Área��67    6E   �� $
 Area�  5c      $ * 6-   $ Quota��67    6F   �� $ Quota�  QuotaValueConverter# [   5d      $ * 6-   $ 
Condómino��67    6J   �� $ CurrentCondomino�  CondominoValueConverter# [ 4	  .System.Windows.Controls.DataGridTemplateColumn	  5e      $ Entrar��61   $ SizeToHeader 6A      
IsReadOnly .  	  CellTemplate 5f      �� 5g   "   .R�5h   &   �� -   5        $��40��5h   ;   #��[ 6F   $��0,0,0,0q�6m   ��5i   *   �� 5j   .   $��5,2,5,2q�64   $��0��6E   $��Center=�6U   $��Uniform=�6p   $��Center=�6�   $��16��6�   $��12��6�   $��/Images/enter.png��6�   5l   '   5m   #   5o      	  5p      $ Apagar��61   $ SizeToHeader 6A    .  5q      �� 5r   "   .R�5s   &   �� -   5        $��40��5s   @   #��[ 6K   $��0,0,0,0q�6r   ��5t   *   �� 5u   .   $��5,2,5,2q�64   $��0��6E   $��Center=�6U   $��Uniform=�6p   $��Center=�6�   $��20��6�   $��12��6�   $��/Images/remove.png��6�   5w   '   5x   #   5z      5|      5}      5~      5      5�      