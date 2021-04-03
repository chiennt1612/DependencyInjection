using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace DependencyInjection.Models
{
    public class ContactRepo : IContactRepo
    {
        private IDataAccess _db;
        public ContactRepo (IDataAccess db)
        {
            _db = db;
        }
        public async Task<bool> Create(Contact contact)
        {
            await AuditLogs.WriteLog($"Create({JsonConvert.SerializeObject(contact)})");
            return true;
        }

        public async Task<bool> Delete(Contact contact)
        {
            await AuditLogs.WriteLog($"Delete({JsonConvert.SerializeObject(contact)})");
            return true;
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public async Task<List<Contact>> List(Contact contact)
        {
            await AuditLogs.WriteLog($"List({JsonConvert.SerializeObject(contact)})");
            return new List<Contact>();
        }

        public async Task<bool> Update(Contact contact)
        {
            await AuditLogs.WriteLog($"Update({JsonConvert.SerializeObject(contact)})");
            return true;
        }
    }
}