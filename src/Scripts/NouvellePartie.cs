using Godot;
using System;

public class NouvellePartie : Control
{
	public class Joueur
	{
		public enum classe
		{
			NONE,
			NAIN,
			HUMAIN,
			ORC,
			ELF
		}
		
		public enum status
		{
			NONE,
			PLAYER,
			BOT
		}
	
		public string name;
		public classe race;
		public Main.Matrice_Joueur[,] Carte;
		public int taille_de_la_carte;
		public bool capitalePOS;
		public Vector2 capitalePOSITION;
		public Main.Aptitude aptitude;
		public status statu;

		public int or;
		public int bois;
		public int fer;
		public int nourriture;
		public int nombre_de_batiment;

		public Joueur(string name, classe race, int taille_de_la_carte, status status)
		{
			this.name = name;
			this.race = race;
			this.statu = status;
			this.capitalePOS = false;
			this.capitalePOSITION = new Vector2(0,0);
			this.aptitude = new Main.Aptitude();
			Carte = new Main.Matrice_Joueur[taille_de_la_carte,taille_de_la_carte];
			for (int i = 0; i < taille_de_la_carte; i++)
			{
				for (int j = 0; j < taille_de_la_carte; j++)
				{
					Carte[i,j] = new Main.Matrice_Joueur();
				}
			}
			this.or = 100;
			this.nourriture = 50;
			this.fer = 50;
			this.bois = 50;
			this.nombre_de_batiment = 0;
		}
		
	}
	
	
	public static int taille = 25;
	public static int NombreJoueurs = 1;


	Label NbJoueurs;

	public override void _Ready()
	{
		NbJoueurs = (Label)GetNode("TitreNombreJoueur/NombreJoueur");
	}

	private void _on_BoutonDroite_pressed()
	{
		NombreJoueurs += 1;
		if (NombreJoueurs > 4)
		{
			NombreJoueurs = 4;
		}
		NbJoueurs.Text = Convert.ToString(NombreJoueurs);
	}

	private void _on_BoutonGauche_pressed()
	{
		NombreJoueurs -= 1;
		if (NombreJoueurs < 1)
		{
			NombreJoueurs = 1;
		}
		NbJoueurs.Text = Convert.ToString(NombreJoueurs);
	}

	private void _on_25x25_pressed()
	{
		taille = 25;
	}
	private void _on_50x50_pressed()
	{
		taille = 25;
	}
	private void _on_100x100_pressed()
	{
		taille = 25;
	}

	private void _on_Retour_pressed()
	{
		GetTree().ChangeScene("res://Scenes/Play Menu.tscn");
	}
	private void _on_Jouer_pressed()
	{
		GetTree().ChangeScene("res://Scenes/Choix.tscn");
	}
}
