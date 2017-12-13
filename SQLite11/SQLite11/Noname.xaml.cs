﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SQLite11
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Noname : ContentPage
    {
        private int deleteId;

       public Noname()
        {
            InitializeComponent();

            var query1 = UserModel.selectUser(); //中身はSELECT * FROM [User]
            var layout1 = new StackLayout { HorizontalOptions = LayoutOptions.Center, Margin = new Thickness { Top = 100 } };
            foreach (var user in query1)
            {
                //Userテーブルの名前列をLabelに書き出す
                layout1.Children.Add(new Label { Text = user.Name });
            }

            

            var Delete = new Button
            {
                WidthRequest = 60,
                Text = "削除",
                TextColor = Color.Aqua,
            };
            layout1.Children.Add(Delete);
            Delete.Clicked += DeleteClicked;


            void DeleteClicked(object sender, EventArgs e)
            {
                UserModel.deleteUser(deleteId);
                UserModel.deleteUser(1);
                var layout = new StackLayout { HorizontalOptions = LayoutOptions.Center, Margin = new Thickness { Top = 100 } };
                foreach (var user in query1)
                {
                    //Userテーブルの名前列をLabelに書き出す
                    layout1.Children.Add(new Label { Text = user.Name });
                }
            }

            Content = layout1;
        }
    }
}