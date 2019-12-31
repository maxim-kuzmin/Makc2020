@echo off

echo Publish all dev start

publish-client "" & ^
publish-server-debug & ^
echo Publish all dev finish & ^
title Publish all dev