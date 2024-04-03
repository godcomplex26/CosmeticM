﻿using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CosmeticM
{
    public class DataManager
    {
        public static List<PData> datas = new List<PData>();

        // 앞으로 DB와의 연락은 mssql이 모두 수행
        private static DBHelper_MSSQL mssql = DBHelper_MSSQL.getInstance; // 싱글톤

        public DataManager()
        {
            Load();
        }

        // 전체 불러오기
        public static void Load()
        {
            try
            {
                mssql.DoQueryR(); // 전체 조회
                datas.Clear(); // datas 초기화
                foreach (DataRow item in mssql.dt.Rows)
                {
                    PData data = new PData();
                    // datetime2 값을 밀리세컨드까지 포함하여 가져옴
                    if (item["datetime"] != DBNull.Value)
                    {
                        data.datetime = (DateTime)item["datetime"];
                    }
                    else
                    {
                        data.datetime = new DateTime(); // 또는 다른 기본값 설정
                    }

                    data.ReactA_Temp = double.Parse(item["ReactA_Temp"].ToString());
                    data.ReactB_Temp = double.Parse(item["ReactB_Temp"].ToString());
                    data.ReactC_Temp = double.Parse(item["ReactC_Temp"].ToString());
                    data.ReactD_Temp = double.Parse(item["ReactD_Temp"].ToString());
                    data.ReactE_Temp = double.Parse(item["ReactE_Temp"].ToString());
                    data.ReactF_Temp = double.Parse(item["ReactF_Temp"].ToString());
                    data.ReactF_PH = double.Parse(item["ReactF_PH"].ToString());
                    data.Power = double.Parse(item["Power"].ToString());
                    data.CurrentA = double.Parse(item["CurrentA"].ToString());
                    data.CurrentB = double.Parse(item["CurrentB"].ToString());
                    data.CurrentC = double.Parse(item["CurrentC"].ToString());
                    datas.Add(data);
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                PrintLog(ex.StackTrace + "from Load");
            }
            finally
            {

            }
        }

        // 조건 불러오기
        public static void Load(string c1, string c2, string c3)
        {
            try
            {
                mssql.DoQueryR(c1, c2, c3); // 전달된 SQL 쿼리 실행
                datas.Clear(); // datas 초기화
                foreach (DataRow item in mssql.dt.Rows)
                {
                    PData data = new PData();
                    // datetime2 값을 밀리세컨드까지 포함하여 가져옴
                    if (item["datetime"] != DBNull.Value)
                    {
                        data.datetime = (DateTime)item["datetime"];
                    }
                    else
                    {
                        data.datetime = new DateTime(); // 또는 다른 기본값 설정
                    }

                    data.ReactA_Temp = double.Parse(item["ReactA_Temp"].ToString());
                    data.ReactB_Temp = double.Parse(item["ReactB_Temp"].ToString());
                    data.ReactC_Temp = double.Parse(item["ReactC_Temp"].ToString());
                    data.ReactD_Temp = double.Parse(item["ReactD_Temp"].ToString());
                    data.ReactE_Temp = double.Parse(item["ReactE_Temp"].ToString());
                    data.ReactF_Temp = double.Parse(item["ReactF_Temp"].ToString());
                    data.ReactF_PH = double.Parse(item["ReactF_PH"].ToString());
                    data.Power = double.Parse(item["Power"].ToString());
                    data.CurrentA = double.Parse(item["CurrentA"].ToString());
                    data.CurrentB = double.Parse(item["CurrentB"].ToString());
                    data.CurrentC = double.Parse(item["CurrentC"].ToString());
                    datas.Add(data);
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                PrintLog(ex.StackTrace + "from Load");
            }
            finally
            {

            }
        }

        // 데이터 추가
        public static void Save(PData random)
        {
            mssql.DoQueryC(random);
            PrintLog(random.datetime.ToString() + " 데이터 추가");
        }

        // 데이터 삭제
        public static void Delete(PData data)
        {
            mssql.DoQueryD(data);
            PrintLog(data.datetime.ToString() + " 데이터 삭제");
        }


        // 로그 저장, contents = 로그 기록용
        public static void PrintLog(string contents)
        {
            DirectoryInfo di = new DirectoryInfo("LogFolder");
            if (di.Exists == false) // 해당 폴더 없으면
            {
                di.Create(); // 폴더 생성
            }

            using (StreamWriter w = new StreamWriter(@"LogFolder\History.txt", true))
            {
                w.Write($"({DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}");
                w.WriteLine(contents);
            }
        }

    }
}
