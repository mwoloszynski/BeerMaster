   M S B A M L   `   `   `  ����E  ABeerMaster, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:BeerMaster.ViewBeerMaster.View  5      S.clr-namespace:BeerMaster.View.IngredientsViews BeerMaster.View.IngredientsViews  5      g8clr-namespace:BeerMaster.ViewModel.IngredientsViewModels*BeerMaster.ViewModel.IngredientsViewModels  5      %    BeerMaster.View.IngredientsView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:BeerMaster.View     5      @views.clr-namespace:BeerMaster.View.IngredientsViews     5      O
viewmodels8clr-namespace:BeerMaster.ViewModel.IngredientsViewModels     5      $
��auto��5
      $
��auto��5      $��Stretch=�5      $��Stretch=�5      $��Stretch=�5      $��Stretch=�5        � 	Resources  5         
font_style �� 
TargetType �� Property �� Value  Btn_menu �� 
TargetType �� Triggers P� Property P� Value��%S  &	        &	 �     �� 5   
   " ��6#   .�5      ��  � ��$ Center=�62   �� 5       � ��$
 Left=�64   �� 5       � ��
 �����6+   �� 5       � ��$ 20(�6)   5      �� 5   
   " ��6!   .�5      ��  � ��
 ���� 6+   �� 5       � �� 5       �� 5!      " ��6&   .R�5"      �� #��z��6!   
������ $��0q�5$   !   ._�5%      �� $��Center=�6/   $��Center=�5&   /   5'      5(      5*       5+      P� 5,       �@J�IsMouseOver$
 True��61   . �5-      ��  � ��
 ���� 63   5.      50      52      .��54      � 
������  � ColumnDefinitions 55   
   �� 56      $	��300 �6   �� 57      $��* �6   .+�5=   
   � $��0��6   .+�5>      �� .+�5?      �� $��0,25,0,0q�5@      $��Center=�5A        Ingredients#���  5B      
������ $	��Top=�5D      #��[  5E      �� 5F      -   5        	 ��Name$	 Settings_LV��5F      
������ 
������ $��0 30 0 0q�5I      $��Disabled=�5J      .@�5K      �� $	��280��6#   $��50��5L   #   $
��Left=�5M   #   $��0q�5N   #   .��5O      �� #��[ 6!   $	��280��5Q   !   $��50��5R   !   ��5P   !   �� *NavigateMaltsCommand+.��5S      �� 
 �� Orientation$
 
Horizontal=�6)   $	��280��5T   )   $��50��5U   )   .+�5V   "   �� $!��../Resources/Img/malt64.png��6(   $
��Fill=�5W   (    �� BitmapScalingMode$
 Fant=�5X   (   $��5,0,0,0q�5Y   (   $��48��5Z   (   $��48��5[   (   �� 5\   "    	 Malts#���  6,   $��25,0,0,0q�5]   ,   $��18(�5^   ,   #��[  5_   ,   5`      5a      5b      �� 5c      $	��280��6#   $��50��5d   #   $
��Left=�5e   #   $��0q�5f   #   .��5g      �� #��[ 6!   $	��280��5i   !   $��50��5j   !   ��5h   !   �� *NavigateHopsCommand+.��5k      �� $
 
