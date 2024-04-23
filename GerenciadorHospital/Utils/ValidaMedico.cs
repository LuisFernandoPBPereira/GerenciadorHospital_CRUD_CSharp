using FileTypeChecker;
using GerenciadorHospital.Models;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorHospital.Utils
{
    public class ValidaMedico : ControllerBase
    {
        private readonly MedicoModel _medicoModel;
        public ValidaMedico(MedicoModel medicoModel)
        {
            _medicoModel = medicoModel;
        }

        public FileContentResult BuscarDocMedico(string caminho)
        {
            if (caminho != null)
            {
                if (_medicoModel.CaminhoDoc == null)
                    throw new Exception("Não foi possível carregar a imagem");

                Byte[] b = System.IO.File.ReadAllBytes($"{caminho}");

                if (_medicoModel.CaminhoDoc.Contains(".jpg"))
                    return File(b, "image/jpg");
                if (_medicoModel.CaminhoDoc.Contains(".jpeg"))
                    return File(b, "image/jpeg");

                return File(b, "image/png");
            }
            else
            {
                throw new Exception("Não foi possível carregar a imagem");
            }

        }

        public bool ValidaImagem()
        {
            var arquivoDoc = _medicoModel.Doc.OpenReadStream();
            var isValidDoc = FileTypeValidator.IsImage(arquivoDoc);

            if (isValidDoc == false) return false;

            Guid guidDoc = Guid.NewGuid();

            var caminhoDoc = Path.Combine("Imagens/", $"{guidDoc.ToString().Substring(0, 8)}-{_medicoModel.Doc.FileName}");

            using (var stream = new FileStream(caminhoDoc, FileMode.Create))
                _medicoModel.Doc.CopyToAsync(stream);

            _medicoModel.CaminhoDoc = caminhoDoc;

            return true;
        }
    }
}
