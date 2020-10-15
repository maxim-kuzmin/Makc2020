@echo off

chcp 65001

rem Для корректной работы скрипта необходимо положить рядом пакетный файл deploy.config.bat.
rem Этот файл предназначен для установки значений переменных, используемых в скрипте.
rem Пример ссодержимого такого файла:

rem set name__of__config=prod
rem set name__of__folder__web_site=makc2020--angular-redux--4201

rem set path__to__web_sites=E:\www\

call deploy.config

set appcmd=%systemroot%\system32\inetsrv\AppCmd.exe

set name__of__web_app_pool=%name__of__folder__web_site%

set path__to__web_site=%path__to__web_sites%%name__of__folder__web_site%

set PATH=%systemroot%\system32\inetsrv;%PATH%

appcmd stop apppool /apppool.name:%name__of__web_app_pool%
appcmd stop sites %name__of__folder__web_site%

del /q %path__to__web_site%\*
FOR /D %%p IN (%path__to__web_site%\*.*) DO rmdir "%%p" /s /q

npm i & ^
ng build --%name__of__config%  & ^
xcopy /s .\dist\browser %path__to__web_site%  & ^
appcmd start apppool /apppool.name:%name__of__web_app_pool% & ^
appcmd start sites %name__of__folder__web_site%
