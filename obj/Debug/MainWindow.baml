   M S B A M L   `   `   `  ����O  KConways Game of Life, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Conway_s_Game_of_LifeConway_s_Game_of_Life  5   	   G(clr-namespace:Conway_s_Game_of_Life.ViewConway_s_Game_of_Life.View  5   	   &     Conway_s_Game_of_Life.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:Conway_s_Game_of_Life     5   	   =controls(clr-namespace:Conway_s_Game_of_Life.View     5   	     � Title$  Game of Death��5	   	   $	��400��6   $	��600��6,    � 	Resources 5
       �� 
TargetType �� Property �� Value��%�   '��       '�� J     �� 5   
   " ��6   .�5      ��  � ��
 ���p�6+   5      �� 5   
   " ��6   .�5      ��  � ��
 �����6+   5      5      .��5      �  � ColumnDefinitions 5   
   �� 5      -   5         ��Name$ 	playspace��5      $��9* �62   �� 5      -   5        $ slider��5      $	��.4* �6/   �� 5      -   5        $ controls��5      $��4* �61   .+�5   
   �� $��1��6   �� 5   
   $��2��6   A� 5   
   -   5         A�Name$ gameGrid��5      $��0��5       � DataContext$ Control.SimulationBoard��5      5      A� 5   
   -   5        $ controlPanel��5      $��2��6,   	 A� Rows$	 7��6<   .+�5      .   (Conway_s_Game_of_Life.View.DisplaySlider  -   5        
  Name$
 gridWidthSlider��5   %     5       -   5        $
 gridHeightSlider��5    %   �� 5!      -   5         ��Name$ updateButton��5"      $��Update Grid��5!      5"   +   �� 5#      -	   5        $ randomizerButton��5$      $��Randomize Cells��5#      5$   /   �� 5%      -
   5        $ 
stepButton��5&      $��Generation Step��5%      5&   )     5'      -   5        $
 ticksPerSecondSlider��5'   %   �� 5(      -   5        $ startStopButton��5(      $��Start��5)      
��� � �5*   (   5+      5,      5-      