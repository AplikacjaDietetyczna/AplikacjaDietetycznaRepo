   M S B A M L   `   `   `  ����O  KAplikacjaDietetyczna, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:AplikacjaDietetyczna.UserControls!AplikacjaDietetyczna.UserControls  5      6    0AplikacjaDietetyczna.UserControls.UserControlSQL   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Alocal/clr-namespace:AplikacjaDietetyczna.UserControls     5      c _MahApps.Metro.IconPacks.Core, Version=3.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Material, Version=3.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a?	iconPacks-http://metro.mahapps.com/winfx/xaml/iconpacks   5      X TXceed.Wpf.Toolkit, Version=3.8.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  6N   -   5        .��5      � ���#7aa9f6.+�5   
   �� -   5          ��Name$  ZapisaneSQL��5      $
��Left=�6(   $��30��6C   $��
958,46,0,0q�6O   $	��Top=�6c   $	��252��6{    �� SelectedIndex$ 0��6�   .@�5      �� 
 � Tag$� �SELECT ID_Produktu, Users.ID_User,NazwaProduktu, Kalorie, Bialka, Tluszcze, Weglowodany, Podanie, Zatwierdzone FROM Produkty INNER JOIN Users ON Produkty.ID_User = Users.ID_User WHERE Zatwierdzone=0��6   .��6�   " Wyświetl zaproponowane produkty6	  �� 5      $ select * from Posilki��6   .��67   Wyświetl Posilki6I   �� 5      $ select * from Produkty��6   .��68   Wyświetl Produkty6K   �� 5      $ select * from Users��6   .��65   Wyświetl Użtkowników6K   �� 5      $� �INSERT INTO Produkty (Kalorie,Bialka,Tluszcze,Weglowodany,Podanie,NazwaProduktu,Zatwierdzone) VALUES ([int], [int], [int], [int],'[varchar(255)]','[varchar(255)]',1);��6   .��6�   Dodaj Produkt6�   �� 5      $� �UPDATE Produkty SET Kalorie/Bialka/Tluszcze/Weglowodany/Podanie/NazwaProduktu/Zatwierdzone = [wartosc] WHERE ID_Produktu = [int];��6   .��6�   Modyfikuj Produkt6�   5      �� 5   
    J� RenderTransformOrigin$ 0.501,0.556&�6   $��0,0,0,0q�69   .+�5      ��  �� Orientation$ 
Horizontal=�6   $��0,20,0,0q�62   .+�5!      (  "Xceed.Wpf.Toolkit.WatermarkTextBox  -   5        $��Select��5#      $��	Helvetica)�5!   (   $����SELECT ID_Produktu, Users.ID_User,NazwaProduktu, Kalorie, Bialka, Tluszcze, Weglowodany, Podanie, Zatwierdzone FROM Produkty INNER JOIN Users ON Produkty.ID_User = Users.ID_User WHERE Zatwierdzone=0��5"      $��20(�5$      $��Light"�5%      $��Center=�5&      $
��Left=�5'      
������ 
�������$��0q�5*      $	��800��5+       J� Opacity$	 0.9Q�5,      $��80��5-      $��40,0,0,0q�5.       �� AcceptsReturn .  �� TextWrapping$
 Wrap=�50      �� 51      -   5         ��Name$ 	policzBMI��51      $	��115��6,   $��60��68   $��Wykonaj��6D   $��25(�6V   $��0,0,0,0q�6d   6u   52      �� 55      $
��1220��6   $��2��56      
�������$	 0.6Q�58      $��0,0,0,0q�6'   �� 59      $ 
Horizontal=�6   $��0,20,0,0q�62   .+�5;      &   System.Windows.Controls.DataGrid  -   5        $��SelectDataGrid��5<      $��	Helvetica)�5;      $��20(�5=      $��Light"�5>      $��Center=�5?      $
��Left=�5@      
������ 
���   �$��0q�5C      $
��1220��5D      $	��265��5E      $��0,0,0,0q�5F      5J      �� 5L      -   5        	 ��Name$	 txtMessages��5L      $
��Wrap=�6-   $�� ��6A   $��20(�5M      $��Light"�5N      $��Center=�5O      
������ 
���   �$
��1220��5R      $��88��5S      $��0,0,0,0q�5T      � 5V      .+�5W      �� -   5        
 ��Name$
 DoZatwierdzeniaTekst��5X      $��	Helvetica)�5W      $��32(�5Y      $��Light"�5Z      $
��Left=�5[      $
��Left=�5\      
������ 
�������$��0q�5_      $	��351��5`      $	 0.8Q�5a      $��Produkt do zatwierdzenia��5b      $��
30,0,0,369q�6=    �� 
IsReadOnly . 5c        5e      -   5          Name$ DoZatwierdzenia��5g      $��	Helvetica)�5f      $��40(�5h      $��Light"�5i      $��Center=�5j      $
��Left=�5k      
������ 
�������$��0q�5n      $	��378��5o         	Watermark$ Przykładowo: 10��5p      $��456,-10,386,9.2q�6-   �� 5r      -	   5        $ 	Zatwierdz��5r      $	��115��6,   $��60��68   $��	Zatwierdz��6D   $��25(�6X   $��801,-10,304,357.2q�6f   6�   5s      5|      5}      5~      