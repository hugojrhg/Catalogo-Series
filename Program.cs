using System;

namespace Catalogo
{
    class Program
    {
        private const int V = 1;
        static SerieRepositorio repositorio = new SerieRepositorio();

        public static String EscolherOpcao()
        {
            Console.WriteLine("Seja bem-vindo(a) ao catálogo de séries do Hugo." + Environment.NewLine);
            Console.WriteLine("Escolha a ação desejada:" + Environment.NewLine);

            Console.WriteLine("1 - Listar Séries");
            Console.WriteLine("2 - Adicionar Série");
            Console.WriteLine("3 - Atualizar Série");
            Console.WriteLine("4 - Excluir Série");
            Console.WriteLine("5 - Visualizar Série");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair" + Environment.NewLine);

            String opcao = Convert.ToString(Console.ReadLine().ToUpper());
            return opcao;
        }

        //Lista as séries já inseridas no catálogo, mostrando ID e Título.
        public static void ListarSeries()
        {

            var lista = repositorio.Lista();
            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série registrada até o momento...");
            }

            Console.WriteLine("1 - Todas as séries");
            Console.WriteLine("2 - Séries por gênero");
            int filtroEscolha = Convert.ToInt16(Console.ReadLine());

            switch (filtroEscolha)
            {
                case 1:
                    foreach (var serie in lista)
                    {
                        Console.WriteLine("#ID: " + serie.RetornaId());
                        Console.WriteLine("Título: " + serie.RetornaTitulo() + Environment.NewLine);     
                    }
                break;
                
                case 2:
                    Console.WriteLine("Escolha o gênero da série: " + Environment.NewLine);
                    foreach (int i in Enum.GetValues(typeof(Genero)))
			        {
				        Console.WriteLine("{0}-{1}" + Environment.NewLine, i, Enum.GetName(typeof(Genero), i));
			        }
                    int escolhaGenero = Convert.ToInt16(Console.ReadLine());

                    foreach (var serie in lista)
                    {
                        Genero filtroGenero = serie.RetornaGenero();
                        var finalGenero = (Genero)escolhaGenero;

                        if (filtroGenero == finalGenero)
                        {
                            Console.WriteLine("#ID: " + serie.RetornaId());
                            Console.WriteLine("Título: " + serie.RetornaTitulo() + Environment.NewLine);
                        }
                             
                    }
                break;

                default:
                break;
            }

            
            
            
        }

        // Adicionar uma série ao catálogo, cotendo Título, Gênero, Ano de Lançamento e Descrição.
        public static void AdicionarSerie()
        {
            Console.WriteLine("- Adicionar Série -");

            Console.WriteLine("Escolha o gênero da série: " + Environment.NewLine);
            foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}" + Environment.NewLine, i, Enum.GetName(typeof(Genero), i));
			}
            int generoSerie = Convert.ToInt16(Console.ReadLine());
            
            Console.WriteLine("Insira o título da série" + Environment.NewLine);
            String tituloSerie = Console.ReadLine();

            Console.WriteLine("Insira o ano de lançamento da série" + Environment.NewLine);
            int anoSerie = Convert.ToInt16(Console.ReadLine());

            Console.WriteLine(Environment.NewLine + "Insira uma descrição para a série" + Environment.NewLine);
            String descricaoSerie = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(), 
                                        titulo: tituloSerie, 
                                        genero: (Genero)generoSerie, 
                                        descricao: descricaoSerie, 
                                        ano: anoSerie);

            repositorio.Insere(novaSerie);
        }

        public static void AtualizarSerie()
        {
            Console.Write("Digite o ID da série que deseja atualizar: " + Environment.NewLine);
            int idSerie = Convert.ToInt16(Console.ReadLine());

            int tamanhorep2 = repositorio.ProximoId() - 1;
            if (idSerie > tamanhorep2)
            {
                Console.WriteLine("Esse ID não pertence a nenhuma série, tente novamente. " + Environment.NewLine);
                Console.WriteLine("1 - Tentar Novamente");
                Console.WriteLine("2 - Cancelar");
                int escolhaAtt = Convert.ToInt16(Console.ReadLine());
                if (escolhaAtt == 1)
                {
                    AtualizarSerie();
                }
                else
                {
                    Environment.Exit(0);
                }
                    
            }

            Console.Write("Escolha o gênero da série: " + Environment.NewLine);
            foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}" + Environment.NewLine, i, Enum.GetName(typeof(Genero), i));
			}
            int generoSerie = Convert.ToInt16(Console.ReadLine());
            
            Console.Write("Insira o título da série" + Environment.NewLine);
            String tituloSerie = Console.ReadLine();

            Console.Write("Insira o ano de lançamento da série" + Environment.NewLine);
            int anoSerie = Convert.ToInt16(Console.ReadLine());

            Console.Write("Insira uma descrição para a série" + Environment.NewLine);
            String descricaoSerie = Console.ReadLine();

            Serie atualizaSerie = new Serie(id: idSerie, 
                                        titulo: tituloSerie, 
                                        genero: (Genero)generoSerie, 
                                        descricao: descricaoSerie, 
                                        ano: anoSerie);

            repositorio.Ataliza(idSerie, atualizaSerie);
        }

        public static void ExcluirSerie()
        {
            Console.Write("Digite o ID da série que deseja excluir: ");
            int idExcluir = Convert.ToInt16(Console.ReadLine());

            repositorio.Exclui(idExcluir);
        }

        public static void VisualizarSerie()
        {
            Console.Write("Digite o ID da série que deseja visualizar: ");
            int idVisu = Convert.ToInt16(Console.ReadLine());

            var serieVisu = repositorio.RetornaPorId(idVisu);

            Console.WriteLine(serieVisu);
        }

        public static void Sair()
        {
            Console.WriteLine("Obrigado por usar o catálogo de séries do Hugo, volte sempre!.");
        }

        static void Main(string[] args)
        {
            String decisao = EscolherOpcao();

            while (decisao.ToUpper() != "X")
			{
				switch (decisao)
				{
					case "1":
						ListarSeries();
						break;
					case "2":
						AdicionarSerie();
						break;
					case "3":
                        int tamanhorep = repositorio.ProximoId();
                        if (tamanhorep == 0)
                        {
                            Console.WriteLine("Ainda não há séries para serem atualizadas." + Environment.NewLine);
                            break;
                        }

						AtualizarSerie();
						break;
					case "4":
						ExcluirSerie();
						break;
					case "5":
                        int tamanhorep2 = repositorio.ProximoId();
                        if (tamanhorep2 == 0)
                        {
                            Console.WriteLine("Ainda não há séries para serem visualizadas." + Environment.NewLine);
                            break;
                        }
						VisualizarSerie();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				decisao = EscolherOpcao();
			}

			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
        }
    }
}
