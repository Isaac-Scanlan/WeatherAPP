   M S B A M L   `   `   `  ����E  AWeatherApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:WeatherApp.View.ControlsWeatherApp.View.Controls  5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089  �� MergedDictionaries �� Source+    %WeatherApp.View.Controls.DisplayTable �� 
TargetType �� Property �� Value&   System.Windows.Controls.DataGrid:  4System.Windows.Controls.Primitives.DataGridRowHeader   PrimaryColor_D=  7System.Windows.Controls.Primitives.DataGridColumnHeader*  $System.Windows.Controls.DataGridCell �� 
TargetType �� CornerRadius  TertiaryColor_L J� Effect3  -System.Windows.Media.Effects.DropShadowEffect   
BlurRadius	   Opacity
   ShadowDepth   Color   AutoGenerateColumns   SelectionMode   
IsReadOnly   ColumnHeaderHeight   	RowHeight   GridLinesVisibility   HorizontalGridLinesBrush   VerticalGridLinesBrush   RowBackground   AlternatingRowBackground   CanUserResizeColumns   HeadersVisibility �� RelativeSource �� Path   RowHeaderStyle �� BasedOn   Columns0  *System.Windows.Controls.DataGridTextColumn,  &System.Windows.Controls.DataGridColumn   Header   Width5  /System.Windows.Controls.DataGridLengthConverter1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding    ColumnHeaderStyle!   	CellStyle�� 5      F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     :x,http://schemas.microsoft.com/winfx/2006/xaml     5      0local&clr-namespace:WeatherApp.View.Controls  5        5      �� 5   
   $2 ,/WeatherApp;component/Resources/Colours.xaml?�6   �� 5   
   $9 3/WeatherApp;component/Resources/MainDictionary.xaml?�6   %  '         7   7  7 7   7 7 �� 5
      "   6   .�5   
   ��  � ��$ Segoe UI Light)�6'   �� 5   
    � ��$ 12(�6%   �� 5   
    � ��
 ���� 6'   �� 5   
    � ��
 �   �6'   �� 5   
    �@ RowBackground
 ���� 6*   �� 5   
     �@ AlternatingRowBackground
 ���� 65   �� 5   
    �@ GridLinesVisibility$	 All=�60   �� 5   
    �@ RowHeaderWidth$ 0Q�6+   �� 5   
    �@ CanUserResizeColumns$
 True��61   �� 5   
    �@ AutoGenerateColumns$ False��60   �� 5   
    �@ SelectionMode$ Extended=�6*   �� 5   
    �@ 
IsReadOnly$
 True��6'   �� 5   
    �@ HeadersVisibility$ Column=�6.   �� 5   
    �@ ColumnHeaderHeight$ 30Q�6/   �� 5   
    �@ 	RowHeight$ 30Q�6&   �� 5   
     �@ HorizontalGridLinesBrush �#e2e2e265   �� 5   
    �@ VerticalGridLinesBrush
 ���� 63   �� 5   
    � ��$ 0q�6,   �� 5   
    � ��$ 	10,0,10,0q�6$   �� 5    
    �@ RowHeaderStyle 5!      �� 5"      "  6   .�5#      ��  � ��8   63   �� 5$       � ��
 �   �63   �� 5%       � ��$ 30��6.   �� 5&       � ��$ Center=�6C   �� 5'       � ��$ Center=�6A   5(      5*      �� 5-   
    �@ ColumnHeaderStyle 5.      �� 5/      "  6   .�50      ��  � ��
 ���� 63   �� 51       � �� �#c2c2c264   �� 52       � ��$ 0,0,0,2q�68   �� 53       � ��
 �   �63   �� 54       � ��$ 30��6/   �� 55       � ��$ 	2, 2, 2,0q�60   �� 56       � ��$ Center=�6C   �� 57       � ��$ Center=�6A   58      5:      �� 5=   
    �@ 	CellStyle 5>      �� 5?      "  6   .�5@      ��  � �� �#e2e2e264   �� 5A       � ��$ 0,0,0,0q�68   �� 5B       � ��$ 0q�60   �� 5C       � ��$ 0,0,0,0q�6/   �� 5D       � ��$ Center=�6C   �� 5E       � ��$ Center=�6A   �� 5G       � �� 5H      �� 5I      "  6.   .R�5J   "   �� #��z��6)   #��z��6S   #��z��6   ._�5K   &   �� $��Center=�67   $��Center=�6T   5L   #   5M      5O      5P      5R      �� 5W   
    � �� 5X      �� 5Y      "   6"   .R�5Z      � .+�5[      �� $��1q�6!   
�������$ 10��6M   8��  5]        5^   "   $ 20Q�63   $		 0.1Q�6C   $
 7Q�6Q   $ DarkSlateGray��6a   ._�5a        # z 5c   !   # z 5d   !   # z 5e   !   # z 5f   !   # z 5g   !   # z 5h   !   # z 5i   !   # z 5j   !   # z 5k   !   # z 5l   !   # z 5m   !   # z 5n   !   #��z��5o   !   #��z��5p   !   #��z��5q   !   #��z��5r   !   #��z��5s   !   #��z��5t   !   ��5b   !   ��  �� *TemplatedParent+$ ItemsSource� 5w   "   �� 5x   &   "  6,   8  .�5y   *   ��  � ��8  6G   �� 5z   *    � ��
 �   �6G   �� 5{   *    � ��$ 30��6B   �� 5|   *    � ��$ Center=�6W   �� 5}   *    � ��$ Center=�6U   5~   '    5�   "     5�   &   $ ID��69   $ 1* 6\    6E   �� *Id+6\     5�   &   $
 City��69   $ 60 6`    6G   �� *City+6`     5�   &   $ Humidity (%)��69   $ 2* 6l    6O   �� *
Humidity+6l     5�   &   $ Pressure (hPa)��69   $ 2* 6n    6Q   �� *
Pressure+6n     5�   &   $ 
Temp (°C)��69   $ 2* 6e    6L   �� *Temp+6e     5�   &   $ Description��69   $ 2* 6n    6N   �� *Description+6n     5�   &   $
 Main��69   $ 2* 6`    6G   �� *Main+6`     5�   &   $
 Icon��69   $ 2* 6`    6G   �� *Icon+6`     5�   "   �� 5�   &   "  6,   8  .�5�   *   ��  � ��
 ���� 6G   �� 5�   *    � �� �#c2c2c26H   �� 5�   *    � ��$ 0,0,0,2q�6L   �� 5�   *    � ��
 �   �6G   �� 5�   *    � ��$ 30��6C   �� 5�   *    � ��$ 2,2,2,0q�6D   �� 5�   *    � ��$ Center=�6W   �� 5�   *    � ��$ Center=�6U   5�   '   ! 5�   "   �� 5�   &   "  6,   8  .�5�   *   ��  � �� �#e2e2e26H   �� 5�   *    � ��$ 0,0,0,0q�6L   �� 5�   *    � ��$ 0q�6D   �� 5�   *    � ��$ 0,0,0,0q�6C   �� 5�   *    � ��$ Center=�6W   �� 5�   *    � ��$ Center=�6U   �� 5�   *    � �� 5�   .   �� 5�   2   "  6B   .R�5�   6   �� #��z��6=   #��z��6g   #��z��6�   ._�5�   :   �� $��Center=�6K   $��Center=�6h   5�   7   5�   3   5�   +   5�   '   5�      5�      5�      5�      5�      5�      5�      