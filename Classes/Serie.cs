using System;
namespace Catalogo
{
    public class Serie : SerieBase
    {
        // Atributos
        
        private String Titulo { get; set; }
        private Genero Genero { get; set; }
        private int Ano { get; set; }
        private String Descricao { get; set; }
        private bool Excluido { get; set; }

        // Métodos
        public Serie(int id, String titulo, Genero genero, int ano, String descricao) 
        {
            this.Id = id;
            this.Titulo = titulo;
            this.Genero = genero;
            this.Ano = ano;
            this.Descricao = descricao;
            this.Excluido = false;
               
        }

        public override string ToString()
		{
            string retorno = "";
            retorno += "Gênero: " + this.Genero + Environment.NewLine;
            retorno += "Titulo: " + this.Titulo + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Ano de Início: " + this.Ano + Environment.NewLine;
			return retorno;
		}

        public int RetornaId()
        {
            return this.Id;
        }

        public String RetornaTitulo()
        {
            return this.Titulo;
        }

        public void Excluir()
        {
            this.Excluido = true;
        }

        public Genero RetornaGenero()
        {
            return this.Genero;
        }
    }
}