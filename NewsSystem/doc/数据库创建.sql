---- 建立类别表
create table category
(
	id int identity(1,1) primary key,
	[name] varchar(20) not null
)
---- 建立新闻表
create table news
(
	id int identity(1,1) primary key,
	title varchar(100) not null,
	[content] text not null,
	createTime datetime not null,
	caId int 
)
---- 建立评论表
create table comment
(
	id int identity(1,1) primary key,
	[content] text not null,
	createTime datetime not null,
	userIp varchar(15) not null,
	newsId int
)