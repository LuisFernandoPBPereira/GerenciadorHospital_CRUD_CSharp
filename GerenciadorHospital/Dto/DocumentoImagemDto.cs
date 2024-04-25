using GerenciadorHospital.Models;

namespace GerenciadorHospital.Dto
{
    public class DocumentoImagemDto
    {
        public IFormFile Doc { get; set; }
        public IFormFile? DocConvenio { get; set; }

        public DocumentoImagemDto() {   }

        public DocumentoImagemDto(PacienteModel pacienteModel)
        {
            Doc = pacienteModel.Doc;
            DocConvenio = pacienteModel.DocConvenio;
        }
    }
}
