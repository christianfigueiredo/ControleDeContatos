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

        
    }
}