Horizontal=�6)   $	��280��5l   )   $��50��5m   )   .+�5n   "   � $��48��6'   $��5 0 0 0q�62   .+�5o   &   �� $ ��../Resources/Img/hop32.png��6,   $
��Fill=�5p   (   $��32��5q   (   $
 Fant=�5r   (   $��32��5s   (   5t   #   �� 5u   "     Hops#���  6,   $��25,0,0,0q�5v   ,   $��18(�5w   ,   #��[  5x   ,   5y      5z      5{      �� 5|      $	��280��6#   $��50��5}   #   $
��Left=�5~   #   $��0q�5   #   .��5�      �� #��[ 6!   $	��280��5�   !   $��50��5�   !   ��5�   !   �� *NavigateYeastsCommand+.��5�      �� $
 
Horizontal=�6)   $	��280��5�   )   $��50��5�   )   .+�5�   "   �� $#��../Resources/Img/yeast512.png��6(   $
��Fill=�5�   (   $
 Fant=�5�   (   $��5,0,0,0q�5�   (   $��48��5�   (   $��48��5�   (   �� 5�   "    
 Yeasts#���  6,   $��25,0,0,0q�5�   ,   $��18(�5�   ,   #��[  5�   ,   5�      5�      5�      �� 5�      $	��280��6#   $��50��5�   #   $
��Left=�5�   #   $��0q�5�   #   .��5�      �� #��[ 6!   $	��280��5�   !   $��50��5�   !   ��5�   !   �� *NavigateAdditivesCommand+.��5�      �� $
 
Horizontal=�6)   $	��280��5�   )   $��50��5�   )   .+�5�   "   �� $$��../Resources/Img/fruits512.png��6(   $
��Fill=�5�   (   $
 Fant=�5�   (   $��5,0,0,0q�5�   (   $��48��5�   (   $��48��5�   (   �� 5�   "     	Additives#���  6,   $��25,0,0,0q�5�   ,   $��18(�5�   ,   #��[  5�   ,   5�      5�      5�      �� 5�      $	��280��6#   $��50��5�   #   $
��Left=�5�   #   $��0q�5�   #   .��5�      �� #��[ 6!   $	��280��5�   !   $��50��5�   !   ��5�   !   �� *NavigateMiscellaneousCommand+.��5�      �� $
 
Horizontal=�6)   $	��280��5�   )   $��50��5�   )   .+�5�   "   �� $$��../Resources/Img/powder512.png��6(   $
��Fill=�5�   (   $
 Fant=�5�   (   $��5,0,0,0q�5�   (   $��48��5�   (   $��48��5�   (   �� 5�   "     Miscellaneous#���  6,   $��25,0,0,0q�5�   ,   $��18(�5�   ,   #��[  5�   ,   5�      5�      5�      �� 5�      $	��280��6#   $��50��5�   #   $
��Left=�5�   #   $��0q�5�   #   .��5�      �� #��[ 6!   $	��280��5�   !   $��50��5�   !   ��5�   !   �� *NavigateWatersCommand+.��5�      �� $
 
Horizontal=�6)   $	��280��5�   )   $��50��5�   )   .+�5�   "   �� $#��../Resources/Img/water512.png��6(   $
��Fill=�5�   (   $
 Fant=�5�   (   $��5,0,0,0q�5�   (   $��48��5�   (   $��48��5�   (   �� 5�   "    
 Waters#���  6,   $��25,0,0,0q�5�   ,   $��18(�5�   ,   #��[  5�   ,   5�      5�      5�      �� 5�      $	��280��6#   $��50��5�   #   $
��Left=�5�   #   $��0q�5�   #   .��5�      �� #��[ 6!   $	��280��5�   !   $��50��5�   !   ��5�   !   �� *NavigateCarbonationCommand+.��5�      �� $
 
Horizontal=�6)   $	��280��5�   )   $��50��5�   )   .+�5�   "   �� $#��../Resources/Img/sugar512.png��6(   $
��Fill=�5�   (   $
 Fant=�5�   (   $��5,0,0,0q�5�   (   $��48��5�   (   $��48��5�   (   �� 5�   "    	 Carbonation#��� 	 6,   $��25,0,0,0q�5�   ,   $��18(�5�   ,   #��[  5�   ,   5�      5�      5�      ��5�      �� 5�      " ��6    .�5�      ��  � �� 5�   "   �� 5�   &   " ��66   .R�5�   *   ��  ��Name$ Bd��61   $��50��5�   5   #��z��5�   5   #��z��5   5   #��z��5  5    �� Padding# z��5  5    J� SnapsToDevicePixels$
 True��5  5   ._�5  .   �� #��z��6?   # z 5  C   #��z��5  C   5  +    �� Triggers 5  *   ]� 5	  .    ]� 
Conditions 5
  2   �� 5  6    �� Property �@J�IsMouseOver �� Value$
 True��6W   ./�5  2   ��  �� 
TargetName$ Bd��5  =    � �� �#404D5B5  =   �� 5  2   $ Bd��5  =    � �� �#404D5B5  =   5  /   5  '   5     5     5     5     5     � 5   
   $��0��6   .+�5!     �� ���#343746$��0 0 1 0q�5"     5#     � 5'  
   -   5         �Name$ Settings_BG��5'     $��1��6   .+�5)     �� ��6   �� *CurrentIngredientsViewModel+  5*      �� DataType?   9BeerMaster.ViewModel.IngredientsViewModels.MaltsViewModel0   *BeerMaster.View.IngredientsViews.MaltsView>   8BeerMaster.ViewModel.IngredientsViewModels.HopsViewModel/   )BeerMaster.View.IngredientsViews.HopsView@   :BeerMaster.ViewModel.IngredientsViewModels.YeastsViewModel1   +BeerMaster.View.IngredientsViews.YeastsViewC   =BeerMaster.ViewModel.IngredientsViewModels.AdditivesViewModel4   .BeerMaster.View.IngredientsViews.AdditivesViewG	   ABeerMaster.ViewModel.IngredientsViewModels.MiscellaneousViewModel8
   2BeerMaster.View.IngredientsViews.MiscellaneousView@   :BeerMaster.ViewModel.IngredientsViewModels.WatersViewModel1   +BeerMaster.View.IngredientsViews.WatersViewE   ?BeerMaster.ViewModel.IngredientsViewModels.CarbonationViewModel6   0BeerMaster.View.IngredientsViews.CarbonationView��%  (��       5+  #   *, +)(�� 2     5.  #   *, +)(�� d     51  #   *, +)(�� �     54  #   *, +)(�� �     57  #   *,	 +)(�� �     5:  #   *, +)(�� ,    5=  #   *, +)�� 5+     "  6#   .R�5,       5-     �� 5.     "  6#   .R�5/       50     �� 51     "  6#   .R�52       53     �� 54     "  6#   .R�55       56     �� 57     " 	 6#   .R�58     
  59     �� 5:     "  6#   .R�5;       5<     �� 5=     "  6#   .R�5>       5?     5@     5A     5B     5D     5E     