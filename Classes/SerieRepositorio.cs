using System;
using System.Collections.Generic;
using Catalogo.Interfaces;
namespace Catalogo
{
    public class SerieRepositorio : IRepositorio<Serie>
    {
        private List<Serie> listaSerie = new List<Serie>();
        public void Ataliza(int id, Serie serie)
        {
            listaSerie[id] = serie;
        }

        public void Exclui(int id)
        {
            listaSerie.Remove(listaSerie[id]);
        }

        public void Insere(Serie serie)
        {
            listaSerie.Add(serie);
        }

        public List<Serie> Lista()
        {
            return listaSerie;
        }

        public int ProximoId()
        {
            return listaSerie.Count;
        }

        public Serie RetornaPorId(int id)
        {
            return listaSerie[id];
        }
    }
}