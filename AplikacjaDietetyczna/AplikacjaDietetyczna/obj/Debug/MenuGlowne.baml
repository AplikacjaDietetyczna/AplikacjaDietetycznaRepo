   M S B A M L   `   `   `  ����O  KAplikacjaDietetyczna, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:AplikacjaDietetycznaAplikacjaDietetyczna  5   	   %    AplikacjaDietetyczna.MenuGlowne   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:AplikacjaDietetyczna     5   	   c _MahApps.Metro.IconPacks.Core, Version=3.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Material, Version=3.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a?	iconPacks-http://metro.mahapps.com/winfx/xaml/iconpacks   5   	   V RMaterialDesignThemes.Wpf, Version=3.1.3.1513, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5          � Title$  
MenuGlowne��5
   	   $	��700��6   $
��1400��6)    � AllowsTransparency . 
������  � WindowStyle$
 None=�5   	    � 
ResizeMode$ NoResize=�6    � WindowStartupLocation$ CenterScreen=�62   .��5      � .+�5   
   � .+�5      ��  �� CornerRadius$ 0��6   $	��640��6'   $��	180,0,0,0q�64   $��Bottom=�6G   ��5      �� 5      .��5      �  � Color$ #7be9f6��6'    � Offset$	 0.0Q�67   � 5      $ #1225ff��6'   $	 1.5Q�67   5      5      � 5      -   5         �Name$ GridMain��5      $��Right=�6%   $��Bottom=�6A   $	��640��6\   $
��1220��6i   � 5       $��60��6   $	��Top=�6   ���	#FF5C99D6.+�5!      �� -   5        	 ��Name$	 PokazID��5!      
�������$
��Left=�6@   $��226,10,0,-15q�6[   $
��Wrap=�6q   $��Witaj, Login��6�   $	��Top=�6�   $��65��6�   $	��629��6�   $��36(�6�   6�   �� 5"      -   5        $	 
PokazAdmin��5"      $
��Left=�60   $��780,23,0,-29q�6K   $
��Wrap=�6a   $�� ��6u   $	��Top=�6}   $��66��6�   $	��474��6�   $��24(�6�   6�   �� 5$      
 �� Orientation$
 
Horizontal=�6   $��Right=�66   .+�5%      '  !MaterialDesignThemes.Wpf.PopupBox     PlacementMode$ BottomAndAlignRightEdges=�6.      	StaysOpen .  $��10q�6i   
�������$��35��6�   $��14(�6�      PopupContent. 5&      �� $	��150��6%   
�������.+�5'      �� -   5        $��Profil��5'   %   66   �� 5(      -   5         ��Name$
 ONas��5(   %   $��O nas��63   6C   �� 5)      �� 5*      -   5        $ Wyloguj��5*   %   $��Wyloguj��66   6H   5+      5,      5-      5/      � 51      -   5        $ GridMenu��51      $	��180��6%   $
��Left=�61   ���	#FF5C99D6.+�55      �� .+�56      � $	��150��6   ���	#FF5C99D6 J� RenderTransformOrigin$ 0.5,0.5&�6?   .+�57      .  (MahApps.Metro.IconPacks.PackIconMaterial     Kind$
 Food=�65   $	��118��6A   $	��160��6N   $��	10,10,0,0q�6Z   58      �� 5:      -	   5         ��Name$ ListViewMenu��5:      ���#c6edf7���	#FF5C99D6$��Disabled=�6b   .@�5;      �� $��60��6(   .��5<      �� $
 
Horizontal=�6)   $	��170��6B   .+�5=   "   �� $��Posilki��6,   $��Center=�6<   $��20 10q�6W     5>   "   $
 Food=�6=   $��25��6I   $��25��6U   $
��55,5q�6`   5?      5@      �� 5B      -
   5         ��Name$ Dodaj_produkt��5B   '   $��60��6>   .��5C      �� $
 
Horizontal=�6)   $	��170��6B   .+�5D   "   �� $��Dodaj produkt��6,   $��Center=�6B   $��20 10q�6]     5E   "   $ FoodForkDrink=�6=   $��25��6R   $��25��6^   $
��12,5q�6i   5F      5G      �� 5I      -   5        $ ItemPodsumowanie��5I   '   $��60��6B   .��5J      �� $
 
Horizontal=�6)   $	��170��6B   .+�5K   "   �� $��Podsumowanie��6,   $��Center=�6@   $��20 10q�6[     5L   "   $ FileAccount=�6=   $��25��6P   $��25��6\   $��9q�6g   5M      5N      �� 5P      -   5        $ Historia_Wagi��5P   '   $��60��6?   .��5Q      �� $
 
Horizontal=�6)   $	��170��6B   .+�5R   "   �� $��Historia wagi��6,   $��Center=�6A   $��20 10q�6\     5S   "   $ WeightKilogram=�6=   $��25��6S   $��25��6_   $
��20,4q�6j   5T      5U      �� 5X      -   5        $ 
Kalkulator��5X   '   $��60��6;   .��5Y      �� $
 
Horizontal=�6)   $	��170��6B   .+�5Z   "   �� $��Kalkulator BMI��6,   $��Center=�6B   $��20 10q�6]     5[   "   $ 
Calculator=�6=   $��25��6O   $��25��6[   $��12q�6f   5\      5^      5`      �� 5a      -   5        $ Dodaj��5a      $	��100��6,   $��40��68   $	��SQL��6D   $��
35,20,45,0q�6R   6f   5f      5g      5h      5k      5l      