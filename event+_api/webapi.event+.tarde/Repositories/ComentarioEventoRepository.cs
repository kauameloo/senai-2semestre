using webapi.event_.tarde.Contexts;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;
using webapi.event_.tarde.Utils;

namespace webapi.event_.tarde.Repositories
{
    public class ComentarioEventoRepository : IComentarioEventoRepository
    {
        private readonly EventContext ctx;

        public ComentarioEventoRepository()
        {
            ctx = new EventContext();
        }

        public ComentarioEvento BuscarPorId(Guid id)
        {
            try
            {
                ComentarioEvento comentarioBuscado = ctx.ComentarioEvento
                    .Select(u => new ComentarioEvento
                    {
                        IdComentarioEvento = u.IdComentarioEvento,
                        IdEvento = u.IdEvento,
                        Usuario = new Usuario
                        {
                            IdUsuario = u.IdUsuario,
                            NomeUsuario = u.Usuario.NomeUsuario
                        },
                        Descricao = u.Descricao,
                    }).FirstOrDefault(u => u.IdComentarioEvento == id)!;

                return comentarioBuscado;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(ComentarioEvento comentarioEvento)
        {
            try
            {
                ctx.ComentarioEvento.Add(comentarioEvento);

                ctx.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Deletar(Guid id)
        {
            ComentarioEvento comentarioBuscado = ctx.ComentarioEvento.Find(id);

            if (comentarioBuscado != null)
            {
                ctx.ComentarioEvento.Remove(comentarioBuscado);
            }

            ctx.SaveChanges();
        }

        public List<ComentarioEvento> Listar()
        {
            return ctx.ComentarioEvento.ToList();
        }
    }
}
