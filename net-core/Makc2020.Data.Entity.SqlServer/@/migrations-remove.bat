@echo off

echo Migrations remove start

cd ..

dotnet ef migrations remove

cd @

echo Migrations remove finish