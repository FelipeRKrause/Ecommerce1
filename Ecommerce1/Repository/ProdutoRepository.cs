using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ecommerce1.Models;

namespace Ecommerce1.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private dbEntities10 dbEntities = new dbEntities10();
        public Produto find(int id)
        {
            return dbEntities.Produto.Find(id);
        }

        public List<Produto> findAll()
        {
            return dbEntities.Produto.ToList();
        }
    }
}