using System.Net.Http.Headers;

namespace exercicio
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Pede para o usuário escrever o local do csv
            Console.WriteLine("Escreva o caminho do arquivo: ");
            string sourcepath = Console.ReadLine(); 

            try
            {
                //Lê todas as linhas do arquivo do usuário
                string[] lines = File.ReadAllLines(sourcepath);

                //Guarda a pasta do usuário
                string sourceFolderPath = Path.GetDirectoryName(sourcepath);
                //Cria o caminho para uma nova pasta
                string targetFolderPath = sourceFolderPath + @"\out";
                //Cria o caminho para o novo arquivo
                string targetFilePath = targetFolderPath + @"\summary.csv";

                //Cria a pasta nova
                Directory.CreateDirectory(targetFolderPath);

                using (StreamWriter sw =  File.AppendText(targetFilePath)) 
                {
                    //Para cada linha encontrada
                    foreach (string line in lines) 
                    {
                        //Extrai as informações
                        string[] fields = line.Split(',');
                        string name = fields[0];
                        float value = float.Parse(fields[1], System.Globalization.CultureInfo.InvariantCulture);
                        int qtd = int.Parse(fields[2]);

                        //Cria um produto
                        Item i = new Item(name, value, qtd);

                        //Escreve num arquivo o nome do protudo e o valor total
                        sw.WriteLine(i.Nome + "," + i.ValorTotal().ToString("F2", System.Globalization.CultureInfo.InvariantCulture));
                    }
                }

                Console.WriteLine("Arquivos gerado com sucesso");

            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
