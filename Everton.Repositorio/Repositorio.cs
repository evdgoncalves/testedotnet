using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Everton.Repositorio
{
    //public class Repositorio<TEntity> : IRepository<TEntity> where TEntity : EntityBase
    public class Repositorio<TEntity> where TEntity : class
    {
        protected readonly AppContexto Context;

        public Repositorio()
        {
            if (Context == null)
            {
                Context = new AppContexto();
            }
        }

        public Repositorio(AppContexto context)
        {
            Context = context;
        }

        private DbSet<TEntity> Entity { get { return Context.Set<TEntity>(); } }

        /// <summary>
        /// Persistir no banco de dados
        /// </summary>
        /// <param name="obj"></param>
        public void Incluir(TEntity obj)
        {
            //obj.DtInclusao = DateTime.Now;
            Entity.Add(obj);
            Salvar();
        }

        /// <summary>
        /// Incluir lista 
        /// </summary>
        /// <param name="obj"></param>
        public void IncluirLista(IEnumerable<TEntity> obj)
        {
            foreach (var entity in obj)
                Incluir(entity);
        }

        /// <summary>
        /// Deletar lista 
        /// </summary>
        /// <param name="obj"></param>
        public void DeletarLista(IEnumerable<TEntity> obj)
        {
            foreach (var entity in obj)
                Deletar(entity);
        }

        /// <summary>
        /// Deletar
        /// </summary>
        /// <param name="obj"></param>
        public void Deletar(TEntity obj)
        {
            Entity.Remove(obj);
            Salvar();
        }

        /// <summary>
        /// Deletar por ID
        /// </summary>
        /// <param name="id"></param>
        public void DeletarPorId(int id)
        {
            Entity.Remove(ObterPorId(id));
            Salvar();
        }

        /// <summary>
        /// Obter o por pk
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TEntity ObterPorId(int id)
        {
            return Entity.Find(id);
        }

        public TEntity First()
        {
            return Entity.FirstOrDefault();
        }

        /// <summary>
        /// Obter todos cadastrados no banco
        /// </summary>
        /// <returns></returns>
        public IQueryable<TEntity> ObterTodos()
        {
            return Entity;
        }

        /// <summary>
        /// Obter todos cadastrados no banco
        /// </summary>
        /// <returns></returns>
        public List<TEntity> ObterTodosList()
        {
            return Entity.ToList();
        }

        /// <summary>
        /// Alterar na base
        /// </summary>
        /// <param name="obj"></param>
        public void Alterar(TEntity obj)
        {
            //Context.Entry(obj).State = EntityState.Modified;
            var entry = Context.Entry(obj);
            entry.State = EntityState.Modified;
            Salvar();
        }

        public void AddOrUpdate(TEntity obj)
        {
            //if (obj.Id > 0)
            //    Update(obj);
            //else
            //    Add(obj);
        }

        /// <summary>
        /// Persistir alteração
        /// </summary>
        private void Salvar()
        {
            try
            {
                Context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw e;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro de Banco: " + ex.Message);
            }
        }

        //public TEntity First()
        //{
        //    return Entity.FirstOrDefault();
        //}
    }
}
