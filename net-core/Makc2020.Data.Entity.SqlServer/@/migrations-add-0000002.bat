@echo off

echo Migrations add 0000002 start

cd ..

dotnet ef migrations add 0000002

cd @

echo Migrations add 0000002 finish