   M S B A M L   `   `   `  ����H  Dphonebook app, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:phonebook_appphonebook_app  5   	        phonebook_app.searchWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:phonebook_app     5   	     � Title$  searchWindow��5   	   $	��300��6   $��426.667��6+   .��5	      � $��0,0,-8,0q�6    � ColumnDefinitions 5
   
   �� 5      $
��419* �6   �� 5      $��0* �6   �� 5      $��8* �6   .+�5   
   �� -   5         ��Name$ lNameBox��5      $
��Left=�6$   $��23��6?    �� TextWrapping$
 Wrap=�6K   $��	Last Name��6_   $	��Top=�6p   $	��120��6�   $��	19,32,0,0q�6�   �� 5   
   -   5         ��Name$ Search��5      $��Search��6!   $
��Left=�62   $��
334,27,0,0q�6M   $	��Top=�6a   $��75��6y   $��22��6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ 	dataGrid1��5      $
��Left=�6&   $	��160��6A   $��	19,94,0,0q�6N   $	��Top=�6a   $	��377��6y   �� 5   
   -   5         ��Name$ Label��5      $��Search For Contact��6   $
��Left=�6<   $��10,5,0,0q�6W   $	��Top=�6i   $��26��6�   $	��110��6�   �� 5   
   -   5        $ popbtn��5      $��View All��6!   $
��Left=�64   $��
334,54,0,0q�6O   $	��Top=�6c   $��75��6{   $��22��6�   �� 5   
   -   5        $ fNameBox��5      $
��Left=�6$   $��23��6?   $��	19,62,0,0q�6K   $
 Wrap=�6^   $��
First Name��6r   $	��Top=�6�   $	��120��6�   �� 5   
   -   5        $ posBox��5      $
��Left=�6"   $��23��6=   $��
144,32,0,0q�6I   $
 Wrap=�6]   $��Position��6q   $	��Top=�6�   $	��120��6�   �� 5   
   -   5        $ label��5      $'��!- Fill in one of the fields below��6   $
��Left=�6K   $��	112,8,0,0q�6f   $	��Top=�6y   $��9.333(�6�   5      5      