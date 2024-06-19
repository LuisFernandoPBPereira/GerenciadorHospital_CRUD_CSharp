using FileTypeChecker;
using GerenciadorHospital.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Text.RegularExpressions;

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
            if (caminho != null || caminho != string.Empty)
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
            if (_medicoModel.Doc is null)
                throw new Exception("Nenhuma imagem foi carregada");

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

        public void ValidacaoMedico()
        {
            if (_medicoModel.Nome.IsNullOrEmpty())
                throw new Exception("Informe um nome para o médico");

            if (Regex.IsMatch(_medicoModel.Nome, "^[0-9]+$"))
                throw new Exception("Informe o nome para o médico corretamente");

            if (_medicoModel.Cpf.IsNullOrEmpty())
                throw new Exception("Informe um CPF para o médico");
            
            if (_medicoModel.Cpf.Length is not 11)
                throw new Exception("Informe um CPF válido para o médico");

            if (_medicoModel.DataNasc > DateTime.Now.AddYears(-18))
                throw new Exception("Informe uma data de nascimento válida");
            
            if (_medicoModel.DataNasc.Year < 1900)
                throw new Exception("Informe uma data de nascimento válida");

            if (_medicoModel.Endereco.IsNullOrEmpty())
                throw new Exception("Informe um endereço para o médico");

            if (_medicoModel.Senha.IsNullOrEmpty())
                throw new Exception("Informe uma senha para o médico");

            if (_medicoModel.Crm.IsNullOrEmpty() || _medicoModel.Crm.Length > 10)
                throw new Exception("Informe um CRM para o médico corretamente");

            if (_medicoModel.Especializacao.IsNullOrEmpty())
                throw new Exception("Informe uma especialização para o médico");

            if (_medicoModel.Doc is null)
                throw new Exception("Imagem do documento não foi carregada");

        }
    }
}
