@echo off

echo Database update 0000001 start

cd ..

dotnet ef database update 0000001

cd @

echo Database update 0000001 finish