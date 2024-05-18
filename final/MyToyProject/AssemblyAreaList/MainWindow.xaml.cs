﻿using System.IO;
using System.Net;
using System.Windows;
using AssemblyAreaList.Models;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json.Linq;

namespace AssemblyAreaList
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            string url = "https://apis.data.go.kr/1741000/EmergencyAssemblyArea_Earthquake5/getArea4List2?ServiceKey=2vtB4IK7A0Zdd3%2B0mcat%2FfF%2BiLxEh3BGGnmVdWl3p8N3e6k%2FklfFCL7q2rG%2FXW1FAwGS2KNUK6iAyZSZRs%2B31w%3D%3D&pageNo=1&numOfRows=100&type=JSON&ctprvn_nm=%EB%B6%80%EC%82%B0%EA%B4%91%EC%97%AD%EC%8B%9C";
            string result = string.Empty;

            // WebRequest, WebResponse 객체
            WebRequest req = null;
            WebResponse res = null;
            StreamReader reader = null;

            try
            {
                req = WebRequest.Create(url);
                res = await req.GetResponseAsync();
                reader = new StreamReader(res.GetResponseStream());
                result = reader.ReadToEnd();

                // await this.ShowMessageAsync("결과", result);
            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync("오류", $"OpenAPI 조회오류 {ex.Message}");
            }

            var jsonResult = JObject.Parse(result);
            // 데이터 출력
            var data1 = jsonResult["EarthquakeOutdoorsShelter2"][0];
            var data5 = Convert.ToInt32(data1["head"][0]["totalCount"]);

            if (data5 > 0)
            {
                var data6 = jsonResult["EarthquakeOutdoorsShelter2"][1]["row"];
                var jsonArray = data6 as JArray; // json자체에서 []안에 들어간 배열데이터만 Array 변환가능

                var assemblyArea = new List<AssemblyArea>();
                foreach (var item in jsonArray)
                {
                    assemblyArea.Add(new AssemblyArea()
                    {
                        Id = 0,
                        Arcd = Convert.ToString(item["arcd"]),
                        Acmdfclty_sn = Convert.ToString(item["acmdfclty_sn"]),
                        Ctprvn_nm = Convert.ToString(item["ctprvn_nm"]),
                        Sgg_nm = Convert.ToString(item["sgg_nm"]),
                        Vt_acmdfclty_nm = Convert.ToString(item["vt_acmdfclty_nm"]),
                        Rdnmadr_cd = Convert.ToString(item["rdnmadr_cd"]),
                        Bdong_cd = Convert.ToString(item["bdong_cd"]),
                        Hdong_cd = Convert.ToString(item["hdong_cd"]),
                        Dtl_adres = Convert.ToString(item["dtl_adres"]),
                        Fclty_ar = Convert.ToString(item["fclty_ar"]),
                        Mngps_nm = Convert.ToString(item["mngps_nm"]),
                        Mngps_telno = Convert.ToString(item["mngps_telno"]),
                        Vt_acmd_psbl_nmpr = Convert.ToString(item["vt_acmd_psbl_nmpr"]),
                        Rn_adres = Convert.ToString(item["rn_adres"]),
                    });
                }

                this.DataContext = assemblyArea;
                StsResult.Content = $"OpenAPI {assemblyArea.Count}건 조회완료!";
            }
        }
        private async void BtnSaveData_Click(object sender, RoutedEventArgs e)
        {
            if (GrdResult.Items.Count == 0)
            {
                await this.ShowMessageAsync("저장오류", "실시간 조회후 저장하십시오.");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(Helpers.Common.CONNSTRING))
                {
                    conn.Open();

                    var insRes = 0;
                    foreach (AssemblyArea item in GrdResult.Items)
                    {
                        SqlCommand cmd = new SqlCommand(Models.AssemblyArea.INSERT_QUERY, conn);
                        cmd.Parameters.AddWithValue("@Arcd", item.Arcd);
                        cmd.Parameters.AddWithValue("@Acmdfclty_sn", item.Acmdfclty_sn);
                        cmd.Parameters.AddWithValue("@Ctprvn_nm", item.Ctprvn_nm);
                        cmd.Parameters.AddWithValue("@Sgg_nm", item.Sgg_nm);
                        cmd.Parameters.AddWithValue("@Vt_acmdfclty_nm", item.Vt_acmdfclty_nm);
                        cmd.Parameters.AddWithValue("@Rdnmadr_cd", item.Rdnmadr_cd);
                        cmd.Parameters.AddWithValue("@Bdong_cd", item.Bdong_cd);
                        cmd.Parameters.AddWithValue("@Hdong_cd", item.Hdong_cd);
                        cmd.Parameters.AddWithValue("@Dtl_adres", item.Dtl_adres);
                        cmd.Parameters.AddWithValue("@Fclty_ar", item.Fclty_ar);
                        cmd.Parameters.AddWithValue("@Mngps_nm", item.Mngps_nm);
                        cmd.Parameters.AddWithValue("@Mngps_telno", item.Mngps_telno);
                        cmd.Parameters.AddWithValue("@Vt_acmd_psbl_nmpr", item.Vt_acmd_psbl_nmpr);
                        cmd.Parameters.AddWithValue("@Rn_adres", item.Rn_adres);

                        insRes += cmd.ExecuteNonQuery();
                    }

                    if (insRes > 0)
                    {
                        await this.ShowMessageAsync("저장", "DB저장성공!");
                        StsResult.Content = $"DB저장 {insRes}건 성공!";
                    }
                }
            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync("저장오류", $"저장오류 {ex.Message}");
            }
        }

        private void CboDistrict_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
 
     
        }


        //private void CboNeighborhood_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        //{

        //}
    }
}