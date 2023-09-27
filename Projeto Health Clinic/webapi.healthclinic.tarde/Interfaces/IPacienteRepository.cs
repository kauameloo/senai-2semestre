﻿using webapi.healthclinic.tarde.Domains;

namespace webapi.healthclinic.tarde.Interfaces
{
    public interface IPacienteRepository
    {
        void Cadastrar(Paciente paciente);

        void Deletar(Guid id);

        List<Paciente> Listar();

        Paciente BuscarPorId(Guid id);

        void Atualizar(Guid id, Paciente paciente);
    }
}
