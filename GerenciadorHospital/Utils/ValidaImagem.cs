using FileTypeChecker;
using GerenciadorHospital.Dto;
using GerenciadorHospital.Models;
using GerenciadorHospital.Repositorios.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorHospital.Utils
{
    public class ValidaImagem : ControllerBase
    {
        private readonly PacienteResquestDto _requestDto;

        public ValidaImagem(PacienteResquestDto requestDto)
        {
            _requestDto = requestDto;
        }

        public bool ValidacaoImagem()
        {
            //Lemos os arquivos que supostamente devem ser imagens
            var arquivoDocConvenio = _requestDto.DocConvenio.OpenReadStream();
            var arquivoDoc = _requestDto.Doc.OpenReadStream();
            var isValidDocConvenio = FileTypeValidator.IsImage(arquivoDocConvenio);
            var isValidDoc = FileTypeValidator.IsImage(arquivoDoc);

            //Verificamos se os documentos são válidos, verificando se são imagens ou não
            if (isValidDoc == false || isValidDocConvenio == false)
                return false;

            if (_requestDto.TemConvenio)
            {
                if (_requestDto.DocConvenio == null || _requestDto.DocConvenio.Length == 0)
                    return false;

                Guid guidDocConvenio = Guid.NewGuid();
                var caminhoConvenio = Path.Combine("Imagens/", $"{guidDocConvenio + _requestDto.DocConvenio.FileName}");
                _requestDto.ImgCarteiraDoConvenio = caminhoConvenio;

                using (var stream = new FileStream(caminhoConvenio, FileMode.Create))
                    _requestDto.DocConvenio.CopyToAsync(stream);
            }

            //Se as fotos não forem carregadas, será retornado uma BadRequest
            if (_requestDto.Doc == null || _requestDto.Doc.Length == 0)
                return false;

            //Geramos um novo guid para deixar a foto com id único
            Guid guidDoc = Guid.NewGuid();

            //Passamos os caminhos das imagens
            var caminhoDoc = Path.Combine("Imagens/", $"{guidDoc + _requestDto.Doc.FileName}");

            //Todos pacientes recebem a imagem de documento

            using (var stream = new FileStream(caminhoDoc, FileMode.Create))
                _requestDto.Doc.CopyToAsync(stream);

            _requestDto.ImgDocumento = caminhoDoc;

            return true;
        }
    }
}
