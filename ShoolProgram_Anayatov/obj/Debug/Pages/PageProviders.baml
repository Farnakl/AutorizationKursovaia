   M S B A M L   `   `   `  ����P  LShoolProgram_Anayatov, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:ShoolProgram_Anayatov.PagesShoolProgram_Anayatov.Pages  5      /    )ShoolProgram_Anayatov.Pages.PageProviders   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;local)clr-namespace:ShoolProgram_Anayatov.Pages     5        N� Title$+  %Таблица поставщиков��5	      .��5      �  � RowDefinitions 5   
   �� 5      $	��41* �6   �� 5      $
��421* �6   .+�5   
   �� -   5        $��	TxbSearch��5      
�������$'��!Поиск поставщиков��5      $��5,0,0,0q�5      $	��120��5      $
��Left=�5      $��Center=�5      $��30��6/   �� 5   
   -   5        $��	BtnSearch��5      $��75��5      $��
Поиск��5      $��	130,0,0,0q�5      
�������$
��Left=�5      $��Center=�5       $��32��5!   )   �� 5#   
   -   5        $��BtnAdd��5%      $	��178��5#      $+��%Добавить поставщика��5$      
�������$��	130,0,0,0q�5'      $��Right=�5(      $��Center=�5)      $��32��5*   &   &   System.Windows.Controls.DataGrid  5,   
   -   5        $��DataGridProviders��5.      $��0,0,0,45q�5-         AutoGenerateColumns .     
IsReadOnly . $��1��50   '      Columns 53      0  *System.Windows.Controls.DataGridTextColumn  54      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��56         Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 58      1  +System.Windows.Controls.DataGridBoundColumn   Binding 57      �� *id+58        5:      $- 'Название предприятия��5;      $ * 5=       5<      �� *Name+5=        5?      $ 
Адрес��5A      $ * 5C       5B      �� *	Address+5C        5E      $ Телефон��5G      $ * 5I       5H      �� *	Telephone+5I        5K      $' !Статус поставщика��5M      $ * 5O       5N      �� *StatusProvider.Name+5O      4  .System.Windows.Controls.DataGridTemplateColumn  5Q      $	 115 6)      CellTemplate 5R      �� 5S      .R�5T      �� 	 �� Orientation$	 
Horizontal=�6)   .+�5V   "   �� $��BtnShowInfoProviders��6)   -   5        $	��...��5Y   %   
������ 
������ 
�������5\   %   �� 5_   "   $��BtnEditInfo��6)   -   5        
������ 
������ 
������ .��5e   &   �� $��./Resource/Gears.png��6,   5f   #   5h      5i      5k        5m      $ 75 6)    5n      �� 5o      .R�5p      �� .+�5q   "   �� $��	BtnDelete��6)   -   5        
������ 
������ $��X��5u   %   $
��Left=�5v   %   
���  ��5w   %   5y      5z      5|      5~      5      5�      