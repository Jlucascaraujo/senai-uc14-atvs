using Exo.WebApi.Contexts;
using Exo.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Exo.WebApi.Repositories
{
    public class UsuarioRepository
    {
        private readonly ExoContext _context;
        public UsuarioRepository(ExoContext context)
        {
            _context = context;
        }

        public Usuario Login(string email, string senha)
        {
            return _context.Set<Usuario>().FirstOrDefault(u => u.Email == email && u.Senha == senha);
        }

        public List<Usuario> Listar()
        {
            return _context.Set<Usuario>().ToList();
        }

        public void Cadastrar(Usuario usuario)
        {
            _context.Set<Usuario>().Add(usuario);
            _context.SaveChanges(); 
        }

        public Usuario BuscarPorId(int id)
        {
            return _context.Set<Usuario>().Find(id);
        }

        public void Atualizar(int id, Usuario usuario)
        {
            Usuario usuarioBuscado = _context.Set<Usuario>().Find(id);
            if (usuarioBuscado != null)
            {
                usuarioBuscado.Email = usuario.Email;
                usuarioBuscado.Senha = usuario.Senha;
            }
            _context.Set<Usuario>().Update(usuarioBuscado);
            _context.SaveChanges();
        }

        public void Deletar(int id)
        {
            Usuario usuarioBuscado = _context.Set<Usuario>().Find(id);
            _context.Set<Usuario>().Remove(usuarioBuscado);
            _context.SaveChanges();
        }
    }
}
