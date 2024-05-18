namespace AssemblyAreaList.Models
{
    public class AssemblyArea
    {
        public string Ctprvn_nm { get; set; } // 시도명
        public string Sgg_nm { get; set; } // 시군구명

        public string Vt_acmdfclty_nm { get; set; } // 시설명

        public string Dtl_adres { get; set; } // 상세 주소
        public string Rn_adres { get; set; } // 도로명 주소
        public string Fclty_ar { get; set; } // 시설 면적
        public string Vt_acmd_psbl_nmpr { get; set; } // 최대 수용 인원수
        public string Mngps_telno { get; set; } // 관리기관 전화번호

        public static readonly string INSERT_QUERY = @"INSERT INTO [dbo].[AssemblyArea]
                                                                   ([Ctprvn_nm]
                                                                   ,[Sgg_nm]
                                                                   ,[Vt_acmdfclty_nm]
                                                                   ,[Dtl_adres]
                                                                   ,[Rn_adres]
                                                                   ,[Fclty_ar]
                                                                   ,[Vt_acmd_psbl_nmpr]
                                                                   ,[Mngps_telno])
                                                             VALUES
                                                                   (@Ctprvn_nm
                                                                   ,@Sgg_nm
                                                                   ,@Vt_acmdfclty_nm
                                                                   ,@Dtl_adres
                                                                   ,@Rn_adres
                                                                   ,@Fclty_ar
                                                                   ,@Vt_acmd_psbl_nmpr
                                                                   ,@Mngps_telno)";

        public static readonly string SELECT_QUERY = @"SELECT  [Ctprvn_nm]
                                                              ,[Sgg_nm]
                                                              ,[Vt_acmdfclty_nm]
                                                              ,[Dtl_adres]
                                                              ,[Rn_adres] 
                                                              ,[Fclty_ar]
                                                              ,[Vt_acmd_psbl_nmpr]
                                                              ,[Mngps_telno]
                                                          FROM [dbo].[AssemblyArea]";

        public static readonly string GETDISTRICT_QUERY = @"SELECT [Sgg_nm] AS Save_District
                                                          FROM [dbo].[AssemblyArea]
                                                         GROUP BY [Sgg_nm]";

        //public static readonly string GETNEIGHBORHOOD_QUERY = @"SELECT [Bdong_cd] AS Save_Neighborhood
        //                                                  FROM [dbo].[AssemblyArea]
        //                                                 GROUP BY [Bdong_cd]";


    }
}