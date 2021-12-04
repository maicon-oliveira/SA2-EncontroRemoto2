using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace CadastroPessoa
{
    class Program
    {
        static void Main(string[] args)
        {  
            //Criação de uma lista para armazenar os objetos do tipo PessoaFisica  
            List<PessoaFisica> lisatPf = new List<PessoaFisica>();
            
            //Criação de uma lista para armazenar os objetos do tipo PessoaFisica 
            List<PessoaJuridica> listaPj = new List<PessoaJuridica>();

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
|               Escolha uma das opções abaixo      |
---------------------------------------------------|
|                  PESSOA FÍSICA                   |
|                1 - Cadastrar P.F.                |
|                2 - Listar    P.F.                |
|                3 - Remover   P.F.                |              
|                                                  |
|                  PESSOA JURIDICA                 |
|                4 - Cadastrar P.J.                |
|                5 - Listar    P.J.                |
|                6 - Remover   P.J.                |
|                                                  |
|                0 - Sair                          |
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

                        //criando o input no atributo logradouro
                        Console.WriteLine($"Digite seu Logradouro: ");
                        //guarda a infomação que o usuário digitar no atributo logradouro
                        end.logradouro = Console.ReadLine();
                        
                        //criando input no atributo numero
                        Console.WriteLine($"Digite o Numero: ");
                        //guarda a informação que o usuário digitar no atributo numero
                        end.numero = int.Parse(Console.ReadLine());//int.parse faz conversão de inteiro para string 

                        //criando input no atributo complemento
                        Console.WriteLine($"Digite o Complemento: ");
                        //guarda a infomação que o usuério digitar no atributo complemento
                        end.complemento = Console.ReadLine();

                        //criando input no atributo enderecoComercial
                        Console.WriteLine($"Este endereço é comercial? S/N ");
                        //criando uma variável para guardar a informação que o usuário digitar
                        string endComercial = Console.ReadLine().ToUpper();// to.Upper caso o usuário use s ou n minusculo
                        //if vai validar a informação de endComercial que o usuário digitou
                        if (endComercial == "S")
                        {
                            end.enderecoComercial = true;
                        } else 
                        {
                            end.enderecoComercial = false;
                        }
                        
                        //atribuindo valores para o objeto pf.
                        novaPf.endereco = end; //no atributo endereco instaciamos os valores do objeto end da classe Endereco.

                        //criando input no atributo cpf                       
                        Console.WriteLine($"Digite seu CPF: ");
                        //guarda a infomação que o usuério digitar no atributo cpf
                        novaPf.cpf = Console.ReadLine();

                        //criando input no atributo nome
                        Console.WriteLine($"Digite seu Nome: ");
                        //guarda a infomação que o usuério digitar no atributo nome
                        novaPf.nome = Console.ReadLine();

                        //criando input no atributo rendimento
                        Console.WriteLine($"Digite o valor do seu rendimento mensal: (somente numeros) ");
                        //guarda a infomação que o usuério digitar no atributo rendimento
                        novaPf.rendimento = int.Parse(Console.ReadLine()); //int.parse faz conversão de inteiro para string

                        //criando input no atributo dataNascimento
                        Console.WriteLine($"Digite sua data de nascimento:  EX: AAAA-MM-DD");
                        //guarda a infomação que o usuério digitar no atributo dataNascimento
                        novaPf.dataNascimento = DateTime.Parse(Console.ReadLine());

                        //metodo que valida a idade.
                        bool idadeValida = pf.ValidarDataNascimento(novaPf.dataNascimento);

                        //verifica a idade.
                        if(idadeValida == true){

                            Console.WriteLine($"Cadastro Aprovado!");
                            //após validar o cadastro, o objeto é adicionado na listaPf
                            lisatPf.Add(novaPf);
                            //chama o metodo pagar imposto da classe PessoaFisica
                            Console.WriteLine(pf.pagarImposto(novaPf.rendimento));
        
                        } else 
                        {

                            Console.WriteLine($"Cadastro Reprovado!");
                                
                        }  
                        break;

                    case "2":
                        //foreach cria a variável = item para guardar cada item da listaPF
                        foreach (var item in lisatPf)
                        {   
                            //items selecionados para serem listados: nome, cpf e endereço
                            Console.WriteLine($"{item.nome}, {item.cpf}, {item.endereco.logradouro}");
                            
                        }
                        break;

                    case "3":
                        Console.WriteLine($"Digite o cpf que deseja remover ? ");
                        string RemoveCpf = Console.ReadLine();
                        
                        /* metodo .Find procura algo dentro da lista
                        pegando o cpf de cada item e verificando se é igual a variável RemoveCpf
                        */
                        PessoaFisica pessoaEncontrada = lisatPf.Find(item => item.cpf == RemoveCpf);

                        /* verificamos se o cpf digitado existe no sistema, armazenando o cpf em uma nova variável pessoaEncontrada 
                        da classe PessoaFisica, se o cpf digitado for diferente de vazio ele remove se não mostra a mensagem de 
                        cpf não encotrado, impossivel remover
                        */
                        if (pessoaEncontrada != null )
                        {
                            lisatPf.Remove(pessoaEncontrada);
                            Console.WriteLine($"Cadastro Removido");
                            
                        } else
                        {
                            Console.WriteLine($"Cpf não encotrado, impossível remover");
                            
                        }   
                        break;

                    case "4":
                        //objeto criado para chamar o metodo ValidarCnpj()
                        PessoaJuridica pj = new PessoaJuridica();

                        //objeto criado para atribuir os valores.
                        PessoaJuridica novaPj = new PessoaJuridica();
                            
                        //estanciando um objeto endPj para a classe Endereco com  4 atributos criados.
                        Endereco endPj = new Endereco();
                        
                        //criando o input no atributo logradouro
                        Console.WriteLine($"Digite seu Logradouro: ");
                        //guarda a infomação que o usuário digitar no atributo logradouro
                        endPj.logradouro = Console.ReadLine();
                        
                        //criando input no atributo numero
                        Console.WriteLine($"Digite o Numero: ");
                        //guarda a informação que o usuário digitar no atributo numero
                        endPj.numero = int.Parse(Console.ReadLine());//int.parse faz conversão de inteiro para string
                        
                        //criando input no atributo complemento
                        Console.WriteLine($"Digite o Complemento: ");
                        //guarda a infomação que o usuério digitar no atributo complemento
                        endPj.complemento = Console.ReadLine();

                        //criando input no atributo enderecoComercial
                        Console.WriteLine($"Este endereço é comercial? S/N ");
                        //criando uma variável para guardar a informação que o usuário digitar
                        string endPjComercial = Console.ReadLine().ToUpper();// to.Upper caso o usuário use s ou n minusculo
                        //if vai validar a informação de endComercial que o usuário digitou
                        if (endPjComercial == "S")
                        {
                            endPj.enderecoComercial = true;
                        } else 
                        {
                            endPj.enderecoComercial = false;
                        }
                        
                        //atribuindo valores para o objeto Pj.
                        novaPj.endereco = endPj; //no atributo endereco instaciamos os valores do objeto endPj da classe Endereco

                        //criando input no atributo cnpj                       
                        Console.WriteLine($"Digite seu CNPJ: ");
                        //guarda a infomação que o usuério digitar no atributo cnpj
                        novaPj.cnpj = Console.ReadLine();
                        
                        //criando input no atributo razaoSocial
                        Console.WriteLine($"Digite sua Razão Social: ");
                        //guarda a infomação que o usuério digitar no atributo razaoSocial
                        novaPj.razaoSocial = Console.ReadLine();
                        
                         //criando input no atributo rendimento
                        Console.WriteLine($"Digite o valor do seu rendimento mensal: (somente numeros) ");
                        //guarda a infomação que o usuério digitar no atributo rendimento
                        novaPj.rendimento = int.Parse(Console.ReadLine()); //int.parse faz conversão de inteiro para string
                        
                            
                            //chama o metodo e valida o cnpj
                        if(pj.ValidarCnpj(novaPj.cnpj))
                        {
                            Console.WriteLine("CNPJ Válido");
                            //após validar o cadastro, o objeto é adicionado na listaPf
                            listaPj.Add(novaPj);
                            //chama o metodo pagar imposto da classe PessoaFisica
                            Console.WriteLine(pj.pagarImposto(novaPj.rendimento));
                            
                        }
                        else
                        {
                            Console.WriteLine("CNPJ  Inválido");
                            
                        } 
                        break;
                    
                    case "5":
                        //foreach cria a variável = item para guardar cada item da listaPj
                        foreach (var item in listaPj)
                        {   
                            //items selecionados para serem listados: nome, cpf e endereço
                            Console.WriteLine($"{item.razaoSocial}, {item.cnpj}, {item.endereco.logradouro}");
                            
                        }
                        break;

                    case "6":
                        Console.WriteLine($"Digite o cnpj que deseja remover ? ");
                        string RemoveCnpj = Console.ReadLine();
                        
                        /* metodo .Find procura algo dentro da lista
                        pegando o cpf de cada item e verificando se é igual a variável RemoveCpf
                        */
                        PessoaJuridica pjEncontrada = listaPj.Find(item => item.cnpj == RemoveCnpj);

                        /* verificamos se o cpf digitado existe no sistema, armazenando o cpf em uma nova variável pessoaEncontrada 
                        da classe PessoaFisica, se o cpf digitado for diferente de vazio ele remove se não mostra a mensagem de 
                        cpf não encotrado, impossivel remover
                        */
                        if (pjEncontrada != null )
                        {
                            listaPj.Remove(pjEncontrada);
                            Console.WriteLine($"Cadastro Removido");
                            
                        } else
                        {
                            Console.WriteLine($"Cnpj não encotrado, impossível remover");
                            
                        }   
                        break;



                    case "0":
                        //limpa a tela
                        Console.Clear();
                        //escreva a mensagem na tela
                        Console.WriteLine($"Obrigado por utilizar nosso sistema.");

                         //chamando a função criada com o argumento "string Carregamento" e idicamos que o argumento é "Finalizando"
                        Carregando("Finalizando"); 
                       
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
        static void Carregando(string CarregaTexto)
        {
            
            //Reseta a cor que foi selecionada, voltando ao padrão do console
            Console.ResetColor();
            //tempo em milissegundos que o sistema vai parar(gera uma pausa para melhor interação do usuário)
            Thread.Sleep(3000);// 3 segundos

            //escolhe a cor para os caracteres
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            
            //aqui ele chama o argumento da função que no caso é "Iniciando" 
            Console.Write(CarregaTexto);
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