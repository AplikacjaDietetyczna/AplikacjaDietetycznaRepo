   M S B A M L   `   `   `  ���� O  KAplikacjaDietetyczna, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:AplikacjaDietetyczna.UserControls!AplikacjaDietetyczna.UserControls  >    8AplikacjaDietetyczna.UserControls.UserControlKalkulkator   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     Alocal/clr-namespace:AplikacjaDietetyczna.UserControls     c _MahApps.Metro.IconPacks.Core, Version=3.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Material, Version=3.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a?	iconPacks-http://metro.mahapps.com/winfx/xaml/iconpacks   X TXceed.Wpf.Toolkit, Version=3.8.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  .��� ���#7aa9f6.+��� $��Center=�$	��185��$��
0,27,0,428q�.+��� $��Kalkulator BMI��$��Light"�$��	hervetica)�$��66(�
�������$��Center=�$	��115��$��200,0,312,0q�$	��418����   J� RenderTransformOrigin$  0.501,0.556&�$��	0,193,0,0q�.+���  �� Orientation$ 
Horizontal=�$��0,20,0,0q�.+�(  "Xceed.Wpf.Toolkit.WatermarkTextBox  -   $��wzrost��$��	Helvetica)�   	Watermark$ Podaj wzrost (Cm)��$��20(�$��Light"�$��Center=�$
��Left=�
������ 
�������$��0q�$	��235�� J� Opacity$	 0.9Q�$��30��$��40,0,0,0q�.  (MahApps.Metro.IconPacks.PackIconMaterial     Kind$ HumanMaleHeight=�$��Center=�$��Center=�
��������� -    ��Name$ 	niedowaga��$��	Helvetica)�$��Niedowaga: poniżej 18,5��$��20(�$��Light"�$��Center=�$
��Left=�
������ 
�������$��0q�$	��235��$	 0.9Q�$��30��$��	400,0,0,0q� �� 
IsReadOnly . �� $	��250��$��2��
�������$	 0.6Q�$��
-885,0,0,0q��� $ 
Horizontal=�$��0,20,0,0q�.+�  -   $
��waga��$��	Helvetica)�$ Podaj wagę (kg)��$��20(�$��Light"�$��Center=�$
��Left=�
������ 
�������$��0q�$	��235��$	 0.9Q�$��30��$��40,0,0,0q�  $ Weight=�$��Center=�$��Center=�
��������� -   $ norma��$��	Helvetica)�$��Norma: 18,5 - 24,9��$��20(�$��Light"�$��Center=�$
��Left=�
������ 
�������$��0q�$	��235��$	 0.9Q�$��30��$��	400,0,0,0q� . �� $	��250��$��2��
�������$	 0.6Q�$��
-885,0,0,0q��� $ 
Horizontal=�$��0,20,0,0q�.+��� $��	Helvetica)�$��Płeć��$��20(�$��Light"�$��Center=�$
��Left=�
������ 
�������$��0q�$	��235��$	 0.9Q�$��30��$��40,0,0,0q� .   $ GenderMaleFemale=�$��Center=�$��Center=�
��������� -   $ nadwaga��$��	Helvetica)�$��Nadwaga: 25,0 - 19,9��$��20(�$��Light"�$��Center=�$
��Left=�
������ 
�������$��0q�$	��235��$	 0.9Q�$��30��$��	400,0,0,0q� . �� $	��250��$��2��
�������$	 0.6Q�$��
-885,0,0,0q��� $ 
Horizontal=�$��0,20,0,0q�.+��� -   $ 	poleError��$��	Helvetica)�$�� ��$��15(�$��Light"�$��Center=�$
��Left=�
������ 
���  ��$��0q�$	��235��$	 0.9Q�$��30��$��40,0,0,0q� . �� -   $ otyloscI��$��	Helvetica)�$��Otyłość I: 30,0 - 34,9��$��20(�$��Light"�$��Center=�$
��Left=�
������ 
�������$��0q�$	��235��$	 0.9Q�$��30��$��	416,0,0,0q� . �� $ 
Horizontal=�$��0,20,0,0q�.+��� -   $ 	otyloscII��$��	Helvetica)�$ ��Otyłość II: powyżej 35��$��20(�$��Light"�$��Center=�$
��Left=�
������ 
�������$��0q�$	��235��$	 0.9Q�$��30��$��	693,0,0,0q� . �� $ 
Horizontal=�$��0,40,0,0q�.+��� -	   $ wynik��$��	Helvetica)�$��Wynik��$��20(�$��Light"�$��Center=�$
��Left=�
������ 
�������$��0q�$	��235��$	 0.9Q�$��30��$��40,0,0,0q� .   $ Equal=�$��Center=�$��Center=�
��������� $	��250��$��2��
�������$	 0.6Q�$��
-885,0,0,0q��� $ 
Horizontal=�$��	0,-10,0,0q�$��50���� $ 
Horizontal=�$��0,10,0,0q�$��69��$  0.502,0.232&�.+��� -
    ��Name$ 	policzBMI��$	��160��$��55��$��
Policz BMI��$��25(�$��
300,0,30,0q��� -   $ pobierzDane��$	��250��$��55��$��Pobierz dane z profilu��$��25(�$��
-700,0,0,0q�	� -   $��PlecMezczyzna�� 	� 	GroupName$
 Plec��$��Mężczyzna��$	 0.9Q�$��13(�$��Light"�$
��Left=�
�������
�������$��0q�$��
90,322,0,0q�$��1��$	��Top=�	 d� 	IsChecked$
	 TrueY�	� -   $��PlecKobieta��$
 Plec��$��Kobieta��$	 0.9Q�$��13(�$��Light"�$
��Left=�
�������
�������$��0q�$��180,322,0,0q�$��1��$	��Top=