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
    public IFormFile DocConvenio { get; set; }
}

```
<ul>
	<li>Aqui nós recebemos os uploads das fotos de documento e o documento do convênio</li>
</ul>
<br/>

<p>Essas entidades possuem relação, então devemos aplicar algumas regras de negócio que ainda não estão concluídas</p>
<h2>Regras de negócio para serem aplicadas:</h2>

<h3 align="center">IMPLEMENTAR FILE.TYPECHECKER (Nuget Package):</h3>
<ul>
	<li>Ao instalarmos este pacote, podemos verificar se o arquivo que está sendo carregado, realmente é do tipo que precisamos, evitando erros e vazamento de exceções</li>
</ul>
<br/>

<h3 align="center">CRIAR VARIÁVEL DE AMBIENTE OU USAR GITIGNORE:</h3>
<ul>
	<li>Não devemos expor nossa string de conexão, é um dado sensível, então podemos ignorar o upload do appsettings.Development.json, ou criar uma variável de ambiente</li>
</ul>
<br/>

