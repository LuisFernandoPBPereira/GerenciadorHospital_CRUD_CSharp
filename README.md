<h1 align="center">Gerenciador de Hospital <img src="https://raw.githubusercontent.com/tomchen/stack-icons/master/logos/c-sharp.svg" width="30px"></h1>
<br/>

<h2>Sobre:</h2>
<br/>

<p>Este projeto consistem em um sistema que gerencie um hospital, neste sistema é possível cadastrar pacientes, médicos, consultas e etc.</p>
<br/>

<p>Essas entidades possuem relação, então devemos aplicar algumas regras de negócio que ainda não estão concluídas</p>
<br/>

<h2>Campos dos atributos (também como tabelas do banco de dados)</h2>

	PACIENTE
	public int Id {  get; set; }
	public string Nome { get; set; }
	public string Cpf { get; set; }
	public string Endereco { get; set; }
	public DateTime DataNasc {  get; set; }
	public bool TemConvenio { get; set; }
	public string ImgCarteiraDoConvenio { get; set; }
	public string ImgDocumento { get; set; }
	public int? ConvenioId { get; set; }
	public int? MedicamentoId { get; set; }
	public virtual ConvenioModel? Convenio {  get; set; }
	public virtual MedicamentoPacienteModel? Medicamento {  get; set; }



	MÉDICO
	public int Id { get; set; }
	public string Nome { get; set; }
	public string Cpf { get; set; }


	CONVÊNIOS
	public int Id { get; set; }
	public string Nome { get; set; }
	public float Preco { get; set; }

	TIPOS EXAMES
	public int Id { get; set; }
	public string Nome { get; set; }

	REGISTRO CONSULTAS
	public int Id { get; set; }
	public int? PacienteId { get; set; }
	public int? MedicoId { get; set; }
	public DateTime DataConsulta {  get; set; }
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

 <h2>Regras de negócio para serem aplicadas:</h2>

<h3 align="center">COBRANÇA</h3>

<p>
  Uma tabela que contenha os dados do paciente, médico, e as informações da consulta, dizendo o valor (ou de graça se for público)
  Ao marcarm uma consulta, são inseridos esses dados nesta tabela, e podemos consulá-los em um endpoint
</p>

<h3 align="center">RETORNO DE CONSULTA</h3>

<p>
  Ao passar 30 dias, podemos fazer um método que busca o usuário e verifica se 30 dias foram passados,
  se esse tempo expirar, será cobrado (caso seja convênio), se for público, a consulta será desmarcada
</p>

<h3 align="center">LEMBRETE:</h3>
<ul>
  <li>Alterar a tabela de consulta, e inserir um campo que contenha a data de 30 dias no futuro</li>
  <li>Alterar a tabela de consulta, inserir um campo que contenha o status da consulta: Agendada, Atendida, Cancelada, Expirada</li>
  <ul>
    <li>Agendada: significa que o paciente não foi atendido ainda</li>
    <li>Atendida: a consulta foi realizada e o paciente tem direito ao retorno</li>
    <li>Cancelada: cancelada pelo paciente</li>
    <li>Expirada: o paciente não compareceu à consulta, e será cobrada (caso haja convenio)</li>
  </ul>
</ul>
