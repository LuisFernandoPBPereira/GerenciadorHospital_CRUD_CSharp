<h1 align="center">Gerenciador de Hospital <img src="https://raw.githubusercontent.com/tomchen/stack-icons/master/logos/c-sharp.svg" width="30px"></h1>
<br/>

<h2>Sobre:</h2>
<br/>

<p>Este projeto consistem em um sistema que gerencie um hospital, neste sistema é possível cadastrar pacientes, médicos, consultas e etc.</p>
<br/>

<h2>Explicando o conceito da API:</h2>
<ul>
	<h3><li>Models:</li></h3><br/>
	<p>
		A partir das Models, modelamos nossas entidades para criarmos relacionamentos entre elas, e isso é possível através do EntityFrameworkCore.
	</p>
	<h3><li>Maps:</li></h3><br/>
	<p>
		Ao criar uma Map, podemos mapear nossas entidades, dizendo o que cada campo é, se é uma chave primária, uma propriedade, ou até mesmo uma FK
		(Foreign Key).
	</p>
	<h3><li>Contexto do Banco de Dados:</li></h3><br/>
	<p>
		Podemos criar um arquivo de contexto do banco de dados ao finalizar nossas models e maps, sendo assim, podemos executar migrations e atualizar
		o nosso banco de dados quando necessário.
	</p>
	<h3><li>Interfaces:</li></h3><br/>
	<p>
		Explicando de uma maneira simples, as interfaces são classes que são feitas para serem herdadas, como se fosse uma classe abstrata, porém,
		apenas aplicamos métodos a elas.
	</p>
	<h3><li>Implementação da interface:</li></h3><br/>
	<p>
		Podemos criar uma pasta repositório que guardam classes que implementam interfaces, desta maneira, a implementação de uma interface é feita
		de uma forma mais organizada e limpa. <br/>
		OBS.: Não é possívem fazer uma injeção de dependência de uma interface dentro de outra.
	</p>
	<h3><li>Controller:</li></h3><br/>
	<p>
		Onde controlamos as ações da API, com os métodos HTTP GET, POST, PUT e DELETE, onde também é aplicada a regra de negócio da aplicação.
	</p>
	<h3><li>DTO (Data Transfer Object):</li></h3><br/>
	<p>
		Classe onde podemos fazer uma transferência de ojetos, é útil para criar campos que não foram necessariamente mapeados e modelados.
	</p>
	<h3><li>Utils</li></h3><br/>
	<p>
		Aqui podemos inserir classes e métodos que podem ser úteis em validações, por exemplo.
	</p>
	<h3><li>Program.cs:</li></h3><br/>
	<p>
		Não podemos nos esquecer de adicionar o escopo das injeções de dependência das nossas interfaces, além de configurarmos o EntityFramework.
	</p>
</ul>

<br/>

<h2>Campos dos atributos (também como tabelas do banco de dados)</h2>

```
PACIENTE
public int Id {  get; set; }
public string Nome { get; set; }
public string Cpf { get; set; }
public string Endereco { get; set; }
public DateTime DataNasc {  get; set; }
public bool TemConvenio { get; set; }
public string? ImgCarteiraDoConvenio { get; set; }
public string? ImgDocumento { get; set; }
public int? ConvenioId { get; set; }
public int? MedicamentoId { get; set; }
public int? ExameId { get; set; }
public virtual ConvenioModel? Convenio {  get; set; }
public virtual MedicamentoPacienteModel? Medicamento {  get; set; }
public virtual TipoExameModel? Exame {  get; set; }



MÉDICO
public int Id { get; set; }
public string Nome { get; set; }
public string Cpf { get; set; }
public string Crm { get; set; }
public string Especializacao { get; set; }


CONVÊNIOS
public int Id { get; set; }
public string Nome { get; set; }
public float Preco { get; set; }

TIPOS EXAMES
public int Id { get; set; }
public string Nome { get; set; }

REGISTRO CONSULTAS
public int Id { get; set; }
public int PacienteId { get; set; }
public int? MedicoId { get; set; }
public DateTime DataConsulta {  get; set; }
public decimal? Valor { get; set; }
public DateTime? DataRetorno { get; set; }
public StatusConsulta? EstadoConsulta { get; set; }
public virtual PacienteModel? Paciente { get; set; }
public virtual MedicoModel? Medico { get; set; }

LAUDOS
public int Id { get; set; }
public string Descricao { get; set; }
public int? PacienteId { get; set; }
public virtual PacienteModel? Paciente { get; set; }

MEDICAMENTOS DO PACIENTE

public int Id { get; set; }
public string Nome { get; set; }
public string Composicao { get; set; }
public DateTime DataFabricacao { get; set; }
public DateTime DataValidade { get; set; }
```

<h2>Campos dos atributos da PacienteRequestDto (DTO: Data Transfer Object -> Objeto de Transferência de Dados)</h2>

```
public class PacienteResquestDto : PacienteModel
{
    public IFormFile Doc { get; set; }
    public IFormFile DocConvenio? { get; set; }
}

```
<h2>Retorno da Imagem do paciente:</h2>
<ul>
	<li>Criamos um endpoint separadamente, apenas para retornar a imagem do paciente, sendo mais eficiente</li>
	<li>O exemplo abaixo mostra o retorno da imagem do documento</li>
