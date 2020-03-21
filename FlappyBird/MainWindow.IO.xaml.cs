using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;



namespace FlappyBird
{
    
    public partial class MainWindow : Window
    {
        private bool space = false;
        private bool firstSpaceBar = false;

        private void restartButton_Click(object sender, RoutedEventArgs e)
        {
            
            collapseScoreboard();
           
            resetPipes();
           
            resetBird();
            
            startGroundScroll();
            
            firstSpaceBar = false;
            
            score = 0;
        } 

        
        private void KeyDown_Event(object sender, KeyEventArgs e)
        {
            if (e.Key.Equals(Key.Space) && !birdCollision)
            {
                space = true;
                if (!firstSpaceBar)
                {
                    firstSpaceBar = true;
                }
            }
        }
    }
}
