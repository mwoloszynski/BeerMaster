   M S B A M L   `   `   `  ����E  ABeerMaster, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:BeerMaster.ViewModelBeerMaster.ViewModel  5   	   1clr-namespace:BeerMaster.ViewBeerMaster.View  5   	   1clr-namespace:BeerMaster.ViewBeerMaster.View  5   	   $    BeerMaster.View.MainWindowView   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9
viewmodels"clr-namespace:BeerMaster.ViewModel     5   	   /viewsclr-namespace:BeerMaster.View     5   	   /localclr-namespace:BeerMaster.View     5   	   -   5          � 
ResizeMode$  CanMinimize=�5
   	    � WindowStyle$
 None=�5   	    � WindowStartupLocation$ CenterScreen=�5   	    � Title$ 
BeerMaster��5   	    � Icon$ ../Resources/logo.png��5   	   $	��720��5   	   $
��1280��5   	    � 	Resources 5         CloseBtn_MouseOver �� ImageSource  	Close_btn �� 
TargetType �� Property	 �� Value
 �� 
TargetType ��Name J� SnapsToDevicePixels �� Triggers P� Property P� Value �� 
TargetName  TabItemStyle �� CornerRadius  TabControlStyle � RowDefinitions K� IsItemsHost��%�  &	        &	 A     7   &	 �    &	 �    �� 5   
   $- '../Resources/Img/closeBtn_MouseOver.png��60   �� 5   
   " ��6"   .�5      ��  � ��	 5      �� 5      "
 ��6&   .R�5      �� $ Button��6!   $��0q�5   !   #��z��5   !   $
 True��5   !   5       5      P� 5        �@J�IsMouseOver$
 True��5!   &   . �5"   "   �� $ Button��5#   )   8	    � ��5$   )   5%      5'      5)      5*      �� 5-   
   " ��6%   .�5.      ��  � ��	 �#2E333A6+   �� 5/       � ��
	 �����6+   �� 50       � ��$	 3 3 3 0q�60   �� 51       � ��	 �#23262b6,   �� 52       � ��$	 0 0 5 0q�6'   �� 53       � ��$		 150��6&   �� 54       � ��$
	 12 8q�6(   �� 55       � ��$	 15(�6)   �� 56       � ��$	 50��6'   �� 57       � ��$		 Top=�62   �� 58       � ��$
	 Left=�64   �� 59       � ��	 5:      �� 5;      "
 ��6&   .R�5<      � $
 True��6   .+�5=      �� $ 0��6%   #��z��5>   %   #��z��5?   %   #��z��5@   %   #��z��5A   %   ._�5B   "   �� $��Header��63   $��Center=�5C   3   $��Center=�5D   3   $
 True��5E   3   $|�False��5F   3   #��z��5G   3   $
��True��5H   3   5I      5J       5K      P� 5L       �@J�IsMouseOver$
 True��6=   . �5M   "   ��  � ��	 �#4A56686?   5N      P� 5O       �@��
IsSelected$
 True��6<   . �5P   "   ��  � ��	 �#23262b6?   5Q      5S      5U      5V      �� 5Y   
   " ��6(   .�5Z      ��  � ��
	 ���� 6+   �� 5[       � ��$	 0q�60   �� 5\       � ��
	 ���� 6,   �� 5]       � ��$	 5q�6(   �� 5^       � ��$	 10 0 0 0q�6'   �� 5_       � ��$	 Center=�62   �� 5`       � ��$
	 Left=�64   �� 5a       � ��	 5b      �� 5c      "
 ��6&   .R�5d      � $
 True��6    5e      �� 5f   "   $��* �60   �� 5g   "   $��50 �60   .+�5i      �� $��1��6'   
������ $
 True��5k   '   �� 5l      $��0��6%   $ 0��5m   %   #��z��5n   %   #��z��5o   %   #��z��5p   %   ._�5q   "   �� $��SelectedContent��63   $
 True��5r   3   #��z��5s   3   5t      5u      5v      5x      5y      5{      .��5}      � ���#2E333A � ColumnDefinitions 5~   
   �� 5      $��* �6   �� 5�      $��60 �6    5�   
   �� 5�      $��60 �6   �� 5�      $��* �6   .+�5�   
   � $��1��6   $��0��5�      $��2��5�      ���#23262b$��
10 0 10 10q�5�      .+�5�      �� $��10q�5�      ��5�      �� *CurrentViewModel+ 5�       �� DataType(   "BeerMaster.ViewModel.HomeViewModel   BeerMaster.View.HomeView(   "BeerMaster.ViewModel.BrewViewModel   BeerMaster.View.BrewView+   %BeerMaster.ViewModel.RecipesViewModel!   BeerMaster.View.RecipesView*   $BeerMaster.ViewModel.StylesViewModel    BeerMaster.View.StylesView/	   )BeerMaster.ViewModel.IngredientsViewModel%
   BeerMaster.View.IngredientsView,   &BeerMaster.ViewModel.SettingsViewModel"   BeerMaster.View.SettingsView��%�  (��       5�   #   *, +)(�� 2     5�   #   *, +)(�� d     5�   #   *, +)(�� �     5�   #   *, +)(�� �     5�   #   *,	 +)(�� �     5�   #   *, +)�� 5�      "  6#   .R�5�        5�      �� 5�      "  6#   .R�5�        5�      �� 5�      "  6#   .R�5�        5�      �� 5�      "  6#   .R�5�        5�      �� 5�      " 	 6#   .R�5�      
  5�      �� 5�      "  6#   .R�5�        5�      5�      5�      5�      � 5�   
   $��0��6   $��2��6   ���#2E333A5�      �� 5�   
   $��0��6   $��0��5�      #���  5�       �� SelectedIndex 5�      �� *SelectedViewIndex+.@�5�      ��   
HomeHeader#���  6   #���  5�      �� 5�        
BrewHeader#���  6   #���  5�      �� 5�        RecipesHeader#���  6   #���  5�      �� 5�        StylesHeader#���  6   #���  5�      �� 5�        IngredientsHeader#���  6   #���  5�      �� 5�       	 SettingsHeader#��� 	 6   #���  5�      5�      �� 5�   
   -   5         ��Name$ CloseBtn��5�      $��1��5�      $��0��5�      $��40��5�      $��40��5�      $��0q�5�      #��[ 5�      ��5�      �� 5�      $+ %../Resources/Img/closeBtn_default.png��6   5�      5�      5�      