using System.Collections.Generic;
using System.IO;

namespace CadastroPessoa
{
    public class PessoaJuridica : Pessoa
    {
        public string cnpj { get; set; }

        public string razaoSocial { get; set; }

        /*atributo caminho criado para indicar o local onde esta o
        o arquivo; pasta = Database, arquivo = PessoaJuridica, tipo = .csv   */
        public string caminho {get; set; } = "Database/PessoaJuridica.csv";
        

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
                //outra forma de calcular porcentagem4
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

        //metodo que vai preparar a linha para ser salva no csv
        public string PrepararLinha(PessoaJuridica pj){
            
            return $"{pj.cnpj};{pj.nome};{pj.razaoSocial}";
        }

        //metodo que vai inserir as linhas dentro do arquivo
        public void Inserir(PessoaJuridica pj){
            //criamos um array de string que vai receber o outro metodo PrepararLinha
            string[] linhas = {PrepararLinha(pj)};

            //metodo AppendAllLines pede o caminho do arquivo e o conteudo como argumentos
            File.AppendAllLines(caminho, linhas);
        }
        
        //metodo que vai ler o arquivo com o retorno de lista
        public List<PessoaJuridica> LerArquivo(){
            
            //criamos uma lista para guardar o conteudo do arquivo e após retornar o conteudo
            List<PessoaJuridica> listaPj = new List<PessoaJuridica>();

            //criamos um array de string para receber e ler o conteudo do arquivo
            string[] linhas = File.ReadAllLines(caminho);

            /* foreach vai receber o conteudo do array e jogar o mesmo para a lista...
            foreach vai executar enquanto tiver conteudo no arquivo csv */
            foreach (var cadaLinha in linhas)
            {   
                /* criamos outro array de string com o nome "atributos" que vai receber a variavel
                cadaLinha e usando o metodo split separamos cada informação do array por ";" */
                string[] atributos = cadaLinha.Split(";");

                //criamos um novo objeto para pegar os valores do array e atribuir nos atributos do objeto cadaPj
                PessoaJuridica cadaPj = new PessoaJuridica();

                //atribuindo os valores do array para o objeto cadaPj
                cadaPj.cnpj = atributos[0];
                
                //adicionando o objeto na listaPj que foi criada no metodo
                listaPj.Add(cadaPj);
            }

            //retornaremos a listaPj
            return listaPj;
        }
    
    }
}