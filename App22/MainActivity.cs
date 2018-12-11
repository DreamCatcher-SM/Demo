using Android.App;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.App;
using Android.Support.V4.View;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Java.Lang;

namespace App22
{
    [Activity(Label = "@string/app_name", Theme = "@style/Theme.AppCompat.Light.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        Android.Support.V7.Widget.Toolbar myToolbar;
        MyAdapter adapter;
        public static Activity MyActitvity { get; set; }
        ViewPager viewPager;
        private int[] tabIcons = {
            Resource.Drawable.ic_dashboard_black_24dp,
            Resource.Drawable.ic_home_black_24dp,
        };

        protected override void OnCreate(Bundle savedInstanceState)
        {

            try

            {
                base.OnCreate(savedInstanceState);
                MyActitvity = this;
                SetContentView(Resource.Layout.MainLayout);


                //set toolbar
                myToolbar = (Android.Support.V7.Widget.Toolbar)FindViewById(Resource.Id.my_toolbar);
                SetSupportActionBar(myToolbar);

                myToolbar.InflateMenu(Resource.Menu.menu);
                
                myToolbar.Title = "Title";



            }
            catch (System.Exception ex)
            {

                string a = ex.Message;
            }
            SupportActionBar.SetDisplayShowTitleEnabled(false);

            adapter = new MyAdapter(SupportFragmentManager);
            viewPager = FindViewById<ViewPager>(Resource.Id.pagerx);
            viewPager.Adapter = adapter;


            TabLayout tabLayout = (TabLayout)FindViewById(Resource.Id.tablayout);

            tabLayout.SetupWithViewPager(viewPager);



        }
        public override bool OnOptionsItemSelected(IMenuItem item)
        {

            Toast.MakeText(this, "Action selected: " + item.TitleFormatted,
            ToastLength.Short).Show();
            return base.OnOptionsItemSelected(item);
        }
        private void Button_Click(object sender, System.EventArgs e)
        {
            StartActivity(typeof(Activity1));
        }



        private void SetupTabIcons(TabLayout tabLayout)
        {

            tabLayout.GetTabAt(0).SetIcon(tabIcons[0]);

            tabLayout.GetTabAt(1).SetIcon(tabIcons[1]);
        }


        public override bool OnPrepareOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu, menu);
            return base.OnPrepareOptionsMenu(menu);
        }
    }

    public class MyAdapter : FragmentStatePagerAdapter
    {
        int tabCount = 2;
        public MyAdapter(Android.Support.V4.App.FragmentManager _fragmentManager) : base(_fragmentManager)
        {

        }
        public override int Count { get { return tabCount; } }

        public override Android.Support.V4.App.Fragment GetItem(int position)
        {


            switch (position)
            {
                case 0: return new Resources.menu.Tab1();
                case 1: return new Resources.menu.Tab2();
                default: return null;
            }
        }

        private int[] tabIcons = {
            Resource.Drawable.ic_dashboard_black_24dp,
            Resource.Drawable.ic_home_black_24dp,
        }; private string[] tabTitles = {
            "Tab 1",
            "Tab 2",
        };
        public override ICharSequence GetPageTitleFormatted(int position)
        {
            // ICharSequence CS = new Java.Lang.String("");


            Drawable image = Android.Support.V4.Content.ContextCompat.GetDrawable(MainActivity.MyActitvity, tabIcons[position]);
            image.SetBounds(0, 0, image.IntrinsicWidth, image.IntrinsicHeight);
            // Replace blank spaces with image icon
            Android.Text.SpannableString sb = new Android.Text.SpannableString("   " + tabTitles[position]);
            Android.Text.Style.ImageSpan imageSpan = new Android.Text.Style.ImageSpan(image, Android.Text.Style.SpanAlign.Bottom);
            sb.SetSpan(imageSpan, 0, 1, Android.Text.SpanTypes.ExclusiveExclusive);


            return sb;
        }
    }
}

