using System.Reflection.Metadata;
using System.Runtime.Serialization.Formatters.Binary;

namespace Zyzgak_McQueenoid
{
    [Serializable]
    public class PotatoEngine
    {
        public List<Obstacle> Obstacles { get; set; }
        public Paletka tinyboard { get; set; }
        public Ball tinyball { get; set; }
        public List<Ball> tinyballs { get; set; }    
        public MapaGry Map { get; set; }
        //public EntityDisplayKeyMove[] Entities { get; set; }
        public int OldPanelWidth { get; set; }
        public int OldPanelHeight { get; set; }
        public int PlayerLives { get; set; }
        public Bonuses Bonus { get; set; }

        [NonSerialized]
        public double currentResMultiplyWidth = 1;

        [NonSerialized]
        public double currentResMultiplyHeight = 1;

        [NonSerialized]
        public bool Menu = true;

        [NonSerialized]
        public int resumingcount = -1;
        public int currentlevel { get; set; }
        public int highscore { get; set; }
        public int score { get; set; }
        public PotatoEngine(Panel MainPanel)
        {
            Obstacles = new();
            Map = new MapaGry(MainPanel.Height, MainPanel.Width);
            tinyboard = new Paletka(0, 0, 15, 15, Color.Blue, 30, 150, Map);
            tinyball = new Ball(tinyboard.locationX+(tinyboard.EntitySizeWidth/2), tinyboard.locationY-(tinyboard.EntitySizeHeight), 15, -15, Color.SpringGreen, Map, 20, 20, tinyboard, true);
            // locationX = paddle.locationX + (paddle.EntitySizeWidth / 2);
            //locationY = paddle.locationY - (paddle.EntitySizeHeight);
            tinyballs = new();
            tinyballs.Add(tinyball);
            tinyballs[0] = tinyball;
            //Entities = new EntityDisplayKeyMove[2];
            //Entities[0] = tinyball; Entities[1] = tinyboard;
            Bonus = new Bonuses(-25,-25,0,10,Color.MediumPurple,Map, 40, 40, tinyboard, tinyballs);
            currentlevel = 3;
        }
        public PotatoEngine(Paletka tinyboard, Ball tinyball, MapaGry Map, EntityDisplayKeyMove[] Entities)
        {
            this.Obstacles = new();
            this.tinyboard = tinyboard;
            this.tinyball = tinyball;
            this.Map = Map;
            //this.Entities = Entities;
            this.currentlevel = 1;
            this.highscore = 0;
            this.score = 0;
        }
        public bool checkLeveComplete()
        {
            foreach (var item in Obstacles)
                if (item.locationX != 0 && item.locationY != 0)
                    return false;
            return true;
        }
        public void CheckBallStatusAndRemoveFallenOnes()
        {
            int i = 0;
            foreach(var item in tinyballs)
            {
                if (item.IsMainBall == false && item.locationX == -100 && item.locationY == -100 && item.Vx == 0 && item.Vy == 0)
                    tinyballs.RemoveAt(i);
                i++;
            }
        }
        public void RemoveAdditionalBallsAfterLevelCompletes()
        {
            int i = 0;
            foreach (var item in tinyballs)
            {
                if (item.IsMainBall == false)
                {
                    item.locationX = -100; item.locationY = -100; item.Vx = 0; item.Vy = 0;
                }
            }
        }
        public void ForceLevelEnd()
        {
            foreach (var item in Obstacles)
            {
                item.locationX = 0;
                item.locationY = 0;
            }
                
        }
        public List<Obstacle> setupObstaclesLevel(double resizewidth, double resizeheight, int LEVEL, Panel panelito)  //prefixy pod 920:1280 - panel 870:1000 X:Y
        {
            Obstacles.Clear();
            if (LEVEL == 1)
            {
                Obstacles.Add(new Obstacle(100 * (int)resizewidth, 200 * (int)resizeheight, 0, 0, Color.YellowGreen, Map, 50 * (int)resizeheight, 100 * (int)resizewidth, 4)); // X i Y
                Obstacles.Add(new Obstacle(300 * (int)resizewidth, 200 * (int)resizeheight, 0, 0, Color.YellowGreen, Map, 50 * (int)resizeheight, 100 * (int)resizewidth, 4));
                Obstacles.Add(new Obstacle(500 * (int)resizewidth, 200 * (int)resizeheight, 0, 0, Color.YellowGreen, Map, 50 * (int)resizeheight, 100 * (int)resizewidth, 4));
                Obstacles.Add(new Obstacle(700 * (int)resizewidth, 200 * (int)resizeheight, 0, 0, Color.YellowGreen, Map, 50 * (int)resizeheight, 100 * (int)resizewidth, 4));
            }
            else if(LEVEL == 2)
            {
                Obstacles.Add(new Obstacle(50 * (int)resizewidth, 100 * (int)resizeheight, 0, 0, Color.YellowGreen, Map, 40 * (int)resizeheight, 80 * (int)resizewidth, 4));
                Obstacles.Add(new Obstacle(100 * (int)resizewidth, 200 * (int)resizeheight, 0, 0, Color.YellowGreen, Map, 40 * (int)resizeheight, 80 * (int)resizewidth, 4));
                Obstacles.Add(new Obstacle(150 * (int)resizewidth, 100 * (int)resizeheight, 0, 0, Color.YellowGreen, Map, 40 * (int)resizeheight, 80 * (int)resizewidth, 4));
                Obstacles.Add(new Obstacle(200 * (int)resizewidth, 200 * (int)resizeheight, 0, 0, Color.YellowGreen, Map, 40 * (int)resizeheight, 80 * (int)resizewidth, 4));
                Obstacles.Add(new Obstacle(250 * (int)resizewidth, 100 * (int)resizeheight, 0, 0, Color.YellowGreen, Map, 40 * (int)resizeheight, 80 * (int)resizewidth, 4));
                Obstacles.Add(new Obstacle(300 * (int)resizewidth, 200 * (int)resizeheight, 0, 0, Color.YellowGreen, Map, 40 * (int)resizeheight, 80 * (int)resizewidth, 4));
                Obstacles.Add(new Obstacle(350 * (int)resizewidth, 100 * (int)resizeheight, 0, 0, Color.YellowGreen, Map, 40 * (int)resizeheight, 80 * (int)resizewidth, 4));
                Obstacles.Add(new Obstacle(400 * (int)resizewidth, 200 * (int)resizeheight, 0, 0, Color.YellowGreen, Map, 40 * (int)resizeheight, 80 * (int)resizewidth, 4));
                Obstacles.Add(new Obstacle(450 * (int)resizewidth, 100 * (int)resizeheight, 0, 0, Color.YellowGreen, Map, 40 * (int)resizeheight, 80 * (int)resizewidth, 4));
                Obstacles.Add(new Obstacle(500 * (int)resizewidth, 200 * (int)resizeheight, 0, 0, Color.YellowGreen, Map, 40 * (int)resizeheight, 80 * (int)resizewidth, 4));
            }
            else if (LEVEL == 3)
            {
                int tmp = panelito.Height / 5/2;
                int tmp2 = panelito.Width / 12;
                for(int i = 0; i < 7; i++)
                    for(int j = 0; j < 7; j++)
                        Obstacles.Add(new Obstacle(i*tmp+35, j*tmp2+35, 0,0, Color.DarkOrange,Map,tmp2,tmp,1));
            }
            else if(LEVEL >= 4) 
            {
                int listLENGTH = 0;
                for (int i = 0; i < LEVEL; i++)
                {
                    Random c1 = new Random();
                    bool CheckIfObstacleFitsAndDoesNotCollide = false;
                    int SizeHeight = c1.Next(80, 100); //80 100
                    int SizeWidth = c1.Next(120, 200); //120 200
                    int locationX = c1.Next(0, Map.WidthOfMap - SizeWidth + 1);
                    int locationY = c1.Next(0, Map.HeightOfMap - 700);
                    int counter = 0;
                    while (CheckIfObstacleFitsAndDoesNotCollide == false)
                    {
                        counter = 0;
                        SizeHeight = c1.Next(80, 100); //80 100
                        SizeWidth = c1.Next(120, 200); //120 200
                        locationX = c1.Next(0, Map.WidthOfMap - SizeWidth + 1);
                        locationY = c1.Next(0, Map.HeightOfMap - 700);
                        foreach (var item in Obstacles)
                        {
                            if (!((locationX >= item.locationX && locationX <= item.locationX + item.EntitySizeWidth && locationY >= item.locationY && locationY <= item.locationY + item.EntitySizeHeight) || (locationX + SizeWidth >= item.locationX && locationX + SizeWidth <= item.locationX + item.EntitySizeWidth && locationY + SizeHeight >= item.locationY && locationY + SizeHeight <= item.locationY + item.EntitySizeHeight)))
                                counter++;
                            if (counter == listLENGTH)
                                CheckIfObstacleFitsAndDoesNotCollide = true;
                        }
                        if (counter == 0 && i == 0)
                            CheckIfObstacleFitsAndDoesNotCollide = true;
                    }
                    Obstacles.Add(new Obstacle(locationX, locationY, 0, 0, Color.YellowGreen, Map, SizeHeight, SizeWidth, 4));
                    listLENGTH++;
                }
            }
            return Obstacles;
        }
        public void LoadTheGame()
        {
            Stream s = new FileStream("save", FileMode.Open);
            BinaryFormatter bw = new BinaryFormatter();
            Obstacles = (List<Obstacle>)bw.Deserialize(s);
            tinyboard = (Paletka)bw.Deserialize(s);
            tinyball = (Ball)bw.Deserialize(s);
            Map = (MapaGry)bw.Deserialize(s);
            //Entities = (EntityDisplayKeyMove[])bw.Deserialize(s);
            OldPanelHeight = (int)bw.Deserialize(s);
            OldPanelWidth = (int)bw.Deserialize(s);
            PlayerLives = (int)bw.Deserialize(s);
            currentlevel = (int)bw.Deserialize(s);
            highscore = (int)bw.Deserialize(s);
            score = (int)bw.Deserialize(s);
            //Entities[0] = tinyball; Entities[1] = tinyboard;
            tinyballs.Clear();
            tinyballs.Add(tinyball);
            tinyball.paddle = tinyboard;
            s.Close();
        }
        public void SaveTheGame()
        {
            Stream s = new FileStream("save", FileMode.Create);
            BinaryFormatter bw = new BinaryFormatter();
            bw.Serialize(s, Obstacles);
            bw.Serialize(s, tinyboard);
            bw.Serialize(s, tinyball);
            bw.Serialize(s, Map);
            bw.Serialize(s, OldPanelHeight);
            bw.Serialize(s, OldPanelWidth);
            bw.Serialize(s, PlayerLives);
            bw.Serialize(s, currentlevel);
            bw.Serialize(s, highscore);
            bw.Serialize(s, score);
            s.Close();
        }
        public void resethegame()
        {
            tinyboard.PreparePaletkaToTheLevel();
            tinyball.followpaddle = true;
            currentlevel = 1;
            PlayerLives = 3;
            score = 0;
        }
    }
}
/*
            public void load3(IMoveObject[] Figury, Stream s, BinaryFormatter bf)
            {
                IMoveObject[] checky = (IMoveObject[])bf.Deserialize(s);
                for (int i = 0; i < Figury.Length; i++)
                    Figury[i] = checky[i];
                s.Close();
            }
            public void Save3(IMoveObject[] Figury)
            {
                Stream s = new FileStream("save", FileMode.Create);
                BinaryFormatter bw = new BinaryFormatter();
                bw.Serialize(s, Figury);
                s.Close();
            }
            public void jsonreader(IMoveObject[] mbappe, int size)
            {
                Figure[] cisco = new Figure[size];
                for(int i = 0; i < cisco.Length; i++)
                    cisco[i] = (Figure)mbappe[i];
                var options = new JsonSerializerOptions { WriteIndented = true };
                string json = JsonSerializer.Serialize(cisco, options);
                //MessageBox.Show(json);
                StreamWriter essa = new StreamWriter("savejson");
                essa.Write(json);
                essa.Close();
            }
*/
