   M S B A M L   `   `   `  ����P  LShoolProgram_Anayatov, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:ShoolProgram_Anayatov.PagesShoolProgram_Anayatov.Pages  5      +    %ShoolProgram_Anayatov.Pages.PageTable   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;local)clr-namespace:ShoolProgram_Anayatov.Pages     5      -   5          N� Title$'  !Таблица Продуктов��5
      .��5      �  � RowDefinitions 5   
   �� 5      $	��41* �6   �� 5      $
��421* �6   .+�5   
   �� -   5        $��	TxbSearch��5      
�������$#��Поиск продуктов��5      $��5,0,0,0q�5      $	��120��5      $
��Left=�5      $��Center=�5      $��30��6/   �� 5   
   -   5        $��	BtnSearch��5      $��75��5      $��
Поиск��5      $��	130,0,0,0q�5      $
��Left=�5      $��Center=�5       
�������$��32��5"   )   �� 5$   
   -   5        $��BtnAdd��5&      $	��159��5$      $%��Добавить продукт��5%      $��	130,0,0,0q�5'      $��Right=�5(      $��Center=�5)      
�������$��32��5+   &   &   System.Windows.Controls.DataGrid  5.   
   -   5        $��DataGridProduct��50      $��1��5.      $��0,0,0,45q�5/         AutoGenerateColumns .     
IsReadOnly .    Columns 55      0  *System.Windows.Controls.DataGridTextColumn  56      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��58         Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 5:      1  +System.Windows.Controls.DataGridBoundColumn   Binding 59      �� *id+5:        5<      $ Продукты��5=      $ * 5?       5>      �� *NameProduct+5?        5A      $ Поставщик��5C      $ * 5E       5D      �� *Provider.Name+5E        5G      $ Тип продукта��5I      $ * 5K       5J      �� *TypeOfProduct.NameType+5K        5M      $ Количество��5O      $ * 5Q       5P      �� *PurchaseVolume+5Q        5S      $' !Единица измерения��5U      $ * 5W       5V      �� *Unit.NameUnit+5W        5Y      $ Цена��5[      $ * 5]       5\      �� *PurchasePrice+5]        5_      $ Статус��5a      $ * 5c       5b      �� *StatusProduct.NameStatus+5c      4  .System.Windows.Controls.DataGridTemplateColumn  5e      $	 120 6)      CellTemplate 5f      �� 5g      .R�5h      �� 	 �� Orientation$	 
Horizontal=�6)   .+�5j   "   �� $��BtnEditInfo��6)   -   5        
������ 
������ 
������ .��5o   &   �� $��./Resource/Gears.png��6,   5p   #   �� 5r   "   $��
BtnDelete1��6)   -   5        
������ 
������ $��X��5v   %   
���  ��5w   %   5y      5z      5|      5~      5      5�      