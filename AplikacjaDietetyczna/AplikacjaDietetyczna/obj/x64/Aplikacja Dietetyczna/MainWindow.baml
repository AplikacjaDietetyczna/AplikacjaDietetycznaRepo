   M S B A M L   `   `   `  ���� O  KAplikacjaDietetyczna, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:AplikacjaDietetycznaAplikacjaDietetyczna  %    AplikacjaDietetyczna.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     4local"clr-namespace:AplikacjaDietetyczna     c _MahApps.Metro.IconPacks.Core, Version=3.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Material, Version=3.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a?	iconPacks-http://metro.mahapps.com/winfx/xaml/iconpacks   X TXceed.Wpf.Toolkit, Version=3.8.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  -     � Title$  
MainWindow��$	��450��$	��380�� � AllowsTransparency . 
������  � WindowStyle$
 None=� � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterScreen=�.��� .+��  � RowDefinitions �� �� .+���  �� CornerRadius$ 10��$��2��$	��450��$��
0,0,0,-0.4q�$��Bottom=����� .���  � Color$ #7be9f6�� � Offset$	 0.0Q�� $ #1225ff��$	 1.5Q��� $��Center=�.+�.  (MahApps.Metro.IconPacks.PackIconMaterial  	   Kind$
	 Food=�$��Center=�$��Center=�
�������$��80��$��80���� $��Aplikacja Dietetyczna��$��Light"�$��	helvetica)�$��22(�
�������$��Center=��� $��1��.+��� 
 �� Orientation$
 
Horizontal=�.+�(  "Xceed.Wpf.Toolkit.WatermarkTextBox  -   $��TextBoxUser��$��	Helvetica)�   	Watermark$ Nazwa użytkownika��$��20(�$��Light"�$��Center=�$
��Left=�
������ 
�������$�� ��$��0q�$	��235�� J� Opacity$	 0.5Q�$��25��$��63,0,0,0q�  $	 Account=�$��Center=�$��Center=�
��������� $	��250��$��2��
�������$	 0.6Q��� $
 
Horizontal=�$��0,20,0,0q�.+�,  &Xceed.Wpf.Toolkit.WatermarkPasswordBox  -   $��TextBoxPassword��$��	Helvetica)�$ ●●●●●●●●��$��20(�$��Light"�$��Center=�$
��Left=�
������ 
�������$��0q�$	��235��$	 0.5Q�$��25��$��63,0,0,0q�  $
	 Lock=�$��Center=�$��Center=�
��������� $	��250��$��2��
�������$	 0.6Q��� $
 
Horizontal=�$��0,25,0,0q�.+��� -   $	��100��$��40��$��Center=�$��Zaloguj��$��	140,0,0,0q��� $
 
Horizontal=�$��0,10,0,0q�.+��� -   $	��100��$��40��$��Rejestracja��$��	20,0,30,0q