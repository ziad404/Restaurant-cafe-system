   M S B A M L   `   `   `  ���� J  FEnterpriseCourt, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:EnterpriseCourt.Screens.AuthEnterpriseCourt.Screens.Auth  ,    &EnterpriseCourt.Screens.Auth.empty_day   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     <local*clr-namespace:EnterpriseCourt.Screens.Auth       � Title$  total_drinks_sales��$	��650��$	��900�� � WindowStartupLocation$ CenterScreen=�.���  � ColumnDefinitions �� �� $��0* �.+�&   System.Windows.Controls.DataGrid  -     Name$ 
sales_grid��   AutoGenerateColumns$ False��   
IsReadOnly$
 True��$��Center=�$��18(�$
��Bold"�$	��252��$��	0,275,0,0q�$	��Top=�$	��786������ *DT+ � 	Resources =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property	 �� Value��%|   '        �� "  .���  � ��
	 ���@���  � ��$	 Center=���  � ��$	 0,0,1,2q���  � ��
	 �   �
   Columns
 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ 
الصنف��   Width5  /System.Windows.Controls.DataGridLengthConverter$	 150 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *name+  $ 
العدد��$	 150  �� *number_of_items+  $ سعر الواحد��$	 150  �� *price+  $ المبيع الكلي��$ *  �� *total_price+�� $��اسم النوع  �����	#FF32DDC1���	#FF6E5FCC$
��Left=�$��40��$��491,120,0,0q�$	��Top=�$	��148�� J� RenderTransformOrigin$ 0.487,0.603&�$��Center=�$��22(�$��Simplified Arabic)�$
��Bold"��� -    ��Name$ filter_sales��$
��Left=�$��40��$��176,120,0,0q�$	��Top=�$	��204��$��Gadugi)�$��16(��� -   $��End Day�����	#FF32DDC1���	#FF6E5FCC$
��Left=�$��47��$��
52,555,0,0q�$	��Top=�$	��164��$��18(�$
��Bold"�$��Gadugi)��� $�� : السعر الكلي��$
��Left=�$��Right=�$��690,552,0,0q�$	��Top=�$	��148��$��50��$��22(�$
��Bold"��� -    ��Name$ total��$�� ��$
��Left=�$��Right=�$��558,552,0,0q�$	��Top=�$	��148��$��50��$��22(�$
��Bold"