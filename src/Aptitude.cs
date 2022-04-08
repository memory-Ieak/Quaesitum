using Godot;
using System;

public class Aptitude : Node2D
{
	TextureButton Capitale;
	TextureButton Capitale2;
	TextureButton Capitale3;
	TextureButton Ferme;
	TextureButton Ferme2;
	TextureButton Ferme3;
	TextureButton Scierie;
	TextureButton Scierie2;
	TextureButton Scierie3;
	TextureButton Mine;
	TextureButton Mine2;
	TextureButton Mine3;
	TextureButton Joueur;
	
	Label BoisText;
	Label OrText;
	Label FerText;
	Label NourritureText;

	Line2D Joueur_Capitale;
	Line2D Joueur_Capitale2;
	Line2D Joueur_Capitale3;
	Line2D Joueur_Ferme;
	Line2D Joueur_Ferme2;
	Line2D Joueur_Ferme3;
	Line2D Joueur_Mine;
	Line2D Joueur_Mine2;
	Line2D Joueur_Mine3;
	Line2D Joueur_Scierie;
	Line2D Joueur_Scierie2;
	Line2D Joueur_Scierie3;
	Line2D Joueur_Soldat;
	

	Color blanc = new Color(1, 1, 1);

	Texture Orc = ResourceLoader.Load("res://Texture/Bouton/OrcBoutonBlanc.png") as Texture;
	Texture Humain = ResourceLoader.Load("res://Texture/Bouton/HumainBoutonBlanc.png") as Texture;
	Texture Nain = ResourceLoader.Load("res://Texture/Bouton/NainBoutonBlanc.png") as Texture;
	Texture Elf = ResourceLoader.Load("res://Texture/Bouton/ElfBoutonBlanc.png") as Texture;
	
	
	
	

