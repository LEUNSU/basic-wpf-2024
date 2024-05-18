namespace AssemblyAreaList.Models
{
    public class AssemblyArea
    {
        public int Id { get; set; } // 추가생성, DB에 넣을때 사용할 값

        public string Arcd { get; set; } // 지역코드
        public string Acmdfclty_sn { get; set; } // 시설 일련번호

        public string Ctprvn_nm { get; set; } // 시도명
        public string Sgg_nm { get; set; } // 시군구명

        public string Vt_acmdfclty_nm { get; set; } // 시설명
        public string Rdnmadr_cd { get; set; } // 도로명 주소 코드
        public string Bdong_cd { get; set; } // 법정동 코드
        public string Hdong_cd { get; set; } // 행정동 코드
        public string Dtl_adres { get; set; } // 상세 주소
        public string Fclty_ar { get; set; } // 시설 면적
        public string Mngps_nm { get; set; } // 관리기관명
        public string Mngps_telno { get; set; } // 관리기관 전화번호
        public string Vt_acmd_psbl_nmpr { get; set; } // 최대 수용 인원수
        public string Rn_adres { get; set; } // 도로명 주소

        public static readonly string INSERT_QUERY = @"INSERT INTO [dbo].[AssemblyArea]
                                                                   ([Arcd]
                                                                   ,[Acmdfclty_sn]
                                                                   ,[Ctprvn_nm]
                                                                   ,[Sgg_nm]
                                                                   ,[Vt_acmdfclty_nm]
                                                                   ,[Rdnmadr_cd]
                                                                   ,[Bdong_cd]
                                                                   ,[Hdong_cd]
                                                                   ,[Dtl_adres]
                                                                   ,[Fclty_ar]
                                                                   ,[Mngps_nm]
                                                                   ,[Mngps_telno]
                                                                   ,[Vt_acmd_psbl_nmpr]
                                                                   ,[Rn_adres])
                                                             VALUES
                                                                   (@Arcd
                                                                   ,@Acmdfclty_sn
                                                                   ,@Ctprvn_nm
                                                                   ,@Sgg_nm
                                                                   ,@Vt_acmdfclty_nm
                                                                   ,@Rdnmadr_cd
                                                                   ,@Bdong_cd
                                                                   ,@Hdong_cd
                                                                   ,@Dtl_adres
                                                                   ,@Fclty_ar
                                                                   ,@Mngps_nm
                                                                   ,@Mngps_telno
                                                                   ,@Vt_acmd_psbl_nmpr
                                                                   ,@Rn_adres)";

        public static readonly string SELECT_QUERY = @"SELECT [Id]
                                                              ,[Arcd]
                                                              ,[Acmdfclty_sn]
                                                              ,[Ctprvn_nm]
                                                              ,[Sgg_nm]
                                                              ,[Vt_acmdfclty_nm]
                                                              ,[Rdnmadr_cd]
                                                              ,[Bdong_cd]
                                                              ,[Hdong_cd]
                                                              ,[Dtl_adres]
                                                              ,[Fclty_ar]
                                                              ,[Mngps_nm]
                                                              ,[Mngps_telno]
                                                              ,[Vt_acmd_psbl_nmpr]
                                                              ,[Rn_adres] 
                                                          FROM [dbo].[AssemblyArea]";

       
    }
}