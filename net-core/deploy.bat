@echo off

chcp 65001

rem Для корректной работы скрипта необходимо положить рядом пакетный файл deploy.config.bat.
rem Этот файл предназначен для установки значений переменных, используемых в скрипте.
rem Пример ссодержимого такого файла:

rem set name__of__folder__web_site__api=makc2020--net-core--api--5002
rem set name__of__folder__web_site__identity_server=makc2020--net-core--identity-server--6002

rem set path__to__web_sites=E:\www\

call deploy.config

set appcmd=%systemroot%\system32\inetsrv\AppCmd.exe

set name__of__web_app_pool__api=%name__of__folder__web_site__api%
set name__of__web_app_pool__identity_server=%name__of__folder__web_site__identity_server%

set path__to__web_site__api=%path__to__web_sites%%name__of__folder__web_site__api%
set path__to__web_site__identity_server=%path__to__web_sites%%name__of__folder__web_site__identity_server%

set PATH="C:\Program Files\dotnet";%PATH%
set PATH=%systemroot%\system32\inetsrv;%PATH%

cd Makc2020.Data.Entity.Clients.PostgreSql
dotnet ef database update --configuration Test
cd ..

cd Makc2020.Data.Entity.Clients.SqlServer
dotnet ef database update --configuration Test
cd ..

appcmd stop apppool /apppool.name:%name__of__web_app_pool__api%
appcmd stop sites %name__of__folder__web_site__api%

del /q %path__to__web_site__api%\*
FOR /D %%p IN (%path__to__web_site__api%\*.*) DO rmdir "%%p" /s /q

cd Makc2020.Apps.Api.Web
dotnet publish Makc2020.Apps.Api.Web.csproj -c Test
cd bin\Test\netcoreapp3.1\publish
xcopy /s *.* %path__to__web_site__api%
cd ..\..\..\..\..

appcmd start apppool /apppool.name:%name__of__web_app_pool__api%
appcmd start sites %name__of__folder__web_site__api%

appcmd stop apppool /apppool.name:%name__of__web_app_pool__identity_server%
appcmd stop sites %name__of__folder__web_site__identity_server%

del /q %path__to__web_site__identity_server%\*
FOR /D %%p IN (%path__to__web_site__identity_server%\*.*) DO rmdir "%%p" /s /q

cd Makc2020.Apps.IdentityServer.Web
dotnet publish Makc2020.Apps.IdentityServer.Web.csproj -c Test
cd bin\Test\netcoreapp3.1\publish
xcopy /s *.* %path__to__web_site__identity_server%
cd ..\..\..\..\..

appcmd start apppool /apppool.name:%name__of__web_app_pool__identity_server%
appcmd start sites %name__of__folder__web_site__identity_server%