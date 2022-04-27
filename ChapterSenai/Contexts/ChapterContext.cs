using ChapterSenai.Models;
using Microsoft.EntityFrameworkCore;

namespace ChapterSenai.Contexts
{
    public class ChapterContext : DbContext
    {
        public ChapterContext()
        {

        }

        public ChapterContext(DbContextOptions<ChapterContext> options) : base(options)
        {

        }
        //Vamos utilizar esse método para configurar os dados

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //Cada provedor tem sua sintaxe para especificação
                optionsBuilder.UseSqlServer("" +
                    "Data Source = DESKTOP-L6A6NA4\\LOCALDB#B043C77D ; initial catalog = Chapter; Integrated Security = true");
            }
        }
        // dbset representa as entidades que serão utilizadas nas operações de leitura, criação, atualização e deleção
        public DbSet<Livro> Livros { get; set; }
    }
}
