using System;
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
         int DeleteId;

       public Noname()
        {
            InitializeComponent();

            var query = UserModel.SelectUser(); //中身はSELECT * FROM [User]
            var layout = new StackLayout { HorizontalOptions = LayoutOptions.Center, Margin = new Thickness { Top = 100 } };
            foreach (var user in query)
            {
                //Userテーブルの名前列をLabelに書き出す
                layout.Children.Add(new Label { Text = user.Name });
            }

            

            var Delete = new Button
            {
                WidthRequest = 60,
                Text = "削除",
                TextColor = Color.Aqua,
            };
            layout.Children.Add(Delete);
            Delete.Clicked += DeleteClicked;


            void DeleteClicked(object sender, EventArgs e)
            {
                UserModel.DeleteUser(DeleteId);
                UserModel.DeleteUser(1);
            }

            Content = layout;
        }

        
    }
}