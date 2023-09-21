using webapi.event_.tarde.Contexts;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;
using webapi.event_.tarde.Utils;

namespace webapi.event_.tarde.Repositories
{
    public class PresencaEventoRepository : IPresencaEventoRepository
    {
        private readonly EventContext ctx;

        public PresencaEventoRepository()
        {
            ctx = new EventContext();
        }
        public void Atualizar(Guid id, PresencaEvento presencaEvento)
        {
            PresencaEvento presencaBuscado = ctx.PresencaEvento.Find(id);

            if (presencaBuscado != null)
            {
                presencaBuscado.IdUsuario = presencaEvento.IdUsuario;
                presencaBuscado.Situacao = presencaEvento.Situacao;
                presencaBuscado.IdEvento = presencaEvento.IdEvento;
            }

            ctx.PresencaEvento.Update(presencaBuscado!);
            ctx.SaveChanges();
        }

        public PresencaEvento BuscarPorId(Guid id)
        {
            try
            {
                PresencaEvento presencaBuscado = ctx.PresencaEvento
                    .Select(u => new PresencaEvento
                    {
                        IdPresencaEvento = u.IdPresencaEvento,
                        IdEvento = u.IdEvento,
                        Usuario = new Usuario
                        {
                            IdUsuario = u.IdUsuario,
                            NomeUsuario = u.Usuario.NomeUsuario
                        },
                        Situacao = u.Situacao
                    }).FirstOrDefault(u => u.IdPresencaEvento == id)!;

                return presencaBuscado;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(PresencaEvento inscricao)
        {
            try
            {
                ctx.PresencaEvento.Add(inscricao);

                ctx.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Deletar(Guid id)
        {
            PresencaEvento presencaBuscado = ctx.PresencaEvento.Find(id);

            if (presencaBuscado != null)
            {
                ctx.PresencaEvento.Remove(presencaBuscado);
            }

            ctx.SaveChanges();
        }

        public List<PresencaEvento> Listar()
        {
            return ctx.PresencaEvento.ToList();
        }

        public List<PresencaEvento> ListarMinhas(Guid id)
        {
            try
            {
                List<PresencaEvento> presencaEvento = ctx.PresencaEvento.Where(x => x.IdUsuario == id).ToList();
                return presencaEvento;
            }
            catch (Exception)
            {

                throw;
            }


        }
    }
}
