using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ecommerce1.Models;

namespace Ecommerce1.Repository
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private dbEntities11 dbEntities = new dbEntities11();
        public Categoria find(int id)
        {
            return dbEntities.Categoria.Find(id);
        }

        public List<Categoria> findAll()
        {
            return dbEntities.Categoria.ToList();
        }
    }
}