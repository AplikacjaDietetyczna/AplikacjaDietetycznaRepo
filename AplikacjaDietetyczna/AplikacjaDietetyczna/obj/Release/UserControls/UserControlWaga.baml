   M S B A M L   `   `   `  ���� O  KAplikacjaDietetyczna, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:AplikacjaDietetyczna.UserControls!AplikacjaDietetyczna.UserControls  7    1AplikacjaDietetyczna.UserControls.UserControlWaga   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     Alocal/clr-namespace:AplikacjaDietetyczna.UserControls     c _MahApps.Metro.IconPacks.Core, Version=3.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Material, Version=3.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a?	iconPacks-http://metro.mahapps.com/winfx/xaml/iconpacks   X TXceed.Wpf.Toolkit, Version=3.8.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  .��� -     �Name$  GridMain�����#7aa9f6.+��� .+��� -    ��Name$
 Waga��$��	Helvetica)�$��50(�$��Light"�$
��Left=�
������ 
�������$��0q� J� Opacity$	 0.8Q�$��Aktualizacja Wagi�� �� 
IsReadOnly . $
��Left=�$	��400��$��120,150,0,0q��� -   $ Nazwa1��$��	Helvetica)�$��30(�$��Light"�$
��Left=�
������ 
�������$��0q�$	 0.8Q�$��Nowa waga(w kg):�� . $
��Left=�$	��240��$��
170,60,0,0q�(  "Xceed.Wpf.Toolkit.WatermarkTextBox  -     Name$ TextBoxWaga��$��	Helvetica)�$��30(�$��Light"�$
��Left=�$
��Left=�
������ 
�������$��0q�$	��256��   	Watermark$ Przykładowo: 45��$��
170,10,0,0q� J� RenderTransformOrigin$ 0.193,0.564&��� -   $��Light"�$��25(�
�������$��60��$��Zmiana Wagi��$��
200,20,0,0q�$
��Left=�$	��200���� -   $��Light"�$��25(�
�������$��60��$��Wróć��$��
235,20,0,0q�$
��Left=�$	��130���� .+��� $��	Helvetica)�$��30(�$��Light"�$
��Left=�
������ 
�������$��0q�$	 0.8Q�$��Historia ważenia�� . $
��Left=�$	��240��$��730,100,0,0q�&   System.Windows.Controls.DataGrid  -     Name$ HistoriaWagDataGrid��$��	Helvetica)�$��20(�$��Light"�
������ 
���   �$��0q�$	��500��$��600,40,120,188q�$	��380��