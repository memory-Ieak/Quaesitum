using Godot;
using System;

public class Main : Node2D
{
	public class Guerrier
	{
		public int nbDeplacement;
		public int hp;
		public int attack;
		public Guerrier()
		{
			this.nbDeplacement = 1;
			this.hp = 10;
			this.attack = 10;
		}
	}
	public class Aptitude
	{
		public bool Capitale;
		public bool Capitale2;
		public bool Capitale3;
		public bool Ferme;
		public bool Ferme2;
		public bool Ferme3;
		public bool Scierie;
		public bool Scierie2;
		public bool Scierie3;
		public bool Mine;
		public bool Mine2;
		public bool Mine3;
		public Aptitude()
		{
			this.Capitale = false;
			this.Capitale2 = false;
			this.Capitale3 = false;
			this.Ferme = false;
			this.Ferme2 = false;
			this.Ferme3 = false;
			this.Scierie = false;
			this.Scierie2 = false;
			this.Scierie3 = false;
			this.Mine = false;
			this.Mine2 = false;
			this.Mine3 = false;
		}
	}
	public class Matrice_Joueur
	{
		public bool cloud;
		public bool soldat;
		public bool marked;
		public Guerrier d;
		public bool ferme;
		public bool mine;
		public bool scierie;
		public Matrice_Joueur()
		{
			this.cloud = true;
			this.soldat = false;
			this.marked = false;
			this.ferme = false;
			this.scierie = false;
			this.mine = false;
			this.d = null;
		}
	}
	
	public class Cell
	{
		public enum BiomeType
		{
			PLAINE,
			MER,
			FORET,
			MONTAGNE,
			CAPITALE_ORC,
			CAPITALE_ELF,
			CAPITALE_NAIN,
			CAPITALE_HUMAIN,
			FERME,
			MINE,
			SCIERIE
		}
		public BiomeType type;
		public Cell(BiomeType type)
		{
			this.type = type;
		}
	}

	TileMap Carte;
	TileMap Deplacement;
	TileMap SoldatAffichage;
	Camera2D MaCamera;
	Label Texte;
	Label FPS;
	Label Tour;
	Label Nom;

	TextureButton Load;
	TextureButton Ferme;
	TextureButton Mine;
	TextureButton Scierie;
	TextureButton Retire;
	TextureButton Race;
	TextureButton Soldat;


	Label BoisText;
	Label OrText;
	Label FerText;
	Label NourritureText;

	Vector2 pos = new Vector2(0,0);
	Vector2 map = new Vector2(0,0);
	Vector2 bug = new Vector2(21,3);
	Vector2 comp = new Vector2(0,32);
	Vector2 CameraBug = new Vector2(6,3);
	Vector2 NouvellePosition = new Vector2(-50,400);
	Vector2 AnciennePosition = new Vector2(-50,600);
	Vector2 AnciennePositionSoldat = new Vector2(0,0);
	public static Vector2 matrice_index;
	
	public int limiteGuerrier = 4;
	
	public int[] prodCapitale = {20 , 30 , 50};
	public int[] prodFerme = {20 , 30 , 50};
	public int[] prodMine = {20 , 30 , 50};
	public int[] prodScierie = {20 , 30 , 50};
	
	public static int index = 0;
	public static int tour = 1;
	public static int Cam_Y_Min_Lim = 500;
	public static int Cam_Y_Max_Lim = (64 * max);

	public static int Cam_X_Min_Lim = (-1) * ((64 * max) / 2);
	public static int Cam_X_Max_Lim = (64 * max) - (8 * max);

	public static bool EnDeplacement = false;
	public static int max = NouvellePartie.taille;

	public override void _Ready()
	{
		Carte = (TileMap)GetNode("Carte");
		Deplacement = (TileMap)GetNode("Marquage");
		SoldatAffichage = (TileMap)GetNode("Soldat");
		MaCamera = (Camera2D)GetNode("Camera");
		FPS = (Label)GetNode("Camera/Interface/FPS");
		Nom = (Label)GetNode("Camera/Interface/Nom");
		Tour = (Label)GetNode("Camera/Interface/Tours");

		OrText = (Label)GetNode("Camera/Interface/OrText");
		FerText = (Label)GetNode("Camera/Interface/FerText");
		BoisText = (Label)GetNode("Camera/Interface/BoisText");
		NourritureText = (Label)GetNode("Camera/Interface/NourritureText");

		Load = (TextureButton)GetNode("Camera/Ferme");
		Ferme = (TextureButton)GetNode("Camera/Ferme");
		Mine = (TextureButton)GetNode("Camera/Mine");
		Scierie = (TextureButton)GetNode("Camera/Scierie");
		Retire = (TextureButton)GetNode("Camera/Retire");
		Race = (TextureButton)GetNode("Camera/Interface/Race");
		Soldat = (TextureButton)GetNode("Camera/Soldat");

		Race.TextureNormal = Choix.race[index];
		Nom.Text = Choix.listeJoueurs[index].name;
		Build(Choix.terrain, Choix.listeJoueurs[index]);
		MaCamera.Position = Carte.MapToWorld(Choix.listeJoueurs[index].capitalePOSITION + CameraBug);
	}

