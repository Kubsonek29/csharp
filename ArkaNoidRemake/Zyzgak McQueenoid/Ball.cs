using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace Zyzgak_McQueenoid
{
    [Serializable]
    public class Ball : Entity, EntityDisplayKeyMove
    {
        public bool IsMainBall = false;
        public Paletka paddle { get; set; }
        public bool followpaddle { get; set; }
        public Ball(int locationX, int locationY, int Vx, int Vy, Color BallColor, MapaGry map, int ballsizeheight, int ballsizewidth, Paletka paddle, bool isMainBall) : base(locationX, locationY, Vx, Vy, BallColor, map, ballsizeheight, ballsizewidth)
        {
            this.locationX = locationX; this.locationY = locationY; this.Vx = Vx; this.Vy = Vy; this.EntityColor = BallColor; this.EntitySizeHeight = ballsizeheight; this.EntitySizeWidth = ballsizewidth; EntityMap = map;
            this.paddle = paddle;
            followpaddle = true;
            IsMainBall = isMainBall;
        }
        public int BasicBallMovement(int lives)
        {
            if (locationY+Vy+EntitySizeHeight < 0)
            {
                Vy = -Vy;
                locationY = Vy;
            }
            else if(locationY+EntitySizeHeight >= EntityMap.HeightOfMap) //spadnie na dol
            {
                if(IsMainBall == true)
                {
                    lives--;
                    followpaddle = true;
                }
                else
                {
                    locationY = -100;
                    locationX = -100; //Poza mapa - do wyczyszczenia
                    Vx = 0;
                    Vx = 0;
                }
                return lives;
            }
            if (locationX+Vx <= 0 || locationX+Vx + EntitySizeWidth  >= EntityMap.WidthOfMap)
                Vx = -Vx;
            if (locationY+Vy <= 0 || locationY+Vy-EntitySizeHeight  >= EntityMap.HeightOfMap)
                Vy = -Vy;
            locationX += Vx;
            locationY += Vy;
            return lives;
        }
        public void displayentity(PaintEventArgs e)
        {
            //e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            Brush kurz = new SolidBrush(EntityColor);
            e.Graphics.FillEllipse(kurz, (int)locationX, (int)locationY, (int)EntitySizeWidth, (int)EntitySizeHeight);
            kurz.Dispose();
        }
        public void keypressMoveEntity(KeyPressEventArgs e)
        {
            if (e.KeyChar == 's' && IsMainBall == true && paddle.canGetBallToMe == true)
            {
                locationX = paddle.locationX + (paddle.EntitySizeWidth / 2);
                locationY = paddle.locationY - (paddle.EntitySizeHeight);
                if (Vy < 0)
                    Vy = -Vy;
                followpaddle = true;
                paddle.canGetBallToMe = false;
            }
            else if(e.KeyChar == 'e' && IsMainBall == true)
            {
                followpaddle = false;
            }
        }
        public void followpaddlemovement()
        {
            locationX = paddle.locationX + (paddle.EntitySizeWidth / 2 - EntitySizeWidth/2);
            locationY = paddle.locationY - (paddle.EntitySizeHeight/2+EntitySizeHeight/4);
        }
        public int BallCollisionObstaclePaletka(List<Obstacle> obstacles, int score)
        {
            if (locationY+ (Vy / 2) >= paddle.locationY + paddle.EntitySizeHeight)
                return score;  //ponizej wysokosci dolnej paletki
            if ((locationX+ (Vx / 2) <= paddle.locationX && locationX + (Vx / 2) >= paddle.locationX + paddle.EntitySizeWidth && locationY+ (Vy / 2) <= paddle.locationY + paddle.EntitySizeHeight && locationY+ (Vy / 2) >= paddle.locationY) || (locationX + (Vx / 2) <= paddle.locationX + paddle.EntitySizeWidth && locationX + (Vx / 2) >= paddle.locationX && locationY + (Vy / 2) <= paddle.locationY + paddle.EntitySizeHeight && locationY + (Vy / 2) >= paddle.locationY))
            {
                Vx = -Vx; //odbijanie bokami paletki
                return score;
            }
            else if (locationX + (Vx/2) >= paddle.locationX && locationY + (Vy/2) + EntitySizeHeight >= paddle.locationY && locationX + (Vx / 2) <= paddle.locationX + paddle.EntitySizeWidth)
            {
                Vy = -Vy; //odbijanie gora paletki
                return score;
            }
            foreach(var item in obstacles)
            {
                if ((locationX + (Vx*2) + EntitySizeWidth >= item.locationX && locationX+ (Vx*2) <= item.locationX+item.EntitySizeWidth && locationY+EntitySizeHeight <= item.locationY + item.EntitySizeHeight && locationY+ EntitySizeHeight >= item.locationY) || (locationX+ (Vx *2) <= item.locationX+item.EntitySizeWidth && locationX+ (Vx*2) + EntitySizeWidth >= item.locationX && locationY + EntitySizeHeight <= item.locationY + item.EntitySizeHeight && locationY + EntitySizeHeight >= item.locationY))
                {
                    item.ObstacleLives--;
                    if(item.ObstacleLives == 0)
                    {
                        item.locationX = 0;
                        item.locationY = 0;
                        score += 40;
                    }
                    score += 10;
                    Vx = -Vx; // odbijanie bokami
                    break;
                }
                else if ((locationX + Vx <= item.locationX + item.EntitySizeWidth && locationX + Vx >= item.locationX && locationY + (Vy*2) >= item.locationY + item.EntitySizeHeight && locationY + (Vy*2) < item.locationY) || (locationX + (Vx) <= item.locationX + item.EntitySizeWidth && locationX + (Vx) >= item.locationX && locationY + (Vy * 2) >= item.locationY && locationY+ (Vy * 2) < item.locationY+item.EntitySizeHeight))
                {
                    item.ObstacleLives--;
                    if (item.ObstacleLives == 0)
                    {
                        item.locationX = 0;
                        item.locationY = 0;
                        score += 40;
                    }
                    score += 10;
                    Vy = -Vy; // odbijanie obstacles od dolu || od gory 
                    break;
                }
            }
            return score;
        }

        public int AdvancedCollisions(List<Obstacle> obstacles, int score)
        {
            ///paletka
            //od dolu
            if (locationY >= paddle.locationY + paddle.EntitySizeHeight)
                return score;
            //od gory
            else if (Vy > 0 && locationX + Vx >= paddle.locationX && locationX + Vx <= paddle.locationX + paddle.EntitySizeWidth && locationY + Vy + EntitySizeHeight >= paddle.locationY && locationY + Vy + EntitySizeHeight <= paddle.locationY + Vy + EntitySizeHeight)
            {
                Vy = -Vy;
                return score;
            }
            // od lewej
            if (Vx > 0 && locationX + Vx <= paddle.locationX + paddle.EntitySizeWidth && locationX + Vx >= paddle.locationX + paddle.EntitySizeWidth + Vx && locationY + Vy >= paddle.locationY && locationY + Vy + EntitySizeHeight <= paddle.locationY + paddle.EntitySizeHeight)
            {
                Vx = -Vx;
                return score;
            }
            // od prawej
            else if (Vx < 0 && locationX + Vx + EntitySizeWidth >= paddle.locationX && locationX + Vx + EntitySizeWidth <= paddle.locationX + Vx + EntitySizeWidth && locationY + Vy >= paddle.locationY && locationY + Vy + EntitySizeHeight <= paddle.locationY + paddle.EntitySizeHeight)
            {
                Vx = -Vx;
                return score;
            }
            //lewy gorny ukos
            if(Vy>0 && Vx>0 && locationX + Vx + EntitySizeWidth >= paddle.locationX && locationX + Vx + EntitySizeWidth <= paddle.locationX + Vx + EntitySizeWidth && locationY + Vy + EntitySizeHeight >= paddle.locationY && locationY + Vy + EntitySizeHeight <= paddle.locationY + Vy + EntitySizeHeight)
            {
                Vy = -Vy;
                Vx = -Vx;
                return score;
            }
            //prawy gorny ukos
            else if (Vy>0 && Vx<0 && locationX + Vx >= paddle.locationX && locationX + Vx <= paddle.locationX + paddle.EntitySizeWidth && locationY + Vy + EntitySizeHeight >= paddle.locationY && locationY + Vy + EntitySizeHeight <= paddle.locationY + Vy + EntitySizeHeight)
            {
                Vy = - Vy;
                Vx = -Vx;
                return score;
            }
            ///Obstacles
            foreach (var item in obstacles)
            {
                //od prawej
                if (Vx > 0 && locationX + Vx + EntitySizeWidth >= item.locationX && locationX + Vx + EntitySizeWidth <= item.locationX + Vx + EntitySizeWidth && locationY + Vy >= item.locationY && locationY + Vy + EntitySizeHeight <= item.locationY + item.EntitySizeHeight)
                {
                    AdjustPointsAndLives(item, ref score, false);
                    return score;
                }
                //od lewej
                else if (Vx < 0 && locationX + Vx <= item.locationX + item.EntitySizeWidth && locationX + Vx >= item.locationX + item.EntitySizeWidth + Vx && locationY + Vy >= item.locationY && locationY + Vy + EntitySizeHeight <= item.locationY + item.EntitySizeHeight)
                {
                    AdjustPointsAndLives(item, ref score, false);
                    return score;
                }
                //od gory
                if (Vy > 0 && locationX + Vx >= item.locationX && locationX + Vx <= item.locationX + item.EntitySizeWidth && locationY + Vy + EntitySizeHeight >= item.locationY && locationY + Vy + EntitySizeHeight <= item.locationY + Vy + EntitySizeHeight)
                {
                    AdjustPointsAndLives(item, ref score, true);
                    return score;
                }
                //od dolu
                else if (Vy < 0 && locationX + Vx >= item.locationX && locationX + Vx <= item.locationX + item.EntitySizeWidth && locationY + Vy <= item.locationY + item.EntitySizeHeight && locationY + Vy >= item.locationY + item.EntitySizeHeight + Vy)
                {
                    AdjustPointsAndLives(item, ref score, true);
                    return score;
                }
                //lewy gorny ukos
                if (Vy>0 && Vx>0 && locationX + Vx + EntitySizeWidth >= item.locationX && locationX + Vx + EntitySizeWidth <= item.locationX + Vx + EntitySizeWidth && locationY + Vy + EntitySizeHeight >= item.locationY && locationY + Vy + EntitySizeHeight <= item.locationY + Vy + EntitySizeHeight)
                {
                    item.ObstacleLives--;
                    if (item.ObstacleLives == 0)
                    {
                        item.locationX = 0;
                        item.locationY = 0;
                        score += 40;
                    }
                    score += 10;
                    Vx = -Vx;
                    Vy = -Vy;
                    return score;
                }
                //prawy gorny ukos
                else if (Vy>0 && Vx<0 && locationX + Vx >= item.locationX && locationX + Vx <= item.locationX + item.EntitySizeWidth && locationY + Vy + EntitySizeHeight >= item.locationY && locationY + Vy + EntitySizeHeight <= item.locationY + Vy + EntitySizeHeight)
                {
                    item.ObstacleLives--;
                    if (item.ObstacleLives == 0)
                    {
                        item.locationX = 0;
                        item.locationY = 0;
                        score += 40;
                    }
                    score += 10;
                    Vx = -Vx;
                    Vy = -Vy;
                    return score;
                }
                //lewy dolny ukos
                else if(Vy<0 && Vx>0 &&locationX + Vx <= item.locationX + item.EntitySizeWidth && locationX + Vx >= item.locationX + item.EntitySizeWidth + Vx && locationY + Vy <= item.locationY + item.EntitySizeHeight && locationY + Vy >= item.locationY + item.EntitySizeHeight + Vy)
                {
                    item.ObstacleLives--;
                    if (item.ObstacleLives == 0)
                    {
                        item.locationX = 0;
                        item.locationY = 0;
                        score += 40;
                    }
                    score += 10;
                    Vx = -Vx;
                    Vy = -Vy;
                    return score;
                }
                //prawy dolny ukos
                else if(Vy<0 && Vx<0 && locationX + Vx + EntitySizeWidth >= item.locationX && locationX + Vx + EntitySizeWidth <= item.locationX + Vx + EntitySizeWidth && locationY + Vy <= item.locationY + item.EntitySizeHeight && locationY + Vy >= item.locationY + item.EntitySizeHeight + Vy)
                {
                    item.ObstacleLives--;
                    if (item.ObstacleLives == 0)
                    {
                        item.locationX = 0;
                        item.locationY = 0;
                        score += 40;
                    }
                    score += 10;
                    Vx = -Vx;
                    Vy = -Vy;
                    return score;
                }
            }

            return score;
        }
        public void AdjustPointsAndLives(Obstacle x1, ref int score, bool direct)
        {
            x1.ObstacleLives--;
            if (x1.ObstacleLives == 0)
            {
                x1.locationX = 0;
                x1.locationY = 0;
                score += 40;
            }
            score += 10;
            if (direct)
                Vy = -Vy;
            else
                Vx = -Vx;
        }
    }
}
