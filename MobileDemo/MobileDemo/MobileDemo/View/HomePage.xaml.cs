using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileDemo.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HomePage : ContentPage
	{
		public HomePage ()
		{
            NavigationPage.SetHasNavigationBar(this, false);
			InitializeComponent ();
		}

	    private void FavouriteCarsButton_OnClicked(object sender, EventArgs e)
	    {

	        if(Globals.LockNavigation == false) {
	            Globals.LockNavigation = true;
	            Navigation.PushAsync(new FavouriteCarsPage())
	                .ContinueWith((t1) => { Globals.LockNavigation = false; });
            }
        }
	}
}