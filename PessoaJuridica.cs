namespace CadastroPessoa
{
    public class PessoaJuridica : Pessoa
    {
        public string cnpj { get; set; }

        public string razaoSocial { get; set; }
        

        public override void pagarImposto(float salario){

        }
        //metodo que valida o CNPJ.
        public bool ValidarCnpj(string cnpj){
            //cnpj tem 14 caracteres e o metodo substring diminui 14 - 6 , e avalia somente 4 == 0001
            if (cnpj.Length == 14 && cnpj.Substring(cnpj.Length - 6, 4) == "0001")
            {
             return true;   
            }
            return false;
        }
    }
}