using System;

namespace CadastroPessoa
{
    public class PessoaFisica : Pessoa
    {
        public string cpf { get; set; }

        public DateTime dataNascimento { get; set; }
        
        //metodo para calcular imposto
        public override double pagarImposto(float rendimento){
            if (rendimento <= 1500)
            {
                return 0;
                
            } else if (rendimento > 1500 && rendimento <= 5000)

            {   //calcula o rendimento com desconto de 3%
                return rendimento * 0.03;

            } else 
            {   //outra forma de calcular porcentagem
                //calcula o rendimento com desconto de 5%
                return (rendimento / 100) * 5;                
            }
        }
        //Metodo que vai validar a idade.
        public bool ValidarDataNascimento(DateTime dataNasc){

            //variavel dataAtual criada para guardar a data atual.
            DateTime dataAtual = DateTime.Today;

            //variavel anos, guarda a idade.
            double anos = (dataAtual - dataNasc).TotalDays / 365;
            
            //verifica a idade.
            if(anos >= 18 ){

                return true;

            } else {

                return false;

            }

        }
    }
}