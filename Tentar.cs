using System;
namespace MeuProjeto
{
    class Tentar
    {
        // Tenta transformar o valor inserido em int, se nao der certo reinicia o loop 
        public static int VerificarInt(string mensagem)
        {
            while (true)
            {
                Console.Write(mensagem);
                string? nuEstoque = Console.ReadLine();
                if (int.TryParse(nuEstoque, out int v))
                {
                    return v;
                }
                Console.WriteLine("Algo deu errado, digite APENAS números sem casas decimais");
            }

        }
    
         // Tenta transformar o valor inserido em double, se nao der certo reinicia o loop 
        public static double CertificarReal(string mensagem)
        {
            while (true)
            {
                Console.Write(mensagem);
                string? nuValor = Console.ReadLine();

                if (double.TryParse(nuValor, out double v))
                {
                    return v;
                }
                Console.WriteLine("Algo deu errado, digite apenas números");
             }
        }
    }

}