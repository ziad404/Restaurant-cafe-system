   M S B A M L   `   `   `  ����J  FEnterpriseCourt, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null[2clr-namespace:EnterpriseCourt.Screens.CashierRoles$EnterpriseCourt.Screens.CashierRoles  5   	   1    +EnterpriseCourt.Screens.CashierRoles.recipt   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Dlocal2clr-namespace:EnterpriseCourt.Screens.CashierRoles     5   	     � Title$  recipt��5   	   $
��auto��6   $	��275��6&    � WindowStartupLocation$ CenterScreen=�62   .��5	      � .+�5
   
   �� -   5         ��Name$ reciept_pnl��5
   #   $
��auto��6   .+�5      �� -   5        $��ImageViewer1��5   =   $%��/Screens/CashierRoles/court.jpg��6   $��80��6Q   $
��Fill=�6]   $	��250��6l   6z   �� 5       �� Orientation$ 
Horizontal=�6   $	��200��64   $��25��6@   .+�5      �� $��10(�6   $��serial number : ��6(   $	��113��6D   $��Segoe UI Semibold)�6P   �� 5      -   5         ��Name$ serial��5      $��20��6*   $��63��68   $��Segoe UI Semibold)�6C   5      �� 5      -   5        $ 	table_pnl��5      $ 
Horizontal=�6,   $	��130��6E   .+�5      �� -   5        $ 	table_num��5      $
��Bold"�6,   $	��250��6>   �� 5      -   5        $ lbl_name��5      $�� : رقم المقعد��6,   $
��Bold"�6D   5      �� 5      -   5        $ reciept_num��5      $ 
Horizontal=�6.   $	��130��6G   .+�5      �� -   5        $ counter��5      $
��Bold"�6*   $	��250��6<   �� 5      $ �� : رقم الفاتورة��6   $
��Bold"�64   5      �� 5      $ 
Horizontal=�6   $	��130��62   .+�5      �� -	   5        $ cashier��5      $
��Bold"�6*   $
��pepo��6<   �� 5      $�� : الكاشير ��6   $
��Bold"�60   5      �� 5      $ 
Horizontal=�6   $	��250��62   .+�5      �� -
   5        $
 time��5      $
��Bold"�6'   $��20-11-2021  12:30 AM��69   $	��151��6X   �� 5      $�� : التاريخ ��6   $
��Bold"�60   5       &   System.Windows.Controls.DataGrid  5"      -   5          Name$ dg��5"   N   $��Disabled=�6   $
��auto��6Z      AutoGenerateColumns$ False��6�   $��0 , 10q�6�      
IsReadOnly$
 True��6�   ��6h   �� *DT+   Columns 5#      0  *System.Windows.Controls.DataGridTextColumn  5$      ,  &System.Windows.Controls.DataGridColumn	   Header$	 سعر الصنف��6)   
   Width5  /System.Windows.Controls.DataGridLengthConverter$
 80 6\   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6=   ��  �� Path$ price�6i     5%      $	 
العدد��6)   $
 35 6b    69   �� $ number_of_items�6o     5&      $	 
الصنف��6)   $	
 160 6V    68   �� $
 name�6d    � 	Resources 5(      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property �� Value��%�   '        �� 5)      "  6   .�5+      ��  � ��$ 1,3,0,1q�6<   6N   �� 5,       � ��$
 Bold"�67   6F   �� 5-       � ��$ 13(�65   6B   �� 5.       � ��
 �   �6H   �� 5/       � ��$ Center=�6G   50      53      54      �� 56      -   5        $ 	total_pnl��56      $ 
Horizontal=�6,   $	��250��6E   $��	0,10,0,10q�6Q   .+�57      �� -   5        $ totalpr��57      $��15(�6)   $
��Bold"�67   $�� ��6I   $	��151��6T   �� 58      $�� : السعر الكلي ��6   $
��Bold"�64   $��15(�6F   59      �� 5:      -   5         ��Name$ xx��5:       �� CornerRadius$ 6��6!   
�������$��2q�6E   $��10 , 0 , 10 ,20q�6Y   ._�5<      �� -   5        $ mm��5<      .+�5=      �� -   5        $ name_pnl��5=   !   $ 
Horizontal=�63   $	��250��6L   $��0,10,0,5q�6X   .+�5>      �� -   5        $
 name��5>   C   $��Right=�6    $��12(�6Q   $��Medium"�6_   $�� ��6s   $	��151��6~   �� 5?      $�� : اسم العميل ��6"   $��Medium"�6;   $��12(�6O   5@      �� 5A      -   5        $ info_pnl��5A   !   $ 
Horizontal=�63   $	��250��6L   $��0,10,0,5q�6X   .+�5B      �� -   5        $
 info��5B   C   $��Right=�6    $��12(�6Q   $��Medium"�6_   $�� ��6s   $	��133��6~   �� 5C      $%�� : ملحوظات العميل ��6"   $��Medium"�6?   $��12(�6S   $	��112��6a   5D      �� 5E      -   5        $ num_pnl��5E   !   $ 
Horizontal=�62   $	��250��6K   $��0,10,0,5q�6W   .+�5F      �� -   5        $ number��5F   C   $��Right=�6    $��12(�6S   $��Medium"�6a   $�� ��6u   $	��151��6�   �� 5G      $�� : رقم العميل ��6"   $��Medium"�6;   $��12(�6O   5H      �� 5I      -   5        $ adr_pnl��5I   !   $ 
Horizontal=�62   $	��250��6K   $��0,10,0,5q�6W   .+�5J      �� -   5        $	 adr��5J   C   $��Right=�6    $��12(�6P   $��Medium"�6^   $�� ��6r   $	��151��6}   �� 5K      $!�� : عنوان العميل ��6"   $��Medium"�6=   $��12(�6Q   5L      5N      5O      5P      5R      5S      