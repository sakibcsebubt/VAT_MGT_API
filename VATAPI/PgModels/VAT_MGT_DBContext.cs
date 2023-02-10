using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace VATAPI.PgModels
{
    public partial class VAT_MGT_DBContext : DbContext
    {
        public VAT_MGT_DBContext()
        {
        }

        public VAT_MGT_DBContext(DbContextOptions<VAT_MGT_DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Areainf> Areainfs { get; set; }
        public virtual DbSet<BusinessInf> BusinessInfs { get; set; }
        public virtual DbSet<Catagorytype> Catagorytypes { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Iteminf> Iteminfs { get; set; }
        public virtual DbSet<LPurchasedtl> LPurchasedtls { get; set; }
        public virtual DbSet<LPurchaseinfo> LPurchaseinfos { get; set; }
        public virtual DbSet<RegType> RegTypes { get; set; }
        public virtual DbSet<Taxrateinf> Taxrateinfs { get; set; }
        public virtual DbSet<Vdsinf> Vdsinfs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=192.168.1.104;Database=VAT_MGT_DB;Username=postgres;Password=1234");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Areainf>(entity =>
            {
                entity.HasKey(e => e.Areaid)
                    .HasName("AREAINF_pkey");

                entity.ToTable("AREAINF");

                entity.HasComment("AREA Code 12 digit \n3-country 2-division 2-District 2-Thana 3- Area");

                entity.Property(e => e.Areaid)
                    .HasColumnName("AREAID")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Areacode)
                    .HasPrecision(12)
                    .HasColumnName("AREACODE");

                entity.Property(e => e.Areaname)
                    .IsRequired()
                    .HasColumnName("AREANAME");
            });

            modelBuilder.Entity<BusinessInf>(entity =>
            {
                entity.HasKey(e => e.BgInfoId)
                    .HasName("BusinessInf_pkey");

                entity.ToTable("BusinessInf");

                entity.Property(e => e.BgInfoId).UseIdentityAlwaysColumn();

                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<Catagorytype>(entity =>
            {
                entity.HasKey(e => e.Ctgid)
                    .HasName("CATAGORYTYPES_pkey");

                entity.ToTable("CATAGORYTYPES");

                entity.Property(e => e.Ctgid)
                    .HasColumnName("CTGID")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("DEPARTMENTS");

                entity.Property(e => e.Id).UseIdentityAlwaysColumn();

                entity.Property(e => e.DeptName)
                    .IsRequired()
                    .HasColumnName("Dept_Name");

                entity.Property(e => e.DeptSname)
                    .IsRequired()
                    .HasColumnName("Dept_SName");
            });

            modelBuilder.Entity<Iteminf>(entity =>
            {
                entity.HasKey(e => e.ItemId)
                    .HasName("ITEMINF_pkey");

                entity.ToTable("ITEMINF");

                entity.Property(e => e.ItemId)
                    .HasColumnName("ItemID")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Exempted).HasColumnName("EXEMPTED");

                entity.Property(e => e.Expdatereq).HasColumnName("EXPDATEREQ");

                entity.Property(e => e.Fixedvat).HasColumnName("FIXEDVAT");

                entity.Property(e => e.Hscode)
                    .IsRequired()
                    .HasColumnName("HSCODE");

                entity.Property(e => e.Iaabu)
                    .HasColumnName("IAABU")
                    .HasComment("IS APPLICABLE FOR ALL BUSINESS UNIT");

                entity.Property(e => e.Iahcs)
                    .HasColumnName("IAHCS")
                    .HasComment("IS APPLICABLE FOR HEALTH CARE SURCHARGE");

                entity.Property(e => e.Iapd)
                    .HasColumnName("IAPD")
                    .HasComment("IS APPLICABLE FOR PRICE DECLARATION");

                entity.Property(e => e.ItemName).IsRequired();

                entity.Property(e => e.Mrp).HasColumnName("MRP");

                entity.Property(e => e.Prtype).HasColumnName("PRTYPE");

                entity.Property(e => e.Rebatable).HasColumnName("REBATABLE");

                entity.Property(e => e.Reduced).HasColumnName("REDUCED");

                entity.Property(e => e.Skucode)
                    .IsRequired()
                    .HasColumnName("SKUCODE");

                entity.Property(e => e.Vds).HasColumnName("VDS");

                entity.Property(e => e.Zerorate).HasColumnName("ZERORATE");
            });

            modelBuilder.Entity<LPurchasedtl>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("L_PURCHASEDTL");

                entity.Property(e => e.Ait).HasColumnName("AIT");

                entity.Property(e => e.AitS).HasColumnName("AIT_S");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Isexemted).HasColumnName("ISEXEMTED");

                entity.Property(e => e.Isfixedvat).HasColumnName("ISFIXEDVAT");

                entity.Property(e => e.Ismrp).HasColumnName("ISMRP");

                entity.Property(e => e.Isrebatable).HasColumnName("ISREBATABLE");

                entity.Property(e => e.Isreduce).HasColumnName("ISREDUCE");

                entity.Property(e => e.Isvds).HasColumnName("ISVDS");

                entity.Property(e => e.Iszerorate).HasColumnName("ISZERORATE");

                entity.Property(e => e.Itemid).HasColumnName("ITEMID");

                entity.Property(e => e.LPurchaseid).HasColumnName("L_PURCHASEID");

                entity.Property(e => e.Qty).HasColumnName("QTY");

                entity.Property(e => e.Remarks).HasColumnName("REMARKS");

                entity.Property(e => e.Sd).HasColumnName("SD");

                entity.Property(e => e.SdS).HasColumnName("SD_S");

                entity.Property(e => e.UPrice).HasColumnName("U_PRICE");

                entity.Property(e => e.UPriceS).HasColumnName("U_PRICE_S");

                entity.Property(e => e.Vat).HasColumnName("VAT");

                entity.Property(e => e.VatS).HasColumnName("VAT_S");

                entity.Property(e => e.VdsAmt).HasColumnName("VDS_AMT");
            });

            modelBuilder.Entity<LPurchaseinfo>(entity =>
            {
                entity.HasKey(e => e.PId)
                    .HasName("L_PURCHASEINFO_pkey");

                entity.ToTable("L_PURCHASEINFO");

                entity.Property(e => e.PId)
                    .HasColumnName("P_ID")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.AgrNo).HasColumnName("AGR_NO");

                entity.Property(e => e.Chldate)
                    .HasColumnType("timestamp with time zone")
                    .HasColumnName("CHLDATE");

                entity.Property(e => e.Ctgid).HasColumnName("CTGID");

                entity.Property(e => e.RcvChldate)
                    .HasColumnType("timestamp with time zone")
                    .HasColumnName("RCV_CHLDATE");

                entity.Property(e => e.RcvScrollno).HasColumnName("RCV_SCROLLNO");

                entity.Property(e => e.RefChlno)
                    .IsRequired()
                    .HasColumnName("REF_CHLNO");

                entity.Property(e => e.RegTypeId).HasColumnName("RegTypeID");

                entity.Property(e => e.Remarks).HasColumnName("REMARKS");

                entity.Property(e => e.Rowtime)
                    .HasColumnType("timestamp with time zone")
                    .HasColumnName("ROWTIME")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                entity.Property(e => e.UDestination).HasColumnName("U_DESTINATION");
            });

            modelBuilder.Entity<RegType>(entity =>
            {
                entity.ToTable("REG_TYPE");

                entity.Property(e => e.Id).UseIdentityAlwaysColumn();

                entity.Property(e => e.TypyName)
                    .IsRequired()
                    .HasColumnName("Typy_Name");
            });

            modelBuilder.Entity<Taxrateinf>(entity =>
            {
                entity.HasKey(e => e.RateId)
                    .HasName("TAXRATEINF_pkey");

                entity.ToTable("TAXRATEINF");

                entity.Property(e => e.RateId)
                    .HasColumnName("RateID")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Ait).HasColumnName("AIT");

                entity.Property(e => e.At).HasColumnName("AT_");

                entity.Property(e => e.Cd).HasColumnName("CD");

                entity.Property(e => e.EffectDate).HasColumnType("date");

                entity.Property(e => e.Itemid).HasColumnName("ITEMID");

                entity.Property(e => e.Llimit)
                    .HasColumnName("LLIMIT")
                    .HasDefaultValueSql("0.00");

                entity.Property(e => e.Rd).HasColumnName("RD");

                entity.Property(e => e.Sd).HasColumnName("SD");

                entity.Property(e => e.Sdamt).HasColumnName("SDAMT");

                entity.Property(e => e.Ttid).HasColumnName("TTID");

                entity.Property(e => e.Ulimit).HasColumnName("ULIMIT");

                entity.Property(e => e.Vat).HasColumnName("VAT");

                entity.Property(e => e.Vatamt).HasColumnName("VATAMT");
            });

            modelBuilder.Entity<Vdsinf>(entity =>
            {
                entity.HasKey(e => e.Vdsid)
                    .HasName("VDSINF_pkey");

                entity.ToTable("VDSINF");

                entity.Property(e => e.Vdsid)
                    .HasColumnName("VDSID")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Vdsname)
                    .IsRequired()
                    .HasColumnName("VDSNAME");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
