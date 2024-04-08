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
            //Lemos os arquivos que supostamente devem ser imagens
            var arquivoDocConvenio = _documentoImagem.DocConvenio.OpenReadStream();
            var arquivoDoc = _documentoImagem.Doc.OpenReadStream();
            var isValidDocConvenio = FileTypeValidator.IsImage(arquivoDocConvenio);
            var isValidDoc = FileTypeValidator.IsImage(arquivoDoc);

            //Verificamos se os documentos são válidos, verificando se são imagens ou não
            if (isValidDoc == false || isValidDocConvenio == false)
                return false;

            if (_pacienteModel.TemConvenio)
            {
                if (_documentoImagem.DocConvenio == null || _documentoImagem.DocConvenio.Length == 0)
                    return false;

                Guid guidDocConvenio = Guid.NewGuid();
                var caminhoConvenio = Path.Combine("Imagens/", $"{guidDocConvenio.ToString().Substring(0, 8)}-{_documentoImagem.DocConvenio.FileName}");
                _pacienteModel.ImgCarteiraDoConvenio = caminhoConvenio;

                using (var stream = new FileStream(caminhoConvenio, FileMode.Create))
                    _documentoImagem.DocConvenio.CopyToAsync(stream);
            }

            //Se as fotos não forem carregadas, será retornado uma BadRequest
            if (_documentoImagem.Doc == null || _documentoImagem.Doc.Length == 0)
                return false;

            //Geramos um novo guid para deixar a foto com id único
            Guid guidDoc = Guid.NewGuid();

            //Passamos os caminhos das imagens
            var caminhoDoc = Path.Combine("Imagens/", $"{guidDoc.ToString().Substring(0, 8)}-{_documentoImagem.Doc.FileName}");

            //Todos pacientes recebem a imagem de documento

            using (var stream = new FileStream(caminhoDoc, FileMode.Create))
                _documentoImagem.Doc.CopyToAsync(stream);

            _pacienteModel.ImgDocumento = caminhoDoc;

            return true;
        }
    }
}
