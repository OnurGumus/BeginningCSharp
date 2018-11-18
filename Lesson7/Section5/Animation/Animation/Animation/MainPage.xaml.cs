using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Animation
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private  async void StartButton_Clicked(object sender, EventArgs e)
        {
            await image.RotateTo(360, 2000);
            image.Rotation = 0;
        }






    }
}
