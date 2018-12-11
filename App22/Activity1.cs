using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace App22
{
    [Activity(Label = "Activity1")]
    public class Activity1 : AppCompatActivity
    {
        private Android.Support.V7.Widget.Toolbar myToolbar;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ToolBarActivitylayout);

            // Create your application here
            myToolbar = (Android.Support.V7.Widget.Toolbar)FindViewById(Resource.Id.mySecToolbar);
            myToolbar.InflateMenu(Resource.Menu.menu);
            myToolbar.Title = "Title";
            SetSupportActionBar(myToolbar);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {

            Toast.MakeText(this, "Action selected: " + item.TitleFormatted,
            ToastLength.Short).Show();
            return base.OnOptionsItemSelected(item);
        }


        public override bool OnPrepareOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu, menu);
            return base.OnPrepareOptionsMenu(menu);
        }
    }
}