	public void Build(Cell[,] terrain, NouvellePartie.Joueur joueur)
	{
		for (int i = 0; i < 25; i++)
		{
			for (int j = 0; j < 25; j++)
			{
				if (joueur.Carte[i,j].cloud)
				{
					Carte.SetCell(i,j,10,false,false,false,null);
					SoldatAffichage.SetCell(i,j,-1,false,false,false,null);
				}

				else
				{
					if (terrain[i,j].type == Cell.BiomeType.PLAINE)
					{
						Carte.SetCell(i,j,4,false,false,false,null);
					}
					if (terrain[i,j].type == Cell.BiomeType.MER)
					{
						Carte.SetCell(i,j,1,false,false,false,null);
					}
					if (terrain[i,j].type == Cell.BiomeType.MONTAGNE)
					{
						Carte.SetCell(i,j,3,false,false,false,null);
					}
					if (terrain[i,j].type == Cell.BiomeType.FORET)
					{
						Carte.SetCell(i,j,0,false,false,false,null);
					}
					if (terrain[i,j].type == Cell.BiomeType.CAPITALE_HUMAIN)
					{
						Carte.SetCell(i,j,6,false,false,false,null);
					}
					if (terrain[i,j].type == Cell.BiomeType.CAPITALE_NAIN)
					{
						Carte.SetCell(i,j,9,false,false,false,null);
					}
					if (terrain[i,j].type == Cell.BiomeType.CAPITALE_ORC)
					{
						Carte.SetCell(i,j,7,false,false,false,null);
					}
					if (terrain[i,j].type == Cell.BiomeType.CAPITALE_ELF)
					{
						Carte.SetCell(i,j,9,false,false,false,null);
					}
					if (terrain[i,j].type == Cell.BiomeType.FERME)
					{
						Carte.SetCell(i,j,8,false,false,false,null);
					}
					if (terrain[i,j].type == Cell.BiomeType.MINE)
					{
						Carte.SetCell(i,j,2,false,false,false,null);
					}
					if (terrain[i,j].type == Cell.BiomeType.SCIERIE)
					{
						Carte.SetCell(i,j,5,false,false,false,null);
					}
					for (int k = 0; k < 3; k++)
					{
						if (Choix.listeJoueurs[k].Carte[i,j].soldat && Choix.listeJoueurs[index].Carte[i,j].cloud == false)
						{
							SoldatAffichage.SetCell(i,j,0,false,false,false,null);
						}
					}
				}
			}
		}
	}

	public static Cell[,] Creator_Map(int taille)
	{
		Cell[,] terrain = new Cell[taille,taille];
		Random rnd = new Random();
		for (int i = 0; i < taille; i++)
		{
			for (int j = 0; j < taille; j++)
			{
				int aleatoire  = rnd.Next(0, 10);
				if (aleatoire >= 0 & aleatoire <= 6)
				{
					terrain[i, j] = new Cell(Cell.BiomeType.PLAINE);
				}
				else
				{
					terrain[i, j] = new Cell(Cell.BiomeType.MER);
				}
			}
		}
		return Corecteur_Map(terrain, max);
	}

	public static Cell[,] Corecteur_Map(Cell[,] terrain, int taille)
	{
		Random rnd = new Random();

		int moitie = (int)(taille/2);
		int sous = (int) taille / 10;

		int x = 0;
		int y = 0;

		for (int i = 0; i < taille; i++)
		{
			for (int j = 0; j < taille; j++)
			{
				if (count_neighbour(terrain, i, j, taille, Cell.BiomeType.MER) == 4 && count_neighbour(terrain, i, j, taille, Cell.BiomeType.MER) == 3)
				{
					terrain[i, j].type = Cell.BiomeType.MER;
				}
			}
		}
		for (int i = 0; i < taille; i++)
		{
			for (int j = 0; j < taille; j++)
			{
				if (count_neighbour(terrain, i, j, taille, Cell.BiomeType.MER) == 0)
				{
					terrain[i, j].type = Cell.BiomeType.PLAINE;
				}
			}
		}
		for (int i = 0; i < taille; i++)
		{
			for (int j = 0; j < taille; j++)
			{
				if (terrain[i,j].type == Cell.BiomeType.PLAINE)
				{
					if (count_neighbour(terrain, i, j, taille, Cell.BiomeType.PLAINE) == 4)
					{
						int aleatoire_montagne  = rnd.Next(1, 10);
						if (aleatoire_montagne == 1 | aleatoire_montagne == 2)
						{
							terrain[i, j].type = Cell.BiomeType.MONTAGNE;
						}
					}
				}
			}
		}
		for (int i = 0; i < taille; i++)
		{
			for (int j = 0; j < taille; j++)
			{
				if (terrain[i,j].type == Cell.BiomeType.PLAINE)
				{
					if (count_neighbour(terrain, i, j, taille, Cell.BiomeType.PLAINE) == 3)
					{
						int aleatoire_for  = rnd.Next(1, 6);
						if (aleatoire_for == 1 | aleatoire_for == 2)
						{
							terrain[i, j].type = Cell.BiomeType.FORET;
						}
					}
				}
			}
		}
		terrain = Ajoute_Capitales(taille,  moitie,  sous,  x,  y, terrain);

		return terrain;
	}

