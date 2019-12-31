@echo off

echo Start dev start

call config

cd %client_project_path%

npm install & ^
cd %script_project_path% & ^
publish-all-dev & ^
echo Start dev end & ^
title Start & ^
start serve & ^
start http://localhost:%debug_site_port%