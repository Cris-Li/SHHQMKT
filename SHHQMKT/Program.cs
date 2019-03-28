using EntityFramework.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Configuration;

namespace SHHQMKT
{
    class Program
    {
        //解析行情文件
        static public MKTDT MKTDTParse(string[] strArr)
        {
            if (strArr[0] == "MD003")
            {
                return new MKTDT()
                {
                    MDStreamID = strArr[0],
                    SecurityID = strArr[1],
                    Symbol = strArr[2],
                    TradeVolume = decimal.Parse(strArr[3]),
                    TotalValueTraded = decimal.Parse(strArr[4]),
                    PreClosePx = decimal.Parse(strArr[5]),
                    OpenPrice = decimal.Parse(strArr[6]),
                    HighPrice = decimal.Parse(strArr[7]),
                    LowPrice = decimal.Parse(strArr[8]),
                    TradePrice = decimal.Parse(strArr[9]),
                    ClosePx = decimal.Parse(strArr[10]),
                    BuyPrice1 = decimal.Parse(strArr[11]),
                    BuyVolume1 = decimal.Parse(strArr[12]),
                    SellPrice1 = decimal.Parse(strArr[13]),
                    SellVolume1 = decimal.Parse(strArr[14]),
                    BuyPrice2 = decimal.Parse(strArr[15]),
                    BuyVolume2 = decimal.Parse(strArr[16]),
                    SellPrice2 = decimal.Parse(strArr[17]),
                    SellVolume2 = decimal.Parse(strArr[18]),
                    BuyPrice3 = decimal.Parse(strArr[19]),
                    BuyVolume3 = decimal.Parse(strArr[20]),
                    SellPrice3 = decimal.Parse(strArr[21]),
                    SellVolume3 = decimal.Parse(strArr[22]),
                    BuyPrice4 = decimal.Parse(strArr[23]),
                    BuyVolume4 = decimal.Parse(strArr[24]),
                    SellPrice4 = decimal.Parse(strArr[25]),
                    SellVolume4 = decimal.Parse(strArr[26]),
                    BuyPrice5 = decimal.Parse(strArr[27]),
                    BuyVolume5 = decimal.Parse(strArr[28]),
                    SellPrice5 = decimal.Parse(strArr[29]),
                    SellVolume5 = decimal.Parse(strArr[30]),
                    TradingPhaseCode = strArr[31],
                    Timestamp = strArr[32]
                };
            }
            else if (strArr[0] == "MD004")
            {
                return new MKTDT()
                {
                    MDStreamID = strArr[0],
                    SecurityID = strArr[1],
                    Symbol = strArr[2],
                    TradeVolume = decimal.Parse(strArr[3]),
                    TotalValueTraded = decimal.Parse(strArr[4]),
                    PreClosePx = decimal.Parse(strArr[5]),
                    OpenPrice = decimal.Parse(strArr[6]),
                    HighPrice = decimal.Parse(strArr[7]),
                    LowPrice = decimal.Parse(strArr[8]),
                    TradePrice = decimal.Parse(strArr[9]),
                    ClosePx = decimal.Parse(strArr[10]),
                    BuyPrice1 = decimal.Parse(strArr[11]),
                    BuyVolume1 = decimal.Parse(strArr[12]),
                    SellPrice1 = decimal.Parse(strArr[13]),
                    SellVolume1 = decimal.Parse(strArr[14]),
                    BuyPrice2 = decimal.Parse(strArr[15]),
                    BuyVolume2 = decimal.Parse(strArr[16]),
                    SellPrice2 = decimal.Parse(strArr[17]),
                    SellVolume2 = decimal.Parse(strArr[18]),
                    BuyPrice3 = decimal.Parse(strArr[19]),
                    BuyVolume3 = decimal.Parse(strArr[20]),
                    SellPrice3 = decimal.Parse(strArr[21]),
                    SellVolume3 = decimal.Parse(strArr[22]),
                    BuyPrice4 = decimal.Parse(strArr[23]),
                    BuyVolume4 = decimal.Parse(strArr[24]),
                    SellPrice4 = decimal.Parse(strArr[25]),
                    SellVolume4 = decimal.Parse(strArr[26]),
                    BuyPrice5 = decimal.Parse(strArr[27]),
                    BuyVolume5 = decimal.Parse(strArr[28]),
                    SellPrice5 = decimal.Parse(strArr[29]),
                    SellVolume5 = decimal.Parse(strArr[30]),
                    PreCloseIOPV = decimal.Parse(strArr[31]),
                    IOPV = decimal.Parse(strArr[32]),
                    TradingPhaseCode = strArr[33],
                    Timestamp = strArr[34]
                };
            }
            else return null;

        }

