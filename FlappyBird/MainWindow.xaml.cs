using System;
using System.Windows;
using System.Windows.Threading;



namespace FlappyBird
{
   
    public partial class MainWindow : Window
    {
        private int tickCount = 0; 

        public MainWindow()
        {
            InitializeComponent();
            collapseScoreboard();
            startTicker();
            collapseChangeBird();
            startGroundScroll();
            showChooseBox();
        }

        private void startTicker()
        {
            DispatcherTimer _timer = new DispatcherTimer(new TimeSpan(0, 0, 0, 0, 30), 
                DispatcherPriority.Background, ticker, Dispatcher.CurrentDispatcher);
        }

        
        private void ticker(object sender, EventArgs e)
        {
            if (firstSpaceBar)
            {
                collapseChooseBox();
                collapseChangeBird();

                if (initializePipes)
                {
                    createPipes();
                }
                else if (detectCollision())
                {
                    makeBirdFall();
                    collapseScoreStatus();
                    displayScoreboard();
                    collapseScoreLabel();
                    //showChangeBird();
                    
                }
               
                else
                {

                    if (space)
                    {
                        moveBirdUp();
                      
                    }
                    else
                    {
                        moveBirdDown();
                    }
                    scrollPipes();
                    tickCount++;
                    displayScoreStatus();
                    displayScoreLabel();
                  
                }
            }
            else
            {
                
                cruiseControlFlight();
                showChangeBird();
                
            }
            space = false;
        }

       
    }
}
