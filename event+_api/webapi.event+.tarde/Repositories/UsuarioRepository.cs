﻿using webapi.event_.tarde.Contexts;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;
using webapi.event_.tarde.Utils;

namespace webapi.event_.tarde.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly EventContext ctx;

        public UsuarioRepository()
        {
            ctx = new EventContext();
        }


        public void Atualizar(Guid id, Usuario usuario)
        {
            Usuario usuarioBuscado = ctx.Usuario.Find(id);

            if (usuario != null)
            {
                usuarioBuscado.NomeUsuario = usuario.NomeUsuario;
            }

            ctx.Usuario.Update(usuarioBuscado!);
            ctx.SaveChanges();
        }

        public Usuario BuscarPorEmailESenha(string email, string senha)
        {
            try
            {
                Usuario usuarioBuscado = ctx.Usuario
                                     .Select(u => new Usuario
                                     {
                                         IdUsuario = u.IdUsuario,
                                         NomeUsuario = u.NomeUsuario,
                                         Email = u.Email,
                                         Senha = u.Senha,

                                         TipoUsuario = new TipoUsuario
                                         {
                                             IdTipoUsuario = u.IdTipoUsuario,
                                             Titulo = u.TipoUsuario.Titulo
                                         }
                                     }).FirstOrDefault(u => u.Email == email)!;

                if (usuarioBuscado != null)
                {
                    bool confere = Criptografia.CompararHash(senha, usuarioBuscado.Senha!);

                    if (confere)
                    {
                        return usuarioBuscado;
                    }
                }
                return null!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Usuario BuscarPorId(Guid id)
        {
            try
            {
                Usuario usuarioBuscado = ctx.Usuario
                    .Select(u => new Usuario
                    {
                        IdUsuario = u.IdUsuario,
                        NomeUsuario = u.NomeUsuario,
                        Email = u.Email,

                        TipoUsuario = new TipoUsuario
                        {
                            IdTipoUsuario = u.IdTipoUsuario,
                            Titulo = u.TipoUsuario.Titulo
                        }
                    }).FirstOrDefault(u => u.IdUsuario == id)!;

                return usuarioBuscado;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(Usuario usuario)
        {
            try
            {
                usuario.Senha = Criptografia.GerarHash(usuario.Senha);
                ctx.Usuario.Add(usuario);

                ctx.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Deletar(Guid id)
        {
            Usuario usuarioBuscado = ctx.Usuario.Find(id);

            if (usuarioBuscado != null)
            {
                ctx.Usuario.Remove(usuarioBuscado);
            }

            ctx.SaveChanges();
        }

        public List<Usuario> Listar()
        {
            return ctx.Usuario.ToList();
        }
    }
}