	public override void _Ready()
	{
		Capitale = (TextureButton)GetNode("Capitale");
		Capitale2 = (TextureButton)GetNode("Capitale2");
		Capitale3 = (TextureButton)GetNode("Capitale3");
		Ferme = (TextureButton)GetNode("Ferme");
		Ferme2 = (TextureButton)GetNode("Ferme2");
		Ferme3 = (TextureButton)GetNode("Ferme3");
		Scierie = (TextureButton)GetNode("Scierie");
		Scierie2 = (TextureButton)GetNode("Scierie2");
		Scierie3 = (TextureButton)GetNode("Scierie3");
		Mine = (TextureButton)GetNode("Mine");
		Mine2 = (TextureButton)GetNode("Mine2");
		Mine3 = (TextureButton)GetNode("Mine3");
		Joueur = (TextureButton)GetNode("Perso");

		Joueur_Capitale = (Line2D)GetNode("LineCapitale");
		Joueur_Capitale2 = (Line2D)GetNode("LineCapitale2");
		Joueur_Capitale3 = (Line2D)GetNode("LineCapitale3");
		Joueur_Ferme = (Line2D)GetNode("LineFerme");
		Joueur_Ferme2 = (Line2D)GetNode("LineFerme2");
		Joueur_Ferme3 = (Line2D)GetNode("LineFerme3");
		Joueur_Mine = (Line2D)GetNode("LineMine");
		Joueur_Mine2 = (Line2D)GetNode("LineMine2");
		Joueur_Mine3 = (Line2D)GetNode("LineMine3");
		Joueur_Scierie = (Line2D)GetNode("LineScierie");
		Joueur_Scierie2 = (Line2D)GetNode("LineScierie2");
		Joueur_Scierie3 = (Line2D)GetNode("LineScierie3");
		
		OrText = (Label)GetNode("OrText");
	  	FerText = (Label)GetNode("FerText");
		BoisText = (Label)GetNode("BoisText");
		NourritureText = (Label)GetNode("NourritureText");
	

		Joueur.Disabled = true;
		
		if (Choix.listeJoueurs[Main.index].aptitude.Capitale == true)
		{
			Capitale.Disabled = true;
			Joueur_Capitale.DefaultColor = blanc;
		}
		if (Choix.listeJoueurs[Main.index].aptitude.Capitale2 == true)
		{
			Capitale2.Disabled = true;
			Joueur_Capitale2.DefaultColor = blanc;
		}
		if (Choix.listeJoueurs[Main.index].aptitude.Capitale3 == true)
		{
			Capitale3.Disabled = true;
			Joueur_Capitale3.DefaultColor = blanc;
		}

		if (Choix.listeJoueurs[Main.index].aptitude.Ferme == true)
		{
			Ferme.Disabled = true;
			Joueur_Ferme.DefaultColor = blanc;
		}
		if (Choix.listeJoueurs[Main.index].aptitude.Ferme2 == true)
		{
			Ferme2.Disabled = true;
			Joueur_Ferme2.DefaultColor = blanc;
		}
		if (Choix.listeJoueurs[Main.index].aptitude.Ferme3 == true)
		{
			Ferme3.Disabled = true;
			Joueur_Ferme3.DefaultColor = blanc;
		}
		
		
		if (Choix.listeJoueurs[Main.index].aptitude.Scierie == true)
		{
			Scierie.Disabled = true;
			Joueur_Scierie.DefaultColor = blanc;
		}
		if (Choix.listeJoueurs[Main.index].aptitude.Scierie2 == true)
		{
			Scierie2.Disabled = true;
			Joueur_Scierie2.DefaultColor = blanc;
		}
		if (Choix.listeJoueurs[Main.index].aptitude.Scierie3 == true)
		{
			Scierie3.Disabled = true;
			Joueur_Scierie3.DefaultColor = blanc;
		}
		
		
		if (Choix.listeJoueurs[Main.index].aptitude.Mine == true)
		{
			Mine.Disabled = true;
			Joueur_Mine.DefaultColor = blanc;
		}
		if (Choix.listeJoueurs[Main.index].aptitude.Mine2 == true)
		{
			Mine2.Disabled = true;
			Joueur_Mine2.DefaultColor = blanc;
		}
		if (Choix.listeJoueurs[Main.index].aptitude.Mine3 == true)
		{
			Mine3.Disabled = true;
			Joueur_Mine3.DefaultColor = blanc;
		}
		
		
		if (Choix.listeJoueurs[Main.index].race == NouvellePartie.Joueur.classe.ELF)
		{
			Joueur.TextureDisabled = Elf;
		}
		if (Choix.listeJoueurs[Main.index].race == NouvellePartie.Joueur.classe.ORC)
		{
			Joueur.TextureDisabled = Orc;
		}
		if (Choix.listeJoueurs[Main.index].race == NouvellePartie.Joueur.classe.HUMAIN)
		{
			Joueur.TextureDisabled = Humain;
		}
		if (Choix.listeJoueurs[Main.index].race == NouvellePartie.Joueur.classe.NAIN)
		{
			Joueur.TextureDisabled = Nain;
		}
		
		OrText.Text =  "x " + Convert.ToString(Choix.listeJoueurs[Main.index].or);
		BoisText.Text = "x " + Convert.ToString(Choix.listeJoueurs[Main.index].bois);
		FerText.Text = "x " + Convert.ToString(Choix.listeJoueurs[Main.index].fer);
		NourritureText.Text = "x " + Convert.ToString(Choix.listeJoueurs[Main.index].nourriture);
	}

	private void _on_Quit_pressed()
	{
		GetTree().ChangeScene("res://Scenes/Main.tscn");
	}
	
