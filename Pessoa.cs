using System.IO;

namespace CadastroPessoa
{
    public abstract class Pessoa 
    {
        public string nome { get; set; }

        public Endereco endereco { get; set; }

        public float rendimento { get; set; }

        public abstract double pagarImposto(float rendimento);

        //metodo AnalisarArquivo criado para verificar se a pasta e o aqruivo existem
        public void AnalisarArquivo(string caminho){
            /* variavel pasta vai verificar se apos a / pegando a posição 0 do array
             ex: Database/PessoaJuridica.csv , metodo vai verificar o arquivo após Database/, ou seja,
             PessoaJuridica.csv  */
            string pasta = caminho.Split("/")[0];
            
            //if valida se a pasta existe, caso contrario ele cria 
            if (!Directory.Exists(pasta))
            {
                Directory.CreateDirectory(pasta);
            }
            
            /* if valida se o arquivo existe passando como argumento o caminho do arquivo,
            senão exite ele  cria */
            if (!File.Exists(caminho))
            {
                File.Create(caminho);
            }
    }
 
    }
}