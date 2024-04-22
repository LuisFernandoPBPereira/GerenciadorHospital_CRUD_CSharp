using FileTypeChecker;
using GerenciadorHospital.Models;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorHospital.Utils
{
    public class ValidaLaudo : ControllerBase
    {
        private readonly LaudoModel _laudoModel;
        public ValidaLaudo(LaudoModel laudoModel)
        {
            _laudoModel = laudoModel;
        }

        public FileContentResult BuscarImagemLaudo(string caminho)
        {
            if (caminho != null)
            {
                if (_laudoModel.CaminhoImagemLaudo == null)
                    throw new Exception("Não foi possível carregar a imagem");

                Byte[] b = System.IO.File.ReadAllBytes($"{caminho}");

                if (_laudoModel.CaminhoImagemLaudo.Contains(".jpg"))
                    return File(b, "image/jpg");
                if (_laudoModel.CaminhoImagemLaudo.Contains(".jpeg"))
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
            var arquivoDoc = _laudoModel.ImagemLaudo.OpenReadStream();
            var isValidDoc = FileTypeValidator.IsImage(arquivoDoc);

            if (isValidDoc == false) return false;

            Guid guidDoc = Guid.NewGuid();

            var caminhoDoc = Path.Combine("Imagens/", $"{guidDoc.ToString().Substring(0, 8)}-{_laudoModel.ImagemLaudo.FileName}");

            using (var stream = new FileStream(caminhoDoc, FileMode.Create))
                _laudoModel.ImagemLaudo.CopyToAsync(stream);

            _laudoModel.CaminhoImagemLaudo = caminhoDoc;

            return true;
        }
    }
}
