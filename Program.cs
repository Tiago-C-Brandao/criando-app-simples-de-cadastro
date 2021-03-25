using System;

namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorioSerie = new SerieRepositorio();
        static FilmeRepositorio repositorioFilme = new FilmeRepositorio();
        static void Main(string[] args)
        {  
            
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    // Filme
                    case "1":
                        ListaFilmes();
                        break;
                    case "2":
                        InserirFilme();
                        break;
                    case "3":
                        AtualizarFilme();
                        break;
                    case "4":
                        ExcluirFilme();
                        break;
                    case "5":
                        VisualizarFilme();
                        break;    

                    // Série                    
                    case "6":
                        ListaSeries();
                        break;
                    case "7":
                        InserirSerie();
                        break;
                    case "8":
                        AtualizarSerie();
                        break;
                    case "9":
                        ExcluirSerie();
                        break;
                    case "10":
                        VisualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default: 
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();                
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadLine();       
        }

        private static void ListaSeries()
        {
            Console.WriteLine("Listar séries");
            var lista = repositorioSerie.Lista();
            
            if (lista.Count == 0) 
            {
                Console.WriteLine("Nenhuma série cadastrada");
                return;
            }

            foreach (var serie in lista)
            {
                var excluido = serie.retornaExcluido();
                Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluído*" : ""));
            }
        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova série\n");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("\nDigite o gênero entre as opções a cima: ");
            int entradaGenero =  int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorioSerie.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            repositorioSerie.Insere(novaSerie);
        }

        private static void ExcluirSerie()
        {
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());
            
            Console.Write("Deseja realmente excluir esta série? S/N: ");
            string confirma = Console.ReadLine();

            if(confirma.ToUpper() == "S") 
            {
                repositorioSerie.Excluir(indiceSerie);
            }
            else 
            {
                return;
            }
        }

        public static void VisualizarSerie()
        {
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorioSerie.RetornaPorId(indiceSerie);

            Console.WriteLine(serie);
        }
        private static void AtualizarSerie()
        {
            Console.Write("Digite o id da serie: ");
            int indiceSerie = int.Parse(Console.ReadLine());
            Console.WriteLine("");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("\nDigite o gênero entre as opções a cima: ");
            int entradaGenero =  int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie atualizaSerie = new Serie(id: indiceSerie,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            repositorioSerie.Atualiza(indiceSerie, atualizaSerie);
        }

//-------------------------------------------------------------------------------------------------------------------------------------------------------------

        private static void ListaFilmes()
        {
            Console.WriteLine("Listar filmes");
            var lista = repositorioFilme.Lista();
            
            if (lista.Count == 0) 
            {
                Console.WriteLine("Nenhuma série cadastrada");
                return;
            }

            foreach (var filme in lista)
            {
                var excluido = filme.retornaExcluido();
                Console.WriteLine("#ID {0}: - {1} {2}", filme.retornaId(), filme.retornaTitulo(), (excluido ? "*Excluído*" : ""));
            }
        }

        private static void InserirFilme()
        {
            Console.WriteLine("Inserir novo filme\n");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("\nDigite o gênero entre as opções a cima: ");
            int entradaGenero =  int.Parse(Console.ReadLine());

            Console.Write("Digite o Título do Filme: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início do Filme: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição do Filme: ");
            string entradaDescricao = Console.ReadLine();

            Filme novoFilme = new Filme(id: repositorioFilme.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            repositorioFilme.Insere(novoFilme);
        }

        private static void ExcluirFilme()
        {
            Console.Write("Digite o id do filmes: ");
            int indiceFilme = int.Parse(Console.ReadLine());
            
            Console.Write("Deseja realmente excluir este filme? S/N: ");
            string confirma = Console.ReadLine();

            if(confirma.ToUpper() == "S") 
            {
                repositorioFilme.Excluir(indiceFilme);
            }
            else 
            {
                return;
            }
        }

        public static void VisualizarFilme()
        {
            Console.Write("Digite o id da filme: ");
            int indiceFilme = int.Parse(Console.ReadLine());

            var filme = repositorioFilme.RetornaPorId(indiceFilme);

            Console.WriteLine(filme);
        }
        private static void AtualizarFilme()
        {
            Console.Write("Digite o id da serie: ");
            int indiceFilme = int.Parse(Console.ReadLine());
            Console.WriteLine("");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("\nDigite o gênero entre as opções a cima: ");
            int entradaGenero =  int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Filme atualizaFilme = new Filme(id: indiceFilme,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            repositorioFilme.Atualiza(indiceFilme, atualizaFilme);
        }

//-------------------------------------------------------------------------------------------------------------------------------------------------------------
        private static string ObterOpcaoUsuario()
        {
                Console.WriteLine();
                Console.WriteLine("DIO Flix a seu dispor!!!");
                Console.WriteLine("Informe a opção desejada:");

                Console.WriteLine("\n------- FILMES -------\n");
                Console.WriteLine("1 - Listar filmes");
                Console.WriteLine("2 - Inserir nova filme");
                Console.WriteLine("3 - Atualizar filme");
                Console.WriteLine("4 - Excluir filme");
                Console.WriteLine("5 - Visualizar filme");

                Console.WriteLine("\n------- SÉRIES -------\n");
                Console.WriteLine("6 - Listar séries");
                Console.WriteLine("7 - Inserir nova série");
                Console.WriteLine("8 - Atualizar série");
                Console.WriteLine("9 - Excluir série");
                Console.WriteLine("10 - Visualizar série");
                Console.WriteLine("C - Limpar tela");
                Console.WriteLine("X - Sair");
                Console.WriteLine();            

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
        
    }
}
