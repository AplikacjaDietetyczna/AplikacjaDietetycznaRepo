   M S B A M L   `   `   `  ���� O  KAplikacjaDietetyczna, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:AplikacjaDietetyczna.UserControls!AplikacjaDietetyczna.UserControls  =    7AplikacjaDietetyczna.UserControls.UserControlPropozycja   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     Alocal/clr-namespace:AplikacjaDietetyczna.UserControls     X TXceed.Wpf.Toolkit, Version=3.8.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  .��� -     �Name$  GridMain��.+��� .+�� ���#7aa9f6$	��640��$��	0,0,0.2,0q� � ColumnDefinitions �� .+��� .+�� .+��� -    ��Name$ 
TypPosilku��$��	Helvetica)�$��32(�$��DemiBold"�$��Center=�$
��Left=�
������ 
�������$��0q�$	��394�� J� Opacity$	 0.8Q�$��Dodaj własny produkt��$��29,11,797,483.6q� �� 
IsReadOnly . �� -   $ 	Sniadanie��$��	Helvetica)�$��32(�$��Light"�$
��Left=�$
��Left=�
������ 
�������$��0q�$	��229��$	 0.8Q�$��Sposób podania:��$��29,107,0,407q� . �� -   $ Sniadanie_Copy��$��	Helvetica)�$��32(�$��Light"�$
��Left=�$
��Left=�
������ 
�������$��0q�$	��229��$	 0.8Q�$��Białka:��$��29,183,0,331q� . �� -   $ Sniadanie_Copy1��$��	Helvetica)�$��32(�$��Light"�$
��Left=�$
��Left=�
������ 
�������$��0q�$	��229��$	 0.8Q�$��Kalorie:��$��29,145,0,369q� . �� -   $ Sniadanie_Copy2��$��	Helvetica)�$��32(�$��Light"�$
��Left=�$
��Left=�
������ 
�������$��0q�$	��229��$	 0.8Q�$��
Tłuszcze:��$��29,221,0,293q� . �� -   $ Sniadanie_Copy3��$��	Helvetica)�$��32(�$��Light"�$
��Left=�$
��Left=�
������ 
�������$��0q�$	��229��$	 0.8Q�$��Węglowodany:��$��29,259,0,255q� . �� -   $ TypPosilku_Copy��$��	Helvetica)�$��32(�$��DemiBold"�$��Center=�$
��Left=�
������ 
�������$��0q�$	��466��$	 0.8Q�$&�� Zmień lub usuń własny produkt��$��604,11,150,483q� . �� -	   $ Sniadanie_Copy4��$��	Helvetica)�$��32(�$��Light"�$
��Left=�$
��Left=�
������ 
�������$��0q�$	��229��$	 0.8Q�$��Sposób podania:��$��604,107,0,407q� . �� -
   $ Sniadanie_Copy5��$��	Helvetica)�$��32(�$��Light"�$
��Left=�$
��Left=�
������ 
�������$��0q�$	��229��$	 0.8Q�$��Kalorie:��$��604,145,0,369q� . �� -   $ Sniadanie_Copy6��$��	Helvetica)�$��32(�$��Light"�$
��Left=�$
��Left=�
������ 
�������$��0q�$	��229��$	 0.8Q�$��Białka:��$��604,183,0,331q� . �� -   $ Sniadanie_Copy7��$��	Helvetica)�$��32(�$��Light"�$
��Left=�$
��Left=�
������ 
�������$��0q�$	��229��$	 0.8Q�$��
Tłuszcze:��$��604,221,0,293q� . �� -   $ Sniadanie_Copy8��$��	Helvetica)�$��32(�$��Light"�$
��Left=�$
��Left=�
������ 
�������$��0q�$	��229��$	 0.8Q�$��Węglowodany:��$��604,259,0,255q� . �� $��	Helvetica)�$��18(�$��DemiBold"�$��Center=�$
��Left=�
������ 
�������$��0q�$	��606��$	 0.8Q� �� TextWrapping$
 Wrap=�$���{Jeśli Twojego produktu brakuje na liście to znaczy, że został od dodany do głównej bazy dla wszystkich użytkowników��$��604,407,10,85q� . �� -    ��Name$ DodajProdukt��$��Dodaj Produkt��$
��Left=�$��
27,330,0,0q�$	��Top=�$	��150��$��50�� J� RenderTransformOrigin$ -0.22,0.466&��� $��	Helvetica)�$��32(�$��Light"�$��Center=�$
��Left=�
������ 
�������$��0q�$	��241��$	 0.8Q�$��Nazwa Produktu:��$��27,71,952,531q� . (  "Xceed.Wpf.Toolkit.WatermarkTextBox  -     Name$ NazwaPosilkuText��	 �� 	MaxLength$	 55��
   	Watermark$
 Wprowadź nazwe��$��	Helvetica)�$��28(�$��Light"�$��Center=�$
��Left=�
������ 
�������$��0q�$	 0.8Q�$��38��$��268,71,61,0q�$
 Wrap=�$	��Top=�$	��891���� -   $ Cofnij��$��Powrót��$
��Left=�$��
27,416,0,0q�$	��Top=�$	��150��$��50��$ -0.22,0.466&�  -   $ SposobPodaniaText��$
 Sztuka,100g,15ml��$	 20��$��	Helvetica)�$��28(�$��Light"�$��Center=�$
��Left=�
������ 
�������$��0q�$	 0.8Q�$��38��$��268,109,700,0q�$
 Wrap=�$	��Top=�$	��252��  -   $ KalorieText��$	 3��$
 	0-999kcal��$��	Helvetica)�$��28(�$��Light"�$��Center=�$
��Left=�
������ 
�������$��0q�$	 0.8Q�$��38��$��268,147,700,0q�$
 Wrap=�$	��Top=�$	��252��  -   $ WeglowodanyText��$	 3��$
 0-999g��$��	Helvetica)�$��28(�$��Light"�$��Center=�$
��Left=�
������ 
�������$��0q�$	 0.8Q�$��38��$��268,261,700,0q�$
 Wrap=�$	��Top=�$	��252��  -   $ TluszczeText��$	 3��$
 0-999g��$��	Helvetica)�$��28(�$��Light"�$��Center=�$
��Left=�
������ 
�������$��0q�$	 0.8Q�$��38��$��268,223,700,0q�$
 Wrap=�$	��Top=�$	��252��  -   $ 
BialkaText��$	 3��$
 0-999g��$��	Helvetica)�$��28(�$��Light"�$��Center=�$
��Left=�
������ 
�������$��0q�$	 0.8Q�$��38��$��268,185,700,0q�$
 Wrap=�$	��Top=�$	��252���� $��	Helvetica)�$��32(�$��Light"�$��Center=�$
��Left=�
������ 
�������$��0q�$	��240��$	 0.8Q�$��Nazwa Produktu:��$��604,71,376,531q� .   -   $ SposobPodaniaText_Copy��$
 Sztuka,100g,15ml��$	 20��$��	Helvetica)�$��28(�$��Light"�$��Center=�$
��Left=�
������ 
�������$��0q�$	 0.8Q�$��38��$��854,109,114,0q�$
 Wrap=�$	��Top=�$	��252��  -   $ KalorieText_Copy��$	 3��$
 	0-999kcal��$��	Helvetica)�$��28(�$��Light"�$��Center=�$
��Left=�
������ 
�������$��0q�$	 0.8Q�$��38��$��854,147,114,0q�$
 Wrap=�$	��Top=�$	��252��  -   $ BialkaText_Copy��$	 3��$
 0-999g��$��	Helvetica)�$��28(�$��Light"�$��Center=�$
��Left=�
������ 
�������$��0q�$	 0.8Q�$��38��$��854,185,114,0q�$
 Wrap=�$	��Top=�$	��252��  -   $ TluszczeText_Copy��$	 3��$
 0-999g��$��	Helvetica)�$��28(�$��Light"�$��Center=�$
��Left=�
������ 
�������$��0q�$	 0.8Q�$��38��$��854,223,114,0q�$
 Wrap=�$	��Top=�$	��252��  -   $ WeglowodanyText_Copy��$	 3��$
 0-999g��$��	Helvetica)�$��28(�$��Light"�$��Center=�$
��Left=�
������ 
�������$��0q�$	 0.8Q�$��38��$��854,261,114,0q�$
 Wrap=�$	��Top=�$	��252���� -    ��Name$ ProduktCombo��$
��Left=�$��35��$��
854,74,0,0q�$	��Top=�$	��262��$ -0.462,0.607&����� *
cbItems1+ �� SelectedItem �� *SelectedcbItem1+�� -   $ ZmienProdukt��$��Zatwierdź zmiany��$
��Left=�$��604,330,0,0q�$	��Top=�$	��150��$��50��$ -0.22,0.466&��� -   $ UsunProdukt��$��Usuń��$
��Left=�$��854,330,0,0q�$	��Top=�$	��150��$��50��$ -0.22,0.466&