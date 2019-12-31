@echo off

echo Start prod start

call config

cd %client_project_path%

npm install & ^
cd %script_project_path% & ^
publish-all-prod & ^
echo Start prod end & ^
title Start prod & ^
start http://localhost:%release_site_port% 