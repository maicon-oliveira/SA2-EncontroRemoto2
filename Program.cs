using System;
using System.IO;
using System.Threading;

namespace CadastroPessoa
{
    class Program
    {
        static void Main(string[] args)
        {  
            //variável criada para guardar opção selecionada do switch case
            string opcao;

            //limpa a tela
            Console.Clear();
            //escolhe a cor dos caracteres 
            Console.ForegroundColor = ConsoleColor.DarkRed;
            //@ no "Console.WriteLine" personaliza no console exatamente o que foi escrito incluido o posicionamento 
            Console.WriteLine(@$"
-----------------------------------------------------
|           Bem vindo ao Sistema de Cadastro de     |      
|            Pessoa Física e Jurídica               |
-----------------------------------------------------
");         //chamando a função criada com o argumento "string Carregamento" e idicamos que o argumento é "Iniciando"
            Carregando("Iniciando");
            Console.Clear();

            //usando o laço de repetição "do" "while", "faça" "enquanto"
            do
            {
                //escolhe a cor dos caracteres
                Console.ForegroundColor = ConsoleColor.DarkRed;
                //@ no "Console.WriteLine" personaliza no console exatamente o que foi escrito incluido o posicionamento
                Console.WriteLine(@$"
====================================================
                Escolha uma das opções abaixo      |
---------------------------------------------------|
               1 - Pessoa Física                   |              
               2 - Pessoa Jurídica                 |
                                                   |
               0 - Sair                            |
====================================================               
                ");
                
                //variável "opcao" guarda a opção que o usuário selecionou a cima
                opcao = Console.ReadLine();

                //estrutura condicional "switch" "case", "escolha" "caso" que controla as opções inseridas a cima
                switch (opcao)
                {   
                    //se usuário selecionou a opção 1 faça
                    case "1":
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
                        novaPf.rendimento = 100000;
                        novaPf.dataNascimento = new DateTime(2000, 06, 15);

                        Console.WriteLine($"{novaPf.endereco.logradouro}, {novaPf.endereco.numero}");

                        //metodo que valida a idade.
                        bool idadeValida = pf.ValidarDataNascimento(novaPf.dataNascimento);

                        //verifica a idade.
                        if(idadeValida == true){

                            Console.WriteLine($"Cadastro Aprovado!");
                                
                        } else 
                        {

                            Console.WriteLine($"Cadastro Reprovado!");
                                
                        }  

                        Console.WriteLine(pf.pagarImposto(novaPf.rendimento));
                        

                        break;

                    //se o usuário selecionou a opção 2 faça
                    case "2":
                        //objeto criado para chamar o metodo ValidarCnpj()
                        PessoaJuridica pj = new PessoaJuridica();

                        //objeto criado para atribuir os valores.
                        PessoaJuridica novaPj = new PessoaJuridica();
                            
                        //estanciando um objeto endPj para a classe Endereco com  4 atributos criados.
                        Endereco endPj = new Endereco();
                        
                        endPj.logradouro = "Rua Z";
                        endPj.numero = 100;
                        endPj.complemento = "Proximo ao senai informatica";
                        endPj.enderecoComercial = true;

                        novaPj.endereco = endPj;
                        novaPj.cnpj = "34567890000199";
                        novaPj.razaoSocial = "Pessoa Juridica";
                        novaPj.rendimento = 10000;
                        

                                
                            //chama o metodo e valida o cnpj
                        if(pj.ValidarCnpj(novaPj.cnpj))
                        {
                            Console.WriteLine("CNPJ Válido");
                            
                        }
                        else
                        {
                            Console.WriteLine("CNPJ  Inválido");
                            
                        }

                        Console.WriteLine(pj.pagarImposto(novaPj.rendimento));
                        
                        break;

                    //se o usuário selecionou a opção 0 faça
                    case "0":
                        //limpa a tela
                        Console.Clear();
                        //escreva a mensagem na tela
                        Console.WriteLine($"Obrigado por utilizar nosso sistema.");
                        
                        //escolhe a cor para os caracteres
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        //escolhe uma cor de fundo para os caracteres
                        Console.BackgroundColor = ConsoleColor.White;

                        //escreve na tela "Finalizando"
                        Console.Write($"Finalizando");
                        //tempo em milissegundos que o sistema vai parar(gera uma pausa para melhor interação do usuário)
                        Thread.Sleep(500);//0,5 segundos
                        //usa-se um laço de repetição "for" para "." após aparecer na tela "Finalizando" = "Finalizando...."
                        for(var i = 0; i < 10; i++)
                        {
                            Console.WriteLine($".");
                            Thread.Sleep(500);    
                        }
                        //Reseta a cor que foi selecionada, voltando ao padrão do console
                        Console.ResetColor();
                        break;
                    //se o usuário selecionar uma opção inválida faça
                    default:
                        Console.ResetColor();
                        Console.WriteLine($"Opção inválida, por favor digite uma opção válida!");
                        break;
                        
                }
              //o sistema vai rodar até o usuário escolher uma opção diferente de 0  
            } while (opcao != "0");

                   
        }
    

        //criando uma função "Carregando" do tipo string que vai receber os argumentos "Iniciando" e "Finalizando"
        static void Carregando(string Carregamento)
        {
            
            //Reseta a cor que foi selecionada, voltando ao padrão do console
            Console.ResetColor();
            //tempo em milissegundos que o sistema vai parar(gera uma pausa para melhor interação do usuário)
            Thread.Sleep(3000);// 3 segundos

            //escolhe a cor para os caracteres
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            //escolhe uma cor de fundo para os caracteres
            Console.BackgroundColor = ConsoleColor.White;
            
            //aqui ele chama o argumento da função que no caso é "Iniciando" 
            Console.Write(Carregamento);
            //tempo em milissegundos que o sistema vai parar(gera uma pausa para melhor interação do usuário)
            Thread.Sleep(500);//0,5 segundos
            //usa-se um laço de repetição "for" para "." após aparecer na tela "Iniciando" = "Iniciando...."
            for(var i = 0; i < 10; i++)
            {
                Console.Write($".");
                Thread.Sleep(500);
            }
            //Reseta a cor que foi selecionada, voltando ao padrão do console
            Console.ResetColor();
        }
    
    }

}