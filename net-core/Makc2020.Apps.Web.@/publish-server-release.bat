@echo off

echo Publish server release start

call config

%systemroot%\system32\inetsrv\appcmd.exe recycle apppool /apppool.name:%release_apppool_name%

rmdir %release_site_path% /s /q

cd %server_project_path%

dotnet publish --configuration Release --output %release_site_path%

cd %script_project_path%

echo Publish server release finish