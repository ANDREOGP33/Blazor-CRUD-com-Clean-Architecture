using Livraria.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.Infrastructure.EntitiesConfiguration
{
    internal class LivroConfiguration : IEntityTypeConfiguration<Livro>
    {
        public void Configure(EntityTypeBuilder<Livro> builder)
        {
            builder.HasKey(x => x.LivroId);
            builder.Property(x => x.Titulo).HasMaxLength(150).IsRequired();
            builder.Property(x => x.Autor).HasMaxLength(200).IsRequired();
            builder.Property(x => x.Lancamento).IsRequired();
            builder.Property(x => x.Capa).HasMaxLength(200);
        }

    }
}
