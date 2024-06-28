using GerenciadorHospital.Domain.Entites;

namespace GerenciadorHospital.Domain.Repository;

public interface IMedicamento
{
    Task<MedicamentoEntity> BuscarPorId(int id);
    Task<MedicamentoEntity> Adicionar(MedicamentoEntity convenio);
    Task<MedicamentoEntity> Atualizar(MedicamentoEntity convenio);
    Task<bool> Apagar(int id);
}
