   M S B A M L   `   `   `  ����N  JCondominium_Manager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullY1clr-namespace:Condominium_Manager.Pages.Add_Pages#Condominium_Manager.Pages.Add_Pages  5      9!clr-namespace:Condominium_ManagerCondominium_Manager  5      2    ,Condominium_Manager.Pages.Add_Pages.PayQuota   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Clocal1clr-namespace:Condominium_Manager.Pages.Add_Pages     5      0cm!clr-namespace:Condominium_Manager     5      6my-http://schemas.microsoft.com/wpf/2008/toolkit  5        � DataContext  5
      �� *CurrentPage+.��5      � $��5q�6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $
��50px �6   .+�5   
   �� $��20(�6   $��Center=�6   $��Pagar Quota��6;   $��0��6Q   6`   �� 5   
   $��Center=�6   $��1��60   $��Center=�6=   .+�5      �� $��16(�6   $��Condómino atual��6"   $��Center=�6<   6[   �� 5      
���   �$	��0.5q�6*    J� Opacity$	 0.5Q�6@   6P   �� 5       �� Orientation$ 
Horizontal=�6   $��Center=�62   .+�5      �� .+�5      �� $
��Nome��6   6-   �� 5       ��6   ��  �� Path$ f.CurrentCondomino.Nome�6O   5!      �� 5"      .+�5#      �� $��Email��6   6.   �� 5$      ��6   �� $ f.CurrentCondomino.Email�6P   5%      �� 5&      .+�5'      �� $	��NIF��6   6,   �� 5(      ��6   �� $ f.CurrentCondomino.NIF�6N   5)      5+      5,      �� 5.   
   $��2��6   
���   �$��1q�62   6H   �� 50   
   $��3��6   $��Center=�6"   $��Center=�6=   .+�51      �� $��16(�6   $��Fração��6"   $��Center=�63   6R   �� 52      
���   �$	��0.5q�6)   $	 0.5Q�6?   6O   �� 53      $ 
Horizontal=�6   $��Center=�62   .+�54      �� .+�55      �� $
��Piso��6   6-   �� 56      ��6   �� $ f.Piso�6>   57      �� 58      .+�59      �� $
��Zona��6   6-   �� 5:      ��6   �� $ f.Zona�6>   5;      �� 5<      .+�5=      �� $
��Tipo��6   6-   �� 5>      ��6   �� $ f.Tipo�6>   5?      �� 5@      .+�5A      �� $��Área��6   6-   �� 5B      ��6   �� $ f.Area�6>   5C      �� 5D      .+�5E      �� $��Valor da Quota��6   67   �� 5F      ��6   �� $ f.Quota�6?   5G      5I      5J      �� 5L   
   $��4��6   
���   �$��1q�62   6H   �� 5N   
   $��5��6   $��Center=�6"   .+�5O      �� $��20(�6   $
��Mês��6"   $��Center=�60   6O   �� 5Q      $ 
Horizontal=�6   .+�5R      �� $��20(�6   ��6&   �� *
Data_Pagar+6G   5T      5V      �� 5W   
   $ 
Horizontal=�6   $��6��6.   $��Center=�6;   .+�5X      �� -   5        $��0,10,5,0q�5X         SidebarButton#��[  6'   $��Pagar Quota��6N   6}   �� 5Y      -   5        $��5,10,0,0q�5Y      #��[  6'   $��Cancelar��6N   6{   5Z      5[      5\      