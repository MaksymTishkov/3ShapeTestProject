   M S B A M L   `   `   `  ���� c  _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity  f bGalaSoft.MvvmLight.Platform, Version=5.3.0.19032, Culture=neutral, PublicKeyToken=5f873c45e98af8a1lMclr-namespace:GalaSoft.MvvmLight.Command;assembly=GalaSoft.MvvmLight.PlatformGalaSoft.MvvmLight.Command L H3ShapeTestProject, Version=0.0.0.1, Culture=neutral, PublicKeyToken=nullM+clr-namespace:_3ShapeTestProject.Converters_3ShapeTestProject.Converters #   _3ShapeTestProject.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     0ignorehttp://www.galasoft.ch/ignore     ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     ]cmdMclr-namespace:GalaSoft.MvvmLight.Command;assembly=GalaSoft.MvvmLight.Platform     <conv+clr-namespace:_3ShapeTestProject.Converters       � Title$  
MainWindow��$	��300��$	��525�� � 	Resources 7  1_3ShapeTestProject.Converters.MultiValueConverter   MultiValueConverter��%   &	          .��� $
��auto�� � ColumnDefinitions �� $
��auto ��� .+�`�  `� Orientation$ Vertical=�$��1�� K� ZIndex$	 100��.�c� .@�	� -   $��addRectangle��$��5q�$��5q� 	� 	GroupName$ radioActions��$��0������ *SelectRadioCommand+.���� .+��� $��30��$��30��
����ح�$��2��
�������$��Center=��� Add rectangle	� -   $��addTriangle��$��5q�$��5q�$ radioActions��$��1������ *SelectRadioCommand+.���� .+��  � Points �   ������������ 
����ح�$��2��
�������$��Center=��� Add triangle	� -   $��
addTrapeze��$��5q�$��5q�$ radioActions��$��2������ *SelectRadioCommand+.���� .+�� % �   ��� �����@����� 
����ح�$��2��
�������$��Center=��� Add trapeze	� -   $��
addEllipse��$��5q�$��5q�$ radioActions��$��3������ *SelectRadioCommand+.���� .+�A� $��60��$��30��
����ح�$��2��
�������$��Center=��� Add ellipse	� -   $��	addCircle��$��5q�$��5q�$ radioActions��$��4������ *SelectRadioCommand+.���� .+�A� $��30��$��30��
����ح�$��2��
�������$��Center=��� 
Add circle�� -    ��Name$ DrawingControl��$��1��$��4q�
����ح�
����������� *	Figures+.   (System.Windows.Interactivity.Interaction   Triggers /   )System.Windows.Interactivity.EventTrigger  	   	EventName$	 MouseLeftButtonUp��.   (System.Windows.Interactivity.TriggerBase
   Actions.
 /  )GalaSoft.MvvmLight.Command.EventToCommand     EventArgsConverter# [     PassEventArgsToCommand .    Command �� *CanvasLeftClick+"   EventArgsConverterParameter ��  �� ElementName$ DrawingControl�� � ContextMenu �� .@�m� $
��Save�� m� Command �� *Save+m� $
��Load�� �� *Load+���� .R��� ���� .R�F� ���� *
Geometry+���� *Fill+���� *Stroke+���� *StrokeThickness+ �� *Menu+