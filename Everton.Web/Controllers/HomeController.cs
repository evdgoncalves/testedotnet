using Everton.Dominio.Entidade;
using Everton.Dominio.ValueObject;
using Everton.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Everton.Web.Controllers
{
    public class HomeController : Controller
    {
        private void CadastrarUsuarioTeste()
        {
            UsuarioBO objBO = new UsuarioBO();

            Cpf cpf = new Cpf("19100000000");
            Email email = new Email("testse@Everton.com.br");
            Cep cep = new Cep("40302000");
            Usuario usuario = new Usuario("exemplotestes", cpf, email, "123456", "123456");

            objBO.IncluirUsuario(usuario);

            List<Usuario> teste = objBO.ObterTodosCadastrados();
        }

        /// <summary>
        /// Retorna lista de usuários cadastrados
        /// </summary>
        /// <returns></returns>
        private List<Usuario> ListaUsuario()
        {
            UsuarioBO objBO = new UsuarioBO();

            return objBO.ObterTodosCadastrados();
        }

        public ActionResult Index()
        {
            //this.CadastrarUsuarioTeste();
            return View(ListaUsuario());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}