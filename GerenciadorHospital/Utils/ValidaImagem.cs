using FileTypeChecker;
using GerenciadorHospital.Dto;
using GerenciadorHospital.Models;
using GerenciadorHospital.Repositorios.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorHospital.Utils
{
    public class ValidaImagem : ControllerBase
    {
        private readonly DocumentoImagemDto _documentoImagem;
        private readonly PacienteModel _pacienteModel;

        public ValidaImagem(DocumentoImagemDto documentoImagem, PacienteModel pacienteModel)
        {
            _documentoImagem = documentoImagem;
            _pacienteModel = pacienteModel;
        }

        public bool ValidacaoImagem()
        {
            if(_pacienteModel.TemConvenio && _documentoImagem.DocConvenio != null)
            {
                var arquivoDocConvenio = _documentoImagem.DocConvenio.OpenReadStream();
                var isValidDocConvenio = FileTypeValidator.IsImage(arquivoDocConvenio);
                    
                if (isValidDocConvenio == false) return false;
                    
                if (_documentoImagem.DocConvenio == null || _documentoImagem.DocConvenio.Length == 0)
                    return false;

                Guid guidDocConvenio = Guid.NewGuid();

                var caminhoConvenio = Path.Combine("Imagens/", $"{guidDocConvenio.ToString().Substring(0, 8)}-{_documentoImagem.DocConvenio.FileName}");
                _pacienteModel.ImgCarteiraDoConvenio = caminhoConvenio;

                using (var stream = new FileStream(caminhoConvenio, FileMode.Create))
                    _documentoImagem.DocConvenio.CopyToAsync(stream);
            }

            if (_documentoImagem.Doc == null || _documentoImagem.Doc.Length == 0 || 
               (_pacienteModel.ConvenioId != null && _pacienteModel.TemConvenio == false))
                return false;
                
            var arquivoDoc = _documentoImagem.Doc.OpenReadStream();
            var isValidDoc = FileTypeValidator.IsImage(arquivoDoc);

            if(isValidDoc == false) return false;

            Guid guidDoc = Guid.NewGuid();

            var caminhoDoc = Path.Combine("Imagens/", $"{guidDoc.ToString().Substring(0, 8)}-{_documentoImagem.Doc.FileName}");

            using (var stream = new FileStream(caminhoDoc, FileMode.Create))
                _documentoImagem.Doc.CopyToAsync(stream);

            _pacienteModel.ImgDocumento = caminhoDoc;

            return true;
        }
    }
}
