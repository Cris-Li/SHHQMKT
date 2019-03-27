using EntityFramework.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHHQMKT
{
    class Program
    {
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

        static public void JobMKT(string strReadFilePath)
        {
            MKTContext db = new MKTContext();

            StreamReader srReadFile = new StreamReader(strReadFilePath);
            List<MKTDT> mKTDT00s = new List<MKTDT>();
            //循环读入
            while (!srReadFile.EndOfStream)
            {
                string strReadLine = srReadFile.ReadLine(); //读取每行数据
                string[] strArr = strReadLine.Replace(" ", "").Split('|');
                MKTDT mkt = MKTDTParse(strArr);
                if (mkt != null)
                {
                    mKTDT00s.Add(mkt);
                    //db.MKTDT00s.Where(c => c.SecurityID == mkt.SecurityID).UpdateAsync(c => new MKTDT00 { OpenPrice = 100 });
                }
                Console.WriteLine(strReadLine); //屏幕打印每行数据
            }
            db.SaveChanges();
            // 关闭读取流文件
            srReadFile.Close();
        }

        static void Main(string[] args)
        {
            //JobMKT("C:\\Users\\l_cry\\Desktop\\MKTDT00.TXT");
            using (var ctx = new MKTContext())
            {
                var stud = new MKTDT() { SecurityID = "000300" };

                ctx.MKTDTs.Add(stud);
                ctx.SaveChanges();
            }
        }
    }
}
