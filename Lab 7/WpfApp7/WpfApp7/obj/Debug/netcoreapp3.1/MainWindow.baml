   M S B A M L   `   `   `  ����B  >WpfApp7, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp7WpfApp7  5   	       WpfApp7.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp7     5   	   -   5          � Title$  
MainWindow��5   	   $	��600��6   $
��1000��6)   .��5	      � .+�5
   
   �� -   5        $��lvUsers��5
      $	��400��6"   $��25,10,575,174q�6/   $ �� IsSynchronizedWithCurrentItem$
 TrueY�6F   $	��400��6k    �� View 5      �� 5      .P�5      �� $��Imię��6%    �� Width$	 130��63    �� DisplayMemberBinding 6?   �� *name+�� 5      $��Nazwisko��6%   $	 130��67    6C   �� *
username+�� 5      $��ID��6%   $	 130��61    6=   �� *id+5      5      �� 5   
   -   5        $��Books��5      $	��400��6    $��576,10,24,174q�6-   $
 TrueY�6D   $	��400��6i    5      �� 5      .P�5      �� $��Tytuł��6%   $ 95��64    6?   �� *title+�� 5      $��Autor��6%   $ 95��64    6?   �� *autor+�� 5      $��ID��6%   $ 95��61    6<   �� *id+�� 5      $��Wypozyczona��6%   $ 95��6:    6E   �� *
borrowed+5      5      �� 5   
   -   5         ��Name$ wypozycz��5      $��	Wypożycz��6#   $��Center=�66   $��	0,129,0,0q�6S   $	��Top=�6f   $��20(�6~   $	��100��6�   6�   �� 5   
   -   5        $ oddaj��5      $��Oddaj��6    $��Center=�60   $��	0,198,0,0q�6M   $	��Top=�6`   $	��100��6x   $��20(�6�   6�   �� 5   
   -   5        $ dodaj_cz��5      $��Dodaj czytelnika��6#   $
��Left=�6>   $��100,471,0,0q�6Y   $	��Top=�6n   $��20(�6�   $	��200��6�   6�   �� 5    
   -   5        $ dodaj_ks��5       $��Dodaj książkę��6#   $
��Left=�6;   $��700,471,0,0q�6V   $	��Top=�6k   $	��200��6�   $��20(�6�   6�   5!      5"      