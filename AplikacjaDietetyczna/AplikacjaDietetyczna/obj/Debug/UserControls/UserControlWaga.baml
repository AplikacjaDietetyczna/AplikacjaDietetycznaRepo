   M S B A M L   `   `   `  ����O  KAplikacjaDietetyczna, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:AplikacjaDietetyczna.UserControls!AplikacjaDietetyczna.UserControls  5      7    1AplikacjaDietetyczna.UserControls.UserControlWaga   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Alocal/clr-namespace:AplikacjaDietetyczna.UserControls     5      c _MahApps.Metro.IconPacks.Core, Version=3.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Material, Version=3.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a?	iconPacks-http://metro.mahapps.com/winfx/xaml/iconpacks   5      X TXceed.Wpf.Toolkit, Version=3.8.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5      .��5      � -   5          �Name$  GridMain��5      ���#7aa9f6.+�5   
   �� .+�5      �� -   5         ��Name$
 Waga��5      $��	Helvetica)�5      $��50(�5      $��Light"�5      $
��Left=�5      
������ 
�������$��0q�5       J� Opacity$	 0.8Q�5      $��Aktualizacja Wagi��5       �� 
IsReadOnly . $
��Left=�5   #   $	��400��6>   $��120,150,0,0q�5      �� 5      -   5        $ Nazwa1��5      $��	Helvetica)�5      $��30(�5       $��Light"�5!      $
��Left=�5"      
������ 
�������$��0q�5%      $	 0.8Q�5&      $��Nowa waga(w kg):��5'       . $
��Left=�5(   #   $	��240��6>   $��
170,60,0,0q�5)      (  "Xceed.Wpf.Toolkit.WatermarkTextBox  5,      -   5          Name$ TextBoxWaga��5.      $��	Helvetica)�5-      $��30(�5/      $��Light"�50      $
��Left=�51      $
��Left=�52      
������ 
�������$��0q�55      $	��256��56         	Watermark$ Przykładowo: 45��57      $��
170,10,0,0q�58       J� RenderTransformOrigin$ 0.193,0.564&�6%   �� 5;      -   5        $��Light"�5<      $��25(�5=      
�������$��60��5>   $   $��Zmiana Wagi��5?      $��
200,20,0,0q�5A      $
��Left=�6%   $	��200��6@   �� 5D      -   5        $��Light"�5E      $��25(�5F      
�������$��60��5G   $   $��Wróć��5H      $��
235,20,0,0q�5J      $
��Left=�6%   $	��130��6@   5L      �� 5M   
   .+�5N      �� $��	Helvetica)�5O      $��30(�5P      $��Light"�5Q      $
��Left=�5R      
������ 
�������$��0q�5U      $	 0.8Q�5V      $��Historia ważenia��5W       . $
��Left=�5X   #   $	��240��6>   $��730,100,0,0q�5Y      &   System.Windows.Controls.DataGrid  5[      -   5          Name$ HistoriaWagDataGrid��5\      $��	Helvetica)�5[      $��20(�5]      $��Light"�5^      
������ 
���   �$��0q�5a      $	��500��5b      $��600,40,120,188q�5c      $	��380��6)   5e      5f      5g      