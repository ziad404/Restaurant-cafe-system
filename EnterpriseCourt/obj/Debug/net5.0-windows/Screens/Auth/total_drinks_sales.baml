   M S B A M L   `   `   `  ����J  FEnterpriseCourt, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:EnterpriseCourt.Screens.AuthEnterpriseCourt.Screens.Auth  5   	   5    /EnterpriseCourt.Screens.Auth.total_drinks_sales   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   <local*clr-namespace:EnterpriseCourt.Screens.Auth     5   	     � Title$  total_drinks_sales��5   	   $	��650��6$   $	��900��61    � WindowStartupLocation$ CenterScreen=�6=   .��5	      �  � ColumnDefinitions 5
   
   �� 5      �� 5      $��0* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ drinks_sales_grid��5   ^      AutoGenerateColumns$ False��6/      
IsReadOnly$
 True��6K   $��Center=�6y   $��18(�6�   $
��Bold"�6�   $	��252��6�   $��	0,228,0,0q�6�   $	��Top=�6�   $	��786��6�   ��6   �� *DT+ � 	Resources 5      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property	 �� Value��%�   '        �� 5      "  6   .�5      ��  � ��
	 ���@�6G   �� 5       � ��$	 Center=�6C   �� 5       � ��$	 0,0,1,2q�68   6J   �� 5       � ��
	 �   �6D   5      5      
   Columns
 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 
الصنف��6&      Width5  /System.Windows.Controls.DataGridLengthConverter$	 150 6T   1  +System.Windows.Controls.DataGridBoundColumn   Binding 66   ��  �� Path$
 name�6b     5      $ 
العدد��6%   $	 150 6^    65   �� $ number_of_items�6l     5      $ سعر الواحد��6%   $	 150 6Y    6:   �� $ price�6g     5      $ المبيع الكلي��6%   $ * 6a    6<   �� $ total_price�6m   5"      �� 5#   
   $��Total drinks sales��6   ���	#FF32DDC1���	#FF6E5FCC$��Center=�6[   $��44��6x   $��0,27,0,0q�6�   $	��Top=�6�   $	��360��6�   $��Center=�6�   $��20(�6�   $
��Bold"�6�   �� 5$   
   $��اسم النوع  ��6   ���	#FF32DDC1���	#FF6E5FCC$
��Left=�6U   $��40��6p   $��695,120,0,0q�6|   $	��Top=�6�   $	��148��6�    J� RenderTransformOrigin$ 0.487,0.603&�6�   $��Center=�6�   $��22(�6�   $��Simplified Arabic)�6  $
��Bold"�6*  �� 5%   
   -   5         ��Name$ filter_drinks��5%      $
��Left=�6+   $��40��6F   $��380,120,0,0q�6R   $	��Top=�6g   $	��204��6   $��Gadugi)�6�   $��16(�6�   6�   �� 5&   
   -   5        $��Export to excel��5&      ���	#FF32DDC1���	#FF6E5FCC$
��Left=�6Y   $��47��6t   $��
57,506,0,0q�6�   $	��Top=�6�   $	��164��6�   $��18(�6�   $
��Bold"�6�   $��Gadugi)�6�   �� 5'   
   $�� : السعر الكلي��6   $
��Left=�6)   $��Right=�6D   $��695,503,0,0q�6g   $	��Top=�6|   $	��148��6�   $��50��6�   $��22(�6�   $
��Bold"�6�   �� 5(   
   -   5         ��Name$ total��5(      $�� ��6   $
��Left=�6*   $��Right=�6E   $��563,503,0,0q�6h   $	��Top=�6}   $	��148��6�   $��50��6�   $��22(�6�   $
��Bold"�6�   5*      5+      