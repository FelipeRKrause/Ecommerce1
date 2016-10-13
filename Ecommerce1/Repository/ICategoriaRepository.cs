using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce1.Models;

namespace Ecommerce1.Repository
{
    public interface ICategoriaRepository {

        List<Categoria> findAll();

        Categoria find(int id);
    }
}
