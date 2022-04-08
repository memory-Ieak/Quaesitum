using Godot;
using System;

public class Defaite : Node2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        Choix.Player1 = new NouvellePartie.Joueur("1",NouvellePartie.Joueur.classe.NAIN,25, NouvellePartie.Joueur.status.NONE);
		Choix.Player2 = new NouvellePartie.Joueur("2",NouvellePartie.Joueur.classe.NAIN,25, NouvellePartie.Joueur.status.NONE);
		Choix.Player3 = new NouvellePartie.Joueur("3",NouvellePartie.Joueur.classe.NAIN,25, NouvellePartie.Joueur.status.NONE);
		Choix.Player4 = new NouvellePartie.Joueur("4",NouvellePartie.Joueur.classe.NAIN,25, NouvellePartie.Joueur.status.NONE);

		Choix.listeJoueurs = new[] {Choix.Player1, Choix.Player2, Choix.Player3 , Choix.Player4};

		Main.tour = 1;
		Main.index = 0;
    }

    void _on_Restart_pressed()
    {


        GetTree().ChangeScene("res://Scenes/NouvellePartie.tscn");
    }

    void _on_Home_pressed()
    {
        GetTree().ChangeScene("res://Scenes/TitleScreen.tscn");
    }
}
