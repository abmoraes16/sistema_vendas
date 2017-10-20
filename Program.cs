using System;
using System.IO;
using System.Text.RegularExpressions;

namespace sistema_vendas
{
    class Program
    {


        static void Main(string[] args)
        {
            string op2;
            do
            {
                
                Console.WriteLine("\nEscolha uma das opções abaixo\n1 - Cadastrar Clientes\n2 - Cadastrar Produtos\n3 - Realizar Vendas\n4 - Extrato de Clientes\n\n0 - Sair");
                do
                {
                    op2 = Console.ReadLine();
                } while (op2 != "1" && op2 != "2" && op2 != "3" && op2 != "4" && op2 != "5" && op2 != "0");

                switch (op2)
                {
                    case "0": Environment.Exit(0); break;
                    case "1": CadastrarClientes(); break;
                    case "2": CadastrarProdutos(); break;
                    case "3": RealizarVendas(); break;
                    case "4": ExtratoClientes(); break;
                }
            } while (op2 != "0");



        }

        private static void ExtratoClientes()
        {
            throw new NotImplementedException();
        }

        private static void RealizarVendas()
        {
            throw new NotImplementedException();
        }

        private static void CadastrarProdutos()
        {
            throw new NotImplementedException();
        }

        private static void CadastrarClientes()
        {
            StreamWriter writer = new StreamWriter("cliente.csv",true);
            string nomeCliente;
            string emailCliente;
            string tipoCliente;
            string docCliente;
            int valid;

            Console.WriteLine("\nCADASTRO DE CLIENTES: \n");

            do{
                Console.Write("Digite 1 para CPF e 2 para CNPJ: ");
                tipoCliente = Console.ReadLine();
                
            }while(tipoCliente!="1" && tipoCliente!="2");

            do{
                if(tipoCliente=="1"){
                    Console.Write("CPF: ");
                    docCliente = Console.ReadLine();
                    valid = ValidarDocumento(docCliente, 1);
                }
                else{
                    Console.Write("CNPJ: ");
                    docCliente = Console.ReadLine();
                    valid = ValidarDocumento(docCliente, 2);
                }
            }while(valid!=1);

            Console.Write("Nome completo: ");
            nomeCliente = Console.ReadLine();

            Console.Write("Email: ");
            emailCliente = Console.ReadLine();

            writer.WriteLine(docCliente+";"+nomeCliente+";"+emailCliente+";"+System.DateTime.Now.ToString());

            writer.Close();
        }

        private static int ValidarDocumento(String docCliente, int tipoCliente)
        {
            int[] chaveCPF = {10,9,8,7,6,5,4,3,2};
            int[] chaveCPF2 = {11,10,9,8,7,6,5,4,3,2};
            int[] chaveCNPJ = {5,4,3,2,9,8,7,6,5,4,3,2};
            int[] chaveCNPJ2 = {6,5,4,3,2,9,8,7,6,5,4,3,2};
            int[] chave1;
            int[] chave2;
            string tipoDoc;
            string primeiroDigito, segundoDigito;

            if(tipoCliente==1){
                tipoDoc = "CPF";
                chave1  = chaveCPF;
                chave2 = chaveCPF2;
            }
            else{
                tipoDoc = "CNPJ";
                chave1 = chaveCNPJ;
                chave2 = chaveCNPJ;
            }

            primeiroDigito = ValidaDigito(docCliente,chave1,tipoCliente);
            
            if (primeiroDigito != docCliente.Substring(chave1.Length,1))
            {
                Console.WriteLine(tipoDoc+" inválido!");
            }
            else
            {
                segundoDigito = ValidaDigito(docCliente,chave2,tipoCliente);
                            
                if (docCliente.EndsWith(segundoDigito) == true)
                {
                    return 1;
                }
                else
                {
                    Console.WriteLine(tipoDoc+" inválido!");
                }
             }
            return 0;
        }

        private static string ValidaDigito(string doc, int[] chave, int tipoDoc)
        {
           int soma = 0, resto = 0;
           string tempdoc;

           tempdoc = doc.Substring(0,chave.Length);

           for(int i=0;i<chave.Length;i++){
                    soma += Convert.ToInt16(tempdoc[i].ToString())*chave[i];
            }

                resto = soma % 11;

                if(resto<2)
                {
                    return "0";        
                }
                else
                {
                    return (11-resto).ToString();
                }
        }

    }

}
    