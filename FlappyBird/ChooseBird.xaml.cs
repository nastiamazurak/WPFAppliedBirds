using System;
using System.Windows;


namespace FlappyBird
{
    /// <summary>
    
    /// </summary>
    public partial class MainWindow: Window
    {
       private void showChooseBox()
        {
            chooseBox.Visibility = Visibility.Visible;
            //choose.Visibility = Visibility.Visible;
        }

        private void collapseChooseBox()
        {
            chooseBox.Visibility = Visibility.Collapsed;

        }

        private void setYurko(object sender, RoutedEventArgs e)
        {
            bird.Source = yurko.Source;
            skyline.Source = carpaty.Source;
        }


        private void setKatya(object sender, RoutedEventArgs e)
        {
            bird.Source = katya.Source;
            skyline.Source = univer.Source;
        }

        private void setYaryna(object sender, RoutedEventArgs e)
        {
            bird.Source = yara.Source;
            skyline.Source = buka.Source;
            

        }

        private void setLiliya(object sender, RoutedEventArgs e)
        {
            bird.Source = lilya.Source;
            skyline.Source = syhiv.Source;
        }

        private void setMisha(object sender, RoutedEventArgs e)
        {
            bird.Source = miha.Source;
            skyline.Source = univer.Source;
        }

        private void showChangeBird()
        {
            ChangeBird.Visibility = Visibility.Visible;   
        }

        private void collapseChangeBird()
        {
            ChangeBird.Visibility = Visibility.Collapsed;
        }

        private void showBirds(object sender, RoutedEventArgs e)
        {
            collapseScoreboard();
            showChooseBox();
            
        }
    }
}
