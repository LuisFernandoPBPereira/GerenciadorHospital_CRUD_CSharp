using GerenciadorHospital.Models;

namespace GerenciadorHospital.Dto.Requests
{
    public class DocumentoImagemDto
    {
        public IFormFile Doc { get; set; }
        public IFormFile? DocConvenio { get; set; }

        // Doc: O campo não anulável precisa conter um valor não nulo ao sair do construtor. Considere declará-lo como anulável.
#pragma warning disable CS8618

        public DocumentoImagemDto() { }

        public DocumentoImagemDto(PacienteModel pacienteModel)
        {
            Doc = pacienteModel.Doc;
            DocConvenio = pacienteModel.DocConvenio;
        }
    }
}
