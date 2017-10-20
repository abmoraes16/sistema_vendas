using System;
using System.IO;

namespace sistema_vendas
{
    class Program
    {
        static string nomeCliente;
        static string emailCliente;
        static string tipoCliente;
        static string cpfCliente;
        static string cnpjCliente;
        static DateTime dataCadastroCliente;

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

            Console.Write("Nome completo: ");
            nomeCliente = Console.ReadLine();

            Console.Write("Email: ");
            emailCliente = Console.ReadLine();

            do{
                Console.Write("Digite 1 para CPF e 2 para CNPJ: ");
                tipoCliente = Console.ReadLine();
            }while(tipoCliente!="1" || tipoCliente!="2");

            switch(tipoCliente){
               case "1":  Console.Write("CPF: ");
                          cpfCliente = Console.ReadLine();
                          //ValidarCPF();
                          writer.WriteLine(nomeCliente+";"+emailCliente+""+tipoCliente+""+System.DateTime.Today.ToString());
                          break;
               case "2":  Console.Write("CNPJ: ");
                          cpfCliente = Console.ReadLine();
                          //ValidarCNPJ();
                          break;
            }


        }

        

    }
}
    