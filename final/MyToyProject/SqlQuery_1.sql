CREATE TABLE [dbo].[AssemblyArea](
   [Id] [int] IDENTITY(1,1) NOT NULL,
   [Arcd] [varchar](20) NULL,
   [Acmdfclty_sn] [varchar](20) NULL,
   [Ctprvn_nm] [nvarchar](50) NULL,
   [Sgg_nm] [nvarchar](50) NULL,
   [Vt_acmdfclty_nm] [nvarchar](50) NULL,
   [Rdnmadr_cd] [varchar](20) NULL,
   [Bdong_cd] [varchar](20) NULL,
   [Hdong_cd] [varchar](20)NULL,
   [Dtl_adres] [nvarchar](50) NULL,
   [Fclty_ar] [varchar](20) NULL,
   [Mngps_nm] [nvarchar](50) NULL,
   [Mngps_telno] [nvarchar](50) NULL,
   [Vt_acmd_psbl_nmpr] [nvarchar](50) NULL,
   [Rn_adres] [nvarchar](50) NULL,
 CONSTRAINT [PK_Dustsensor] PRIMARY KEY
 (    [Id] ASC ) ON [PRIMARY]
) ON [PRIMARY]
GO