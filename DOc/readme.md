CREATE TABLE [dbo].[zk_platelist](
 [list_id] [int] IDENTITY(1,1) NOT NULL,
 [plate] [varchar](10) NULL,
 [parked_id] [int] NULL,
 [starttime] [datetime] NULL,
 [endtime] [datetime] NULL,
 [group_name] [varchar](30) NULL,
 [oper_name] [varchar](30) NULL,
 [list_time] [datetime] NULL,
 [zk_id] [int] NULL,
 [list_kind] [int] NULL,
 [card_id] [varchar](20) NULL,
 [list_state] [int] NOT NULL,
 [note] [varchar](100) NOT NULL,
 [use_num] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
 [list_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO