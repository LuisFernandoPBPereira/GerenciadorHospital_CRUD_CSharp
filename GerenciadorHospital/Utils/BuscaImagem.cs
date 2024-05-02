using GerenciadorHospital.Models;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorHospital.Utils;

public class BuscaImagem : ControllerBase
{
    private readonly PacienteModel _pacienteModel;
    public BuscaImagem(PacienteModel pacienteModel)
    {
        _pacienteModel = pacienteModel;
    }
    public FileContentResult BuscarImagem(string caminho)
    {
        if (caminho != null)
        {
            if ((_pacienteModel.TemConvenio && _pacienteModel.ImgCarteiraDoConvenio == null) || _pacienteModel.ImgDocumento == null)
                throw new Exception("Não foi possível carregar a imagem");

            Byte[] b = System.IO.File.ReadAllBytes($"{caminho}");

            if (_pacienteModel.ImgDocumento.Contains(".jpg"))
                return File(b, "image/jpg");
            if (_pacienteModel.ImgDocumento.Contains(".jpeg"))
                return File(b, "image/jpeg");
        
            return File(b, "image/png");
        }
        else
        {
            throw new Exception("Não foi possível carregar a imagem");
        }

    }
}
