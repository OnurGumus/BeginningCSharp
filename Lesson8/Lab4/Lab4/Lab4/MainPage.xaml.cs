using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Lab4
{
    public partial class MainPage : ContentPage
    {

        Game game;

        public MainPage()
        {
            InitializeComponent();
            Restart_Clicked(null, null);
        }


        private async void Button_Clicked(object sender, EventArgs e)
        {
            var result = await game.MakeGuess(int.Parse(this.GuessText.Text));
            this.Output.Text += result + Environment.NewLine;
        }


        private async void Restart_Clicked(object sender, EventArgs e)
        {
            this.game = new Game("Onur");
            var highScore = await game.GetHighScore();
            this.Output.Text =
                highScore == null ? "No high scores yet" + Environment.NewLine :
                $"Current high score belongs to player {highScore.PlayerName} with {highScore.BestAttempt} attempts!{Environment.NewLine}";
        }

    }
}
