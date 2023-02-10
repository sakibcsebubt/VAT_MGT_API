using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace VATAPI.MSModels
{
    public partial class SQLDbContext : DbContext
    {
        public SQLDbContext()
        {
        }

        public SQLDbContext(DbContextOptions<SQLDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Areainf> Areainfs { get; set; }
        public virtual DbSet<Businessinf> Businessinfs { get; set; }
        public virtual DbSet<Catagorytype> Catagorytypes { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Iteminf> Iteminfs { get; set; }
        public virtual DbSet<LPurchasedtl> LPurchasedtls { get; set; }
        public virtual DbSet<LPurchaseinfo> LPurchaseinfos { get; set; }
        public virtual DbSet<RegType> RegTypes { get; set; }
        public virtual DbSet<Sirinf> Sirinfs { get; set; }
        public virtual DbSet<Taxrateinf> Taxrateinfs { get; set; }
        public virtual DbSet<Unitinf> Unitinfs { get; set; }
        public virtual DbSet<Userinf> Userinfs { get; set; }
        public virtual DbSet<VatEntite> VatEntites { get; set; }
        public virtual DbSet<Vdsinf> Vdsinfs { get; set; }
        public virtual DbSet<Worklog> Worklogs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Server=ASITDEV11\\SQL2K12ENT;Database=VAT_MGT_DB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Areainf>(entity =>
            {
                entity.HasKey(e => e.Areaid);

                entity.ToTable("AREAINF");

                entity.Property(e => e.Areaid).HasColumnName("AREAID");

                entity.Property(e => e.Areacode)
                    .IsRequired()
                    .HasMaxLength(12)
                    .HasColumnName("AREACODE");

                entity.Property(e => e.Areaname)
                    .IsRequired()
                    .HasColumnName("AREANAME");
            });

            modelBuilder.Entity<Businessinf>(entity =>
            {
                entity.HasKey(e => e.BgInfoId)
                    .HasName("PK_BusinessInf");

                entity.ToTable("BUSINESSINF");
            });

            modelBuilder.Entity<Catagorytype>(entity =>
            {
                entity.HasKey(e => e.Ctgid);

                entity.ToTable("CATAGORYTYPES");

                entity.Property(e => e.Ctgid).HasColumnName("CTGID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.Deptid);

                entity.ToTable("DEPARTMENTS");

                entity.Property(e => e.Deptid).HasColumnName("DEPTID");

                entity.Property(e => e.DeptName)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("DEPT_NAME")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DeptSname)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("DEPT_SNAME")
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<Iteminf>(entity =>
            {
                entity.HasKey(e => e.Itemid);

                entity.ToTable("ITEMINF");

                entity.Property(e => e.Itemid).HasColumnName("ITEMID");

                entity.Property(e => e.Exempted).HasColumnName("EXEMPTED");

                entity.Property(e => e.Expdatereq).HasColumnName("EXPDATEREQ");

                entity.Property(e => e.Fixedvat).HasColumnName("FIXEDVAT");

                entity.Property(e => e.Hscode)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("HSCODE")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Iaabu).HasColumnName("IAABU");

                entity.Property(e => e.Iahcs).HasColumnName("IAHCS");

                entity.Property(e => e.Iapd).HasColumnName("IAPD");

                entity.Property(e => e.ItemName)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("ITEM_NAME")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Mrp).HasColumnName("MRP");

                entity.Property(e => e.Prtype)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("PRTYPE");

                entity.Property(e => e.Rebatable).HasColumnName("REBATABLE");

                entity.Property(e => e.Reduced).HasColumnName("REDUCED");

                entity.Property(e => e.Rowtime)
                    .HasColumnType("datetime")
                    .HasColumnName("ROWTIME")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Skucode)
                    .HasMaxLength(100)
                    .HasColumnName("SKUCODE")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UnitId).HasColumnName("UNIT_ID");

                entity.Property(e => e.Vds).HasColumnName("VDS");

                entity.Property(e => e.Zerorate).HasColumnName("ZERORATE");
            });

            modelBuilder.Entity<LPurchasedtl>(entity =>
            {
                entity.ToTable("L_PURCHASEDTL");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Ait)
                    .HasColumnType("decimal(18, 6)")
                    .HasColumnName("AIT");

                entity.Property(e => e.AitS)
                    .HasColumnType("decimal(18, 6)")
                    .HasColumnName("AIT_S");

                entity.Property(e => e.Isexempted).HasColumnName("ISEXEMPTED");

                entity.Property(e => e.Isfixedvat).HasColumnName("ISFIXEDVAT");

                entity.Property(e => e.Ismrp).HasColumnName("ISMRP");

                entity.Property(e => e.Isrebatable).HasColumnName("ISREBATABLE");

                entity.Property(e => e.Isreduced).HasColumnName("ISREDUCED");

                entity.Property(e => e.Isvds).HasColumnName("ISVDS");

                entity.Property(e => e.Iszerorate).HasColumnName("ISZERORATE");

                entity.Property(e => e.Itemid).HasColumnName("ITEMID");

                entity.Property(e => e.LPurchaseid).HasColumnName("L_PURCHASEID");

                entity.Property(e => e.Qty)
                    .HasColumnType("decimal(18, 6)")
                    .HasColumnName("QTY");

                entity.Property(e => e.Remarks)
                    .IsRequired()
                    .HasColumnName("REMARKS")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Rowtime)
                    .HasColumnType("datetime")
                    .HasColumnName("ROWTIME")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Sd)
                    .HasColumnType("decimal(18, 6)")
                    .HasColumnName("SD");

                entity.Property(e => e.SdS)
                    .HasColumnType("decimal(18, 6)")
                    .HasColumnName("SD_S");

                entity.Property(e => e.UPrice)
                    .HasColumnType("decimal(18, 6)")
                    .HasColumnName("U_PRICE");

                entity.Property(e => e.UPriceS)
                    .HasColumnType("decimal(18, 6)")
                    .HasColumnName("U_PRICE_S");

                entity.Property(e => e.Vat)
                    .HasColumnType("decimal(18, 6)")
                    .HasColumnName("VAT");

                entity.Property(e => e.VatS)
                    .HasColumnType("decimal(18, 6)")
                    .HasColumnName("VAT_S");

                entity.Property(e => e.VdsAmt)
                    .HasColumnType("decimal(18, 6)")
                    .HasColumnName("VDS_AMT");
            });

            modelBuilder.Entity<LPurchaseinfo>(entity =>
            {
                entity.HasKey(e => e.PId);

                entity.ToTable("L_PURCHASEINFO");

                entity.Property(e => e.PId).HasColumnName("P_ID");

                entity.Property(e => e.AgrNo).HasColumnName("AGR_NO");

                entity.Property(e => e.Chldate)
                    .HasColumnType("datetime")
                    .HasColumnName("CHLDATE");

                entity.Property(e => e.Ctgid).HasColumnName("CTGID");

                entity.Property(e => e.RcvChldate)
                    .HasColumnType("datetime")
                    .HasColumnName("RCV_CHLDATE");

                entity.Property(e => e.RcvScrollno).HasColumnName("RCV_SCROLLNO");

                entity.Property(e => e.RefChlno)
                    .IsRequired()
                    .HasColumnName("REF_CHLNO")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Regtypeid).HasColumnName("REGTYPEID");

                entity.Property(e => e.Remarks).HasColumnName("REMARKS");

                entity.Property(e => e.Rowtime)
                    .HasColumnType("datetime")
                    .HasColumnName("ROWTIME")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Supplierid).HasColumnName("SUPPLIERID");

                entity.Property(e => e.UDestination).HasColumnName("U_DESTINATION");
            });

            modelBuilder.Entity<RegType>(entity =>
            {
                entity.ToTable("REG_TYPE");

                entity.Property(e => e.RegTypeId).HasColumnName("REG_TYPE_ID");

                entity.Property(e => e.TypeName)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("TYPE_NAME")
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<Sirinf>(entity =>
            {
                entity.HasKey(e => e.Sirid);

                entity.ToTable("SIRINF");

                entity.Property(e => e.Sirid).HasColumnName("SIRID");

                entity.Property(e => e.Busnssinf)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("BUSNSSINF")
                    .HasDefaultValueSql("('')")
                    .HasComment("PARTY BUSINESS INFO");

                entity.Property(e => e.Crdtlimit)
                    .HasColumnType("decimal(18, 6)")
                    .HasColumnName("CRDTLIMIT");

                entity.Property(e => e.Emailaddr)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("EMAILADDR")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Isdevsurcharge)
                    .HasColumnName("ISDEVSURCHARGE")
                    .HasComment("ID DEVELOPMENT SURCHARGE");

                entity.Property(e => e.Isenvsafety)
                    .HasColumnName("ISENVSAFETY")
                    .HasComment("IS ENVIRONMENT SAFETY");

                entity.Property(e => e.Isexciseduty)
                    .HasColumnName("ISEXCISEDUTY")
                    .HasComment("IS EXCISE DUTY");

                entity.Property(e => e.Ishlthsafety)
                    .HasColumnName("ISHLTHSAFETY")
                    .HasComment("IS HEALTH SAFETY");

                entity.Property(e => e.Isit)
                    .HasColumnName("ISIT")
                    .HasComment("IS INFORMATION TECHNOLOGY");

                entity.Property(e => e.Isvdsdeducted)
                    .HasColumnName("ISVDSDEDUCTED")
                    .HasComment("IS VDS DEDUCTED");

                entity.Property(e => e.Majorarea)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("MAJORAREA")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Nid)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("NID")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Ownername)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("OWNERNAME")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Phoneno)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("PHONENO")
                    .HasDefaultValueSql("('')")
                    .HasComment("PARTY PHONE");

                entity.Property(e => e.Prtyaddress)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("PRTYADDRESS")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Prtybin)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("PRTYBIN")
                    .HasDefaultValueSql("('')")
                    .HasComment("PARTY BIN NUMBER");

                entity.Property(e => e.Prtycode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("PRTYCODE")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Prtyname)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("PRTYNAME")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Prtype)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("PRTYPE")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Regtypid).HasColumnName("REGTYPID");

                entity.Property(e => e.Ultmtdestnation)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("ULTMTDESTNATION")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Vdsnam)
                    .IsRequired()
                    .HasMaxLength(7)
                    .HasColumnName("VDSNAM")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Webaddr)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("WEBADDR")
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.Regtyp)
                    .WithMany(p => p.Sirinfs)
                    .HasForeignKey(d => d.Regtypid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SIRINF_SIRINF");
            });

            modelBuilder.Entity<Taxrateinf>(entity =>
            {
                entity.HasKey(e => e.Rateid);

                entity.ToTable("TAXRATEINF");

                entity.Property(e => e.Rateid)
                    .ValueGeneratedNever()
                    .HasColumnName("RATEID");

                entity.Property(e => e.Ait).HasColumnName("AIT");

                entity.Property(e => e.At).HasColumnName("AT_");

                entity.Property(e => e.Cd).HasColumnName("CD");

                entity.Property(e => e.Effectdate)
                    .HasColumnType("datetime")
                    .HasColumnName("EFFECTDATE");

                entity.Property(e => e.Itemid).HasColumnName("ITEMID");

                entity.Property(e => e.Llimit)
                    .HasColumnType("decimal(18, 6)")
                    .HasColumnName("LLIMIT");

                entity.Property(e => e.Rd).HasColumnName("RD");

                entity.Property(e => e.Rowtime)
                    .HasColumnType("datetime")
                    .HasColumnName("ROWTIME")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Sd).HasColumnName("SD");

                entity.Property(e => e.Sdamt)
                    .HasColumnType("decimal(18, 6)")
                    .HasColumnName("SDAMT");

                entity.Property(e => e.Ttid).HasColumnName("TTID");

                entity.Property(e => e.Ulimit)
                    .HasColumnType("decimal(18, 6)")
                    .HasColumnName("ULIMIT");

                entity.Property(e => e.Vat).HasColumnName("VAT");

                entity.Property(e => e.Vatamt)
                    .HasColumnType("decimal(18, 6)")
                    .HasColumnName("VATAMT");
            });

            modelBuilder.Entity<Unitinf>(entity =>
            {
                entity.HasKey(e => e.Unitid);

                entity.ToTable("UNITINF");

                entity.Property(e => e.Unitid).HasColumnName("UNITID");

                entity.Property(e => e.UnitName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("UNIT_NAME")
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<Userinf>(entity =>
            {
                entity.HasKey(e => new { e.Comcod, e.Hccode });

                entity.ToTable("USERINF");

                entity.Property(e => e.Comcod)
                    .HasMaxLength(4)
                    .HasColumnName("COMCOD")
                    .IsFixedLength(true);

                entity.Property(e => e.Hccode)
                    .HasMaxLength(12)
                    .HasColumnName("HCCODE")
                    .IsFixedLength(true);

                entity.Property(e => e.LOG_PASS)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("LOG_PASS");

                entity.Property(e => e.Perdesc).HasColumnName("PERDESC");

                entity.Property(e => e.Rowid)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ROWID");

                entity.Property(e => e.Rowtime)
                    .HasColumnType("datetime")
                    .HasColumnName("ROWTIME")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LOG_ID)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("LOG_ID");

                entity.Property(e => e.Userrmrk)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("USERRMRK");
            });

            modelBuilder.Entity<VatEntite>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("VAT_ENTITES");

                entity.Property(e => e.EntityId).ValueGeneratedOnAdd();

                entity.Property(e => e.Rowtime)
                    .HasColumnType("datetime")
                    .HasColumnName("ROWTIME")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Sortid).HasColumnName("SORTID");

                entity.Property(e => e.Tagdesc)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("TAGDESC")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Tagfor)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("TAGFOR")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Tagid)
                    .IsRequired()
                    .HasMaxLength(7)
                    .HasColumnName("TAGID")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Vdsinf>(entity =>
            {
                entity.HasKey(e => e.Vdsid);

                entity.ToTable("VDSINF");

                entity.Property(e => e.Vdsid).HasColumnName("VDSID");

                entity.Property(e => e.Vdsname)
                    .HasMaxLength(250)
                    .HasColumnName("VDSNAME");
            });

            modelBuilder.Entity<Worklog>(entity =>
            {
                entity.HasKey(e => new { e.Comcod, e.Logsl })
                    .HasName("PK_WORKLOGS_1");

                entity.ToTable("WORKLOGS");

                entity.Property(e => e.Comcod)
                    .HasMaxLength(4)
                    .HasColumnName("COMCOD")
                    .IsFixedLength(true);

                entity.Property(e => e.Logsl)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("LOGSL");

                entity.Property(e => e.Logbyid)
                    .IsRequired()
                    .HasMaxLength(12)
                    .HasColumnName("LOGBYID")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);

                entity.Property(e => e.Logdata)
                    .HasColumnType("xml")
                    .HasColumnName("LOGDATA");

                entity.Property(e => e.Logref)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("LOGREF")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Logses)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("LOGSES")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Logtime)
                    .HasColumnType("datetime")
                    .HasColumnName("LOGTIME")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Logtrm)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("LOGTRM")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Trnnum)
                    .IsRequired()
                    .HasMaxLength(18)
                    .HasColumnName("TRNNUM")
                    .HasDefaultValueSql("('')")
                    .IsFixedLength(true);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
