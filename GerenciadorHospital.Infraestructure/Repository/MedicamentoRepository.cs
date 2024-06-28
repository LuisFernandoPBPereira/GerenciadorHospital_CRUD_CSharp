using GerenciadorHospital.Domain.Entites;
using GerenciadorHospital.Domain.Repository;

namespace GerenciadorHospital.Infraestructure.Repository;

public class MedicamentoRepository : IMedicamento
{
    public Task<MedicamentoEntity> Adicionar(MedicamentoEntity convenio)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Apagar(int id)
    {
        throw new NotImplementedException();
    }

    public Task<MedicamentoEntity> Atualizar(MedicamentoEntity convenio)
    {
        throw new NotImplementedException();
    }

    public Task<MedicamentoEntity> BuscarPorId(int id)
    {
        throw new NotImplementedException();
    }
}
