@echo off

echo Publish server debug start

call config

%systemroot%\system32\inetsrv\appcmd.exe recycle apppool /apppool.name:%debug_apppool_name%

rmdir %debug_site_path% /s /q

cd %server_project_path%

dotnet publish --configuration Debug --output %debug_site_path%

cd %script_project_path%

echo Publish server debug finish