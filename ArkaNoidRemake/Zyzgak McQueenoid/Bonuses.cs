using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zyzgak_McQueenoid
{
    public class Bonuses : Entity, EntityDisplayKeyMove
    {
        Paletka paddle;
        List<Ball> BigBalls;
        Color BonusColor;
        bool active = false;
        int typeofBonus = 0;
        public Bonuses(int locationX, int locationY, int Vx, int Vy, Color EntityColor, MapaGry EntityMap, int EntitySizeHeight, int EntitySizeWidth, Paletka paddle, List<Ball> bigBalls) : base(locationX, locationY, Vx, Vy, EntityColor, EntityMap, EntitySizeHeight, EntitySizeWidth)
        {
            this.locationX = locationX;
            this.locationY = locationY;
            this.Vx = Vx;
            this.Vy = Vy;
            this.EntityColor = EntityColor;
            this.EntityMap = EntityMap;
            this.EntitySizeHeight = EntitySizeHeight;
            this.EntitySizeWidth = EntitySizeWidth;
            this.paddle = paddle;
            this.BigBalls = bigBalls;
        }
        public void Movingdown()
        {
            if(active == true)
            {
                if (locationY > EntityMap.HeightOfMap)
                {
                    active = false;
                    locationY = -EntitySizeHeight;
                    locationX = -EntitySizeWidth;
                }
                if(locationX + Vx >= paddle.locationX && locationX + Vx <= paddle.locationX + paddle.EntitySizeWidth && locationY + Vy + EntitySizeHeight >= paddle.locationY && locationY + Vy + EntitySizeHeight <= paddle.locationY + Vy + EntitySizeHeight)
                {
                    if (typeofBonus == 1 && paddle.EntitySizeWidth<600)
                    {
                        paddle.EntitySizeWidth *= 2;
                        if (paddle.locationX + paddle.EntitySizeWidth > EntityMap.WidthOfMap)
                            paddle.locationX -= paddle.EntitySizeWidth/2;
                    }
                    else if (typeofBonus == 2 && paddle.EntitySizeWidth>100)
                    {
                        paddle.EntitySizeWidth -= 50;
                    }
                    else if(typeofBonus == 3 /*&& BigBalls[0].followpaddle == false && BigBalls[0].locationY >= paddle.locationY*/)
                    {
                        int fixedVy;
                        if (BigBalls[0].Vy > 0)
                            fixedVy = -BigBalls[0].Vy;
                        else
                            fixedVy = BigBalls[0].Vy;
                        if (BigBalls[0].locationX >= EntityMap.WidthOfMap / 2)
                        {
                            BigBalls.Add(new Ball(BigBalls[0].locationX + BigBalls[0].EntitySizeWidth, BigBalls[0].locationY, -BigBalls[0].Vx, fixedVy, Color.Orchid, EntityMap, BigBalls[0].EntitySizeHeight - 10, BigBalls[0].EntitySizeWidth - 5, paddle, false));
                            BigBalls.Add(new Ball(BigBalls[0].locationX + BigBalls[0].EntitySizeWidth+5, BigBalls[0].locationY+5, -BigBalls[0].Vx, fixedVy, Color.OrangeRed, EntityMap, BigBalls[0].EntitySizeHeight - 10, BigBalls[0].EntitySizeWidth - 5, paddle, false));
                            BigBalls.Add(new Ball(BigBalls[0].locationX + BigBalls[0].EntitySizeWidth+10, BigBalls[0].locationY+10, -BigBalls[0].Vx, fixedVy, Color.DarkOliveGreen, EntityMap, BigBalls[0].EntitySizeHeight - 10, BigBalls[0].EntitySizeWidth - 5, paddle, false));
                        }
                        else
                        {
                            BigBalls.Add(new Ball(BigBalls[0].locationX - BigBalls[0].EntitySizeWidth, BigBalls[0].locationY, -BigBalls[0].Vx, fixedVy, Color.Orange, EntityMap, BigBalls[0].EntitySizeHeight - 10, BigBalls[0].EntitySizeWidth - 5, paddle, false));
                            BigBalls.Add(new Ball(BigBalls[0].locationX - BigBalls[0].EntitySizeWidth-5, BigBalls[0].locationY-5, -BigBalls[0].Vx, fixedVy, Color.DarkSalmon, EntityMap, BigBalls[0].EntitySizeHeight - 10, BigBalls[0].EntitySizeWidth - 5, paddle, false));
                            BigBalls.Add(new Ball(BigBalls[0].locationX - BigBalls[0].EntitySizeWidth-10, BigBalls[0].locationY-10, -BigBalls[0].Vx, fixedVy, Color.DeepPink, EntityMap, BigBalls[0].EntitySizeHeight - 10, BigBalls[0].EntitySizeWidth - 5, paddle, false));
                        }
                    }
                    else if(typeofBonus == 4)
                    {
                        paddle.canGetBallToMe = true;
                    }
                    active = false;
                    locationY = -EntitySizeHeight;
                    locationX = -EntitySizeWidth;
                    Vx = 0;
                    Vy = 0;
                }
                else
                {
                    locationY += Vy;
                }
            }
        }
        public void forcemetodespawn()
        {
            active = false;
            locationY = -EntitySizeHeight;
            locationX = -EntitySizeWidth;
        }
        public void RollToSpawnTheBonus()
        {
            if (active == false)
            {
                Random c1 = new Random();
                if(c1.Next(1,30) == 5)
                {
                    //typeofBonus = c1.Next(1, 5); //od 1 do n-1
                    typeofBonus = 3;
                    if (typeofBonus == 1)
                        BonusColor = Color.Yellow;
                    else if (typeofBonus == 2)
                        BonusColor = Color.AliceBlue;
                    else if (typeofBonus == 3)
                        BonusColor = Color.Orange;
                    else if (typeofBonus == 4)
                        BonusColor = Color.Purple;
                    locationY = EntitySizeHeight;
                    locationX = c1.Next(5,EntityMap.WidthOfMap-EntitySizeWidth-5);
                    Vx = 10;
                    Vy = 10;
                    active = true;
                }
            }
        }
        public void displayentity(PaintEventArgs e)
        {
            Brush pencil = new SolidBrush(Color.Black);
            Font countdownFont = new Font("Arial", 10, FontStyle.Bold);
            Brush kurz = new SolidBrush(BonusColor);
            e.Graphics.FillEllipse(kurz, (int)locationX, (int)locationY, (int)EntitySizeWidth, (int)EntitySizeHeight);
            e.Graphics.DrawString(typeofBonus.ToString(), countdownFont, pencil, locationX+EntitySizeWidth/2, locationY+EntitySizeHeight/2,
            new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
            kurz.Dispose();
        }

        public void keypressMoveEntity(KeyPressEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
