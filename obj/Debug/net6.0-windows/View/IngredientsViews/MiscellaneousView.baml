   M S B A M L   `   `   `  ����E  ABeerMaster, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:BeerMaster.View.IngredientsViews BeerMaster.View.IngredientsViews  5      8    2BeerMaster.View.IngredientsViews.MiscellaneousView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      @local.clr-namespace:BeerMaster.View.IngredientsViews     5      $
��auto��5      $
��auto��5	      $��Stretch=�5
      $��Stretch=�5      $��Stretch=�5      $��Stretch=�5        � 	Resources  5         TestFont_style �� 
TargetType �� Property �� Value��%�   &	        �� 5   
   " ��6'   .�5      ��  � ��$ Center=�62   �� 5       � ��$
 Left=�64   �� 5       � ��
 �����6+   �� 5       � ��$ 20(�6)   5      5      .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6    � RowDefinitions 5    
   �� 5!      $	��10* �6   �� 5"      $��8* �6   �� 5#      $��5* �6   �� 5$      $	��40* �6   .+�5)   
   � $��0��6   $��	0 25 0 10q�6   .+�5*      �� $��Inne składniki��6   $��25(�5+      $��Center=�5,      $��Center=�5-      #��[  5.      ]� 5/      $	��220��6   $��Right=�50      $��Center=�51      .+�52      �� $��Right=�6   $��Stretch=�53      $��0 0 40 0q�54      .+�55      �� $��32��6     Btn_menu#��[ 57      ��56      �� *AddMiscCommand+.��58      �� $!��../../Resources/Img/add.png��6    $
��Fill=�59   !    �� BitmapScalingMode$
 Fant=�5:   !   $��0q�5;   !   $��32��5<   !   $��32��5=   !   5>      �� 5?      $��Dodaj inny składnik��6    $��16(�5@       #��[  5A       5B      5C      5D      � 5F   
   $��0��6   .+�5G      �� ���#343746$��0 0 0 1q�5H      $
��40 0q�5I      5J      � 5N   
   $��1��6   $��3��6   .+�5O      �� $��Stretch=�6   $��Stretch=�5P      .+�5Q      �� -   5         ��Name$ MiscellaneousListView��5S      $��
13 10 13 0q�5Q      $	��450��5R        LV_style#��[ 5U        	LVI_style#��[ 5V      $��Visible=�5W      ��5T      �� *Miscs+  5X        FavsScrollViewer �� BasedOn��%0   '��       7  �� 5Y      " ��6    8   6q   5Z      	 �� View	 5[      �� 5\      .P�5]      �� 
 �� Width$
 50��6-    �� CellTemplate 5^   "   �� 5_   &   .R�5`   *   ��  ��Name$ CloseBtn��61     CloseBtn_style#��[ 5c   1   ��5a   1   ��  �� ElementName$ MiscellaneousListView�� �� Path$# DataContext.DeleteMiscCommand���5b   1   �� *Id+5c   1   5d   '   5f      �� 5g      $	
 250��6-   $��Nazwa��69    �� DisplayMemberBinding 6H   �� *Name+�� 5h      $	
 200��6-   $	��Typ��69    6F   �� *Type+�� 5i      $	
 300��6-   $��Czas dodania��69    6O   �� *	TimeOfUse+! �� ColumnHeaderContainerStyle 5j      �� 5k   "     	LVH_style# [ 6(   " ��6M   6z   5m      5o      5p      5q      5s      5t      