using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Data;

namespace RazorPagesMovie.Models;

public static class SeedData //expresa la lógica para  "sembrar la base de datos"
{
    public static void Initialize(IServiceProvider serviceProvider) //método estático que utiliza el parámetro IServiceProvider
                                                                    // usado para resolver las dependencias en el contexto de la BD
    {
        using (var context = new RazorPagesMovieContext(        //crea un contexto de base de datos para la conexión a la BD y conectarse la tabla Movie
            serviceProvider.GetRequiredService<
                DbContextOptions<RazorPagesMovieContext>>()))       //Recupera el contexto "RazorPagesMovieContext"
        {
            if (context == null || context.Movie == null)   //revisa la disponibilidad de la BD y lanza el mensaje en caso de indisponibilidad
            {
                throw new ArgumentNullException("Null RazorPagesMovieContext");
            }

            // Look for any movies.
            if (context.Movie.Any())
            {
                return;   // DB has been seeded
            }

            context.Movie.AddRange(     //Agrega unr anto de objetos  al objeto 'Movie' de la BD
                new Movie
                {
                    Title = "When Harry Met Sally",
                    ReleaseDate = DateTime.Parse("1989-2-12"),
                    Genre = "Romantic Comedy",
                    Price = 7.99M,
                    Rating = "R"
                },

                new Movie
                {
                    Title = "Ghostbusters ",
                    ReleaseDate = DateTime.Parse("1984-3-13"),
                    Genre = "Comedy",
                    Price = 8.99M
                },

                new Movie
                {
                    Title = "Ghostbusters 2",
                    ReleaseDate = DateTime.Parse("1986-2-23"),
                    Genre = "Comedy",
                    Price = 9.99M
                },

                new Movie
                {
                    Title = "Rio Bravo",
                    ReleaseDate = DateTime.Parse("1959-4-15"),
                    Genre = "Western",
                    Price = 3.99M
                }
            );
            context.SaveChanges(); //Guarda todos los datos en la BD
        }
    }
}