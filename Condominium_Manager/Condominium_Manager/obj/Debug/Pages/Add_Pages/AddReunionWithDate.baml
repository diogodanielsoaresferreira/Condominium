   M S B A M L   `   `   `  ����N  JCondominium_Manager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullY1clr-namespace:Condominium_Manager.Pages.Add_Pages#Condominium_Manager.Pages.Add_Pages  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5      <    6Condominium_Manager.Pages.Add_Pages.AddReunionWithDate   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Clocal1clr-namespace:Condominium_Manager.Pages.Add_Pages     5      9System&clr-namespace:System;assembly=mscorlib     5        � DataContext  5	      �� *CurrentPage+.��5      � $��5q�6    � ColumnDefinitions 5   
   �� 5      $��4* �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��10q�6"   .+�5      �� $��20(�6   .��6"   Adicionar Reunião65   �� 5      -   5         ��Name$ ErrorBorder��5      
���  �� �� CornerRadius$ 5��6;   $	��0,5q�6L    �� Padding$ 5q�6Y   $y�	Collapsed=�6e   ._�5      �� -   5         ��Name$ 
ErrorLabel��5      
�������6A   5      �� 5      .��6   Data6   (  "System.Windows.Controls.DatePicker  5      -   5        $��
datePicker��5   4   $
��Left=�6   $	��Top=�5         SelectedDate 5      ��  �� Path$
 Date� �� Mode$ TwoWay=�
	 �� Now
 �� TargetNullValue#
 Z	 5      �� 5      .��6   Título (*)6    �� 5      -   5         ��Name$ tbTitulo��5       �� 	MaxLength$ 25��6(   69   �� 5       .��6   Descrição6   �� 5!      -   5        $ tbDesc��5!   F   $
��Auto=�6    �� TextWrapping$
 Wrap=�6V    �� AcceptsReturn . $
��50px��6   $	 100��6�   6�   �� 5"      .��6   Ata6   �� 5#      -   5        $ tbAta��5#   F   $
��Auto=�6   $
 Wrap=�6U    . $��150px��6~   $
 1000��6�   6�   �� 5$      .��6   Participantes6#   �� 5%      -   5         ��Name$ selectedCondominos��5%       �� SelectionMode$ Multiple=�6Z   $
��auto=�6s   ��62   �� $ 
Condominos���5&      �� 5'      .R�5(      �� ��6)   �� *Nome+5)      5+      � 5,       5-      �� 5.      �� 5/      .+�51      �� -   5        $��0��51      $��0,10,5,0q�6)      SidebarButton#��[  6;   $��Adicionar Reunião��6b   6�   �� 52      -	   5        $��1��52      $��5,10,0,0q�6)   #��[  6;   $��Cancelar��6b   6�   53      55      56      57      