	public static Cell[,] Ajoute_Capitales(int taille, int moitie, int sous, int x, int y, Cell[,] terrain)
	{
		Random rnd = new Random();

		for (int i = 0; i < Choix.listeJoueurs.Length; i++)
		{
			while (Choix.listeJoueurs[i].capitalePOS != true)
			{
				if (i == 0)
				{
					x = rnd.Next(sous, moitie-sous);
					y = rnd.Next(sous, moitie-sous);
				}

				if (i == 1)
				{
					x = rnd.Next(moitie+sous, taille-sous);
					y = rnd.Next(sous, moitie-sous);
				}

				if (i == 2)
				{
					x = rnd.Next(sous, moitie-sous);
					y = rnd.Next(moitie+sous, taille-sous);
				}
			
				if (i == 3)
				{
					x = rnd.Next(moitie+sous, taille-sous);
					y = rnd.Next(moitie+sous, taille-sous);
				}

				if (terrain[x,y].type == Cell.BiomeType.PLAINE)
				{
					if (Choix.listeJoueurs[i].race == NouvellePartie.Joueur.classe.ELF)
					{
						terrain[x, y].type = Cell.BiomeType.CAPITALE_ELF;
					}
					if (Choix.listeJoueurs[i].race == NouvellePartie.Joueur.classe.NAIN)
					{
						terrain[x, y].type = Cell.BiomeType.CAPITALE_NAIN;
					}
					if (Choix.listeJoueurs[i].race == NouvellePartie.Joueur.classe.ORC)
					{
						terrain[x, y].type = Cell.BiomeType.CAPITALE_ORC;
					}
					if (Choix.listeJoueurs[i].race == NouvellePartie.Joueur.classe.HUMAIN)
					{
						terrain[x, y].type = Cell.BiomeType.CAPITALE_HUMAIN;
					}

					Choix.listeJoueurs[i].capitalePOS = true;
					Choix.listeJoueurs[i].capitalePOSITION.x = x;
					Choix.listeJoueurs[i].capitalePOSITION.y = y;

					Choix.listeJoueurs[i].Carte[x, y].cloud = false;

					RetireNuage(Choix.listeJoueurs[i],i,x,y);
				}
			}
		}

		return terrain;
	}

	public static int count_neighbour(Cell[,] terrain, int x, int y,int max, Cell.BiomeType type)
	{
		int nb_neighbours = 0;
		for (int i = 0; i < 4; i++)
		{
			if (i == 0 & x > 0)
			{
				if (terrain[x-1,y].type == type)
				{
					nb_neighbours += 1;
				}
			}
			if (i == 1 & y > 0)
			{
				if (terrain[x,y-1].type == type)
				{
					nb_neighbours += 1;
				}
			}
			if (i == 2 & x < max-1)
			{
				if (terrain[x+1,y].type == type)
				{
					nb_neighbours += 1;
				}
			}
			if (i == 3 & y < max-1)
			{
				if (terrain[x,y+1].type == type)
				{
					nb_neighbours += 1;
				}
			}
		}
		return nb_neighbours;
	}

	public static void RetireNuage(NouvellePartie.Joueur joueur, int i , int x, int y)
	{
		for (int j = 0; j < 8; j++)
		{
			if (j == 0 & x - 1 >= 0)
			{
				Choix.listeJoueurs[i].Carte[x-1, y].cloud = false;
			}
			if (j == 1 & y - 1 >= 0)
			{
				Choix.listeJoueurs[i].Carte[x, y-1].cloud = false;
			}
			if (j == 2 & x + 1 < max-1)
			{
				Choix.listeJoueurs[i].Carte[x+1, y].cloud = false;
			}
			if (j == 3 & y + 1 < max-1)
			{
				Choix.listeJoueurs[i].Carte[x, y+1].cloud = false;
			}

			if (j == 4 & x - 1 >= 0 & y - 1 >= 0)
			{
				Choix.listeJoueurs[i].Carte[x-1, y-1].cloud = false;
			}
			if (j == 5 & x + 1 < max-1 & y + 1 < max-1)
			{
				Choix.listeJoueurs[i].Carte[x+1, y+1].cloud = false;
			}
			if (j == 6 & x - 1 >= 0 & y + 1 < max-1)
			{
				Choix.listeJoueurs[i].Carte[x-1, y+1].cloud = false;
			}
			if (j == 7 & x + 1 < max-1 & y - 1 >= 0)
			{
				Choix.listeJoueurs[i].Carte[x+1, y-1].cloud = false;
			}
		}
	}