	private void _on_Capitale_pressed()
	{
		if (Choix.listeJoueurs[Main.index].fer >= 50 && Choix.listeJoueurs[Main.index].bois >= 100)
		{
			Choix.listeJoueurs[Main.index].fer = Choix.listeJoueurs[Main.index].fer - 50;
			Choix.listeJoueurs[Main.index].bois = Choix.listeJoueurs[Main.index].bois - 100;
			Capitale.Disabled = true;
			Choix.listeJoueurs[Main.index].aptitude.Capitale = true;
			Joueur_Capitale.DefaultColor = blanc;
			BoisText.Text = "x " + Convert.ToString(Choix.listeJoueurs[Main.index].bois);
			FerText.Text = "x " + Convert.ToString(Choix.listeJoueurs[Main.index].fer);
		}
		
	}
	private void _on_Capitale2_pressed()
	{
		if (Choix.listeJoueurs[Main.index].aptitude.Capitale == true)
		{
			if (Choix.listeJoueurs[Main.index].fer >= 150 && Choix.listeJoueurs[Main.index].bois >= 400)
			{
				Choix.listeJoueurs[Main.index].fer = Choix.listeJoueurs[Main.index].fer - 150;
				Choix.listeJoueurs[Main.index].bois = Choix.listeJoueurs[Main.index].bois - 400;
				Capitale2.Disabled = true;
				Choix.listeJoueurs[Main.index].aptitude.Capitale2 = true;
				Joueur_Capitale2.DefaultColor = blanc;
				BoisText.Text = "x " + Convert.ToString(Choix.listeJoueurs[Main.index].bois);
				FerText.Text = "x " + Convert.ToString(Choix.listeJoueurs[Main.index].fer);
			}
		}
	}
	private void _on_Capitale3_pressed()
	{
		if (Choix.listeJoueurs[Main.index].aptitude.Capitale2 == true)
		{
			if (Choix.listeJoueurs[Main.index].fer >= 300 && Choix.listeJoueurs[Main.index].bois >= 800)
			{
				Choix.listeJoueurs[Main.index].fer = Choix.listeJoueurs[Main.index].fer - 300;
				Choix.listeJoueurs[Main.index].bois = Choix.listeJoueurs[Main.index].bois - 800;
				Capitale3.Disabled = true;
				Choix.listeJoueurs[Main.index].aptitude.Capitale3 = true;
				Joueur_Capitale3.DefaultColor = blanc;
				BoisText.Text = "x " + Convert.ToString(Choix.listeJoueurs[Main.index].bois);
				FerText.Text = "x " + Convert.ToString(Choix.listeJoueurs[Main.index].fer);
				
			}
		}
	}

	private void _on_Ferme_pressed()
	{
		if (Choix.listeJoueurs[Main.index].bois >= 40)
		{
			Choix.listeJoueurs[Main.index].bois = Choix.listeJoueurs[Main.index].bois - 40;
			Ferme.Disabled = true;
			Choix.listeJoueurs[Main.index].aptitude.Ferme = true;
			Joueur_Ferme.DefaultColor = blanc;
			BoisText.Text = "x " + Convert.ToString(Choix.listeJoueurs[Main.index].bois);
		}
		
	}
	
	private void _on_Ferme2_pressed()
	{
		if (Choix.listeJoueurs[Main.index].aptitude.Ferme == true)
		{
			if (Choix.listeJoueurs[Main.index].bois >= 80)
			{
				Choix.listeJoueurs[Main.index].bois = Choix.listeJoueurs[Main.index].bois - 80;
				Ferme2.Disabled = true;
				Choix.listeJoueurs[Main.index].aptitude.Ferme2 = true;
				Joueur_Ferme2.DefaultColor = blanc;
				BoisText.Text = "x " + Convert.ToString(Choix.listeJoueurs[Main.index].bois);
			}
		
		}
	}
	
	private void _on_Ferme3_pressed()
	{
		if (Choix.listeJoueurs[Main.index].aptitude.Ferme2 == true)
		{
			if (Choix.listeJoueurs[Main.index].bois >= 120)
			{
				Choix.listeJoueurs[Main.index].bois = Choix.listeJoueurs[Main.index].bois - 120;
				Ferme3.Disabled = true;
				Choix.listeJoueurs[Main.index].aptitude.Ferme3 = true;
				Joueur_Ferme3.DefaultColor = blanc;
				BoisText.Text = "x " + Convert.ToString(Choix.listeJoueurs[Main.index].bois);
			}
		}
   
	}
	

