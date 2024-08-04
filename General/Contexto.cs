using Domain;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class Contexto : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<PedidoComun> PedidosComunes { get; set; }
        public DbSet<PedidoExpress> PedidosExpress { get; set; }
        public DbSet<Articulo> Articulos { get; set; }
        public DbSet<LineaPedido> LineaPedidos { get; set; }

        public Contexto(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>()
                .OwnsOne(c => c.Direccion);             //direccion es VO de Cliente

            modelBuilder.Entity<Usuario>()
                .HasIndex(u => u.Email).IsUnique();

            modelBuilder.Entity<Articulo>()
                .HasIndex(a => a.Codigo).IsUnique();

            modelBuilder.Entity<LineaPedido>()
                .HasOne(lp => lp.Pedido)                //una linea de pedido tiene un pedido
                .WithMany()                             //un pedido puede estar en distintas lineas de pedido
                .HasForeignKey(lp => lp.PedidoId);      //pedido es FK de linea de pedido

            modelBuilder.Entity<LineaPedido>() 
                .HasOne(lp => lp.Articulo)              //una linea de pedido tiene un articulo
                .WithMany()                             //un articulo puede estar en distintas lineas de pedido
                .HasForeignKey(lp => lp.ArticuloId);    //articulo es FK de linea de pedido

            modelBuilder.Entity<Pedido>()
                .HasOne(p => p.Cliente)                 //un pedido tiene un cliente
                .WithMany()                             //un cliente puede tener varios pedidos
                .HasForeignKey(p  => p.ClienteId);      //cliente es FK de pedido

            /*declarar que pedidoexpress y pedidocomun son herencia de pedido*/
            modelBuilder.Entity<PedidoComun>().ToTable("PedidoComun");
            modelBuilder.Entity<PedidoExpress>().ToTable("PedidoExpress");





            base.OnModelCreating(modelBuilder);
        }








    }
}
