using System;

namespace CadastroPessoa
{
    public class PessoaFisica : Pessoa
    {
        public string cpf { get; set; }

        public DateTime dataNascimento { get; set; }
        

        public override void pagarImposto(float salario){

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