@echo off

echo Migrations add 0000001 start

cd ..

dotnet ef migrations add 0000001

cd @

echo Migrations add 0000001 finish