	public override void _Input(InputEvent @event)
	{
		if (Input.IsActionPressed("click") && @event is InputEventMouseMotion eventMouseMotion)
		{
			var rel_x = eventMouseMotion.Relative.x;
			var rel_y = eventMouseMotion.Relative.y;

			var campos = MaCamera.Position ;

			campos.x -= rel_x ;
			campos.y -= rel_y ;

			MaCamera.Position = campos;
		}

		else if (Input.IsActionJustReleased("click"))
		{
			var mouse_coord = GetViewport().GetMousePosition();

			matrice_index = Carte.WorldToMap(GetViewport().GetMousePosition() + MaCamera.Position - comp) - bug;
			Load.RectPosition = AnciennePosition;
			
			if (((matrice_index.x >= 0 && matrice_index.x <= max - 1) && (matrice_index.y >= 0 && matrice_index.y <= max - 1)) && (Choix.listeJoueurs[index].Carte[(int)matrice_index.x, (int)matrice_index.y].cloud == false))
			{
				
				if(EnDeplacement == true)
				{
					if (Enemie((int)matrice_index.x, (int)matrice_index.y))
					{
						for (int i = 0; i < 3; i++)
						{
							if(i != index && Choix.listeJoueurs[i].Carte[(int)matrice_index.x, (int)matrice_index.y].soldat)
							{
								Choix.listeJoueurs[i].Carte[(int)matrice_index.x, (int)matrice_index.y].soldat = false;
							}						
						}
						Deplacement_Retire();
					}
					if(Choix.listeJoueurs[index].Carte[(int)matrice_index.x, (int)matrice_index.y].marked == true)
					{
						Deplacement_Retire();
					}
				}
				else
				{
					if (Choix.listeJoueurs[index].Carte[(int)matrice_index.x, (int)matrice_index.y].soldat == true && Choix.listeJoueurs[index].Carte[(int)matrice_index.x, (int)matrice_index.y].d.nbDeplacement == 1)
					{
						AjouteDeplacement(Choix.listeJoueurs[index], index , (int)matrice_index.x, (int)matrice_index.y, false);
						AnciennePositionSoldat.x = (int)matrice_index.x;
						AnciennePositionSoldat.y = (int)matrice_index.y;
						EnDeplacement = true;
					}
					else
					{
						AnciennePositionSoldat.x = (int)matrice_index.x;
						AnciennePositionSoldat.y = (int)matrice_index.y;
						Bouton_Batiment();
					}
				}
			}
			
		}

		if (Input.IsActionJustPressed("Menu"))
		{
			_on_Back_pressed();
		}

		if (Input.IsActionJustReleased("Tours"))
		{
			_on_Passez_Tour_pressed();
		}

		if (Input.IsActionJustReleased("Aptitude"))
		{
			_on_Aptitude_pressed();
		}
	}

	public void Deplacement_Retire()
	{
		EnDeplacement = false;
		Choix.listeJoueurs[index].Carte[(int)matrice_index.x, (int)matrice_index.y].soldat = true;
		Choix.listeJoueurs[index].Carte[(int)matrice_index.x, (int)matrice_index.y].d = new Guerrier();
		//SoldatAffichage.SetCell((int)matrice_index.x, (int)matrice_index.y,0,false,false,false,null);
		Choix.listeJoueurs[index].Carte[(int)matrice_index.x, (int)matrice_index.y].d.nbDeplacement -= 1;
		Choix.listeJoueurs[index].Carte[(int)AnciennePositionSoldat.x, (int)AnciennePositionSoldat.y].soldat = false;
		Choix.listeJoueurs[index].Carte[(int)AnciennePositionSoldat.x, (int)AnciennePositionSoldat.y].d = null;
		SoldatAffichage.SetCell((int)AnciennePositionSoldat.x, (int)AnciennePositionSoldat.y,-1,false,false,false,null);
		RetireNuage(Choix.listeJoueurs[index],index,(int)matrice_index.x, (int)matrice_index.y);
		AjouteDeplacement(Choix.listeJoueurs[index], index , (int)AnciennePositionSoldat.x, (int)AnciennePositionSoldat.y, true);
		Build(Choix.terrain,Choix.listeJoueurs[index]);
	}

	public void Bouton_Batiment()
	{
		if (Choix.listeJoueurs[index].nombre_de_batiment < 6)
		{
			if (Choix.terrain[(int)matrice_index.x, (int)matrice_index.y].type == Cell.BiomeType.PLAINE & Choix.listeJoueurs[index].aptitude.Ferme == true)
			{
				Ferme.RectPosition = NouvellePosition;
				Load = Ferme;
			}
			if (Choix.terrain[(int)matrice_index.x, (int)matrice_index.y].type == Cell.BiomeType.MONTAGNE & Choix.listeJoueurs[index].aptitude.Mine == true)
			{
				Mine.RectPosition = NouvellePosition;
				Load = Mine;							
			}
			if (Choix.terrain[(int)matrice_index.x, (int)matrice_index.y].type == Cell.BiomeType.FORET & Choix.listeJoueurs[index].aptitude.Scierie == true)
			{
				Scierie.RectPosition = NouvellePosition;
				Load = Scierie;								
			}
			if (new Vector2((int)matrice_index.x, (int)matrice_index.y) == Choix.listeJoueurs[index].capitalePOSITION && (Choix.listeJoueurs[index].or > 10 && Choix.listeJoueurs[index].nourriture > 10))
			{
				Soldat.RectPosition = NouvellePosition;
				Load = Soldat;
			}
		}
		if (Choix.listeJoueurs[index].Carte[(int)matrice_index.x, (int)matrice_index.y].mine | Choix.listeJoueurs[index].Carte[(int)matrice_index.x, (int)matrice_index.y].ferme | Choix.listeJoueurs[index].Carte[(int)matrice_index.x, (int)matrice_index.y].scierie)
		{
			Retire.RectPosition = NouvellePosition;
			Load = Retire;
		}
	}
	
