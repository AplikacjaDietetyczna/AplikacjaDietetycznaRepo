   M S B A M L   `   `   `  ���� O  KAplikacjaDietetyczna, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:AplikacjaDietetyczna.UserControls!AplikacjaDietetyczna.UserControls  8    2AplikacjaDietetyczna.UserControls.UserControlDodaj   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     Alocal/clr-namespace:AplikacjaDietetyczna.UserControls     X TXceed.Wpf.Toolkit, Version=3.8.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  .��� -     �Name$  GridMain��.+��� .+�� ���#7aa9f6$	��640��$��	0,0,0.2,0q� � ColumnDefinitions �� $	��38* ��� $
��267* �.+��� -    ��Name$ NowyPosilek��$��	Helvetica)�$��32(�$��Light"�$��Center=�$
��Left=�
������ 
�������$��0q�$	��706�� J� Opacity$	 0.8Q�$��Twoj nowy Posiłek: ��$��352,10,10,587q� �� 
IsReadOnly . $��1���� $��2��$��
0,0,-0.2,0q�.+�� .+��� -   $ 
TypPosilku��$��	Helvetica)�$��32(�$��DemiBold"�$��Center=�$
��Left=�
������ 
�������$��0q�$	��394��$	 0.8Q�$��
TypPosilku��$��29,11,797,483.6q� . �� -   $ 	Sniadanie��$��	Helvetica)�$��32(�$��Light"�$��Center=�$
��Left=�
������ 
�������$��0q�$	��147��$	 0.8Q�$��Produkt��$��29,155,1044,359.8q� . �� -    ��Name$ ProduktCombo��$
��Left=�$��30��$��252,155,0,0q�$	��Top=�$	��193�� J� RenderTransformOrigin$ -0.462,0.607&����� *
cbItems1+ �� SelectedItem �� *SelectedcbItem1+�� $��0,100,-0.2,0q�$��2��.+��  �� $
��163* ��� $
��447* �.+��� -   $ Lunch��$��	Helvetica)�$��32(�$��Light"�$��Center=�$
��Left=�
������ 
�������$��0q�$	��147��$ 1Q�$��Ilość��$��31,136,148.4,378.8q� . �� -   $ 
IloscCombo��$
��Left=� �� SelectedIndex$ 0��$	 �� IsSynchronizedWithCurrentItem$
	 TrueY�$��30��$��255,136,0,0q�$	��Top=�$	��193��$��2���� -   $ Weglowodany_Podsumowanie��$��	Helvetica)�$��32(�$��Light"�$��Center=�$
��Left=�
������ 
�������$��0q�$	��367��$ 1Q�$��Węglowodany: ��$��181.433,410,346,104.6q� . $��1���� -	   $ Kalorie_Podsumowanie��$��	Helvetica)�$��32(�$��Light"�$��Center=�$
��Left=�
������ 
�������$��0q�$	��372��$ 1Q�$��	Kalorie: ��$��181.433,453,341,61.6q� . $��1���� -
   $ Tluszcze_Podsumowanie��$��	Helvetica)�$��32(�$��Light"�$��Center=�$
��Left=�
������ 
�������$��0q�$	��331��$ 1Q�$��Tłuszcze: ��$��553.433,410,10,104.6q� . $ 1.003,0.553&�$��1���� -   $ Białko_Podsumowanie��$��	Helvetica)�$��32(�$��Light"�$��Center=�$
��Left=�
������ 
�������$��0q�$	��331��$ 1Q�$��	Białko: ��$��553.433,453,10,61.6q� . $ 1.003,0.553&�$��1���� -   $ 
Lunch_Copy��$��	Helvetica)�$��22(�$��Light"�$��Center=�$
��Left=�
������ 
�������$��0q�$	��218��$ 1Q�$@��:Nie widzisz produktu którego szukasz? Zaproponuj własny!��$��31,279,77,191q�
 �� TextWrapping$

 Wrap=� . �� -   $ Lunch_Copy1��$��	Helvetica)�$��18(�$��Light"�$

 Wrap=�$��Center=�$
��Left=�
������ 
�������$��0q�$	��187��$ 1Q�$(��"Chcesz usunąć któryś posiłek?��$��31,423,108,83q� . �� $��0,200,-0.2,0q�$��2��.+�� �� $��0,300,-0.2,0q�$��2��.+�� �� -    ��Name$ DodajProdukt��$��Dodaj Produkt��$
��Left=�$��120,300,0,0q�$	��Top=�$	��150��$��50��$��1��$ -0.22,0.466&��� -   $ DodajPosilek��$��Utwórz Posiłek��$
��Left=�$��120,470,0,0q�$	��Top=�$	��150��$��50��$ -0.22,0.466&�$��1���� $��	Helvetica)�$��32(�$��Light"�$��Center=�$
��Left=�
������ 
�������$��0q�$	��209��$	 0.8Q�$��Nazwa posiłku:��$��27,71,984,531q� . $��2��(  "Xceed.Wpf.Toolkit.WatermarkTextBox  -     Name$ NazwaPosilkuText��   	Watermark$ Wprowadź nazwe��$��	Helvetica)�$��32(�$��Light"�$��Center=�$
��Left=�
������ 
�������$��0q�$	 0.8Q�$��38��$��89,71,727,0q�$

 Wrap=�$	��Top=�$	��252��$��1���� -   $ Reset��$��	Wyczyść��$
��Left=�$��
32,470,0,0q�$	��Top=�$	��150��$��50��$ -0.22,0.466&�$��2���� -   $ Cofnij��$��Cofnij��$
��Left=�$��
32,300,0,0q�$	��Top=�$	��150��$��50��$ -0.22,0.466&�$��2���� -   $ ZaproponujProdukt��$��Zaproponuj Produkt��$
��Left=�$��120,377,0,0q�$	��Top=�$	��150��$��50��$ -0.22,0.466&�$��1���� -   $ PosilekCombo��$
��Left=�$��30��$��
27,562,0,0q�$	��Top=�$	��193��$ -0.462,0.607&�$��2������ *
cbItems2+ �� *SelectedcbItem2+�� -   $ UsunPosilek��$��Usuń Posiłek��$
��Left=�$��120,542,0,0q�$	��Top=�$	��150��$��50��$ -0.22,0.466&�$��1���� -    ��Name$ Podsumowanie��$
��Left=�$
��Wrap=�$�� ��$	��Top=�$��
499,69,0,0q�$	��432��$	��721���� -   $ Podsumowanie_Ghost��$
��Left=�
�������$
��Wrap=�$�� ��$	��Top=�$��
499,69,0,0q�$	��432��$	��721��