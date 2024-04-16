<h1 align="center">Gerenciador de Hospital <img src="https://raw.githubusercontent.com/tomchen/stack-icons/master/logos/c-sharp.svg" width="30px"></h1>
<br/>

<h2>Sobre:</h2>
<br/>

<p>Este projeto consistem em um sistema que gerencie um hospital, neste sistema é possível cadastrar pacientes, médicos, consultas e etc.</p>
<br/>

<h2>Wiki</h2>
<ul>
	<li><a href="https://github.com/LuisFernandoPBPereira/GerenciadorHospital_CRUD_CSharp/wiki/Estrutura-da-API">Estrutura da API</a></li>
	<li><a href="https://github.com/LuisFernandoPBPereira/GerenciadorHospital_CRUD_CSharp/wiki/Entidades">Entidades</a></li>
</ul>

<h2>Retorno da Imagem do paciente:</h2>
<ul>
	<li>Criamos um endpoint separadamente, apenas para retornar a imagem do paciente, sendo mais eficiente;</li>
	<li>O exemplo abaixo mostra o retorno da imagem do documento:</li>
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
	<li>O exemplo abaixo mostra outro endpoint para retornar a imagem da carteira do convênio:</li>
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
	<li>Usamos o Summary para documentar nossa API nos enpoints, para melhor visualização das regras de negócio;</li>
	<li>Primeiro devemos configurar nosso projeto para usá-lo. Abrimos o xml do projeto (está com o nome do projeto) e inserimos esse bloco de código abaixo:</li>
</ul>

```
<GenerateDocumentationFile>true</GenerateDocumentationFile>
<NoWarn>$(NoWarn);1591</NoWarn>
```
<br/>
<ul>
	<li>Logo após, configuramos a documentação do Swagger na Program.cs;</li>
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

<h2>ConnectionStrings SQL Server (Conexão do banco de dados):</h2>

```
"server=nomeDoServidor;database=nomeDoBancoDeDados;TrustServerCertificate=True;Integrated Security=SSPI;"
```
<br/>

<h2>ConnectionStrings com SQLite (Para fins de teste):</h2>

```
"Data Source=Data/BancoSQLite/database.db;"
```
<br/>

<h2>Usamos JWT para autenticar os usuários em nosso sistema.</h2>
<div align="center">
	<img src="https://github.com/LuisFernandoPBPereira/GerenciadorHospital_CRUD_CSharp/assets/86135150/b8f8b462-bc18-4d07-a115-032ca2830bb7"/>
</div>

<h3>Com o JWT, nos permite:</h3>
<ul>
	<li>Definir políticas de acesso (as Roles ("papéis"));</li>
	<li>Aplicar autorizações usando o token, podendo criar um sistema de login seguro;</li>
	<li>Transportar dados de maneira segura, pois o token contém as informações que quisermos de maneira criptografada;</li>
</ul>

<br/>

<h3>Mas em qual caso isso é útil?</h3>
<p>
	Nesta api, por exemplo, definimos 3 tipos de acessos: "ElevatedRights", "AdminAndDoctorRights", "StandardRights". E o que isso quer dizer?
	<ul>
		<li>ElevatedRights: Apenas o usuário Admin consegue usar todas as funcionalidades do sistema;</li>
		<li>AdminAndDoctorRights: Como o próprio nome sugere, os endpoints que tiverem essa política, serão acessados apenas pelo Admin e o Médico;</li>
		<li>StandardRights: Todos usuários tem acesso, porém é um acesso mais restrito para o paciente, como visualização e alteração do próprio cadastro;</li>
	</ul>
</p>
<br/>

<h2>Roles</h2>
<p>
	Como vimos no tópico sobre JWT, ele nos permite trabalhar com Roles, mas como definimos as roles? Simples! Usamos o Identity!
</p>
<h3>O que é o Identity?</h3>
<p>Identity é uma api que gerencia os dados de um usuário, podendo até criar entidade pronta para se usar, com uma simples herança em sua entidade e ela está pronta.</p>
