namespace GerenciadorHospital
{
    public static class Consts
    {
        public const int TamanhoMinimoUserName = 5;
        public const int TamanhoCPF = 11;
        public const int TamanhoDataNasc = 10;
        public const string RegexSenha = 
            @"^(?=.*\d{1})(?=.*[a-z]{1})(?=.*[A-Z]{1})(?=.*[!@#$%^&*{|}?~_=+.-]{1})(?=.*[^a-zA-Z0-9])(?!.*\s).{6,24}$";
        
        public const string ErroDeValidacaoTamanhoUserName= "Username deve conter no mínimo 5 caracteres";
        public const string ErroDeValidacaoCPF= "Digite o CPF corretamente";
        public const string ErroDeValidacaoDataNasc= "Digite a data de nascimento corretamente";
        
        public const string ErroDeValidacaoSenha = 
            "A Senha deve conter no mínimo 6 caracteres. 1 maiúsculo e 1 minúsculo no mínimo, e pelo menos 1 caractere especial";
    }
}
