select * from login.user2;
select name from login.user2;
/*로그인 스키마에서 user 이름이 윤나은인 데이터*/
select * from login.user2 where name = "윤나은";
/*로그인 스키마에서 user 주소 서울인 데이터*/
select * from login.user2 where address = "서울";
/*범위 검색 : 2부터 3까지의 데이터*/
select * from login.user2 where `index` between 2 and 3;
/*범위 검색 : 2이상인 데이터*/
select * from login.user2 where `index` > 2;
/*범위 검색 : 2인 데이터*/
select * from login.user2 where `index` = 2;
/*범위 검색 : 2가 아닌 데이터*/
select * from login.user2 where `index` != 2;	
select * from login.user2 where `index` <> 2;	
/*범위 검색 : 인덱스가 2이거나 1인 데이터*/
select * from login.user2 where `index` = 2 or `index`=1;
/*범위 검색 : 인덱스가 2이거나 이름이 윤나은과 같은 데이터*/
select * from login.user2 where `index` = 2 or `name`="윤나은";
/*범위 검색 : 이름이 윤으로 시작하는 데이터*/
select * from login.user2 where `name`like"윤%";
/*범위 검색 : 한 글자와 매칭 하기 위한 문자*/
select * from login.user2 where `name`like "윤_은";
/*범위 검색 : 오름차순*/
select * from login.user2 order by `index`;
/*범위 검색 : 내림차순*/
select * from login.user2 order by `index` desc;
/*서브쿼리 : 조건을 여러개 준다, name 이 () 의 쿼리문을 만족하는 데이터 검색*/
select * from login.user2 where `name` =(select `name` from login.user2 where `index`=1);
/*테이블 생성*/
create table `login` .`Test`(id varchar (8), name varchar(12));
select * from `login`.`Test`;
/*sys 스키마를 사용*/
use sys;
select * from sys.sys_config;
insert into login.user2(`index`,name,address) value (7,'나은','대구시');
