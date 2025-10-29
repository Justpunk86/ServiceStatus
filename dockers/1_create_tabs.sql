--CREATE DATABASE srvs;

\c srvs

\set AUTOCOMMIT FALSE

create user app with password 'app';
grant connect on database srvs to app;

CREATE SCHEMA APP;

grant usage on schema app to app;
grant select on all tables in schema app to app;

set search_path =  public, app, "$user";

create sequence if not exists app.srv_ids
as bigint
increment by 1
minvalue 1
start with 1
no cycle;

create table app.service (
  id        integer       not null,
  name      varchar(255)  not null,
  address   varchar(255)  not null,
  status    varchar(30)   not null,
  constraint app_srv_pk primary key (id),
  constraint app_srv_nm_uk unique (name,address)
);

insert into app.service (id, name, address, status)
values (nextval('app.srv_ids'), 'service1', 'localhost:5001','active'),
 (nextval('app.srv_ids'), 'service2', 'localhost:5002','down'),
 (nextval('app.srv_ids'), 'service3', 'localhost:5003','error');

commit;