        //解析基础信息文件
        static public CPXXMMDD CPXXMMDDParse(string[] strArr)
        {
            return new CPXXMMDD
            {
                SecurityID = strArr[0],
                ISIN = strArr[1],
                Updatetime = strArr[2],
                ChineseName = strArr[3],
                EnglishName = strArr[4],
                BasicCode = strArr[5],
                MarketType = strArr[6],
                SecurityType = strArr[7],
                SecuritySubType = strArr[8],
                CurrencyType = strArr[9],
                FaceValue = strArr[10] == "" ? 0 : decimal.Parse(strArr[10]),
                UnmarketableAmount = strArr[11] == "" ? 0 : decimal.Parse(strArr[11]),
                LastTradeDate = strArr[12],
                IssueDate = strArr[13],
                SETNo = strArr[14],
                BuyUnit = strArr[15] == "" ? 0 : decimal.Parse(strArr[15]),
                SellUnit = strArr[16] == "" ? 0 : decimal.Parse(strArr[16]),
                AmountLowLimit = strArr[17] == "" ? 0 : decimal.Parse(strArr[17]),
                AmountHighLimt = strArr[18] == "" ? 0 : decimal.Parse(strArr[18]),
                PreClose = strArr[19] == "" ? 0 : decimal.Parse(strArr[19]),
                PriceStall = strArr[20] == "" ? 0 : decimal.Parse(strArr[20]),
                PriceLimitType = strArr[21],
                HighLimt = strArr[22] == "" ? 0 : decimal.Parse(strArr[22]),
                LowLimit_ = strArr[23] == "" ? 0 : decimal.Parse(strArr[23]),
                ExRightsRatio = strArr[24] == "" ? 0 : decimal.Parse(strArr[24]),
                ExDividendAmount = strArr[25] == "" ? 0 : decimal.Parse(strArr[25]),
                FinancingTag = strArr[26],
                MarginTag = strArr[27],
                State = strArr[28],
                Comment = strArr[29]
            };
        }

        /**
         * 更新脚本
         **/
        static public int JobMKT(string strReadFilePath, HashSet<int> lines)
        {
            using (var db = new MKTContext())
            {

                StreamReader srReadFile = new StreamReader(strReadFilePath);
                
                int i = 0; //标记行号
                //循环读入
                while (!srReadFile.EndOfStream)
                {
                    string strReadLine = srReadFile.ReadLine(); //读取每行数据
                    if (lines.Contains(i))
                    {                    
                        string[] strArr = strReadLine.Replace(" ", "").Split('|');
                        MKTDT mkt = MKTDTParse(strArr);
                        if (mkt != null)
                        {
                            db.MKTDTs.Where(c => c.SecurityID == mkt.SecurityID).UpdateAsync(c => mkt);
                            Console.WriteLine(mkt.SecurityID+" "+mkt.Symbol+" "+mkt.TradePrice+" "+mkt.Timestamp); //屏幕打印每行数据
                        }
                    }
                    i++; // 行号+1
                }
                try
                {
                    db.SaveChanges();
                }
                catch(Exception e)
                {
                    Console.WriteLine(e);
                }
                srReadFile.Close();
            }
            return 1;
        }

        static HashSet<int> InitMKT(string filePath)
        {
            StreamReader srReadFile = new StreamReader(filePath);
            List<MKTDT> mKTDTs = new List<MKTDT>();
            HashSet<string> mktstr = new HashSet<string>() { "018009", "113013", "019009", "511010", "511020", "511030" };
            HashSet<int> lines = new HashSet<int>();

            //循环读入
            using (var db = new MKTContext())
            {
                db.MKTDTs.Delete();
                int i = 0;//标记行号
                while (!srReadFile.EndOfStream)
                {
                    string strReadLine = srReadFile.ReadLine(); //读取每行数据
                    string[] strArr = strReadLine.Replace(" ", "").Split('|');

                    if (mktstr.Contains(strArr[1]))
                    {
                        MKTDT mkt = MKTDTParse(strArr);
                        db.MKTDTs.Add(mkt);
                        lines.Add(i);
                    }

                    i++;
                }
                db.SaveChanges();
            }
            srReadFile.Close();
            return lines;
        }

        static int InitCPXX(string filePath)
        {
            StreamReader srReadFile = new StreamReader(filePath);
            List<CPXXMMDD> cPXXMMDDs = new List<CPXXMMDD>();

            //循环读入
            using (var db = new MKTContext())
            {
                db.CPXXMMDDs.Delete();
                
                while (!srReadFile.EndOfStream)
                {
                    string strReadLine = srReadFile.ReadLine(); //读取每行数据
                    string[] strArr = strReadLine.Replace(" ", "").Split('|');
                    try
                    {
                        CPXXMMDD cPXXMMDD = CPXXMMDDParse(strArr);
                        cPXXMMDDs.Add(cPXXMMDD);
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
                srReadFile.Close();
                db.CPXXMMDDs.AddRange(cPXXMMDDs);
                db.SaveChanges();
            }
            return 0;
        }

        static void Main(string[] args)
        {
            string MKTPath = ConfigurationManager.AppSettings["MKTPath"];
            string CPXXPath = ConfigurationManager.AppSettings["CPXXPath"];

            //记录要更新的行号
            HashSet<int> lines = InitMKT(MKTPath); 
            string filePath = string.Format(CPXXPath, DateTime.Now);
            InitCPXX(filePath);

            while (true)
            {
                Task<int> task = new Task<int>(()=>JobMKT(filePath, lines));
                task.Start();
                Thread.Sleep(50);
            }
        }
    }
}
