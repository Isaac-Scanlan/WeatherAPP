   M S B A M L   `   `   `  ����E  AWeatherApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:WeatherApp.View.ControlsWeatherApp.View.Controls  5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089  �� MergedDictionaries �� Source �� 
TargetType   CustomClearButtonStyle �� Property �� Value �� 
TargetType F�Name �� Stretch �� StrokeStartLineCap	 �� StrokeEndLineCap
 �� ScaleX �� ScaleY J� RenderTransformOrigin �� Triggers P� Property P� Value �� 
TargetName/    )WeatherApp.View.Controls.ClearableTextBox �� 
StartPoint �� EndPoint  GradientStartColor � Color � Offset  GradientEndColor3  -System.Windows.Media.Effects.DropShadowEffect   
BlurRadius   Opacity   ShadowDepth   Color ��Name �� RadiusX �� RadiusY ��Name ��Name K� ZIndex �� RelativeSource  �� Path! :� RoutedEvent" �� TargetProperty	# W� To$ g� Duration�� 5      F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     :x,http://schemas.microsoft.com/winfx/2006/xaml     5      0local&clr-namespace:WeatherApp.View.Controls  5        5      �� 5   
   $2 ,/WeatherApp;component/Resources/Colours.xaml?�6   �� 5   
   $9 3/WeatherApp;component/Resources/MainDictionary.xaml?�6   %�  &	        '   �    7  7  7   �� 5
      " ��6   .�5   
   ��  � ��
 ���� 6'   �� 5   
    � ��
 ���� 6(   �� 5   
    � �� 5      �� 5      " ��6"   .R�5      � .+�5      �� #��z��6!   ._�5      F� $ ClearButtonPath��6#   S����@T� @T� �@T� @T� ����������������@T� ����@T� @T� ���@T� ���	$ Uniform=�5      
�������
������ $��15��5      $��15��5      $��9q�5      $	��3.5��5      $ Round=�5      $	 Round=�5      z�5   "   �� 5   &   $
 1Q�65   $ 1Q�6@   $ 0.5, 0.5&�5#   >   5$      5&      5'       5(      P� 5*       �@J�IsMouseOver$
 True��69   . �5+      �� $ ClearButtonPath��6%    � �� �	#EEDDDDDD6T   5,      P� 5-       �@J�IsMouseOver$ False��69   . �5.      �� $ ClearButtonPath��6%    � ��
 �����6T   5/      51      53      54      �� 57      "   6   .�58   
   ��  � ��$ Center=�65   �� 59   
    � ��$
 Left=�67   �� 5:   
    � ��$ Segoe UI)�6'   �� 5<   
    � ��$ 15(�6%   �� 5=   
    �@��SelectionBrush
 �����6+   �� 5>   
    �@��SelectionTextBrush
 �����6/   �� 5?   
    �@��SelectionOpacity$
 0.17Q�6-   �� 5@   
    � ��
 �����6'   �� 5A   
    �@��
CaretBrush
 �����6'   �� 5B   
    � �� 5C      �� 5D      $	 0,0&�6&   $	 1,1&�67   .��5E      � 8   $ 0Q�6O   � 5F      8  $ 1Q�6M   5G      5I      �� 5J   
    �@J�Effect 5K        5L      $ 20Q�6#   $	 0.2Q�63   $ 5Q�6A   $ DarkSlateGray��6Q   5N      �� 5O   
    �@J�RenderTransformOrigin$ 0.5,0.5&�62   �� 5P   
    � z� 5Q      �� 5R      $
 1Q�6!   $ 1Q�6,   5T      �� 5U   
    � �� 5V      �� 5W      "   6"   .R�5X      � .+�5Z      �� $ BackgroundRectangle��6$   $ 9��5[      $ 9��5\      #��z��5]      �� 5`      $ PART_ContentHost��6'   $��5,0,40,0q�5a      $��Stretch=�5b      
������ $��Stretch=�5d      #��z��5e      #��z��5f      z�5g      �� 5h   "   $
 1Q�61   $ 1Q�6<   5k      �� 5n      $ ClearButton��6!   $y�Visible=�5o      $��35��5p      $��35��5q      $��Right=�5r      $��0,0,5,0q�5s      $��Center=�5t      
������ 
������ $��0q�5w      $ 1��5x      8�� ��5z      ��  �� *TemplatedParent+$  ClearCommand�5{       5}      P� 5~       � ��$  ��62   . �5      �� $ ClearButton��6%    � y�$ 	Collapsed=�6T   5�      :� 5�      $! 
MouseEnter��6'   .[�5�      �� .��5�   "   �� .��5�   &   W� $" RenderTransform.ScaleX�5�   %   # 1.045�   %   $$ 0:0:0.23D�5�   %   W� 5�   &   $" RenderTransform.ScaleY�5�   %   # 1.045�   %   $$ 0:0:0.23D�5�   %   5�   #   5�      5�      :� 5�      $! 
MouseLeave��6'   .[�5�      �� .��5�   "   �� .��5�   &   W� $" RenderTransform.ScaleX�5�   %   # 1.05�   %   $$ 0:0:0.3D�5�   %   W� 5�   &   $" RenderTransform.ScaleY�5�   %   # 1.05�   %   $$ 0:0:0.3D�5�   %   5�   #   5�      5�      5�      5�      5�      5�      