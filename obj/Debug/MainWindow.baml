   M S B A M L   `   `   `  ����[  WSystem.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089Y@clr-namespace:System.Windows.Forms;assembly=System.Windows.FormsSystem.Windows.Forms  5   	   J FVideo_Stream_DX, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Video_Stream_DXVideo_Stream_DX 5   	       Video_Stream_DX.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   UwinForms@clr-namespace:System.Windows.Forms;assembly=System.Windows.Forms     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:Video_Stream_DX     5   	   -   5          � WindowStartupLocation$  CenterScreen=�5	   	    � Title$ Video_Stream_DX��5
   	   $��378.474��6!   $��582.684��62    � AllowsTransparency . ���	#60188764 � WindowStyle$
 None=�5   	    � 
ResizeMode$ CanResizeWithGrip=�5   	   .��5      � .+�5   
   �� -   5         ��Name$ image��5      $
��Left=�6   $	��378��6:   $	��Top=�6G   $	��583��6_   r� 5   
   -   5         r�Name$ mediaElement��5   a   $��0��6   $��0��6@   $��3��6M   $
��Left=�6w   $	��378��6�   $	��Top=�6�   $	��583��6�    r� Stretch$
 Fill=�6�   �� 5   
   -   5         ��Name$ 	textBlock��5      
������ $
��Left=�6@   $��	10,38,0,0q�6[   $
��Wrap=�6n   $�� ��6�   
�������$	��Top=�6�   $��18(�6�   $��UD Digi Kyokasho N-B)�6�   �� 5   
   -   5        	 ��Name$	 button��5      $��動画を選択��6!   
������ 
�������
�������$
��Left=�6q   $��
179,22,0,0q�6�   $	��Top=�6�   $	��224��6�   $��51��6�   $��UD Digi Kyokasho N-B)�6�   $��20(�6�   $
��Bold"�6   6  �� 5   
   -   5        $	 button1��5      $
��Left=�6"   $��440,337,0,0q�6=   $	��Top=�6R   $	��139��6j   $��20(�6v   $��UD Digi Kyokasho N-B)�6�   $
��Bold"�6�   
 J� RenderTransformOrigin$
 0.5,0.5&�6�   $��39��6�   
������ 
�������
����� �$��終了��69  z�5      V� 5      .~�5      �� �� 5      �� 5       �� Angle$ -0.211Q�6&   T� 5      5      5      �� 5   
   -   5        $	 Stop_B��5      $��停止��6!   
������ 
�������
����  �$
��Left=�6m   $��	0,308,0,0q�6�   $	��Top=�6�   $��79��6�   $��20(�6�   $
��Bold"�6�   $��UD Digi Kyokasho N-B)�6�   $��27��6   6  �� 5   
   -   5        $	 Start_B��5      $��再生��6"   
������ 
�������
����  �$
��Left=�6n   $��
80,308,0,0q�6�   $	��Top=�6�   $��79��6�   $��20(�6�   $
��Bold"�6�   $��UD Digi Kyokasho N-B)�6�   $��27��6  6  �� 5    
   -	   5         ��Name$ slider��5        �� TickPlacement$ BottomRight=�6!   $
��Left=�6>   $��	0,343,0,0q�6Y   $	��Top=�6l   $	��162��6�   $��35��6�   �� 5!   
   -
   5        $	 button2��5!      $��戻る��6"   
������ 
�������
�������$
��Left=�6r   $	��Top=�6�   $	��125��6�   $��20(�6�   $��UD Digi Kyokasho N-B)�6�   $
��Bold"�6�   $��37��6�   6�   �� 5"   
   -   5        $	 Minus_B��5"      $��-10秒��6"   
������ 
�������
����  �$
��Left=�6p   $��211,343,0,0q�6�   $	��Top=�6�   $��83��6�   $��20(�6�   $
��Bold"�6�   $��UD Digi Kyokasho N-B)�6�   $��35��6  6  �� 5#   
   -   5        $	 Plas_B��5#      $��+10秒��6!   
������ 
�������
����  �$
��Left=�6o   $��294,343,0,0q�6�   $	��Top=�6�   $��83��6�   $��20(�6�   $
��Bold"�6�   $��UD Digi Kyokasho N-B)�6�   $��35��6  6  �� 5$   
   -   5        $ Volume_V��5$      $
��Left=�6#   $��
408,10,0,0q�6>   $	��Top=�6R   $	��165��6j   �� 5%   
   -   5         ��Name$ checkBox��5%      $�� ��6%   
�������
�������$
��Left=�6[   $��
179,99,0,0q�6v   $	��Top=�6�   $��16��6�   �� 5&   
   -   5         ��Name$ label��5&      $$��フルスクリーンで表示��6   
�������$��18(�6G   $
��Left=�6U   $��UD Digi Kyokasho N-B)�6p   $��
195,90,0,0q�6�   $	��Top=�6�   �� 5'   
   -   5         ��Name$ Canvas��5'      $
��Left=�6!   $��378.474��6<   $��0,0,0,0q�6M   $	��Top=�6^   $��582.684��6v   5)      5*      