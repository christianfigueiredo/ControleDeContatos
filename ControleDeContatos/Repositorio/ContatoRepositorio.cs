using ControleDeContatos.Data;
using ControleDeContatos.Models;
using System.Collections.Generic;
using System.Linq;

namespace ControleDeContatos.Repositorio
{
    public class ContatoRepositorio : IContatoRepositorio
    {
        private readonly Contexto _contexto;
        public ContatoRepositorio(Contexto contexto)
        {
            _contexto = contexto;
        }

        public ContatoModel ListarPorId(int id)
        {
           return _contexto.Contatos.FirstOrDefault(c => c.Id == id);
        }

        public List<ContatoModel> BuscarTodos()
        {
            return _contexto.Contatos.ToList();
        }
        public ContatoModel Adicionar(ContatoModel contato)
        {
            //gravar no banco de dados
            _contexto.Contatos.Add(contato);
            _contexto.SaveChanges();
            return contato;
        }

        public ContatoModel Atualizar(ContatoModel contato)
        {
            ContatoModel contatodb = ListarPorId(contato.Id);

            if (contatodb == null) throw new System.Exception("Houve erro na atualização em contato");

            contatodb.Nome = contato.Nome;
            contatodb.Email = contato.Email;
            contatodb.Celular = contato.Celular;

            _contexto.Update(contatodb);
            _contexto.SaveChanges();
            return contatodb;
           
        }

        public bool Apagar(int id)
        {
            ContatoModel contatodb = ListarPorId(id);
            if (contatodb == null) throw new System.Exception("Houve erro na deleção do contato");

            _contexto.Contatos.Remove(contatodb);
            _contexto.SaveChanges();
            return true;

        }
    }
}