	public void AjouteDeplacement(NouvellePartie.Joueur joueur, int i , int x, int y, bool res)
	{
		for (int j = 0; j < 4; j++)
		{
			if (((j == 0 & x > 0) & (Choix.listeJoueurs[i].Carte[x-1, y].cloud == false)) && (Choix.terrain[x-1, y].type != Cell.BiomeType.MER && new Vector2(x-1, y) != Choix.listeJoueurs[index].capitalePOSITION))
			{
				if (res)
				{
					Deplacement.SetCell(x-1,y,-1,false,false,false,null);
					Choix.listeJoueurs[i].Carte[x-1, y].marked = false;
				}
				else
				{
					if (Enemie(x-1,y))
					{
						Deplacement.SetCell(x-1,y,2,false,false,false,null);
						Choix.listeJoueurs[i].Carte[x-1,y].marked = true;
					}
					else
					{
						if(Choix.listeJoueurs[i].Carte[x-1,y].soldat == false)
						{
							Deplacement.SetCell(x-1,y,0,false,false,false,null);
							Choix.listeJoueurs[i].Carte[x-1,y].marked = true;
						}						
					}
				}
			}
			if (((j == 1 & y > 0) & (Choix.listeJoueurs[i].Carte[x, y-1].cloud == false)) && (Choix.terrain[x, y-1].type != Cell.BiomeType.MER && new Vector2(x, y-1) != Choix.listeJoueurs[index].capitalePOSITION))
			{
				if (res)
				{
					Deplacement.SetCell(x,y-1,-1,false,false,false,null);
					Choix.listeJoueurs[i].Carte[x, y-1].marked = false;
				}
				else
				{
					if (Enemie(x,y-1))
					{
						Deplacement.SetCell(x,y-1,2,false,false,false,null);
						Choix.listeJoueurs[i].Carte[x,y-1].marked = true;
					}
					else
					{
						if(Choix.listeJoueurs[i].Carte[x, y-1].soldat == false)
						{
							Deplacement.SetCell(x,y-1,0,false,false,false,null);
							Choix.listeJoueurs[i].Carte[x, y-1].marked = true;
						}						
					}
				}
			}
			if (((j == 2 & x < max-1) & (Choix.listeJoueurs[i].Carte[x+1, y].cloud == false)) && (Choix.terrain[x+1, y].type != Cell.BiomeType.MER && new Vector2(x+1, y) != Choix.listeJoueurs[index].capitalePOSITION))
			{
				if (res)
				{
					Deplacement.SetCell(x+1,y,-1,false,false,false,null);
					Choix.listeJoueurs[i].Carte[x+1, y].marked = false;
				}
				else
				{
					if (Enemie(x+1,y))
					{
						Deplacement.SetCell(x+1,y,2,false,false,false,null);
						Choix.listeJoueurs[i].Carte[x+1,y].marked = true;
					}
					else
					{
						if(Choix.listeJoueurs[i].Carte[x+1,y].soldat == false)
						{
							Deplacement.SetCell(x+1,y,0,false,false,false,null);
							Choix.listeJoueurs[i].Carte[x+1,y].marked = true;
						}						
					}
				}
			}
			if (((j == 3 & y < max-1) & (Choix.listeJoueurs[i].Carte[x, y+1].cloud == false)) && (Choix.terrain[x, y+1].type != Cell.BiomeType.MER && new Vector2(x, y+1) != Choix.listeJoueurs[index].capitalePOSITION))
			{
				if (res)
				{
					Deplacement.SetCell(x,y+1,-1,false,false,false,null);
					Choix.listeJoueurs[i].Carte[x, y+1].marked = false;
				}
				else
				{
					if (Enemie(x,y+1))
					{
						Deplacement.SetCell(x,y+1,2,false,false,false,null);
						Choix.listeJoueurs[i].Carte[x, y+1].marked = true;
					}
					else
					{
						if(Choix.listeJoueurs[i].Carte[x, y+1].soldat == false)
						{
							Deplacement.SetCell(x,y+1,0,false,false,false,null);
							Choix.listeJoueurs[i].Carte[x, y+1].marked = true;
						}
					}
				}
			}
		}
	}

	public bool Enemie(int x, int y)
	{
		bool res = false;

		for (int i = 0; i < Choix.listeJoueurs.Length; i++)
		{
			if(i != index && Choix.listeJoueurs[i].Carte[x,y].soldat)
			{
				res = true;
			}
		}

		return res;
	}

	public void Bot(NouvellePartie.Joueur joueur)
	{
		Add_Aptitude();
		Add_Building();
		Add_Soldat();
		Deplacement_Soldat();
	}

	public void Add_Aptitude()
	{
		int plaine = 0;
		int foret = 0;
		int montagne = 0;
		for (int i = 0; i < max; i++)
		{
			for (int j = 0; j < max; j++)
			{
				if (Choix.listeJoueurs[index].Carte[i,j].cloud == false && Choix.terrain[i,j].type == Cell.BiomeType.PLAINE)
				{
					plaine += 1;
				}

				if (Choix.listeJoueurs[index].Carte[i,j].cloud == false && Choix.terrain[i,j].type == Cell.BiomeType.FORET)
				{ 
					foret += 1;
				}

				if (Choix.listeJoueurs[index].Carte[i,j].cloud == false && Choix.terrain[i,j].type == Cell.BiomeType.MONTAGNE)
				{
					montagne += 1;
				}
			}
		}
		if ((plaine > foret && plaine > montagne) && Choix.listeJoueurs[index].aptitude.Ferme3 == false)
		{
			Get_Ferme();
		}
		if ((foret > plaine && foret > montagne) && Choix.listeJoueurs[index].aptitude.Scierie3 == false)
		{
			Get_Scierie();
		}
		if ((montagne > foret && montagne > plaine) && Choix.listeJoueurs[index].aptitude.Mine3 == false)
		{
			Get_Mine();
		}
		else
		{
			if (Choix.listeJoueurs[index].aptitude.Capitale3 == false)
			{
				Get_Capitale();
			}
		}
	}

