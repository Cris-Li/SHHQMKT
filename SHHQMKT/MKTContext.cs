﻿namespace SHHQMKT
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Linq;

    public class MKTContext : DbContext
    {
        //您的上下文已配置为从您的应用程序的配置文件(App.config 或 Web.config)
        //使用“MKTContext”连接字符串。默认情况下，此连接字符串针对您的 LocalDb 实例上的
        //“SHHQMKT.MKTContext”数据库。
        // 
        //如果您想要针对其他数据库和/或数据库提供程序，请在应用程序配置文件中修改“MKTContext”
        //连接字符串。
        public MKTContext()
            : base("name=MKTContext")
        {
            Database.SetInitializer<MKTContext>(new DropCreateDatabaseIfModelChanges<MKTContext>());
        }

        //为您要在模型中包含的每种实体类型都添加 DbSet。有关配置和使用 Code First  模型
        //的详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=390109。

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public DbSet<MKTDT> MKTDTs { get; set; }
        public DbSet<CPXXMMDD> CPXXMMDDs { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MKTDT>().Property(p => p.TradeVolume).HasPrecision(16,0);
            modelBuilder.Entity<MKTDT>().Property(p => p.TotalValueTraded).HasPrecision(16, 2);
            modelBuilder.Entity<MKTDT>().Property(p => p.PreClosePx).HasPrecision(11, 3);
            modelBuilder.Entity<MKTDT>().Property(p => p.OpenPrice).HasPrecision(11, 3);
            modelBuilder.Entity<MKTDT>().Property(p => p.HighPrice).HasPrecision(11, 3);
            modelBuilder.Entity<MKTDT>().Property(p => p.LowPrice).HasPrecision(11, 3);
            modelBuilder.Entity<MKTDT>().Property(p => p.TradePrice).HasPrecision(11, 3);
            modelBuilder.Entity<MKTDT>().Property(p => p.ClosePx).HasPrecision(11, 3);
            modelBuilder.Entity<MKTDT>().Property(p => p.BuyPrice1).HasPrecision(11, 3);
            modelBuilder.Entity<MKTDT>().Property(p => p.BuyVolume1).HasPrecision(12, 0);
            modelBuilder.Entity<MKTDT>().Property(p => p.SellPrice1).HasPrecision(11, 3);
            modelBuilder.Entity<MKTDT>().Property(p => p.SellVolume1).HasPrecision(12, 0);
            modelBuilder.Entity<MKTDT>().Property(p => p.BuyPrice2).HasPrecision(11, 3);
            modelBuilder.Entity<MKTDT>().Property(p => p.BuyVolume2).HasPrecision(12, 0);
            modelBuilder.Entity<MKTDT>().Property(p => p.SellPrice2).HasPrecision(11, 3);
            modelBuilder.Entity<MKTDT>().Property(p => p.SellVolume2).HasPrecision(12, 0);
            modelBuilder.Entity<MKTDT>().Property(p => p.BuyPrice3).HasPrecision(11, 3);
            modelBuilder.Entity<MKTDT>().Property(p => p.BuyVolume3).HasPrecision(12, 0);
            modelBuilder.Entity<MKTDT>().Property(p => p.SellPrice3).HasPrecision(11, 3);
            modelBuilder.Entity<MKTDT>().Property(p => p.SellVolume3).HasPrecision(12, 0);
            modelBuilder.Entity<MKTDT>().Property(p => p.BuyPrice4).HasPrecision(11, 3);
            modelBuilder.Entity<MKTDT>().Property(p => p.BuyVolume4).HasPrecision(12, 0);
            modelBuilder.Entity<MKTDT>().Property(p => p.SellPrice4).HasPrecision(11, 3);
            modelBuilder.Entity<MKTDT>().Property(p => p.SellVolume4).HasPrecision(12, 0);
            modelBuilder.Entity<MKTDT>().Property(p => p.BuyPrice5).HasPrecision(11, 3);
            modelBuilder.Entity<MKTDT>().Property(p => p.BuyVolume5).HasPrecision(12, 0);
            modelBuilder.Entity<MKTDT>().Property(p => p.SellPrice5).HasPrecision(11, 3);
            modelBuilder.Entity<MKTDT>().Property(p => p.SellVolume5).HasPrecision(12, 0);
            modelBuilder.Entity<MKTDT>().Property(p => p.PreCloseIOPV).HasPrecision(11, 3);
            modelBuilder.Entity<MKTDT>().Property(p => p.IOPV).HasPrecision(11, 3);

            modelBuilder.Entity<CPXXMMDD>().Property(p => p.FaceValue).HasPrecision(15, 3);
            modelBuilder.Entity<CPXXMMDD>().Property(p => p.UnmarketableAmount).HasPrecision(15, 0);
            modelBuilder.Entity<CPXXMMDD>().Property(p => p.BuyUnit).HasPrecision(12, 0);
        }
    }

    public class MKTDT
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(5)]
        public string MDStreamID { get; set; }
        [MaxLength(6)]
        public string SecurityID { get; set; }
        [MaxLength(15)]
        public string Symbol { get; set; }
        public decimal TradeVolume { get; set; }
        public decimal TotalValueTraded { get; set; }
        public decimal PreClosePx { get; set; }
        public decimal OpenPrice { get; set; }
        public decimal HighPrice { get; set; }
        public decimal LowPrice { get; set; }
        public decimal TradePrice { get; set; }
        public decimal ClosePx { get; set; }
        public decimal BuyPrice1 { get; set; }
        public decimal BuyVolume1 { get; set; }
        public decimal SellPrice1 { get; set; }
        public decimal SellVolume1 { get; set; }
        public decimal BuyPrice2 { get; set; }
        public decimal BuyVolume2 { get; set; }
        public decimal SellPrice2 { get; set; }
        public decimal SellVolume2 { get; set; }
        public decimal BuyPrice3 { get; set; }
        public decimal BuyVolume3 { get; set; }
        public decimal SellPrice3 { get; set; }
        public decimal SellVolume3 { get; set; }
        public decimal BuyPrice4 { get; set; }
        public decimal BuyVolume4 { get; set; }
        public decimal SellPrice4 { get; set; }
        public decimal SellVolume4 { get; set; }
        public decimal BuyPrice5 { get; set; }
        public decimal BuyVolume5 { get; set; }
        public decimal SellPrice5 { get; set; }
        public decimal SellVolume5 { get; set; }
        public decimal PreCloseIOPV { get; set; }
        public decimal IOPV { get; set; }
        [MaxLength(8)]
        public string TradingPhaseCode { get; set; }
        [MaxLength(12)]
        public string Timestamp { get; set; }
    }

    public class CPXXMMDD
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(6)]
        public string SecurityID { get; set; }
        [MaxLength(12)]
        public string ISIN { get; set; }
        [MaxLength(8)]
        public string Updatetime { get; set; }
        [MaxLength(8)]
        public string ChineseName { get; set; }
        [MaxLength(10)]
        public string EnglishName { get; set; }
        [MaxLength(6)]
        public string BasicCode { get; set; }
        [MaxLength(4)]
        public string MarketType { get; set; }
        [MaxLength(6)]
        public string SecurityType { get; set; }
        [MaxLength(3)]
        public string SecuritySubType { get; set; }
        [MaxLength(3)]
        public string CurrencyType { get; set; }
        public decimal FaceValue { get; set; }
        public decimal UnmarketableAmount { get; set; }
        [MaxLength(15)]
        public string LastTradeDate { get; set; }
        [MaxLength(8)]
        public string IssueDate { get; set; }
        [MaxLength(3)]
        public string SETNo { get; set; }
        public decimal BuyUnit { get; set; }
        public decimal SellUnit { get; set; }
        public decimal AmountLowLimit { get; set; }
        public decimal AmountHighLimt { get; set; }
        public decimal PreClose { get; set; }
        public decimal PriceStall { get; set; }
        [MaxLength(1)]
        public string PriceLimitType { get; set; }
        public decimal HighLimt { get; set; }
        public decimal LowLimit_ { get; set; }
        public decimal ExRightsRatio { get; set; }
        public decimal ExDividendAmount { get; set; }
        [MaxLength(1)]
        public string FinancingTag { get; set; }
        [MaxLength(1)]
        public string MarginTag { get; set; }
        [MaxLength(20)]
        public string State { get; set; }
        [MaxLength(50)]
        public string Comment { get; set; }
    }

}    