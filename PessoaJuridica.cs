namespace CadastroPessoa
{
    public class PessoaJuridica : Pessoa
    {
        public string cnpj { get; set; }

        public string razaoSocial { get; set; }
        

        public override double pagarImposto(float rendimento){
             if (rendimento <= 5000)
            {   
                //calcula o rendimento com desconto de 6%
                return rendimento * .06;
                
                
            } else if (rendimento > 5000 && rendimento <= 10000)
            {   
                //calcula o rendimento com desconto de 8%
                return rendimento * .08;

            } else 
            {   
                //outra forma de calcular porcentagem
                //calcula o rendimento com desconto de 10%
                return (rendimento / 100) * 10;                
            }
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