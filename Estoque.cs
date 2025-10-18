/*
 * Sistema de Controle de Estoque (C#)
 * Autor: Ryan [se quiser colocar o sobrenome]
 * Descrição: Projeto de console simples para cadastrar, consultar,
 * adicionar e remover produtos de um estoque, com validação de entrada.
 * 
 * Objetivo: Demonstrar uso de listas, loops, métodos e validação de dados
 * com boas práticas de código e legibilidade.
 */
using System;

namespace MeuProjeto
{
    class Estoque
    {
        static void Main()
        {
            // Lista que armazena os produtos e suas informações(Valor e qntd no estoque)
            List<string> produtos = new List<string>();
            List<double> valor_produto = new List<double>();
            List<int> quantidade = new List<int>();


            const int senhaCerta = 31415; // Senha para adicionar e remover do estoque
            int i = 1;

            while (true) // Aqui começa o cadastro dos produtos
            {

                Console.Write($"Digite o nome do {i}° produto: ");
                string? nome = Console.ReadLine();


                produtos.Add(nome);

                /* Chama os métodos da class "Tentar " e garante que o q for digitado esteja de acordo
                com o esperado, evitando por exemplo que alguém coloque "4,6" na quantidade do 
                estoque e trave a execução*/
                valor_produto.Add(Tentar.CertificarReal($"Digite o valor do {i}° produto: R$"));
                quantidade.Add(Tentar.VerificarInt($"Digite a quantidade no estoque do {i}° produto: "));

                Console.WriteLine("");
                i += 1;

                // Opção para parar o cadastro e ir para o menu
                Console.Write("Deseja adicionar mais um produto? S/N:\n ");
                string? simounao = Console.ReadLine();

                if (simounao.Equals("n", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("");
                    break;

                }

            }

            // Menu do sistema 
            int opcao;
            do
            {
                Console.WriteLine("-----MENU DO ESTOQUE----");
                Console.WriteLine("1 - Verificar produto");
                Console.WriteLine("2 - Adicionar ao estoque ");
                Console.WriteLine("3 - Remover do estoque");
                Console.WriteLine("4 - Listar todos os produtos");
                Console.WriteLine("0 - Sair");

                opcao = Tentar.VerificarInt("Escolha uma opção: ");
                Console.WriteLine("");

                switch (opcao)
                {
                    // Chamando funções para opcao escolhida 
                    case 1:
                        Verificarprodutos(produtos, valor_produto, quantidade);
                        break;
                    case 2:
                        AdicionarProduto(produtos, quantidade, senhaCerta);
                        break;
                    case 3:
                        RemoverProduto(produtos, quantidade, senhaCerta);
                        break;
                    case 4:
                        ListarProdutos(produtos, valor_produto, quantidade);
                        break;
                    case 0:
                        Console.Write("Fim do programa");
                        break;
                    default:
                        Console.Write("Opção inválida");
                        break;
                }
            } while (opcao != 0);

        }

        // Método que mostra um produto específico de acordo com que o usuário digitou   
        static void Verificarprodutos(List<string> produtos, List<double> valor_produto, List<int> quantidade)
        {
            Console.Write("Digite o nome do produto que você deseja ver: ");
            string? nomePro = Console.ReadLine();
            int localizar = 0;


            for (int i = 0; i < produtos.Count; i++)
            {
                if (produtos[i].Equals(nomePro, StringComparison.OrdinalIgnoreCase)) 
                {
                    Console.WriteLine($"Produto: {produtos[i]} - R${valor_produto[i]:F2} - Estoque: {quantidade[i]} \n");
                    localizar = 1;
                    break;
                }
            }
            if (localizar < 1) Console.WriteLine("Produto não encontrado\n");
        }

        // Método para adicionar unidades de um produto ao estoque 
        static void AdicionarProduto(List<string> produtos, List<int> quantidade, int senhaCerta)
        {
            Console.Write("Digite o nome do produto que deseja adicionar: ");
            string? nomePro = Console.ReadLine();
            int localizar = 0;

            for (int i = 0; i < produtos.Count; i++)  
            {
                if (produtos[i].Equals(nomePro, StringComparison.OrdinalIgnoreCase))
                {

                    localizar = 1;
                    Console.WriteLine("Digite quantidade desejada: ");
                    int quantida = int.Parse(Console.ReadLine());
                    Console.WriteLine("Confirme com a senha da gerencia para adicionar:\n ");
                    int senha = int.Parse(Console.ReadLine());
                    if (senha.Equals(senhaCerta))
                    {
                        quantidade[i] += quantida;
                        Console.WriteLine("Adicionado ao estoque");
                    }
                    else
                    {
                        Console.WriteLine("Senha incorreta. Favor solicitar ao gerente!");
                    }

                }


            }
            if (localizar < 1) Console.WriteLine("Produto não encontrado\n");
        } 

         // Método para remover unidades de um produto do estoque
        static void RemoverProduto(List<string> produtos, List<int> quantidade, int senhaCerta)
        {
            Console.Write("Digite o nome do produto que deseja remover: ");
            string? nomePro = Console.ReadLine();
            int localizar = 0;

            for (int i = 0; i < produtos.Count; i++) 
            {
                if (produtos[i].Equals(nomePro, StringComparison.OrdinalIgnoreCase))
                {

                    localizar = 1;
                    Console.WriteLine("Digite quantidade desejada: ");
                    int quantida = int.Parse(Console.ReadLine());
                    Console.WriteLine("Confirme com a senha da gerencia para remover:\n ");
                    int senha = int.Parse(Console.ReadLine());
                    if (senha.Equals(senhaCerta) && quantidade[i] >= quantida)
                    {
                        quantidade[i] -= quantida;
                        Console.WriteLine("Removido do estoque");
                    }
                    else
                    {
                        Console.WriteLine("Erro, consulte a SENHA e QUANTIDADE TOTAL a ser removida com gerente!");
                    }

                }
            }
            if (localizar < 1) Console.WriteLine("Produto não encontrado\n");
        } 
        
         //Método que mostra todos os produtos com suas informações 
        static void ListarProdutos(List<string> produtos, List<double> valor_produto, List<int> quantidade)
        {
            for(int i = 0; i < produtos.Count; i++)
            {
                Console.WriteLine($"{i + 1}° Produto: {produtos[i]}");
                Console.WriteLine($"Valor do {i+1}° produto: {valor_produto[i]}");
                Console.WriteLine($"Quantidade no do {i+1}° produto: {quantidade[i]}\n");
            }
        }

    }

}