	public void Get_Ferme()
	{
		if (Choix.listeJoueurs[index].aptitude.Ferme == false && Choix.listeJoueurs[index].bois > 40)
		{
			Choix.listeJoueurs[index].aptitude.Ferme = true;
		}
		if (Choix.listeJoueurs[index].aptitude.Ferme2 == false && Choix.listeJoueurs[index].bois > 80)
		{
			Choix.listeJoueurs[index].aptitude.Ferme2 = true;
		}
		else
		{
			if (Choix.listeJoueurs[index].bois > 120)
			{
				Choix.listeJoueurs[index].aptitude.Ferme3 = true;
			}
		}
	}

	public void Get_Scierie()
	{
		if (Choix.listeJoueurs[index].aptitude.Scierie == false && Choix.listeJoueurs[index].or > 30)
		{
			Choix.listeJoueurs[index].aptitude.Scierie = true;
		}
		if (Choix.listeJoueurs[index].aptitude.Scierie2 == false && Choix.listeJoueurs[index].or > 90)
		{
			Choix.listeJoueurs[index].aptitude.Scierie2 = true;
		}
		else
		{
			if (Choix.listeJoueurs[index].or > 180)
			{
				Choix.listeJoueurs[index].aptitude.Scierie3 = true;
			}
		}
	}

	public void Get_Mine()
	{
		if (Choix.listeJoueurs[index].aptitude.Mine == false && Choix.listeJoueurs[index].bois > 50)
		{
			Choix.listeJoueurs[index].aptitude.Mine = true;
		}
		if (Choix.listeJoueurs[index].aptitude.Mine2 == false && Choix.listeJoueurs[index].bois > 150)
		{
			Choix.listeJoueurs[index].aptitude.Mine2 = true;
		}
		else
		{
			if (Choix.listeJoueurs[index].bois > 225)
			{
				Choix.listeJoueurs[index].aptitude.Mine3 = true;
			}
		}
	}

	public void Get_Capitale()
	{
		if (Choix.listeJoueurs[index].aptitude.Ferme == false && (Choix.listeJoueurs[index].fer > 50 &&  Choix.listeJoueurs[index].bois > 100))
		{
			Choix.listeJoueurs[index].aptitude.Ferme = true;
		}
		if (Choix.listeJoueurs[index].aptitude.Ferme2 == false && (Choix.listeJoueurs[index].fer > 150 &&  Choix.listeJoueurs[index].bois > 400))
		{
			Choix.listeJoueurs[index].aptitude.Ferme2 = true;
		}
		else
		{
			if ((Choix.listeJoueurs[index].fer > 300 &&  Choix.listeJoueurs[index].bois > 800))
			{
				Choix.listeJoueurs[index].aptitude.Ferme3 = true;
			}
		}
	}

	public void Add_Building()
	{
		for (int i = 0; i < max; i++)
		{
			for (int j = 0; j < max; j++)
			{
				if (Choix.listeJoueurs[index].Carte[i,j].cloud == false)
				{
					AnciennePositionSoldat.x = i;
					AnciennePositionSoldat.y = j;
					
					if (Choix.terrain[i,j].type == Cell.BiomeType.PLAINE && Choix.listeJoueurs[index].nombre_de_batiment < 6)
					{
						_on_Ferme_pressed();
					}
					if (Choix.terrain[i,j].type == Cell.BiomeType.FORET && Choix.listeJoueurs[index].nombre_de_batiment < 6)
					{
						_on_Scierie_pressed();
					}
					if (Choix.terrain[i,j].type == Cell.BiomeType.MONTAGNE && Choix.listeJoueurs[index].nombre_de_batiment < 6)
					{
						_on_Mine_pressed();
					}
				}
			}
		}
	}

	public void Add_Soldat()
	{
		if (tour % 2 == 0 && Choix.listeJoueurs[index].Carte[(int)Choix.listeJoueurs[index].capitalePOSITION.x, (int)Choix.listeJoueurs[index].capitalePOSITION.y].soldat == false && Choix.listeJoueurs[index].or > 10)
		{
			AnciennePositionSoldat.x = (int)Choix.listeJoueurs[index].capitalePOSITION.x;
			AnciennePositionSoldat.y = (int)Choix.listeJoueurs[index].capitalePOSITION.y;

			_on_Soldat_pressed();
		}
	}
	
	public void Deplacement_Soldat()
	{
		Random rnd = new Random();
		int aleatoire;
		for (int i = 0; i < max; i++)
		{
			for (int j = 0; j < max; j++)
			{
				if (Choix.listeJoueurs[index].Carte[i,j].soldat)
				{
					aleatoire  = rnd.Next(0, 3);
					if (aleatoire == 0 && i+1 < max - 1 && Choix.terrain[i+1, j].type != Cell.BiomeType.MER)
					{
						Bot_Deplacement(i, j, i+1, j);
						RetireNuage(Choix.listeJoueurs[index],index,i+1,j);
					}
					if (aleatoire == 1 && j+1 < max - 1 && Choix.terrain[i, j+1].type != Cell.BiomeType.MER)
					{
						Bot_Deplacement(i, j, i, j+1);
						RetireNuage(Choix.listeJoueurs[index],index,i,j+1);
					}
					if (aleatoire == 2 && i-1 > 0 && Choix.terrain[i-1, j].type != Cell.BiomeType.MER)
					{
						Bot_Deplacement(i, j, i-1, j);
						RetireNuage(Choix.listeJoueurs[index],index,i-1,j);
					}
					if (aleatoire == 3 && j-1 > 0 && Choix.terrain[i, j-1].type != Cell.BiomeType.MER)
					{
						Bot_Deplacement(i, j, i, j-1);
						RetireNuage(Choix.listeJoueurs[index],index,i,j-1);
					}
				}
			}
		}
	}

