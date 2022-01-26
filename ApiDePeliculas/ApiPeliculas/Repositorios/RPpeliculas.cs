using ApiPeliculas.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApiPeliculas.Repositorios
{
    public class RPpeliculas
    {
        public static List<Pelicula> _listaPeliculas = new List<Pelicula>()
        {
             //Id = 1, NombrePelicula = "Harry Potter y la Piedra Filosofal", Director = "J. K. Rowling", Genero = "Fantasia", Puntuacion = "4.8", Rating = "4778", FechaPublicacion = "26/06/1997"

        };

        //Obtener la lista de peliculas
        public IEnumerable<Pelicula> ObtenerPelicula()
        {
            return _listaPeliculas;
        }

        //Obtener la lista de peliculas por una id especifica
        public Pelicula ObtenerPeliculaId(int id)
        {
            var pelicula = _listaPeliculas.Where(peli => peli.Id == id);

            return pelicula.FirstOrDefault();
        }

        public IEnumerable<Pelicula> BuscarporDirector(string director)
        {
            var pelicula = _listaPeliculas.Where(peli => peli.Director == director);

            return pelicula;
        }

        //Agregar nueva pelicula con todos los campos
        public void Agregar(Pelicula nuevapelicula)
        {
            _listaPeliculas.Add(nuevapelicula);
        }
        //Borrar pelicula por id
        public void BorrarPelicula(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Falta Informacion ");
            }
            var result = ObtenerPeliculaId(id);
            _listaPeliculas.Remove(result);
        }
        //Actualizar Pelicula por Id
        public void ActualizarPelicula (int id, Pelicula actualizarpelicula)
        {
            if (id <= 0  || actualizarpelicula == null)
            {
                throw new ArgumentException("Falta Informacion :c");
            }
            var mdpelicula = ObtenerPeliculaId(id);

            mdpelicula.NombrePelicula = actualizarpelicula.NombrePelicula;
            mdpelicula.Director = actualizarpelicula.Director;
            mdpelicula.Genero = actualizarpelicula.Genero;
            mdpelicula.Puntuacion = actualizarpelicula.Puntuacion;
            mdpelicula.Rating = actualizarpelicula.Rating;
            mdpelicula.FechaPublicacion = actualizarpelicula.FechaPublicacion;
            _listaPeliculas.Remove(mdpelicula);
            _listaPeliculas.Add(mdpelicula);

        }

        





    }
}
