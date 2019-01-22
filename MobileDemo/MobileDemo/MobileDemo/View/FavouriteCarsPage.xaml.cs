using System;
using MobileDemo.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileDemo.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FavouriteCarsPage : ContentPage
	{
	    public FavouriteCarsViewModel FavouriteCarsViewModel;
		public FavouriteCarsPage ()
		{
		    Title = "Favourite Cars";

            FavouriteCarsViewModel= new FavouriteCarsViewModel();
		    BindingContext = FavouriteCarsViewModel;

			InitializeComponent ();
		}

	    private void UpdateButton_OnClicked(object sender, EventArgs e)
	    {
	        FavouriteCarsViewModel.UpdateData();

	        Navigation.PopAsync();
	    }
	}
}