	private void _on_Scierie_pressed()
	{
		if (Choix.listeJoueurs[Main.index].or >= 30)
		{
			Choix.listeJoueurs[Main.index].or = Choix.listeJoueurs[Main.index].or - 30;
			Scierie.Disabled = true;
			Choix.listeJoueurs[Main.index].aptitude.Scierie = true;
			Joueur_Scierie.DefaultColor = blanc;
			OrText.Text =  "x " + Convert.ToString(Choix.listeJoueurs[Main.index].or);
		}
	}
	
	private void _on_Scierie2_pressed()
	{
		if (Choix.listeJoueurs[Main.index].aptitude.Scierie == true)
		{
			if (Choix.listeJoueurs[Main.index].or >= 90)
			{
				Choix.listeJoueurs[Main.index].or = Choix.listeJoueurs[Main.index].or - 90;
				Scierie2.Disabled = true;
				Choix.listeJoueurs[Main.index].aptitude.Scierie2 = true;
				Joueur_Scierie2.DefaultColor = blanc;
				OrText.Text =  "x " + Convert.ToString(Choix.listeJoueurs[Main.index].or);
			}
		}
	}
	
	private void _on_Scierie3_pressed()
	{
		if (Choix.listeJoueurs[Main.index].aptitude.Scierie2 == true)
		{
			if (Choix.listeJoueurs[Main.index].or >= 180)
			{
				Choix.listeJoueurs[Main.index].or = Choix.listeJoueurs[Main.index].or - 180;
				Scierie3.Disabled = true;
				Choix.listeJoueurs[Main.index].aptitude.Scierie3 = true;
				Joueur_Scierie3.DefaultColor = blanc;
				OrText.Text =  "x " + Convert.ToString(Choix.listeJoueurs[Main.index].or);
			}
		}
	}
	

	private void _on_Mine_pressed()
	{
		if (Choix.listeJoueurs[Main.index].bois >= 50)
		{
			Choix.listeJoueurs[Main.index].bois = Choix.listeJoueurs[Main.index].bois - 50;
			Mine.Disabled = true;
			Choix.listeJoueurs[Main.index].aptitude.Mine = true;
			Joueur_Mine.DefaultColor = blanc;
			BoisText.Text = "x " + Convert.ToString(Choix.listeJoueurs[Main.index].bois);
		}
	}
	
	private void _on_Mine2_pressed()
	{
		if (Choix.listeJoueurs[Main.index].aptitude.Mine == true)
		{
			if (Choix.listeJoueurs[Main.index].bois >= 150)
			{
				Choix.listeJoueurs[Main.index].bois = Choix.listeJoueurs[Main.index].bois - 150;
				Mine2.Disabled = true;
				Choix.listeJoueurs[Main.index].aptitude.Mine2 = true;
				Joueur_Mine2.DefaultColor = blanc;
				BoisText.Text = "x " + Convert.ToString(Choix.listeJoueurs[Main.index].bois);
			}
		}
	}
	
	private void _on_Mine3_pressed()
	{
		if (Choix.listeJoueurs[Main.index].aptitude.Mine2 == true)
		{
			if (Choix.listeJoueurs[Main.index].bois >= 225)
			{
				Choix.listeJoueurs[Main.index].bois = Choix.listeJoueurs[Main.index].bois - 225;
				Mine3.Disabled = true;
				Choix.listeJoueurs[Main.index].aptitude.Mine3 = true;
				Joueur_Mine3.DefaultColor = blanc;
				BoisText.Text = "x " + Convert.ToString(Choix.listeJoueurs[Main.index].bois);
			}
		}
	} 

	public override void _Input(InputEvent @event)
	{
		if (Input.IsActionJustReleased("Aptitude"))
		{
			_on_Quit_pressed();
		}
	}
}





