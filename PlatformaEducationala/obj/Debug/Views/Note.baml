   M S B A M L   `   `   `  ����P  LPlatformaEducationala, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:PlatformaEducationala.ViewModels PlatformaEducationala.ViewModels  5   	   S.clr-namespace:PlatformaEducationala.Converters PlatformaEducationala.Converters  5   	   I)clr-namespace:PlatformaEducationala.ViewsPlatformaEducationala.Views  5   	   &     PlatformaEducationala.Views.Note   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   >ctx.clr-namespace:PlatformaEducationala.ViewModels     5   	   Bconvert.clr-namespace:PlatformaEducationala.Converters     5   	   ;local)clr-namespace:PlatformaEducationala.Views     5   	     � Title$
  Note��5
   	   $	��588��6   $	��395��6#    � DataContext 5      -   'PlatformaEducationala.ViewModels.NotaVM  5   
   .��5      ��  � 	Resources 5   
   4  .PlatformaEducationala.Converters.ConvertorNota   notaConvert��%   &	          5      6$   5      .+�5   
   � .+�5      �� $��Inserare��6   $��15q�6(   $	��100��64   $��30��6@   ��5      �� *ComandaInserare+��5      `� 5   
    `� 	Converter# [  6   .1�5      ��  �� ElementName$ txtIdMaterie��6    �� Path$
 Text�61   �� 5      $ 
txtValoare��6   $
 Text�6/   �� 5      $ txtEsteTeza��6   $ 	IsChecked�60   �� 5      $ txtSemestru��6   $
 Text�60   �� 5      $ txtMedieIncheiata��6   $ 	IsChecked�66   �� 5      $ 	txtIdElev��6   $
 Text�6.   5      5      �� 5       $��Actualizare��6   $��15q�6#   $	��100��6/   ��6;   �� *ComandaActualizare+��5!      �� $ gridNote��$ SelectedItem��� 5"      $��Stergere��6   $��15q�6    $	��100��6,   ��68   �� *ComandaStergere+��5#      �� $ gridNote��$ SelectedItem�5$      � 5%      $��0,15,0,0q�6   5&      � 5'      $��0,15,0,0q�6   .+�5(   
   �� $	��150��6   $��15(�6   .��6*   Nume + Id Materie:6>   �� 5+      -   5        $��txtIdMaterie��5+      $	��200��6+    �� SelectedValuePath$ Value��5-      ��5+   7   �� *ListaIdMaterii+ �� SelectedValue 5,      �� $ gridNote��$ SelectedItem.IdMaterie���5.      �� 5/      .R�50      �� ��51      `� 52   "    �� StringFormat$ 	{0} - {1}��6/   .1�53   &   �� $	 Key�6.   �� 54   &   $ Value�6.   55   #   57      58      5:      5;      � 5<      $��0,15,0,0q�6   .+�5=   
   �� $	��150��6   $��15(�6   .��6*   
Valoare:64   �� 5>   
   -   5        $��
txtValoare��5>      $	��200��6$   ��60   �� $ gridNote��$ SelectedItem.Valoare�	 �� UpdateSourceTrigger$	 PropertyChanged=�5@      � 5A      $��0,15,0,0q�6   .+�5B   
   �� $	��150��6   $��15(�6   .��6*   
Este Teza:66   �� 5C   
   -   5        $��txtEsteTeza��5C      $	��200��6&   
 d� 	IsChecked
 62   �� $ gridNote��$ SelectedItem.EsteTeza�$	 PropertyChanged=�5E      � 5F      $��0,15,0,0q�6   .+�5G   
   �� $	��150��6   $��15(�6   .��6*   	Semestru:65   �� 5H   
   -   5        $��txtSemestru��5H      $	��200��6%   ��61   �� $ gridNote��$ SelectedItem.Semestru�$	 PropertyChanged=�5J      � 5K      $��0,15,0,0q�6   .+�5L   
   �� $	��150��6   $��15(�6   .��6*   Medie Incheiata:6<   �� 5M   
   -   5        $��txtMedieIncheiata��5M      $	��200��6,   
 68   �� $ gridNote��$! SelectedItem.MedieIncheiata�$	 PropertyChanged=�5O      � 5P      $��0,15,0,0q�6   .+�5Q   
   �� $	��150��6   $��15(�6   .��6*   Nume + Id Elev:6;   �� 5T      -   5        $��	txtIdElev��5T      $	��200��6(   $ Value��5V      ��5T   4   �� *ListaIdElevi+ 5U      �� $ gridNote��$ SelectedItem.IdElev���5W      �� 5X      .R�5Y      �� ��5Z      `� 5[   "   $ 	{0} - {1}��6/   .1�5\   &   �� $	 Key�6.   �� 5]   &   $ Value�6.   5^   #   5`      5a      5c      5d      &   System.Windows.Controls.DataGrid  5e   
   -   5        $��gridNote��5e      $��0,15,0,0q�6#      AutoGenerateColumns .  $	��250��5f         
IsReadOnly . $��Visible=�5g      ��5f       �� *	ListaNote+   Columns 5h   
   0  *System.Windows.Controls.DataGridTextColumn  5i      ,  &System.Windows.Controls.DataGridColumn   Header$ 
Id Materie��6!   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   �� *	IdMaterie+  5j      $ Valoare��6!    62   �� *	Valoare+  5k      $ 	Este Teza��6!    64   �� *
EsteTeza+  5l      $ Semestru��6!    63   �� *
Semestru+  5m      $ Medie Incheiata��6!    6:   �� *MedieIncheiata+  5n      $ Id Elev��6!    62   �� *IdElev+5p      5q      5r      