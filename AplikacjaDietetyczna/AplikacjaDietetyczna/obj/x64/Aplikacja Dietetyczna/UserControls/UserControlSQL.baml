   M S B A M L   `   `   `  ���� O  KAplikacjaDietetyczna, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:AplikacjaDietetyczna.UserControls!AplikacjaDietetyczna.UserControls  6    0AplikacjaDietetyczna.UserControls.UserControlSQL   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     Alocal/clr-namespace:AplikacjaDietetyczna.UserControls     c _MahApps.Metro.IconPacks.Core, Version=3.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Material, Version=3.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a?	iconPacks-http://metro.mahapps.com/winfx/xaml/iconpacks   X TXceed.Wpf.Toolkit, Version=3.8.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  -   .��� ���#7aa9f6.+��� -     ��Name$  ZapisaneSQL��$
��Left=�$��30��$��
958,46,0,0q�$	��Top=�$	��252�� �� SelectedIndex$ 0��.@��� 
 � Tag$� �SELECT ID_Produktu, Users.ID_User,NazwaProduktu, Kalorie, Bialka, Tluszcze, Weglowodany, Podanie, Zatwierdzone FROM Produkty INNER JOIN Users ON Produkty.ID_User = Users.ID_User WHERE Zatwierdzone=0��.��" Wyświetl zaproponowane produkty�� $ select * from Posilki��.��Wyświetl Posilki�� $ select * from Produkty��.��Wyświetl Produkty�� $ select * from Users��.��Wyświetl Użtkowników�� $� �INSERT INTO Produkty (Kalorie,Bialka,Tluszcze,Weglowodany,Podanie,NazwaProduktu,Zatwierdzone) VALUES ([int], [int], [int], [int],'[varchar(255)]','[varchar(255)]',1);��.��Dodaj Produkt�� $� �UPDATE Produkty SET Kalorie/Bialka/Tluszcze/Weglowodany/Podanie/NazwaProduktu/Zatwierdzone = [wartosc] WHERE ID_Produktu = [int];��.��Modyfikuj Produkt��  J� RenderTransformOrigin$ 0.501,0.556&�$��0,0,0,0q�.+���  �� Orientation$ 
Horizontal=�$��0,20,0,0q�.+�(  "Xceed.Wpf.Toolkit.WatermarkTextBox  -   $��Select��$��	Helvetica)�$����SELECT ID_Produktu, Users.ID_User,NazwaProduktu, Kalorie, Bialka, Tluszcze, Weglowodany, Podanie, Zatwierdzone FROM Produkty INNER JOIN Users ON Produkty.ID_User = Users.ID_User WHERE Zatwierdzone=0��$��20(�$��Light"�$��Center=�$
��Left=�
������ 
�������$��0q�$	��800�� J� Opacity$	 0.9Q�$��80��$��40,0,0,0q� �� AcceptsReturn .  �� TextWrapping$
 Wrap=��� -    ��Name$ 	policzBMI��$	��115��$��60��$��Wykonaj��$��25(�$��0,0,0,0q��� $
��1220��$��2��
�������$	 0.6Q�$��0,0,0,0q��� $ 
Horizontal=�$��0,20,0,0q�.+�&   System.Windows.Controls.DataGrid  -   $��SelectDataGrid��$��	Helvetica)�$��20(�$��Light"�$��Center=�$
��Left=�
������ 
���   �$��0q�$
��1220��$	��265��$��0,0,0,0q��� -   	 ��Name$	 txtMessages��$
��Wrap=�$�� ��$��20(�$��Light"�$��Center=�
������ 
���   �$
��1220��$��88��$��0,0,0,0q�� .+��� -   
 ��Name$
 DoZatwierdzeniaTekst��$��	Helvetica)�$��32(�$��Light"�$
��Left=�$
��Left=�
������ 
�������$��0q�$	��351��$	 0.8Q�$��Produkt do zatwierdzenia��$��
30,0,0,369q� �� 
IsReadOnly .   -     Name$ DoZatwierdzenia��$��	Helvetica)�$��40(�$��Light"�$��Center=�$
��Left=�
������ 
�������$��0q�$	��378��   	Watermark$ Przykładowo: 10��$��456,-10,386,9.2q��� -	   $ 	Zatwierdz��$	��115��$��60��$��	Zatwierdz��$��25(�$��801,-10,304,357.2q