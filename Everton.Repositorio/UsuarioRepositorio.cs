using Everton.Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Everton.Repositorio
{
    public class UsuarioRepositorio : Repositorio<Usuario>
    {
        private readonly AppContexto contexto;
        
        public UsuarioRepositorio()
        {
            if (contexto == null)
            {
                contexto = new AppContexto();
            }
        }

        public void Salvar(Usuario objEntidade)
        {
            Incluir(objEntidade);
        }
        
        public void ResetarBancoDeDados()
        {
            if (contexto.Database.Exists())
                contexto.Database.Delete();
                
            contexto.Database.Create();
        }
    }
}
