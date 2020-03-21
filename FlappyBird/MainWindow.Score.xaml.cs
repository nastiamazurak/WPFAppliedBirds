using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;





namespace FlappyBird
{
   
    public partial class MainWindow : Window
    {
        private int score = 0;
        private int bestScore = 0;

        private void displayScoreboard()
        {
            scoreboard.Visibility = Visibility.Visible;
            restartButton.Visibility = Visibility.Visible;

           
            updateScoreboard();
        }

        private void displayScoreStatus()
        {
            
            this.scoreStatus.Text = score.ToString();
            scoreStatus.Visibility = Visibility.Visible;

        }

        private void displayScoreLabel()
        {
            if ( score > 1)
            {
                this.Label.Text = "Вітаємо! У вас не талон!";
                Label.Visibility = Visibility.Visible; 
            }

            if (score > 2)
            {
                Label.Visibility = Visibility.Collapsed;
            }

            if (score > 5)
            {
                this.Label.Text = "Йдете на 91!";
                Label.Visibility = Visibility.Visible;
            }

            if (score > 6)
            {
                Label.Visibility = Visibility.Collapsed;
            }
        }

        private void collapseScoreStatus()
        {

            scoreStatus.Visibility = Visibility.Collapsed;

        }

        private void collapseScoreLabel()
        {
            Label.Visibility = Visibility.Collapsed;
        }


        private void collapseScoreboard()
        {
            scoreboard.Visibility = Visibility.Collapsed;
            restartButton.Visibility = Visibility.Collapsed;
        }

        private void updateScoreboard()
        {
            
            this.scoreTextBlock.Text = score.ToString();
            
            if (score > bestScore)
            {
                bestScore = score;
            }
            this.bestScoreTextBlock.Text = bestScore.ToString();
        }
    }
}
