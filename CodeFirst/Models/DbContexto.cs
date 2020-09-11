using Microsoft.EntityFrameworkCore;

namespace CodeFirst.Models
{
    public class DbContexto : DbContext
    {
        public DbContexto()
        {

        }
        //con :base indicamos el parametro al padre DbContext de la que hereda esta clase
        public DbContexto(DbContextOptions<DbContexto> options) : base(options) 
        {

        }
        //Exponer clases
        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }

        /*Sobrescribir el metodo onModelCreating de la clase padre
         * El metodo onModelCreating nos va a permitir mapear nuestras entidades con la 
         * base de datos y le enviamos como parametro un objeto que instancia de la clase ModelBuilder
         */
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>(entity =>
            {
                //Creacion del modelo (tabla en base de datos)
                entity.ToTable("categoria");
                entity.HasKey(e => e.idCategoria);
                entity.Property(e => e.idCategoria).HasColumnName("idcategoria");

                entity.Property(e => e.nombre)
                    .HasColumnName("nombre")
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);//Indica que la columna de la base de datos se almacenara como varchar en lugar de nvarchar

                entity.Property(e => e.descripcion)
                    .HasColumnName("descripcion")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.estado)
                    .HasColumnName("estado")
                    .HasDefaultValueSql("((1))");

            });
            modelBuilder.Entity<Producto>(entity =>
            {
                entity.ToTable("producto");
                entity.HasKey(e => e.idProducto);
                entity.Property(e => e.idProducto).HasColumnName("idproducto");

                entity.Property(e => e.idCategoria).HasColumnName("idcategoria");

                entity.Property(e => e.codigo)
                    .HasColumnName("codigo")
                    .HasMaxLength(64)
                    .IsUnicode(false);//Indica que la columna de la base de datos se almacenara como varchar en lugar de nvarchar

                entity.Property(e => e.nombre)
                    .HasColumnName("nombre")
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.HasIndex(e => e.nombre)
                    .IsUnique();

                entity.Property(e => e.precioVenta)
                    .HasColumnName("precio_venta")
                    .IsRequired()
                    .HasColumnType("decimal(11, 2)");//11 digitos 2 decimales

                entity.Property(e => e.stock)
                    .HasColumnName("stock")
                    .IsRequired();

                entity.Property(e => e.descripcion)
                    .HasColumnName("descripcion")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.estado)
                    .HasColumnName("estado")
                    .HasDefaultValueSql("((1))");

                //Relacion (una categoria tiene muchos productos)
                entity.HasOne(p => p.categoria) //una categoria - categoria(objeto)
                    .WithMany(c => c.productos) //con muchos productos - productos(lista)
                    .HasForeignKey(p => p.idCategoria) //llave foranea
                    .OnDelete(DeleteBehavior.ClientSetNull) //ningun tipo de eliminacion
                    .HasConstraintName("FK_producto_categoria"); //nombre fk
            });
        }
    }
}
