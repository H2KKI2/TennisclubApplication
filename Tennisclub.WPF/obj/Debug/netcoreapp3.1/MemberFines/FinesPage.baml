   M S B A M L   `   `   `  ����I  ETennisclub.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:Tennisclub.WPF.MemberFinesTennisclub.WPF.MemberFines  5      *    $Tennisclub.WPF.MemberFines.FinesPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:Tennisclub.WPF.MemberFines     5        N� Title$  	FinesPage��5	      .��5      �  � ColumnDefinitions 5   
   �� 5      $��20 �6   6,   �� 5      $��* �6   6+   �� 5      $
��0.5* �6   6.   �� 5      $��20 �6   6,    � RowDefinitions 5   
   �� 5      $��20 �6   6*   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $��* �6   6)   �� 5      $��20 �6   6*   .+�5   
   �� $��1��6   $��1��6!   $��2��61   $��30(�6E   ���#DADADA$��Fines��6h   6w   � 5   
   $��1��6   $��2��6   $
��auto��6,   .+�5      ��  �� Orientation$ 
Horizontal=�6   $��	0,10,0,10q�62   ���#1D1D1D$
��Left=�6Z   .+�5      � $��Bottom=�6   $��	20 5 0 10q�62    5      �� 5      $
��auto �6(   68   �� 5       $
��auto �6(   68   .+�5"      �� $��Handout Date��6    ���#DADADA6K   (  "System.Windows.Controls.DatePicker  5#      -   5          Name$ dp_HandoutDateFilter��5#   !   $��1��6?   $	��150��6L   $��30��6X   ���#DADADA$
��Left=�6y   6�   5$      � 5%      $��Bottom=�6   $��	20 5 0 10q�62    5&      �� 5'      $
��auto �6(   68   �� 5(      $
��auto �6(   68   .+�5*      �� $��Payment Date��6    ���#DADADA6K     5+      -   5        $ dp_PaymentDateFilter��5+   !   $��1��6?   $	��150��6L   $��30��6X   ���#DADADA$
��Left=�6y   6�   5,      �� 5.      -   5         ��Name$ 
btn_Filter��5.      
������ $��0q�6F   $��	10 10 0 0q�6Z   .��6�   Filter6�   �� 5/      -   5        $ btn_ClearFilter��5/      
������ $��0q�6K   $��0 10 0 0q�6_   .��6�   Clear Filter6�   50      51      &   System.Windows.Controls.DataGrid  54   
   -   5          Name$ finesDataGrid��54      $��3��6*   $��1��67      
IsReadOnly$
 True��6G      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6Y   	   HeadersVisibility$	 Column=�6i   $��10(�6�   
   AutoGenerateColumns$
 False��55         CanUserAddRows$ False��60      SelectionMode$ Single=�6G      GridLinesVisibility$
 None=�6^      Columns 56      0  *System.Windows.Controls.DataGridTextColumn  57      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6%      Width$ 0.50* 6O   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *	Member.Id+6O     58      $ FineNr��6%   $
 0.6* 6T    65   �� *
FineNumber+6T     59      $ Amount��6%   $ * 6P    65   �� *Amount+6P     5:      $ 
First Name��6%   $ * 6^    69   �� *Member.FirstName+6^     5;      $ 	Last Name��6%   $ * 6\    68   �� *Member.LastName+6\     5<      $ Handout Date��6%   $ * 6x    6;   �� *HandoutDate+ �� StringFormat$ {0:dd/MM/yy}��6x     5=      $ Payment Date��6%   $ * 6x    6;   �� *PaymentDate+$ {0:dd/MM/yy}��6x   5?      � 5A   
   $��3��6   $��2��6   .+�5B      � $��2��6   $��2��6    ���#1D1D1D$��10 0 0 0q�6E    5C      �� 5D      $��20 �6'   64   �� 5E      $��* �6'   63   �� 5F      $��20 �6'   64    5H      �� 5I      $��20 �6$   62   �� 5J      $
��auto �6$   64   �� 5K      $��* �6$   61   �� 5L      $��0.33* �6$   65   �� 5M      $��20 �6$   62   .+�5O      �� $��1��6   $��1��6)   $��20(�69   ���#DADADA$��Complete Payment��6\   $��Center=�6t   6�   � 5P      $��1��6   $��2��6'   $��Center=�64   $��Center=�6Q    5Q      �� 5R      $
��auto �6(   68   �� 5S      $
��auto �6(   68   .+�5U      �� $��Payment Date��6    ���#DADADA6K     5V      -   5        $ dp_PaymentDate��5V   !   $��1��69   $	��150��6F   $��30��6R   ���#DADADA$
��Left=�6s   6�   5W      �� 5X      -   5        $ btn_CompletePayment��5X      $��1��66   $��3��6F   $��center=�6S   ���#1D1D1D$��15(�6�   $��0q�6�   $	��175��6�   $��40��6�   .��6�   Complete Payment6�   5Y      5Z      5[      5\      