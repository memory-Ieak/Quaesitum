using Godot;
using System;
using System.Collections.Generic;

public class Choix : Node2D
{
	int t = NouvellePartie.NombreJoueurs;
	int l = 0;

	public static NouvellePartie.Joueur Player1 = new NouvellePartie.Joueur("1",NouvellePartie.Joueur.classe.NAIN,25, NouvellePartie.Joueur.status.NONE);
	public static NouvellePartie.Joueur Player2 = new NouvellePartie.Joueur("2",NouvellePartie.Joueur.classe.ORC,25, NouvellePartie.Joueur.status.NONE);
	public static NouvellePartie.Joueur Player3 = new NouvellePartie.Joueur("3",NouvellePartie.Joueur.classe.ELF,25, NouvellePartie.Joueur.status.NONE);
	public static NouvellePartie.Joueur Player4 = new NouvellePartie.Joueur("4",NouvellePartie.Joueur.classe.HUMAIN,25, NouvellePartie.Joueur.status.NONE);

	public static NouvellePartie.Joueur[] listeJoueurs = new[] {Player1, Player2, Player3 , Player4};

	public static Main.Cell[,] terrain;
	
	TextureButton Humain;
	TextureButton Nain;
	TextureButton Elf;
	TextureButton Orc;

	Texture OrcText = ResourceLoader.Load("res://Texture/Bouton/OrcBoutonNoir.png") as Texture;
	Texture HumainText = ResourceLoader.Load("res://Texture/Bouton/HumainBoutonNoir.png") as Texture;
	Texture NainText = ResourceLoader.Load("res://Texture/Bouton/NainBoutonNoir.png") as Texture;
	Texture ElfText = ResourceLoader.Load("res://Texture/Bouton/ElfBoutonNoir.png") as Texture;
	public static List<Texture> race;

	public override void _Ready()
	{
		Humain = (TextureButton)GetNode("Humain");
		Nain = (TextureButton)GetNode("Nain");
		Orc = (TextureButton)GetNode("Orc");
		Elf = (TextureButton)GetNode("Elf");

		race = new List<Texture>();

		_Process(0.1f);
	}

	private void _on_Humain_pressed()
	{
		Humain.Disabled = true;
		listeJoueurs[l].statu = NouvellePartie.Joueur.status.PLAYER;
		listeJoueurs[l].race = NouvellePartie.Joueur.classe.HUMAIN;
		listeJoueurs[l].name = "Aragorn";
		race.Add(HumainText);
		l += 1;
	}

	private void _on_Elf_pressed()
	{
		Elf.Disabled = true;
		listeJoueurs[l].statu = NouvellePartie.Joueur.status.PLAYER;
		listeJoueurs[l].race = NouvellePartie.Joueur.classe.ELF;
		listeJoueurs[l].name = "Legolas";
		race.Add(ElfText);
		l += 1;
	}

	private void _on_Orc_pressed()
	{
		Orc.Disabled = true;
		listeJoueurs[l].statu = NouvellePartie.Joueur.status.PLAYER;
		listeJoueurs[l].race = NouvellePartie.Joueur.classe.ORC;
		listeJoueurs[l].name = "Gollum";
		race.Add(OrcText);
		l += 1;
	}

	private void _on_Nain_pressed()
	{
		Nain.Disabled = true;
		listeJoueurs[l].statu = NouvellePartie.Joueur.status.PLAYER;
		listeJoueurs[l].race = NouvellePartie.Joueur.classe.NAIN;
		listeJoueurs[l].name = "Gimli";
		race.Add(NainText);
		l += 1;
	}

	private void _on_DLC1_pressed()
	{
		System.Diagnostics.Process.Start("http://google.com");
	}

	private void _on_DLC2_pressed()
	{
		System.Diagnostics.Process.Start("http://google.com");       
	}


	public override void _Process(float delta)
	{
		if (l == t)
		{
			for (int i = t; i < 4; i++)
			{
				listeJoueurs[i].statu = NouvellePartie.Joueur.status.BOT;
				if (Humain.Disabled == false)
				{
					listeJoueurs[i].race = NouvellePartie.Joueur.classe.HUMAIN;
					race.Add(HumainText);
				}
				else if (Orc.Disabled == false)
				{
					listeJoueurs[i].race = NouvellePartie.Joueur.classe.ORC;
					race.Add(OrcText);
				}
				else if (Nain.Disabled == false)
				{
					listeJoueurs[i].race = NouvellePartie.Joueur.classe.NAIN;
					race.Add(NainText);
				}
				else if (Elf.Disabled == false)
				{
					listeJoueurs[i].race = NouvellePartie.Joueur.classe.ELF;
					race.Add(ElfText);
				}
			}

			terrain = Main.Creator_Map(Main.max);

			GetTree().ChangeScene("res://Scenes/Main.tscn");
		}
	}
}
