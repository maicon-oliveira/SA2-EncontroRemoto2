using System;

namespace CadastroPessoa
{
    class Program
    {
        static void Main(string[] args)
        {  /* 
            //objeto criado para chamar o metodo ValidarDataNascimento().
            PessoaFisica pf = new PessoaFisica();

            //objeto criado para atribuir os valores.
           PessoaFisica novaPf = new PessoaFisica();

           //estanciando um objeto end para a classe Endereco com  4 atributos criados.
           Endereco end = new Endereco();
          
          //atribuindo valores para o objeto end.
           end.logradouro = "Rua X";
           end.numero = 100;
           end.complemento = "proximo ao senai";
           end.enderecoComercial = false;

           //atribuindo valores para o objeto pf.
           novaPf.endereco = end; //no atributo endereco instaciamos os valores do objeto end da classe Endereco.
           novaPf.cpf = "123456789";
           novaPf.nome = "Pessoa Fisica";
           novaPf.dataNascimento = new DateTime(2000, 06, 15);

           Console.WriteLine($"{novaPf.endereco.logradouro}, {novaPf.endereco.numero}");

            //metodo que valida a idade.
           bool idadeValida = pf.ValidarDataNascimento(novaPf.dataNascimento);

            //verifica a idade.
           if(idadeValida == true){

               Console.WriteLine($"Cadastro Aprovado!");
               
           } else {

               Console.WriteLine($"Cadastro Reprovado!");
               

           }  
           */
           
           //objeto criado para chamar o metodo ValidarCnpj()
           PessoaJuridica pj = new PessoaJuridica();

            //objeto criado para atribuir os valores.
           PessoaJuridica novaPj = new PessoaJuridica();
            
           //estanciando um objeto end para a classe Endereco com  4 atributos criados.
           Endereco end = new Endereco();
           
           end.logradouro = "Rua Z";
           end.numero = 100;
           end.complemento = "Proximo ao senai informatica";
           end.enderecoComercial = true;

           novaPj.endereco = end;
           novaPj.cnpj = "12345678900001";
           novaPj.razaoSocial = "Pessoa Juridica";

                 
            //chama o metodo e valida o cnpj
           if(pj.ValidarCnpj(novaPj.cnpj))
           {
               Console.WriteLine("CNPJ Válido");
               
           }
           else
           {
               Console.WriteLine("CNPJ  Inválido");
               
           }
        }
    }
}