using ControleDeContatos.Data;
using ControleDeContatos.Models;

namespace ControleDeContatos.Repositorio
{
    public class ContatoRepositorio : IContatoRepositorio
    {
        private readonly BancoContext _context;
        public ContatoRepositorio(BancoContext bancoContext)
        {
            _context = bancoContext;
        }

        public ContatoModel Adicionar(ContatoModel contato)
        {
            //gravar no Banco de dados
            _context.Contatos.Add(contato);
            _context.SaveChanges();
            return contato;
        }

        public ContatoModel Atualizar(ContatoModel contato)
        {
            ContatoModel contatoDb = ListarPorId(contato.Id);

            if (contatoDb == null) throw new Exception("Houve um erro na atualização do contato");

            contatoDb.Nome = contato.Nome;
            contatoDb.Email = contato.Email;
            contatoDb.Celular = contato.Celular;

            _context.Contatos.Update(contatoDb);
            _context.SaveChanges();
            return contatoDb;
        }

        public List<ContatoModel> BuscarTodos()
        {
            return _context.Contatos.ToList();
        }

        public ContatoModel ListarPorId(int id)
        {
            return _context.Contatos.FirstOrDefault(x => x.Id == id);
        }
        public bool Apagar(int id)
        {
            ContatoModel contatoDb = ListarPorId(id);
            if (contatoDb == null) throw new Exception("Houve um erro na atualização do contato");

            _context.Contatos.Remove(contatoDb);
            _context.SaveChanges();
            return true;
        }
    }
}
