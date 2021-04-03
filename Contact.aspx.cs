using DependencyInjection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DependencyInjection
{
    public partial class Contact : Page
    {
        //private IDataAccess _db;
        private IContactRepo _contact;

        public Contact(IContactRepo _contact)//IDataAccess _db, 
        {
            //this._db = _db;
            this._contact = _contact;
        }
        protected async void Page_Load(object sender, EventArgs e)
        {
            await AuditLogs.WriteLog($"Page_Load()");
            var a = await _contact.List(new DependencyInjection.Models.Contact() { ID = 1, Fullname = "Nguyễn Văn A", Email = "anv@gmail.com", Mobile = "098xxxxxx", Content = "text" });
        }

        protected async void bntAction_Click(object sender, EventArgs e)
        {
            await AuditLogs.WriteLog($"bntAction_Click()");
            var a = await _contact.Create(new Models.Contact() { ID = 1, Fullname = txtFullname.Text, Email = txtEmail.Text, Mobile = txtMobile.Text , Content = txtContent.Text  });
        }
        public override void Dispose()
        {
            _contact.Dispose();
            base.Dispose();
        }
    }
}