using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;


namespace FlappyBird
{
    
    public partial class MainWindow : Window
    {
        private bool birdCollision = false;
        private int cruiseControlHeightCount = 0;
        private const int birdStartLeftCoordinate = 63;
        private const int birdStartTopCoordinate = 135;

        
        private int BirdTopCoordinate
        {
            get{
                return (int)Convert.ToInt64(bird.GetValue(Canvas.TopProperty));
            }
            set{
                Canvas.SetTop(bird, value);
            }
        }
        private int BirdLeftCoordinate
        {
            get{
                return (int)Convert.ToInt64(bird.GetValue(Canvas.LeftProperty)); 
            }
            set{
                Canvas.SetLeft(bird, value);
            }
        }
        private int BirdRightCoordinate
        {
            get{
                return BirdLeftCoordinate + (int)bird.Width;  
            }
        }
        private int BirdBottomCoordinate
        {
            get{
                return BirdTopCoordinate + (int)bird.Height;
            }
        }

        private void rotateBirdTo(int angle)
        {
            RotateTransform rotate = new RotateTransform(angle);
            rotate.CenterX = bird.ActualWidth / 2;
            rotate.CenterY = bird.ActualHeight / 2;
            bird.RenderTransform = rotate; 
        }

        private void moveBirdDown()
        {
            if (tickCount < 5)
             {
                rotateBirdTo(-15); 
            }
            else if (tickCount > 8 && tickCount < 13)
            {
                rotateBirdTo(0);
            }
            else if (tickCount > 14 && tickCount < 19)
            {
                rotateBirdTo(30);
            }
            else if (tickCount > 20)
            {
                rotateBirdTo(65);
            }

            BirdTopCoordinate = BirdTopCoordinate + 5; 
        }

        private void moveBirdUp()
        {
            rotateBirdTo(-15);
            BirdTopCoordinate = BirdTopCoordinate - 50;
            tickCount = 0; 
        }

        private void resetBird()
        {
            rotateBirdTo(0);
            BirdLeftCoordinate = birdStartLeftCoordinate;
            BirdTopCoordinate = birdStartTopCoordinate;
            birdCollision = false;
        }

        private void makeBirdFall()
        {
            
            birdCollision = true;

            
            rotateBirdTo(90);

            // Make the bird drop to the ground. 
            if (BirdTopCoordinate < CanvasHeight - GroundHeight - 50)
            {
                BirdTopCoordinate = BirdTopCoordinate + 12;
            }
        }

        private void cruiseControlFlight()
        {
            bool up = cruiseControlHeightCount % 20 == 4;
            bool midUp = cruiseControlHeightCount % 20 == 6;
            bool midDown = cruiseControlHeightCount % 20 == 16;
            bool down = cruiseControlHeightCount % 20 == 18;

            if (up)
            {
                BirdTopCoordinate = BirdTopCoordinate - 5; 
            }
            else if (midUp)
            {
                BirdTopCoordinate = BirdTopCoordinate - 7;
            }
            else if (midDown)
            {
                BirdTopCoordinate = BirdTopCoordinate + 7;
            }
            else if (down)
            {
                BirdTopCoordinate = BirdTopCoordinate + 5; 
            }
            cruiseControlHeightCount++;
        }

        
        private bool detectCollision()
        {
           
            if (birdCollision)
            {
                return true;
            }
            
            else if (BirdBottomCoordinate > CanvasHeight - GroundHeight)
            {
                return stopGroundScroll();
            }
            
            else if ((PipeBotLeft_LeftCoordinate <= BirdRightCoordinate && BirdRightCoordinate <= PipeBotLeft_RightCoordinate) || 
                (PipeBotLeft_LeftCoordinate <= BirdLeftCoordinate && BirdLeftCoordinate <= PipeBotLeft_RightCoordinate))
            {
                if (PipeTopLeft_BotCoordinate <= BirdTopCoordinate && PipeBotLeft_TopCoordinate >= BirdBottomCoordinate)
                {
                    return false;
                }
                else
                {
                    return stopGroundScroll();
                }
            }
           
            else if ((PipeBotRight_LeftCoordinate <= BirdRightCoordinate && BirdRightCoordinate <= PipeBotRight_RightCoordinate) || 
                     (PipeBotRight_LeftCoordinate <= BirdLeftCoordinate && BirdLeftCoordinate <= PipeBotRight_RightCoordinate))
            {
                if (PipeTopRight_BotCoordinate <= BirdTopCoordinate && PipeBotRight_TopCoordinate >= BirdBottomCoordinate)
                {
                    return false;
                }
                else
                {
                    return stopGroundScroll();
                }
            }
            
            else
            {
                return false;
            }
        }
    }
}
