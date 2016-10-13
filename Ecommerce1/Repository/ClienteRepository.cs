using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ecommerce1.Models;

namespace Ecommerce1.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private dbEntities1 dbEntities = new dbEntities1();

        public void create(Cliente cliente)
        {
            dbEntities.Cliente.Add(cliente);
            dbEntities.SaveChanges();
        }

        public Cliente login(string email, string senha)
        {
            try
            {
                return dbEntities.Cliente.Single(acc => acc.email.Equals(email) && acc.senha.Equals(senha));

            }
            catch {

                return null;

            }
        }
    }
}