	public void Bot_Deplacement(int x, int y, int new_x, int new_y)
	{
		Choix.listeJoueurs[index].Carte[new_x,new_y].soldat = true;
		Choix.listeJoueurs[index].Carte[new_x,new_y].d = new Guerrier();
		SoldatAffichage.SetCell(new_x,new_y,0,false,false,false,null);

		Choix.listeJoueurs[index].Carte[x,y].soldat = false;
		Choix.listeJoueurs[index].Carte[x,y].d = null;
		SoldatAffichage.SetCell(x,y,-1,false,false,false,null);
	}

	public int UpgradeFerme()
	{
		int ind = 0;
		int Nourr = prodFerme[ind];
		if (Choix.listeJoueurs[Main.index].aptitude.Ferme2 == true)
		{
			Nourr = prodFerme[ind + 1];
		}
		if (Choix.listeJoueurs[Main.index].aptitude.Ferme3 == true)
		{
			Nourr = prodFerme[ind + 2];
		}
		return Nourr;
	}
	
	public int UpgradeMine()
	{
		int ind = 0;
		int Fer = prodMine[ind];
		if (Choix.listeJoueurs[Main.index].aptitude.Mine2 == true)
		{
			Fer = prodMine[ind + 1];
		}
		if (Choix.listeJoueurs[Main.index].aptitude.Mine3 == true)
		{
			Fer = prodMine[ind + 2];
		}
		return Fer;
	}
	
	public int UpgradeScierie()
	{
		int ind = 0;
		int Bois = prodScierie[ind];
		if (Choix.listeJoueurs[Main.index].aptitude.Scierie2 == true)
		{
			 Bois = prodScierie[ind + 1];
		}
		if (Choix.listeJoueurs[Main.index].aptitude.Scierie3 == true)
		{
			Bois = prodScierie[ind + 2];
		}
		return Bois;
	}
	
	
	public int UpgradeCapitale()
	{
		int ind = 0;
		int Or = prodCapitale[ind];
		if (Choix.listeJoueurs[Main.index].aptitude.Capitale2 == true)
		{
			Or = prodCapitale[ind + 1];
		}
		if (Choix.listeJoueurs[Main.index].aptitude.Capitale3 == true)
		{
			Or = prodCapitale[ind + 2];
		}
		return Or;
	}
	
	
	public void Production()
	{
		Choix.listeJoueurs[index].or += UpgradeCapitale();
		
		for (int i = 0; i < max; i++)
		{
			for (int j = 0; j < max; j++)
			{
				if (Choix.listeJoueurs[index].Carte[i,j].ferme)
				{
					Choix.listeJoueurs[index].nourriture += UpgradeFerme();
				}
				
				if (Choix.listeJoueurs[index].Carte[i,j].mine)
				{
					Choix.listeJoueurs[index].fer += UpgradeMine();
				}
				
				if (Choix.listeJoueurs[index].Carte[i,j].scierie)
				{
					Choix.listeJoueurs[index].bois += UpgradeScierie();
				}
				
			}
		}
	}
	
	
	private void _on_Passez_Tour_pressed()
	{
		if (EnDeplacement == false)
		{
			index += 1;
			if (index > 3)
				{
					index = 0;
					tour += 1;
				}
			while (Choix.listeJoueurs[index].statu == NouvellePartie.Joueur.status.BOT)
			{
				Bot(Choix.listeJoueurs[index]);
				Production();
				index += 1;
				if (index > 3)
				{
					index = 0;
					tour += 1;
				}
			}
			Production();
			Race.TextureNormal = Choix.race[index];
			Nom.Text = Choix.listeJoueurs[index].name;
			Build(Choix.terrain, Choix.listeJoueurs[index]);
			MaCamera.Position = Carte.MapToWorld(Choix.listeJoueurs[index].capitalePOSITION + CameraBug);
			Load.RectPosition = AnciennePosition;
			for (int i = 0; i < max; i++)
			{
				for (int j = 0; j < max; j++)
				{
					if (Choix.listeJoueurs[index].Carte[i,j].d != null)
					{
						Choix.listeJoueurs[index].Carte[i,j].d.nbDeplacement = 1;
					}
				}
			}
		}
	}

	private void _on_Ferme_pressed()
	{
		Choix.listeJoueurs[index].nombre_de_batiment += 1;
		Choix.listeJoueurs[index].Carte[(int)AnciennePositionSoldat.x, (int)AnciennePositionSoldat.y].ferme = true;
		Carte.SetCell((int)AnciennePositionSoldat.x, (int)AnciennePositionSoldat.y,8,false,false,false,null);
		Choix.terrain[(int)AnciennePositionSoldat.x, (int)AnciennePositionSoldat.y].type = Cell.BiomeType.FERME;
	}

	private void _on_Mine_pressed()
	{
		Choix.listeJoueurs[index].nombre_de_batiment += 1;
		Choix.listeJoueurs[index].Carte[(int)AnciennePositionSoldat.x, (int)AnciennePositionSoldat.y].mine = true;
		Carte.SetCell((int)AnciennePositionSoldat.x, (int)AnciennePositionSoldat.y,2,false,false,false,null);
		Choix.terrain[(int)AnciennePositionSoldat.x, (int)AnciennePositionSoldat.y].type = Cell.BiomeType.MINE;
	}

