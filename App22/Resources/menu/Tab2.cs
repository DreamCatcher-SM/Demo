﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace App22.Resources.menu
{
    public class Tab2 : Android.Support.V4.App.Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.Tab2, container, false);
            Button button =view.FindViewById<Button>(Resource.Id.button1);
            button.Click += Button_Click;


            // Use this to return your custom view for this Fragment
            return view;

            //return base.OnCreateView(inflater, container, savedInstanceState);
        }
        private void Button_Click(object sender, System.EventArgs e)
        {
            Application.Context.StartActivity(typeof(Activity1));
        }

    }
}