   M S B A M L   `   `   `  ���� O  KAplikacjaDietetyczna, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:AplikacjaDietetycznaAplikacjaDietetyczna  &     AplikacjaDietetyczna.Rejestracja   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     4local"clr-namespace:AplikacjaDietetyczna     c _MahApps.Metro.IconPacks.Core, Version=3.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Material, Version=3.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a?	iconPacks-http://metro.mahapps.com/winfx/xaml/iconpacks   X TXceed.Wpf.Toolkit, Version=3.8.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  -     � Title$  
MainWindow��$	��650��$	��380�� � AllowsTransparency . 
������  � WindowStyle$
 None=� � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterScreen=�.��� .+��  � RowDefinitions �� $
��159* ��� $
��491* �.+���  �� CornerRadius$ 10��$��2��$	��650��$��Bottom=����� .���  � Color$ #7be9f6�� � Offset$	 0.0Q�� $ #1225ff��$	 1.5Q��� $��Center=�$	��106��$��	0,28,0,25q�.+�.  (MahApps.Metro.IconPacks.PackIconMaterial  	   Kind$
	 Food=�$��Center=�$��Center=�
�������$��80��$��80���� $��Rejestracja��$��Light"�$��	helvetica)�$��22(�
�������$��Center=��� $��1��.+��� 
 �� Orientation$
 
Horizontal=�.+�(  "Xceed.Wpf.Toolkit.WatermarkTextBox  -   $��TextBoxUser��$��	Helvetica)�   	Watermark$ Podaj login��$��20(�$��Light"�$��Center=�$
��Left=�
������ 
�������$��0q�$	��235�� J� Opacity$	 0.9Q�$�� ��$��30��$��63,0,0,0q�  $	 Account=�$��Center=�$��Center=�
��������� $	��250��$��2��
�������$	 0.6Q��� $
 
Horizontal=�$��0,20,0,0q�.+�,  &Xceed.Wpf.Toolkit.WatermarkPasswordBox  -   $��TextBoxPassword��$��	Helvetica)�$ Podaj hasło��$��20(�$��Light"�$��Center=�$
��Left=�
������ 
�������$��0q�$	��235��$	 0.9Q�   Password$  ��$��30��$��63,0,0,0q�  $
	 Lock=�$��Center=�$��Center=�
��������� $	��250��$��2��
�������$	 0.6Q��� $
 
Horizontal=�$��0,20,0,0q�.+�  -   $��TextBoxPassword2��$��	Helvetica)�$ Powtórz hasło��$��20(�$��Light"�$��Center=�$
��Left=�
������ 
�������$��0q�$	��235��$	 0.9Q�$  ��$��30��$��63,0,0,0q�  $
	 Lock=�$��Center=�$��Center=�
��������� $	��250��$��2��
�������$	 0.6Q��� $
 
Horizontal=�$��0,20,0,0q�.+�  -   $��EMail��$��	Helvetica)�$ Podaj e-mail��$��20(�$��Light"�$��Center=�$
��Left=�
������ 
�������$��0q�$	��235��$	 0.9Q�$��30��$��63,0,0,0q�  $	 Email=�$��Center=�$��Center=�
��������� $	��250��$��2��
�������$	 0.6Q��� $
 
Horizontal=�$��0,20,0,0q�.+�  -   $
��Wiek��$��	Helvetica)�$ 
Podaj wiek��$��20(�$��Light"�$��Center=�$
��Left=�
������ 
�������$��0q�$	��235��$	 0.9Q�$��30��$��63,0,0,0q�  $	 BabyCarriage=�$��Center=�$��Center=�
��������� $	��250��$��2��
�������$	 0.6Q��� $
 
Horizontal=�$��0,20,0,0q�.+�  -   $��Wzrost��$��	Helvetica)�$ Podaj wzrost (cm)��$��20(�$��Light"�$��Center=�$
��Left=�
������ 
�������$��0q�$	��235��$	 0.9Q�$��30��$��63,0,0,0q�  $	 HumanMaleHeight=�$��Center=�$��Center=�
��������� $	��250��$��2��
�������$	 0.6Q��� $
 
Horizontal=�$��0,20,0,0q�.+�  -   $
��Waga��$��	Helvetica)�$ Podaj wagę (kg)��$��20(�$��Light"�$��Center=�$
��Left=�
������ 
�������$��0q�$	��235��$	 0.9Q�$��30��$��63,0,0,0q�  $	 Weight=�$��Center=�$��Center=�
��������� $	��250��$��2��
�������$	 0.6Q��� $
 
Horizontal=�$��0,20,0,0q�.+��� $��	Helvetica)�$��Płeć��$��20(�$��Light"�$��Center=�$
��Left=�
������ 
�������$��0q�$	��235��$	 0.9Q�$��30��$��63,0,0,0q� �� 
IsReadOnly .   $	 GenderMaleFemale=�$��Center=�$��Center=�
��������� $	��250��$��2��
�������$	 0.6Q��� $
 
Horizontal=�$��0,10,0,0q��� $
 
Horizontal=�$��0,10,0,0q�.+��� -	   $��Anuluj��$	��100��$��40��$��Anuluj��$��	20,0,30,0q��� -
   $��Zarejestruj��$	��100��$��40��$��Zarejestruj��$��
100,0,30,0q�	� -   $��PlecMezczyzna�� 	� 	GroupName$
 Plec��$��Mężczyzna��$	 0.9Q�$��13(�$��Light"�$
��Left=�
�������
�������$��0q�$��115,369.8,0,0q�$��1��$	��Top=� d� 	IsChecked$
 TrueY�	� -   $��PlecKobieta��$
 Plec��$��Kobieta��$	 0.9Q�$��13(�$��Light"�$
��Left=�
�������
�������$��0q�$��212,369.8,0,0q�$��1��$	��Top=