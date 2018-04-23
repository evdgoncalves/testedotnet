using Everton.Dominio.Entidade;
using Everton.Dominio.ValueObject;
using Everton.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Everton.Negocio
{
    public class UsuarioBO
    {
        ///// <summary>
        ///// Propriedade repositório
        ///// </summary>
        private static UsuarioRepositorio objRepositorio = null;

        /// <summary>
        /// Método construtor
        /// </summary>
        public UsuarioBO()
        {
            if (objRepositorio == null)
            {
                objRepositorio = new UsuarioRepositorio();
            }
            //objRepositorio.ResetarBancoDeDados();
        }

        /// <summary>
        /// Obter lista de usuários cadastrados.
        /// </summary>
        /// <returns></returns>
        public List<Usuario> ObterTodosCadastrados()
        {
            //objRepositorio.ResetarBancoDeDados();
            
            return objRepositorio.ObterTodosList();
        }

        public void IncluirUsuario(Usuario entidade)
        {
            objRepositorio.Incluir(entidade);
        }

        public Usuario ObterPorId(int idUsuario)
        {
            return objRepositorio.ObterPorId(idUsuario);
        }

        public Usuario Editar(Usuario entidade)
        {
            objRepositorio.Alterar(entidade);

            return ObterPorId(entidade.IdUsuario);
        }

        public void Deletar(Usuario entidade)
        {
            objRepositorio.Deletar(entidade);
        }
    }
}
