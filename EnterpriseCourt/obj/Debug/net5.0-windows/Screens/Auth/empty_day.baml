   M S B A M L   `   `   `  ����J  FEnterpriseCourt, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:EnterpriseCourt.Screens.AuthEnterpriseCourt.Screens.Auth  5   	   ,    &EnterpriseCourt.Screens.Auth.empty_day   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   <local*clr-namespace:EnterpriseCourt.Screens.Auth     5   	     � Title$  total_drinks_sales��5   	   $	��650��6$   $	��900��61    � WindowStartupLocation$ CenterScreen=�6=   .��5	      �  � ColumnDefinitions 5
   
   �� 5      �� 5      $��0* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ 
sales_grid��5   ^      AutoGenerateColumns$ False��6/      
IsReadOnly$
 True��6K   $��Center=�6r   $��18(�6�   $
��Bold"�6�   $	��252��6�   $��	0,275,0,0q�6�   $	��Top=�6�   $	��786��6�   ��6   �� *DT+ � 	Resources 5      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property	 �� Value��%�   '        �� 5      "  6   .�5      ��  � ��
	 ���@�63   �� 5       � ��$	 Center=�6C   �� 5       � ��$	 0,0,1,2q�68   �� 5       � ��
	 �   �64   5      5      
   Columns
 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 
الصنف��6&      Width5  /System.Windows.Controls.DataGridLengthConverter$	 150 6O   1  +System.Windows.Controls.DataGridBoundColumn   Binding 66   �� *name+6O     5      $ 
العدد��6%   $	 150 6Y    65   �� *number_of_items+6Y     5      $ سعر الواحد��6%   $	 150 6T    6:   �� *price+6T     5      $ المبيع الكلي��6%   $ * 6\    6<   �� *total_price+6\   5      �� 5   
   $��اسم النوع  ��6   ���	#FF32DDC1���	#FF6E5FCC$
��Left=�6U   $��40��6p   $��491,120,0,0q�6|   $	��Top=�6�   $	��148��6�    J� RenderTransformOrigin$ 0.487,0.603&�6�   $��Center=�6�   $��22(�6�   $��Simplified Arabic)�6  $
��Bold"�6*  �� 5    
   -   5         ��Name$ filter_sales��5       $
��Left=�6*   $��40��6E   $��176,120,0,0q�6Q   $	��Top=�6f   $	��204��6~   $��Gadugi)�6�   $��16(�6�   6�   �� 5!   
   -   5        $��End Day��5!      ���	#FF32DDC1���	#FF6E5FCC$
��Left=�6Q   $��47��6l   $��
52,555,0,0q�6x   $	��Top=�6�   $	��164��6�   $��18(�6�   $
��Bold"�6�   $��Gadugi)�6�   6�   �� 5"   
   $�� : السعر الكلي��6   $
��Left=�6)   $��Right=�6D   $��690,552,0,0q�6g   $	��Top=�6|   $	��148��6�   $��50��6�   $��22(�6�   $
��Bold"�6�   �� 5#   
   -   5         ��Name$ total��5#      $�� ��6   $
��Left=�6*   $��Right=�6E   $��558,552,0,0q�6h   $	��Top=�6}   $	��148��6�   $��50��6�   $��22(�6�   $
��Bold"�6�   5%      5&      