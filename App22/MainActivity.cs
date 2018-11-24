using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.App;
using Android.Support.V4.View;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using com.refractored;
using Java.Lang;

namespace App22
{
    [Activity(Label = "@string/app_name", Theme = "@style/Theme.AppCompat.Light.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity 
    {
        TextView textMessage;
        MyAdapter adapter;
        PagerSlidingTabStrip pageSlidingTabStrip;
        ViewPager viewPager;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);


           // ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;
            SetContentView(Resource.Layout.activity_main);

            adapter = new MyAdapter(SupportFragmentManager);
            viewPager = FindViewById<ViewPager>(Resource.Id.pager);
            pageSlidingTabStrip = FindViewById<PagerSlidingTabStrip>(Resource.Id.tabs);

            viewPager.Adapter = adapter;
            pageSlidingTabStrip.SetViewPager(viewPager);
            pageSlidingTabStrip.SetBackgroundColor(Android.Graphics.Color.Argb(255,0,149,164));
        }
        
    }

    public class MyAdapter : FragmentPagerAdapter
    {
        int tabCount = 2;
        public MyAdapter(Android.Support.V4.App.FragmentManager _fragmentManager): base (_fragmentManager)
        {
            
        }
        public override int Count { get { return tabCount; } }

        public override Android.Support.V4.App.Fragment GetItem(int position)
        {
          return  ContentFragment.NewInstance(position);
        }


        public override ICharSequence GetPageTitleFormatted(int position)
        {
            ICharSequence CS = new Java.Lang.String("");
            if (position == 0)
            {
                CS = new Java.Lang.String("Android");
            }
            else if (position == 1)
            {
                CS = new Java.Lang.String("iOS");

            }
            else if (position == 2)
            {
                CS = new Java.Lang.String("UWP");

            }
            return CS;
        }
    }
}

