   M S B A M L   `   `   `  ����O  KAplikacjaDietetyczna, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:AplikacjaDietetycznaAplikacjaDietetyczna  5   	   %    AplikacjaDietetyczna.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:AplikacjaDietetyczna     5   	   c _MahApps.Metro.IconPacks.Core, Version=3.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Material, Version=3.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a?	iconPacks-http://metro.mahapps.com/winfx/xaml/iconpacks   5   	   X TXceed.Wpf.Toolkit, Version=3.8.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	   -   5          � Title$  
MainWindow��5
   	   $	��450��6   $	��380��6)    � AllowsTransparency . 
������  � WindowStyle$
 None=�5   	    � 
ResizeMode$ NoResize=�6    � WindowStartupLocation$ CenterScreen=�5   &   .��5      � .+�5   
   �  � RowDefinitions 5      �� 5      �� 5      .+�5      ��  �� CornerRadius$ 10��6   $��2��6'   $	��450��68   $��
0,0,0,-0.4q�6E   $��Bottom=�6Y   ��5      �� 5      .��5      �  � Color$ #7be9f6��6'    � Offset$	 0.0Q�67   � 5      $ #1225ff��6'   $	 1.5Q�67   5      5      �� 5!      $��Center=�6   .+�5"      .  (MahApps.Metro.IconPacks.PackIconMaterial  	   Kind$
	 Food=�6-   $��Center=�5#   "   $��Center=�5$   "   
�������$��80��5%   5   $��80��5&   "   �� 5'      $��Aplikacja Dietetyczna��6   $��Light"�69   $��	helvetica)�5(      $��22(�63   
�������$��Center=�5)      5+      �� 5/      $��1��6   .+�50      �� 
 �� Orientation$
 
Horizontal=�6   .+�52      (  "Xceed.Wpf.Toolkit.WatermarkTextBox  -   5        $��TextBoxUser��54      $��	Helvetica)�52   ,      	Watermark$ Nazwa użytkownika��53      $��20(�55      $��Light"�56      $��Center=�57      $
��Left=�58      
������ 
�������$�� ��5;      $��0q�5<      $	��235��5=       J� Opacity$	 0.5Q�5>      $��25��5@      $��63,0,0,0q�5A        5C      $	 Account=�61   $��Center=�5D   "   $��Center=�5E   "   
�������5F   "   5H      �� 5J      $	��250��6   $��2��5K      
�������$	 0.6Q�5M      �� 5P      $
 
Horizontal=�6   $��0,20,0,0q�66   .+�5R      ,  &Xceed.Wpf.Toolkit.WatermarkPasswordBox  -   5        $��TextBoxPassword��5T      $��	Helvetica)�5R   0   $ ●●●●●●●●��5S      $��20(�5U      $��Light"�5V      $��Center=�5W      $
��Left=�5X      
������ 
�������$��0q�5[      $	��235��5\      $	 0.5Q�5]      $��25��5^      $��63,0,0,0q�5_        5a      $
	 Lock=�61   $��Center=�5b   "   $��Center=�5c   "   
�������5d   "   5f      �� 5h      $	��250��6   $��2��5i      
�������$	 0.6Q�5k      �� 5o      $
 
Horizontal=�6   $��0,25,0,0q�66   .+�5p      �� -   5        $	��100��5p      $��40��6)   $��Center=�65   $��Zaloguj��6P   $��	140,0,0,0q�6b   6u   5s      �� 5t      $
 
Horizontal=�6   $��0,10,0,0q�66   .+�5x      �� -   5        $	��100��5x      $��40��6)   $��Rejestracja��65   $��	20,0,30,0q�6K   6^   5z      5~      5�      5�      5�      