</ul>
<br/>

```
[HttpGet("MostrarDoc/{id}")]
public async Task<ActionResult<List<PacienteModel>>> BuscarDocPorId(int id)
{
    PacienteModel paciente = await _pacienteRepositorio.BuscarDocPorId(id);
    
    var caminho = paciente.ImgDocumento;
    Byte[] b = System.IO.File.ReadAllBytes($"{caminho}");

    if (paciente.ImgDocumento.Contains(".png"))
        return File(b, "image/png");
    if (paciente.ImgDocumento.Contains(".jpg"))
        return File(b, "image/jpg");
    if (paciente.ImgDocumento.Contains(".jpeg"))
        return File(b, "image/jpeg");

    return BadRequest("Não foi possível buscar a imagem");
}
```
<ul>
	<li>O exemplo abaixo mostra outro endpoint para retornar a imagem da carteira do convênio</li>
</ul>

```
[HttpGet("MostrarDocConvenio/{id}")]
public async Task<ActionResult<List<PacienteModel>>> BuscarDocConvenioPorId(int id)
{
    //Capturamos o paciente pelo ID
    PacienteModel paciente = await _pacienteRepositorio.BuscarDocConvenioPorId(id);

    //Se o paciente não tiver uma imagem salva, retorna uma BadRequest
    if (paciente.ImgCarteiraDoConvenio == null)
    {
        return BadRequest("Este paciente não possui foto da carteira do convênio");
    }
    //Caso o paciente não tenha convênio, retorna outra BadRequest
    else if (paciente.TemConvenio == false)
    {
        return BadRequest("Este paciente não possui convênio");

    }

    var caminho = paciente.ImgCarteiraDoConvenio;

    if(caminho is null)
    {
        return BadRequest("Este paciente não possui carteira do convênio");
    }

    Byte[] b = System.IO.File.ReadAllBytes($"{caminho}");

    if (paciente.ImgDocumento.Contains(".png"))
        return File(b, "image/png");
    if (paciente.ImgDocumento.Contains(".jpg"))
        return File(b, "image/jpg");
    if (paciente.ImgDocumento.Contains(".jpeg"))
        return File(b, "image/jpeg");

    return BadRequest("Não foi possível buscar a imagem");
}
```
<br/>

<h2>Verificações e Tratativas de Imagem</h2>
<ul>
	<li>Verificamos tanto a inserção quanto o retorno:</li>
	<li>A seguir, a inserção:</li>
</ul>

```
 //Lemos os arquivos que supostamente devem ser imagens
 var arquivoDocConvenio = requestDto.DocConvenio.OpenReadStream();
 var arquivoDoc = requestDto.Doc.OpenReadStream();
 var isValidDocConvenio = FileTypeValidator.IsImage(arquivoDocConvenio);
 var isValidDoc = FileTypeValidator.IsImage(arquivoDoc);
 
 //Verificamos se os documentos são válidos, verificando se são imagens ou não
 if(isValidDoc == false || isValidDocConvenio == false)
     return BadRequest("O arquivo carregado não é uma imagem");
```
<ul>
	<li>Agora o retorno:</li>
</ul>

```
PacienteModel paciente = await _pacienteRepositorio.BuscarDocPorId(id);

var caminho = paciente.ImgDocumento;
Byte[] b = System.IO.File.ReadAllBytes($"{caminho}");

if (paciente.ImgDocumento.Contains(".png"))
    return File(b, "image/png");
if (paciente.ImgDocumento.Contains(".jpg"))
    return File(b, "image/jpg");
if (paciente.ImgDocumento.Contains(".jpeg"))
    return File(b, "image/jpeg");

return BadRequest("Não foi possível buscar a imagem");
```

<br/>



<h2>Usando Summary:</h2>
<ul>
	<li>Usamos o Summary para documentar nossa API nos enpoints, para melhor visualização das regras de negócio</li>
	<li>Primeiro devemos configurar nosso projeto para usá-lo. Abrimos o xml do projeto (está com o nome do projeto) e inserimos esse bloco de código abaixo:</li>
</ul>

```
<GenerateDocumentationFile>true</GenerateDocumentationFile>
<NoWarn>$(NoWarn);1591</NoWarn>
```
<br/>
<ul>
	<li>Logo após, configuramos a documentação do Swagger na Program.cs</li>
</ul>

```
builder.Services.AddSwaggerGen(c =>
{   
    c.SwaggerDoc("v1", new OpenApiInfo
    {

    });
    var xmlFile = "GerenciadorHospital.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

    c.IncludeXmlComments(xmlPath);
});
```
<ul>
	<li>Agora podemos usar em nossos endpoints!</li>
</ul>

```
/// <summary>
/// Cadastrar um Paciente
/// </summary>
/// <param name="requestDto">Dados do Paciente</param>
/// <returns>Paciente Cadastrado</returns>
/// <response code="200">Paciente cadastrado com SUCESSO</response>
```

<h2>ConnectionStrings (Conexão do banco de dados):</h2>

```
"server=nomeDoServidor;database=nomeDoBancoDeDados;TrustServerCertificate=True;Integrated Security=SSPI;"
```
<br/>
