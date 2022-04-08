using Godot;
using System;

public class Play_Menu : Control
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

		private void _on_New_Game_pressed()
		{
			GetTree().ChangeScene("res://Scenes/NouvellePartie.tscn");
		}

		private void _on_Continue_pressed()
		{
			GetTree().ChangeScene("res://Scenes/Main.tscn");
		}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
