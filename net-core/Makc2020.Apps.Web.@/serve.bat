@echo off

echo Serve start

call config

cd %client_project_path%

ng serve --watch --open & echo Serve finish & title Serve