   M S B A M L   `   `   `  ����I  ETennisclub.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:Tennisclub.WPF.GameResultsTennisclub.WPF.GameResults  5      0    *Tennisclub.WPF.GameResults.GameResultsPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:Tennisclub.WPF.GameResults     5        N� Title$  GameResultsPage��5	      .��5      �  � ColumnDefinitions 5   
   �� 5      $��20 �6   6,   �� 5      $��* �6   6+   �� 5      $
��0.5* �6   6.   �� 5      $��20 �6   6,    � RowDefinitions 5   
   �� 5      $��20 �6   6*   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $��* �6   6)   �� 5      $��20 �6   6*   .+�5   
   �� $��1��6   $��1��6"    �� Orientation$ 
Horizontal=�62   .+�5      �� $��30(�6   ���#DADADA$��Game Results��6;   6Q   �� 5      -   5         ��Name$ tb_TitleMember��5      $��20(�60   ���#DADADA$��Bottom=�6S   $��5 0 0 2q�6n   6�   5      � 5   
   $��1��6   $��2��6   $
��auto��6,   .+�5      �� $ 
Horizontal=�6   $��	0,10,0,10q�62   ���#1D1D1D$
��auto��6Z   .+�5       � $��Bottom=�6   $��	20 5 0 10q�62    5!      �� 5"      $
��auto �6(   68   �� 5#      $
��auto �6(   68   .+�5%      �� $
��Date��6    ���#DADADA6C   (  "System.Windows.Controls.DatePicker  5&      -   5          Name$ dp_DateFilter��5&   !   $��1��68   $	��150��6E   $��30��6Q   ���#DADADA$
��Left=�6r   6�   5'      �� 5)      -   5         ��Name$ 
btn_Filter��5)      
������ $��0q�6F   $��
10 10 10 0q�6Z   .��6�   Filter6�   �� 5*      -   5        $ btn_ClearFilter��5*      
������ $��0q�6K   $��0 10 0 0q�6_   .��6�   Clear Filter6�   5+      5,      &   System.Windows.Controls.DataGrid  5/   
   -   5          Name$ resultsDataGrid��5/      $��3��6,   $��1��69      
IsReadOnly$
 True��6I   	   ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$	 * 6[   
   HeadersVisibility$
 Column=�6k   $��10(�6�      AutoGenerateColumns$ False��50         CanUserAddRows$ False��60      SelectionMode$ Single=�6G      GridLinesVisibility$
 None=�6^      Columns 51      0  *System.Windows.Controls.DataGridTextColumn  52      ,  &System.Windows.Controls.DataGridColumn   Header$ GameNr��6%      Width$
 0.5* 6Y   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   �� *Game.GameNumber+6Y     53      $ League��6%   $
 0.7* 6Z    65   �� *Game.League.Name+6Z     54      $
 Date��6%   $
 0.7* 6n    63   �� *	Game.Date+ �� StringFormat$ {0:dd/MM/yy}��6n     55      $ SetNr��6%   $
 0.7* 6N    64   �� *SetNr+6N     56      $ Score Team Member��6%   $ * 6d    6@   �� *ScoreTeamMember+6d     57      $ Score Opponent��6%   $ * 6_    6=   �� *ScoreOpponent+6_   59      � 5;   
   $��2��6   $��2��6   $��2��6,   $��0 10 0 0q�6=    5<      �� 5=      $
��auto �6    �� 5>      $��* �6    .+�5@      � -   5         �Name$ EditGameResultMenu��5@      $��2��6/   $��2��6<   $y�Visible=�6L   ���#1D1D1D$��10 0 0 0q�6v    5A      �� 5B      $��20 �6'   64   �� 5C      $��* �6'   63   �� 5D      $��20 �6'   64    5F      �� 5G      $��20 �6$   62   �� 5H      $
��auto �6$   64   �� 5I      $��* �6$   61   �� 5J      $��* �6$   61   �� 5K      $��* �6$   61   �� 5L      $��0.33* �6$   65   �� 5M      $��20 �6$   62   .+�5O      �� $��1��6   $��1��6)   $��20(�69   ���#DADADA$��Edit a Result��6\   $��Center=�6q   6�   � 5Q      $��1��6   $��2��6'   $��Center=�64   $��Center=�6Q    5R      �� 5S      $
��auto �6(   68   �� 5T      $
��auto �6(   68   .+�5V      �� $��
Set Number��6    ���#DADADA6I   �� 5W      -   5         ��Name$ tb_SetNrEdit��5W      $��1��64   $	��150��6A   $��30��6M   ���#DADADA6�   5X      � 5Z      $��1��6   $��3��6'   $��Center=�64   $��Center=�6Q    5[      �� 5\      $
��auto �6(   68   �� 5]      $
��auto �6(   68   .+�5_      �� $��Score Teammate��6    ���#DADADA6M   �� 5`      -   5        $ tb_ScoreTeammateEdit��5`      $��1��6<   $	��150��6I   $��30��6U   ���#DADADA6�   5a      � 5c      $��1��6   $��4��6'   $��Center=�64   $��Center=�6Q    5d      �� 5e      $
��auto �6(   68   �� 5f      $
��auto �6(   68   .+�5h      �� $��Score Opponent��6    ���#DADADA6M   �� 5i      -	   5        $ tb_ScoreOpponentEdit��5i      $��1��6<   $	��150��6I   $��30��6U   ���#DADADA6�   5j      �� 5k      -
   5        $ btn_EditGameResult��5k      $��1��65   $��5��6E   $��center=�6R   ���#1D1D1D$��15(�6�   $��0q�6�   $	��175��6�   $��40��6�   .��6�   Edit a Result6�   5l      5m      5n      5o      