using DependencyInjection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DependencyInjection
{
    public partial class About : Page
    {
        private IContactRepo _contact;
        protected async void Page_Load(object sender, EventArgs e)
        {
            TextBox1.Text = await FakeTask();
            if (HiddenField1.Value == "")
            {
                Menu1.Items.Add(new MenuItem() { Text = "Menu 1", Value = "1" });
                Menu1.Items[0].ChildItems.Add(new MenuItem() { Text = "Menu 1.1", Value = "1.1" });
                Menu1.Items[0].ChildItems[0].ChildItems.Add(new MenuItem() { Text = "Menu 1.1.1", Value = "1.1.1" });
                Menu1.Items[0].ChildItems[0].ChildItems.Add(new MenuItem() { Text = "Menu 1.1.2", Value = "1.1.2", NavigateUrl = "~/Contact" });
                Menu1.Items[0].ChildItems.Add(new MenuItem() { Text = "Menu 1.2", Value = "1.2" });
                Menu1.Items[0].ChildItems.Add(new MenuItem() { Text = "Menu 1.3", Value = "1.3" });
                Menu1.Items[0].ChildItems.Add(new MenuItem() { Text = "Menu 1.4", Value = "1.4" });
                Menu1.Items.Add(new MenuItem() { Text = "Menu 2", Value = "2" });
                Menu1.Items.Add(new MenuItem() { Text = "Menu 3", Value = "3" });
                Menu1.Items.Add(new MenuItem() { Text = "Menu 4", Value = "4" });
                HiddenField1.Value = "1";
            }           
        }

        public About(IContactRepo _contact)
        {
            this._contact = _contact;
        }
        public override void Dispose()
        {
            _contact.Dispose();
            base.Dispose();
        }
        protected async void Button1_Click(object sender, EventArgs e)
        {
            await Task.Run(() => {
                var a = TextBox1.Text;
                var b = Calendar1.SelectedDate;
            });
        }

        protected async void TextBox1_TextChanged(object sender, EventArgs e)
        {
            await Task.Run(() => {
                var a = TextBox1.Text;
            });
        }

        private async Task<string> FakeTask()
        {
           var q = await Task.Run(() => {
               return "FakeTask";
            });
            return q;
        }

        protected async void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            await Task.Run(() => {
                var b = Calendar1.SelectedDate;
            });
        }

        protected async void Menu1_MenuItemClick(object sender, MenuEventArgs e)
        {
            await Task.Run(() => {
                var b = Menu1.SelectedValue;
            });
        }

    }
}