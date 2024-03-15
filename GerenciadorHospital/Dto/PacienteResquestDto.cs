using GerenciadorHospital.Models;

namespace GerenciadorHospital.Dto
{
    /*
     * Criamos um Data Transfer Object para recebermos as imagens necessárias
     * da PacienteModel, esses atríbutos não estão mapeados no banco de dados
    */
    public class PacienteResquestDto : PacienteModel
    {
        public IFormFile Doc { get; set; }
        public IFormFile? DocConvenio { get; set; }
    }
}
