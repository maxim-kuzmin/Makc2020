@echo off

echo Publish client start

call config

cd %client_project_path%

set params=%1

set wwwroot=%server_project_path%\wwwroot

ng build %params% & ^
rmdir %wwwroot% /s /q & ^
mkdir %wwwroot% & xcopy /s /e /y dist\%client_project_name% %wwwroot% & ^
cd %script_project_path% & ^
echo Publish client finish