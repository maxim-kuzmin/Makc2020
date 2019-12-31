@echo off

echo Database update start

cd ..

dotnet ef database update

cd @

echo Database update finish