	private void _on_Scierie_pressed()
	{
		Choix.listeJoueurs[index].nombre_de_batiment += 1;
		Choix.listeJoueurs[index].Carte[(int)AnciennePositionSoldat.x, (int)AnciennePositionSoldat.y].scierie = true;
		Carte.SetCell((int)AnciennePositionSoldat.x, (int)AnciennePositionSoldat.y,5,false,false,false,null);
		Choix.terrain[(int)AnciennePositionSoldat.x, (int)AnciennePositionSoldat.y].type = Cell.BiomeType.SCIERIE;
	}

	private void _on_Retire_pressed()
	{
		if (Choix.listeJoueurs[index].Carte[(int)AnciennePositionSoldat.x, (int)AnciennePositionSoldat.y].ferme)
		{
			Choix.terrain[(int)AnciennePositionSoldat.x, (int)AnciennePositionSoldat.y].type = Cell.BiomeType.PLAINE;
			Choix.listeJoueurs[index].Carte[(int)AnciennePositionSoldat.x, (int)AnciennePositionSoldat.y].ferme = false;
			Carte.SetCell((int)AnciennePositionSoldat.x, (int)AnciennePositionSoldat.y,4,false,false,false,null);
		}
		if (Choix.listeJoueurs[index].Carte[(int)AnciennePositionSoldat.x, (int)AnciennePositionSoldat.y].mine)
		{
			Choix.terrain[(int)AnciennePositionSoldat.x, (int)AnciennePositionSoldat.y].type = Cell.BiomeType.MONTAGNE;
			Choix.listeJoueurs[index].Carte[(int)AnciennePositionSoldat.x, (int)AnciennePositionSoldat.y].mine = false;
			Carte.SetCell((int)AnciennePositionSoldat.x, (int)AnciennePositionSoldat.y,3,false,false,false,null);
		}
		if (Choix.listeJoueurs[index].Carte[(int)AnciennePositionSoldat.x, (int)AnciennePositionSoldat.y].scierie)
		{
			Choix.terrain[(int)AnciennePositionSoldat.x, (int)AnciennePositionSoldat.y].type = Cell.BiomeType.FORET;
			Choix.listeJoueurs[index].Carte[(int)AnciennePositionSoldat.x, (int)AnciennePositionSoldat.y].scierie = false;
			Carte.SetCell((int)AnciennePositionSoldat.x, (int)AnciennePositionSoldat.y,0,false,false,false,null);
		}
		Choix.listeJoueurs[index].nombre_de_batiment -= 1;
	}

	private void _on_Aptitude_pressed()
	{
		if (EnDeplacement == false)
		{
			GetTree().ChangeScene("res://Scenes/Aptitude.tscn");
		}
	}

	private void _on_Soldat_pressed()
	{
		Choix.listeJoueurs[index].or -= 10;
		Choix.listeJoueurs[index].nourriture -= 10;
		Choix.listeJoueurs[index].Carte[(int)AnciennePositionSoldat.x, (int)AnciennePositionSoldat.y].soldat = true;
		Choix.listeJoueurs[index].Carte[(int)AnciennePositionSoldat.x, (int)AnciennePositionSoldat.y].d = new Guerrier();
		SoldatAffichage.SetCell((int)AnciennePositionSoldat.x, (int)AnciennePositionSoldat.y,0,false,false,false,null);
	}

	private void _on_Back_pressed()
	{
		Choix.Player1 = new NouvellePartie.Joueur("1",NouvellePartie.Joueur.classe.NAIN,25, NouvellePartie.Joueur.status.NONE);
		Choix.Player2 = new NouvellePartie.Joueur("2",NouvellePartie.Joueur.classe.NAIN,25, NouvellePartie.Joueur.status.NONE);
		Choix.Player3 = new NouvellePartie.Joueur("3",NouvellePartie.Joueur.classe.NAIN,25, NouvellePartie.Joueur.status.NONE);
		Choix.Player4 = new NouvellePartie.Joueur("4",NouvellePartie.Joueur.classe.NAIN,25, NouvellePartie.Joueur.status.NONE);

		Choix.listeJoueurs = new[] {Choix.Player1, Choix.Player2, Choix.Player3 , Choix.Player4};

		tour = 1;
		index = 0;

		GetTree().ChangeScene("res://Scenes/Play Menu.tscn");
	}

	public void Defaite()
	{
		GetTree().ChangeScene("res://Scenes/Defaite.tscn");
	}

	public void Victoire()
	{
		GetTree().ChangeScene("res://Scenes/Victoire.tscn");
	}

	public override void _Process(float delta)
	{
		FPS.Text = ("FPS: " + Convert.ToString(Engine.GetFramesPerSecond()));
		Tour.Text = "Tours: " + Convert.ToString(tour);

		OrText.Text =  "x " + Convert.ToString(Choix.listeJoueurs[index].or);
		BoisText.Text = "x " + Convert.ToString(Choix.listeJoueurs[index].bois);
		FerText.Text = "x " + Convert.ToString(Choix.listeJoueurs[index].fer);
		NourritureText.Text = "x " + Convert.ToString(Choix.listeJoueurs[index].nourriture);

		if (tour >= 100)
		{
			Defaite();
		}

		for (int i = 0; i < 3; i++)
		{
			if (i != index && Choix.listeJoueurs[index].Carte[(int)Choix.listeJoueurs[i].capitalePOSITION.x, (int)Choix.listeJoueurs[i].capitalePOSITION.y].soldat == true)
			{
				Victoire();
			}
		}
	}
}
