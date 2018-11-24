using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Support.V4.View;
using Android.Views;
using Android.Widget;

namespace App22
{
    class ContentFragment : Fragment
    {
        private int position;
        public static ContentFragment NewInstance(int postion)
        {
            var f = new ContentFragment();
            var b = new Bundle();
            b.PutInt("position", postion);

            f.Arguments = b;
            return f;
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            position = Arguments.GetInt("position");
        }
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var root = inflater.Inflate(Resource.Layout.Fragment, container, false);
            var text = root.FindViewById<TextView>(Resource.Id.textView);
            if (position == 0)
            {
                text.Text = "P Android";

            }else if(position == 1)
            {
                text.Text = "P iOS";

            }
            else if (position == 2)
            {
                text.Text = "P UWP";
                
            }
            ViewCompat.SetElevation(root, 50);
            return root;
        }
    }
}