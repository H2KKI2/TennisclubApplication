   M S B A M L   `   `   `  ����I  ETennisclub.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:Tennisclub.WPF.MemberRolesTennisclub.WPF.MemberRoles  5      4    .Tennisclub.WPF.MemberRoles.MemberWithRolesPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:Tennisclub.WPF.MemberRoles     5        N� Title$  MemberWithRolesPage��5	      .��5      �  � ColumnDefinitions 5   
   �� 5      $��20 �6   6,   �� 5      $��* �6   6+   �� 5      $
��0.5* �6   6.   �� 5      $��20 �6   6,    � RowDefinitions 5   
   �� 5      $��20 �6   6*   �� 5      $
��auto �6   6,   �� 5      $��* �6   6)   �� 5      $��20 �6   6*   .+�5   
   �� $��1��6   $��1��6"   $��2��62    �� Orientation$ 
Horizontal=�6F   .+�5      �� $��30(�6   ���#DADADA$��Members with Role(s):��6;   6Z   �� 5      -   5         ��Name$ tb_TitleRoles��5      $��20(�6/   ���#DADADA$��Bottom=�6R   $��5 0 0 2q�6m   6�   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ MembersDataGrid��5      $��2��6,   $��1��69      
IsReadOnly$
 True��6I      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6[      HeadersVisibility$ Column=�6k   $��10(�6�   	   AutoGenerateColumns$	 False��5      
   CanUserAddRows$
 False��60      SelectionMode$ Single=�6G      GridLinesVisibility$
 None=�6^      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5       ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6%      Width$ 0.50* 6O   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *	Member.Id+6O     5!      $ FederationNr��6%   $
 0.6* 6c    6;   �� *Member.FederationNr+6c     5"      $ 
First Name��6%   $ * 6^    69   �� *Member.FirstName+6^     5#      $ 	Last Name��6%   $ * 6\    68   �� *Member.LastName+6\     5$      $
 Role��6%   $ * 6Q    63   �� *	Role.Name+6Q     5%      $ 
Start Date��6%   $ * 6t    69   �� *	StartDate+ �� StringFormat$ {0:dd/MM/yy}��6t     5&      $ End Date��6%   $ * 6p    67   �� *	EndDate+$ {0:dd/MM/yy}��6p   5(      � 5*   
   $��2��6   $��2��6    5+      �� 5,      $
��auto �6    60   �� 5-      $��* �6    6-   .+�50      � -   5         �Name$ RemoveRoleMenu��50      $��2��6+   $��2��68   ���#1D1D1D$��10 0 0 0q�6]    51      �� 52      $��20 �6'   64   �� 53      $��* �6'   63   �� 54      $��20 �6'   64    56      �� 57      $��20 �6$   62   �� 58      $
��auto �6$   64   �� 59      $��* �6$   61   �� 5:      $��0.33* �6$   65   �� 5;      $��20 �6$   62   .+�5=      �� $��1��6   $��1��6)   $��20(�69   ���#DADADA$��Remove role of member��6\   $��Center=�6y   6�   � 5>      $��1��6   $��2��6'   $��Center=�64   $��Center=�6Q    5?      �� 5@      $
��auto �6(   68   �� 5A      $
��auto �6(   68   .+�5C      �� $��End Date��6    ���#DADADA6G   (  "System.Windows.Controls.DatePicker  5D      -   5          Name$ 
dp_EndDate��5D   !   $��1��65   $	��150��6B   $��30��6N   ���#DADADA$
��Left=�6o   6�   5E      �� 5F      -   5         ��Name$ btn_RemoveSelectedRole��5F      $��1��69   $��3��6I   $��center=�6V   ���#1D1D1D$��15(�6�   $��0q�6�   $	��150��6�   $��40��6�   .��6�   Remove role6�   5G      5H      5I      5J      