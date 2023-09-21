using webapi.event_.tarde.Contexts;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;
using webapi.event_.tarde.Utils;

namespace webapi.event_.tarde.Repositories
{
    public class EventoRepository : IEventoRepository
    {

        private readonly EventContext ctx;

        public EventoRepository()
        {
            ctx = new EventContext();
        }

        public void Atualizar(Guid id, Evento evento)
        {
            Evento eventoBuscado = ctx.Evento.Find(id);

            if (evento != null)
            {
                eventoBuscado.NomeEvento = evento.NomeEvento;
                eventoBuscado.DataEvento = evento.DataEvento;
                eventoBuscado.Descricao = evento.Descricao;
                eventoBuscado.IdTipoEvento = evento.IdTipoEvento;
            }

            ctx.Evento.Update(eventoBuscado!);
            ctx.SaveChanges();
        }

        public Evento BuscarPorId(Guid id)
        {
            try
            {
                Evento eventoBuscado = ctx.Evento
                    .Select(u => new Evento
                    {
                        IdEvento = u.IdEvento,
                        NomeEvento = u.NomeEvento,
                        DataEvento = u.DataEvento,
                        Descricao = u.Descricao,


                        TipoEvento = new TipoEvento
                        {
                            IdTipoEvento = u.IdTipoEvento,
                            Titulo = u.TipoEvento.Titulo
                        },
                        Instituicao = new Instituicao
                        {
                            IdInstituicao = u.IdInstituicao,
                            NomeFantasia = u.Instituicao.NomeFantasia,
                            CNPJ = u.Instituicao.CNPJ,
                            Endereco = u.Instituicao.Endereco
                        }
                    }).FirstOrDefault(u => u.IdEvento == id)!;

                return eventoBuscado;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(Evento evento)
        {
            try
            {
                ctx.Evento.Add(evento);

                ctx.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Deletar(Guid id)
        {
            Evento eventoBuscado = ctx.Evento.Find(id);

            if (eventoBuscado != null)
            {
                ctx.Evento.Remove(eventoBuscado);
            }

            ctx.SaveChanges();
        }

        public List<Evento> Listar()
        {
            return ctx.Evento.ToList();
        }
    }
}
