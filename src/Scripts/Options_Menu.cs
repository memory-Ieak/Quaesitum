using Godot;
using System;

public class Options_Menu : Control
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}

		private void _on_Back_pressed()
		{
			GetTree().ChangeScene("res://Scenes/TitleScreen.tscn");
		} 

		private void _on_Language_pressed()
		{
			GetTree().ChangeScene("res://Scenes/Language Menu.tscn");
		}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
