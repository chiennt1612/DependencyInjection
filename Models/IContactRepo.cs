using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace DependencyInjection.Models
{
    public interface IContactRepo : IDisposable
    {
        Task<bool> Create(Contact contact);
        Task<List<Contact>> List(Contact contact);
        Task<bool> Update(Contact contact);
        Task<bool> Delete(Contact contact);
    }
}