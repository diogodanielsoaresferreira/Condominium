   M S B A M L   `   `   `  ����N  JCondominium_Manager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Condominium_ManagerCondominium_Manager  5   	   $    Condominium_Manager.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:Condominium_Manager     5   	   -   5          �Name$  MainApp��5   	    � WindowStyle$
 None=�5	   	    � AllowsTransparency .  � WindowStartupLocation$ CenterScreen=�5   	    � Title$ Condominium Manager��5   	   $	��650��5   	   $	��850��6   ��5   	   �� *WindowMinimumWidth+��5   	   �� *WindowMinimumHeight+ J� InputBindings 5      �� 5   
   
 �� Key$ V��6    �� 	Modifiers$
 Ctrlf�6    �� Command 6.   �� *V+�� 5   
   $ F��6   $
 Ctrlf�6    6.   �� *F+�� 5   
   $ B��6   $
 Ctrlf�6    6.   �� *B+�� 5   
   $ C��6   $
 Ctrlf�6    6.   �� *C+�� 5   
   $ Q��6   $
 Ctrlf�6    6.   �� *Q+�� 5   
   $ A��6   $
 Ctrlf�6    6.   �� *A+�� 5   
   $ R��6   $
 Ctrlf�6    6.   �� *R+�� 5   
   $ O��6   $
 Ctrlf�6    6.   �� *O+�� 5   
   $ M��6   $
 Ctrlf�6    6.   �� *M+	 � 	Resources	 5      $   Condominium_Manager.MainWindow
 �� 
TargetType �� Property �� Value �� 
TargetType �� Padding �� FallbackValue ��Name �� CornerRadius   DominiumMainColor J� Effect3  -System.Windows.Media.Effects.DropShadowEffect   ShadowDepth   Opacity J� OpacityMask !� Visual �� ElementName � RowDefinitions � ColumnDefinitions'  !System.Windows.Shell.WindowChrome   IsHitTestVisibleInChrome � Cursor K� ZIndex ��Name �� 
IsEditable �� 
IsReadOnly  �� Text  ComboBoxMenu! �� SelectedIndex" �� Mode# �� Orientation  WindowControlButton  WindowCloseButton$ >�Name��%<	  '        7   7   7  7  7  7  �� 5   
   "
  6   .�5       ��  � �� 5"      �� 5#      " �6&   .R�5$      ��  6!   �� *OuterMarginSizeThickness+$ 10��._�5&      � .+�5)   "   �� $ 	Container��6)   
���   � 5+   )   �� *WindowCornerRadius+$ 10���� 5.   "   8��   6)   �� *WindowCornerRadius+$ 10�� 50   &     51   *   $ 0Q�6;   $	 0.2Q�6K   53   #   � 56   "    59   &   !� 5:   *    66   �� $ 	Container�� 5=   &   �� 5?   *   ��68   �� *TitleHeightGridLength+$ 42���� 5A   *   $��5* �68   .+�5D   &   � $��0��6+    5E   *   �� 5F   .   $��* �6?   �� 5G   .   $��5* �6?   .+�5I   *   �� -   5         . $��0��5I   |   8�� $
��Auto��6�   $��	0,0,0,-12q�6  ��6�   �� *TitleHeightGridLength+$ 42����5J   .   �� 5K   2   " ��6C   .R�5L   6   �� $
��Auto��6<   $
��Auto��6I   $
 Hand��6W   $7��1pack://application:,,,/Images/dominium_symbol.png��6e   5M   3   5O   +   � 5Q   *   $��1��6/   $ 1��6?    5R   .   �� 5S   2   $
��auto �6C   �� 5U   2   $��* �6C   �� 5V   2   $
��auto �6C   �� 5X   2   $
��Auto �6C   .+�5Z   .   �� $��0��65   $��1q�6E   
�������6Y   �� 5[   .   $ Choose_Building��67   -   5         .  . $  Escolher um prédio��5[   �    . 8�� {�. $��1��6E  ! 6P   �� *
_cbIndex+$" TwoWay=���6  �� *
_Buildings+6�  �� 5\   .   $��2��65   $��1q�6E   
�������$��	10,0,10,0q�6m   �� 5]   .   $��3��69   $# 
Horizontal=�6I   .+�5^   2   �� 8�� $��_��6�   ��69   �� *MinimizeCommand+6�   �� 5_   2   8�� $	��[ ]��6�   ��69   �� *MaximizeCommand+6�   �� 5`   2   8�� $��X��6�   ��69   �� *CloseCommand+6�   5a   /   5b   +   5c   '   � 5f   &   $��1��6+    5h   *   �� 5j   .   ��6?   �� *Column1Width+$ *���� 5l   .   ��6?   �� *Column2Width+$ 5*��.+�5o   *   �� $��0��61   $��0,0,0,0q�6A   $ 10,10,10,10��6R   }�. ._�5p   .   >� $$ SidebarMenu��6:   
���������5q   0   �� *CurrentSidebar+5r   0   5s   +   �� 5w   *   $��1��61   $��0,0,0,0q�6i   
������� 6A   �� *InnerContentPadding+._�5x   .   �� #��z��6?   5y   +   5z   '   5{   #   5~      5      5�      5�      5�      5�      %   WindowChrome% 5�        5�   
   &   CornerRadius$& 50��5�      '   GlassFrameThickness$' 0q�5�      (   UseAeroCaptionButtons( .  )   ResizeBorderThickness) 5�      �� *ResizeBorderThickness+*   CaptionHeight* 5�      �� *TitleHeight+5�      .��5�      �� ._�5�   
   �  5�      �� 5�      $	��53* �6#   �� 5�      $
��120* �6#   .+�5�      >� -   5        $$ 	MainFrame��5�      
������ $��2��5�   -   ��5�      �� *CurrentPage+5�   -   5�      5�      5�      